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

        public MainWindow()
        {        
            InitializeComponent();
            PersentReturn();
            ghost.TimerForChangeParameters();
            TimarForViewParametrs();
        }
        private void TimarForViewParametrs()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 120000);///120 000
            dispatcherTimer.Start();
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
                ToolsForms.ChooseFoodWindow chooseFoodWindow = new ToolsForms.ChooseFoodWindow();
                chooseFoodWindow.Show();
            }
            else { MessageBox.Show("Ghost is not hungry!", "Message", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void btnSleep_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnHealth_Click(object sender, RoutedEventArgs e)
        {
            if (ghost.HealthReturn() < 90)
            { 
                ghost.Healthing();
                MessageBox.Show("Ghost is healed!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("Ghost is healthy!", "Message", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
        private void btnHappy_Click(object sender, RoutedEventArgs e)
        {

            if (ghost.HappyReturn() < 90)
            {
                ToolsForms.ChooseGameWindow chooseGameWindow = new ToolsForms.ChooseGameWindow();
                chooseGameWindow.Show();
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
    }
}
