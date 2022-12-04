using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ShitShit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ghost ghost = new Ghost();
        //DispatcherTimer dispatcherTimerVP = new DispatcherTimer();


        public MainWindow()
        {        
            InitializeComponent();
            GhostCheck();
            PersentReturn();
            var uriCandleOn = new Uri("/MyImages/candleskull_icon.png", UriKind.Relative);
            imageCandle.Source = new BitmapImage(uriCandleOn);
            ghost.TimerForChangeParameters();
            
        }
        //private void TimarForChangeghostPic()
        //{

        //    dispatcherTimerVP.Tick += new EventHandler(dispatcherTimer_Tick);
        //    dispatcherTimerVP.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        //    dispatcherTimerVP.Start();
        //}
        private void GhostCheck()
        {
            if (ghost.Health >= 60 || ghost.Food >= 60 || ghost.Happy >= 60 || ghost.Sleep >= 60)
            {
                var uriHappy = new Uri("/MyImages/happyghost_icon.png", UriKind.Relative);
                imageGhost.Source = new BitmapImage(uriHappy);
            }
            if (ghost.Health <= 20 || ghost.Food <= 20 || ghost.Happy <= 20 || ghost.Sleep <= 20)
            {
                var uriSad = new Uri("/MyImages/sadghost_icon.png", UriKind.Relative);
                imageGhost.Source = new BitmapImage(uriSad);
            }
            if ( ghost.Health <= 50 && ghost.Health >= 30|| ghost.Food <= 50 && ghost.Food >= 30 || ghost.Happy <= 50 && ghost.Happy >= 30 || ghost.Sleep <= 50 && ghost.Sleep >= 30)
            {
                var uriNormal = new Uri("/MyImages/normalghost_icon.png", UriKind.Relative);
                imageGhost.Source = new BitmapImage(uriNormal);
            }

        }
        //private void dispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    var uriVeryHappy = new Uri("/MyImages/veryhappyghost_icon.png", UriKind.Relative);
        //    imageGhost.Source = new BitmapImage(uriVeryHappy);
        //}

        public void PersentReturn()
        {
            tbFoodPercent.Text = $"{Convert.ToString(ghost.FoodReturn())}%";
            tbHappyPercent.Text = $"{Convert.ToString(ghost.HappyReturn())}%";
            tbHealthPercent.Text = $"{Convert.ToString(ghost.HealthReturn())}%";
            tbSleepPercent.Text = $"{Convert.ToString(ghost.SleepReturn())}%";
        }

        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            if (ghost.FoodReturn() < 90)
            {
                spFoodChoose.Visibility = Visibility.Visible;
            }
            else { MessageBox.Show("Ghost is not hungry!", "Message", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void btnSleep_Click(object sender, RoutedEventArgs e)
        {
           
            if (ghost.SleepReturn() < 90)
            {
                spBlack.Visibility = Visibility.Visible;
                var uriCandleOff = new Uri("/MyImages/candleskulloff_icon.png", UriKind.Relative);
                imageCandle.Source = new BitmapImage(uriCandleOff);
                var uriSleep = new Uri("/MyImages/sleepghost.png", UriKind.Relative);
                imageGhost.Source = new BitmapImage(uriSleep);
                for (int i = 10; i > 0; i--)
                {
                    pbSleep.Value++;
                    ghost.Sleep = 100;
                    Thread.Sleep(1000);
                }
                spBlack.Visibility = Visibility.Hidden;
                var uriCandleOn = new Uri("/MyImages/candleskull_icon.png", UriKind.Relative);
                imageCandle.Source = new BitmapImage(uriCandleOn);
                GhostCheck();
                PersentReturn();
                return;
            }
            else
            {
                MessageBox.Show("Ghost doesn't want to sleep!", "Message", MessageBoxButton.OK, MessageBoxImage.Information); 
            }           
        }       
        private void btnHealth_Click(object sender, RoutedEventArgs e)
        {
            if (ghost.HealthReturn() < 90)
            {
                ghost.Health = 100;
                PersentReturn();
                MessageBox.Show("Ghost is healed!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("Ghost is healthy!", "Message", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
        private void btnHappy_Click(object sender, RoutedEventArgs e)
        {

            if (ghost.HappyReturn() < 90)
            {
               spGameChoose.Visibility = Visibility.Visible;
            }
            else { MessageBox.Show("Ghost is already happy!", "Message", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void btnGames_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.GamesWindow gamesWindow = new ToolsForms.GamesWindow();
            gamesWindow.Show();
        }

        private void btnAddName_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghostName = new Ghost();
            try
            {
                Name = tbAddGhostName.Text;
                tbGhostName.Text = Name;
                spName.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEatFear_Click(object sender, RoutedEventArgs e)
        {
            ghost.EatFear();
            PersentReturn();
            GhostCheck();
            spFoodChoose.Visibility = Visibility.Hidden;
        }

        private void btnEatRatSoul_Click(object sender, RoutedEventArgs e)
        {
            ghost.EatRatsSoul();
            PersentReturn();
            GhostCheck();
            spFoodChoose.Visibility = Visibility.Hidden;
        }

        private void btnEatSoul_Click(object sender, RoutedEventArgs e)
        {
            ghost.EatRatsSoul();
            PersentReturn();
            GhostCheck();
            spFoodChoose.Visibility = Visibility.Hidden;
        }

        private void btnPlayWithBouns_Click(object sender, RoutedEventArgs e)
        {
            ghost.PlayWithBones();
            PersentReturn();
            GhostCheck();
            spGameChoose.Visibility = Visibility.Hidden;
        }

        private void btnPlayWithRats_Click(object sender, RoutedEventArgs e)
        {
            ghost.PlayWithRats();
            PersentReturn();
            GhostCheck();
            spGameChoose.Visibility = Visibility.Hidden;
        }

        private void btnPlayWithPerson_Click(object sender, RoutedEventArgs e)
        {
            ghost.PlayWithPerson();
            PersentReturn();
            GhostCheck();
            spGameChoose.Visibility = Visibility.Hidden;
        }

    }
}
