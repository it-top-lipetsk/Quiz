using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;
using Quiz.Desktop.Components.Question;
using Quiz.Models;

namespace Quiz.Desktop.Windows.Main
{
    public partial class MainWindow : Window
    {
        private List<QuestionModel> _questions;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGetQuestions_OnClick(object sender, RoutedEventArgs e)
        {
            var url = "http://localhost:5108/api/v1/questions";
            using var tempStream = WebRequest.Create(url).GetResponse().GetResponseStream();
            using var stream = new StreamReader(tempStream);
            var json = stream.ReadToEnd();
            _questions = JsonSerializer.Deserialize<List<QuestionModel>>(json);
            InitQuestionsPanel();
        }

        private void InitQuestionsPanel()
        {
            foreach (var question in _questions)
            {
                QuestionsPanel.Children.Add(new QuestionComponent(question));
            }
            
        }
    }
}