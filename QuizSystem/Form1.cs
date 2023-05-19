using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class Form1 : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex;
        private ICheckingStrategy checkingStrategy;
        private QuizScoreObserver scoreObserver;

        private static Form1 instance;
        public static Form1 Instance
        {
            get
            {
                if (instance == null)
                    instance = new Form1();
                return instance;
            }
        }

        public Form1()
        {
            InitializeComponent();
            InitializeQuestions();
            currentQuestionIndex = 0;
            checkingStrategy = new DefaultCheckingStrategy();
            scoreObserver = new QuizScoreObserver();
            scoreObserver.Subscribe(DisplayScore);
        }

        private void InitializeQuestions()
        {
            questions = new List<Question>
    {
        QuestionFactory.CreateQuestion("What is the purpose of the Singleton design pattern?", new List<string> { "To ensure that only one instance of a class is created", "To separate the construction of a complex object from its representation", "To define an interface for creating objects, but let subclasses decide which class to instantiate", "To allow for flexible and interchangeable checking mechanisms" }, 0),
        QuestionFactory.CreateQuestion("Which design pattern promotes loose coupling between objects?", new List<string> { "Observer", "Singleton", "Prototype", "Factory" }, 0),
        QuestionFactory.CreateQuestion("Which design pattern is used to encapsulate the creation logic of an object?", new List<string> { "Factory", "Strategy", "Prototype", "Observer" }, 0),
        QuestionFactory.CreateQuestion("What problem does the Strategy design pattern solve?", new List<string> { "It allows behavior to be changed at runtime without altering the class that uses it", "It ensures that only one instance of a class is created", "It promotes loose coupling between objects", "It encapsulates the creation logic of an object" }, 0),
        QuestionFactory.CreateQuestion("What is the main principle behind the Decorator design pattern?", new List<string> { "Open for extension, but closed for modification", "Program to an interface, not an implementation", "Favor object composition over class inheritance", "Encapsulate what varies" }, 0),
        QuestionFactory.CreateQuestion("Which design pattern is commonly used to provide a simplified interface to a complex subsystem?", new List<string> { "Facade", "Adapter", "Proxy", "Composite" }, 0),
        QuestionFactory.CreateQuestion("What does the Observer design pattern allow?", new List<string> { "Objects to be notified of changes in a subject's state", "Objects to be created without specifying the exact class", "Behavior to be changed at runtime without altering the class", "Multiple objects to be treated as a single instance" }, 0),
        QuestionFactory.CreateQuestion("Which design pattern is used to define an interface for creating objects, but let subclasses decide which class to instantiate?", new List<string> { "Factory", "Singleton", "Prototype", "Builder" }, 0),
        QuestionFactory.CreateQuestion("What is the purpose of the Prototype design pattern?", new List<string> { "To create new objects by cloning existing instances", "To ensure that only one instance of a class is created", "To provide a simplified interface to a complex subsystem", "To separate the construction of a complex object from its representation" }, 0),
        QuestionFactory.CreateQuestion("What is the main advantage of the Composite design pattern?", new List<string> { "It allows you to treat individual objects and compositions of objects uniformly", "It ensures that only one instance of a class is created", "It promotes loose coupling between objects", "It encapsulates the creation logic of an object" }, 0),
        // Add more questions here...
    };
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayQuestion(currentQuestionIndex);
        }

        private void DisplayQuestion(int questionIndex)
        {
            Question currentQuestion = questions[questionIndex];
            questionLabel.Text = currentQuestion.Text;

            optionsListBox.Items.Clear();
            foreach (string option in currentQuestion.Options)
            {
                optionsListBox.Items.Add(option);
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (optionsListBox.SelectedItem != null)
            {
                Question currentQuestion = questions[currentQuestionIndex];
                int selectedOptionIndex = optionsListBox.SelectedIndex;
                bool isCorrectAnswer = checkingStrategy.CheckAnswer(currentQuestion, selectedOptionIndex);

                if (isCorrectAnswer)
                {
                    // Handle correct answer logic here
                    MessageBox.Show("Correct!");
                    scoreObserver.IncrementScore();
                }
                else
                {
                    // Handle incorrect answer logic here
                    MessageBox.Show("Incorrect!");
                }

                currentQuestionIndex++;
                if (currentQuestionIndex < questions.Count)
                {
                    DisplayQuestion(currentQuestionIndex);
                }
                else
                {
                    // End of the quiz
                    MessageBox.Show("Quiz completed!");
                    scoreObserver.DisplayFinalScore();
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Please select an option.");
            }
        }

        private void DisplayScore(int score)
        {
            scoreLabel.Text = $"Score: {score}";
        }
    }

    public class Question
    {
        public string Text { get; }
        public List<string> Options { get; }
        public int CorrectOptionIndex { get; }

        public Question(string text, List<string> options, int correctOptionIndex)
        {
            Text = text;
            Options = options;
            CorrectOptionIndex = correctOptionIndex;
        }

        public Question Clone()
        {
            return new Question(Text, new List<string>(Options), CorrectOptionIndex);
        }
    }

    public interface ICheckingStrategy
    {
        bool CheckAnswer(Question question, int selectedOptionIndex);
    }

    public class DefaultCheckingStrategy : ICheckingStrategy
    {
        public bool CheckAnswer(Question question, int selectedOptionIndex)
        {
            return selectedOptionIndex == question.CorrectOptionIndex;
        }
    }

    public class CustomCheckingStrategy : ICheckingStrategy
    {
        public bool CheckAnswer(Question question, int selectedOptionIndex)
        {
            // Custom logic for checking the answer
            return false;
        }
    }

    public class QuestionFactory
    {
        public static Question CreateQuestion(string text, List<string> options, int correctOptionIndex)
        {
            return new Question(text, options, correctOptionIndex);
        }
    }

    public class QuizScoreObserver
    {
        private int score;
        private List<Action<int>> scoreObservers;

        public QuizScoreObserver()
        {
            score = 0;
            scoreObservers = new List<Action<int>>();
        }

        public void Subscribe(Action<int> observer)
        {
            scoreObservers.Add(observer);
        }

        public void Unsubscribe(Action<int> observer)
        {
            scoreObservers.Remove(observer);
        }

        public void IncrementScore()
        {
            score++;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in scoreObservers)
            {
                observer(score);
            }
        }

        public void DisplayFinalScore()
        {
            MessageBox.Show($"Final Score: {score}");
        }
    }
}
