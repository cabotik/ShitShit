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
        DispatcherTimer dispatcherTimerVP = new DispatcherTimer();
        private bool IsToggle;

        public MainWindow()
        {        
            InitializeComponent();
           
            var uri = new Uri("/MyImages/happyghost_icon.png", UriKind.Relative);
            imageGhost.Source = new BitmapImage(uri);
            PersentReturn();
            ghost.TimerForChangeParameters();
            TimarForViewParametrs();
        }
        private void TimarForViewParametrs()
        {
           
            dispatcherTimerVP.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimerVP.Interval = new TimeSpan(0, 0, 0, 0, 8000);
            dispatcherTimerVP.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            PersentReturn();
        }

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
                var uriOne = new Uri("/MyImages/sleepghost.png", UriKind.Relative);
                imageGhost.Source = new BitmapImage(uriOne);
                dispatcherTimerVP.Stop();
                for (int i = 10; i > 0; i--)
                {
                    ghost.Sleep = 100;
                    Thread.Sleep(1000);
                }
                var uri = new Uri("/MyImages/happyghost_icon.png", UriKind.Relative);
                imageGhost.Source = new BitmapImage(uri);
                PersentReturn();
                dispatcherTimerVP.Start();
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
                ghost.Healthing();
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
            spFoodChoose.Visibility = Visibility.Hidden;
        }

        private void btnEatRatSoul_Click(object sender, RoutedEventArgs e)
        {
            ghost.EatRatsSoul();
            PersentReturn();
            spFoodChoose.Visibility = Visibility.Hidden;
        }

        private void btnEatSoul_Click(object sender, RoutedEventArgs e)
        {
            ghost.EatRatsSoul();
            PersentReturn();
            spFoodChoose.Visibility = Visibility.Hidden;
        }

        private void btnPlayWithBouns_Click(object sender, RoutedEventArgs e)
        {
            ghost.PlayWithBones();
            PersentReturn();
            spGameChoose.Visibility = Visibility.Hidden;
        }

        private void btnPlayWithRats_Click(object sender, RoutedEventArgs e)
        {
            ghost.PlayWithRats();
            PersentReturn();
            spGameChoose.Visibility = Visibility.Hidden;
        }

        private void btnPlayWithPerson_Click(object sender, RoutedEventArgs e)
        {
            ghost.PlayWithPerson();
            PersentReturn();
            spGameChoose.Visibility = Visibility.Hidden;
        }
    }
}
