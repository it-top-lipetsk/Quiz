using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Quiz.Models;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace Quiz.TelegramBot
{
    static class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5297338841:AAHtUVOBQ6RF9m9raeQjrRt-7HB7neiE5rE");

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                switch (message.Text.ToLower())
                {
                    case "/start":
                        await botClient.SendTextMessageAsync(message.Chat, $"Добро пожаловать, {message.Chat.FirstName}!");
                        break;
                    case "/questions":
                    {
                        var url = "http://localhost:5108/api/v1/questions";
                        using var tempStream = WebRequest.Create(url).GetResponse().GetResponseStream();
                        using var stream = new StreamReader(tempStream);
                        var json = stream.ReadToEnd();
                        var questions = JsonSerializer.Deserialize<List<QuestionModel>>(json);
                        foreach (var question in questions)
                        {
                            var answers = new List<string>();
                            foreach (var answer in question.Answers)
                            {
                                answers.Add(answer.Answer);
                            }
                            
                            await botClient.SendPollAsync(
                                chatId: message.Chat,
                                question: question.Question,
                                options: answers,
                                cancellationToken: cancellationToken);
                        }
                    }
                        break;
                    default:
                        await botClient.SendTextMessageAsync(message.Chat, $"{message.Chat.FirstName}, я вас не понял!");
                        break;
                }
            }
        }

        private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}