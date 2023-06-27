using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string answerSelected = "1";
        string answerCurrent = "2";
        int questionCounter = 0;
        int answered = 0;
        int skiped = 0;
        List<RadioButton> radioButtons = new List<RadioButton>();
        // Вопрос, номер ответа, Варианты ответов с 1 по 4
        List<Question> questions = new List<Question>
        {
            new Question("Какое число получится, если сложить 43 и 27?", "2", "60", "70", "80", "90" ),
            new Question("Какое число следует после числа 99?", "1", "100", "101", "102", "103" ),
            new Question("Какое число является четным?", "2", "45", "38", "25", "21" ),
            new Question("Как называется фигура, у которой все стороны равны?", "2", "Круг", "Квадрат", "Прямоугольник", "Треугольник" ),
            new Question("Сколько будет 5 умножить на 6?", "4", "10", "20", "25", "30" )
        };

        public MainWindow()
        {
            InitializeComponent();

            radioButtons = new List<RadioButton>
            {
                Radio1, Radio2, Radio3, Radio4
            };

            setupQuestion();

        }

        public void setupQuestion()
        {
            Radio1.IsChecked = true;
            if (questionCounter == questions.Count)
            {
                MessageBox.Show("Тест окончен!\nВы набрали: " + answered + " баллов!\nПропущено: " + skiped + " вопросов.");
                this.Close();
            }
            else
            {
                Question current = questions[questionCounter];
                questionText.Text = current.Text;
                answerCurrent = current.Answer;

                for (int i = 0; i < 4; i++)
                {
                    RadioButton a = radioButtons[i];
                    a.Content = (i + 1) + ") " + current.Variants[i];
                }
                questionCounter++;
            }
        }



        private void giveAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (answerSelected == answerCurrent)
            {
                answered++;
            }
            setupQuestion();
        }

        private void skipAnswer_Click(object sender, RoutedEventArgs e)
        {
            skiped++;
            setupQuestion();
        }

        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            answerSelected = button.Tag.ToString();
        }
    }
}
