using System.Windows.Controls;
using Quiz.Models;

namespace Quiz.Desktop.Components.Question;

public partial class QuestionComponent : UserControl
{
    public QuestionComponent(QuestionModel question)
    {
        InitializeComponent();
        
        Init(question);
    }

    private void Init(QuestionModel question)
    {
        LabelQuestion.Content = question.Question;

        foreach (var answer in question.Answers)
        {
            var div = new StackPanel { Orientation = Orientation.Horizontal };
            div.Children.Add(new CheckBox());
            div.Children.Add(new Label { Content = answer.Answer });
            
            AnswersPanel.Children.Add(div);
        }
    }
}