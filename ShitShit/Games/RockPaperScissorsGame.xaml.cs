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
        public string gamerChoosen;
        public int wins = 0;
        public int loses = 0;
        public RockPaperScissorsGame()
        {
            InitializeComponent();

        }

        private void Result(string gamerChoosen)
        {           
            string[] variant = new string[3];
            variant[0] = "rock";
            variant[1] = "paper";
            variant[2] = "scissors";
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
                loses++;
                MessageBox.Show("LOSE!!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (gamerChoosen == "rock" && opponentVariant == "scissors" || gamerChoosen == "paper" && opponentVariant == "rock" || gamerChoosen == "scissors" && opponentVariant == "paper")
            {
                wins++;
                MessageBox.Show("WIN!!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            tbLoses.Text = Convert.ToString(loses);
            tbWins.Text = Convert.ToString(wins);
        }

        private void btnRock_Click(object sender, RoutedEventArgs e)
        {
            gamerChoosen = "rock";
            var uri = new Uri("/MyImages/rock_icon.png", UriKind.Relative);
            imageChoosen.Source = new BitmapImage(uri);
            Result(gamerChoosen);
        }

        private void btnPaper_Click(object sender, RoutedEventArgs e)
        {
            gamerChoosen = "paper";
            var uriOne = new Uri("/MyImages/paper_icon.png", UriKind.Relative);
            imageChoosen.Source = new BitmapImage(uriOne);
            Result(gamerChoosen);
        }

        private void btnScissors_Click(object sender, RoutedEventArgs e)
        {
            gamerChoosen = "scissors";
            var uriTwo = new Uri("/MyImages/scissors_icon.png", UriKind.Relative);
            imageChoosen.Source = new BitmapImage(uriTwo);
            Result(gamerChoosen);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.GamesWindow gamesWindow = new ToolsForms.GamesWindow();
            gamesWindow.Show();
            Close();
        }

        private void btnRefreash_Click(object sender, RoutedEventArgs e)
        {
            imageChoosen.Source = null;
            imageOpponentChoosen.Source = null;
            //Games.RockPaperScissorsGame rockPaperScissorsGame = new RockPaperScissorsGame();
            //Application.Current.MainWindow = rockPaperScissorsGame;
            //rockPaperScissorsGame.Show();
            //this.Close();
        }
    }
}
