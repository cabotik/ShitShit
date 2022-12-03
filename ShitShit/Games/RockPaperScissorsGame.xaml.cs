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
using System.Windows.Shapes;

namespace ShitShit.Games
{
    /// <summary>
    /// Логика взаимодействия для RockPaperScissorsGame.xaml
    /// </summary>
    public partial class RockPaperScissorsGame : Window
    {
        public RockPaperScissorsGame()
        {
            InitializeComponent();            
            string[] variant = new string[3];
            variant[1] = "rock";
            variant[2] = "paper";
            variant[3] = "scissors";
           
        }

        private void Result(string[] variant, string gamerChoosen)
        {
            Random random = new Random();
            int variantBotInt = random.Next(3);
            string opponentVariant = variant[variantBotInt];
            switch (opponentVariant)
            {
                case "rock":
                    var uri = new Uri("/MyImages/rock_icon.png", UriKind.Relative);
                    imageOpponentChoosen.Source = new BitmapImage(uri);
                    break;
                case "paper":
                    var uriOne = new Uri("/MyImages/paper_icon.png", UriKind.Relative);
                    imageOpponentChoosen.Source = new BitmapImage(uriOne);
                    break;
                case "scissors":
                    var uriTwo = new Uri("/MyImages/scissors_icon.png", UriKind.Relative);
                    imageOpponentChoosen.Source = new BitmapImage(uriTwo);
                    break;
            }
            if (gamerChoosen == "rock" && opponentVariant == "rock" || gamerChoosen == "paper" && opponentVariant == "paper" || gamerChoosen == "scissors" && opponentVariant == "scissors")
            {
                MessageBox.Show("DROW!!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (gamerChoosen == "rock" && opponentVariant == "paper" || gamerChoosen == "paper" && opponentVariant == "scissors" || gamerChoosen == "scissors" && opponentVariant == "rock")
            {
                MessageBox.Show("LOSE!!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (gamerChoosen == "rock" && opponentVariant == "scissors" || gamerChoosen == "paper" && opponentVariant == "rock" || gamerChoosen == "scissors" && opponentVariant == "paper")
            {
                MessageBox.Show("WIN!!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private string GamerChoosenRock()
        {
            string gamerChoosen = "rock";
            var uri = new Uri("/MyImages/rock_icon.png", UriKind.Relative);
            imageChoosen.Source = new BitmapImage(uri);
            return gamerChoosen;
        }
        private string GamerChoosenPapper()
        {
            string gamerChoosen = "paper";
            var uriOne = new Uri("/MyImages/paper_icon.png", UriKind.Relative);
            imageChoosen.Source = new BitmapImage(uriOne);
            return gamerChoosen;
        }
        private string GamerChoosenRockScissors()
        {
            string gamerChoosen = "scissors";
            var uriTwo = new Uri("/MyImages/scissors_icon.png", UriKind.Relative);
            imageChoosen.Source = new BitmapImage(uriTwo);
            return gamerChoosen;
        }
        private void btnRock_Click(object sender, RoutedEventArgs e)
        {
            GamerChoosenRock();
        }

        private void btnPaper_Click(object sender, RoutedEventArgs e)
        {
            GamerChoosenPapper();
        }

        private void btnScissors_Click(object sender, RoutedEventArgs e)
        {
            GamerChoosenRockScissors();
        }
    }
}
