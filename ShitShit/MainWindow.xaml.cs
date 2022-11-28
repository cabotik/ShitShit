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

namespace ShitShit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            TimerCallback tm = new TimerCallback(ReducingParametersTimer);
            Timer timer = new Timer(tm, 0, 0, 2000);
            
        }
        public void PersentReturn()
        {
            Ghost ghost = new Ghost();
            tbFoodPercent.Text = $"{Convert.ToString(ghost.FoodReturn())}%";
            tbHappyPercent.Text = $"{Convert.ToString(ghost.HappyReturn())}%";
            tbHealthPercent.Text = $"{Convert.ToString(ghost.HealthReturn())}%";
            tbSleepPercent.Text = $"{Convert.ToString(ghost.SleepReturn())}%";
        }
        private void ReducingParametersTimer(object obj)
        {
            ReducingParameters();
        }
        private int ReducingParameters()
        {

            Ghost ghost = new Ghost();
            ghost.Food = ghost.Food - 10;
            ghost.Happy = ghost.Happy - 10;
            ghost.Health = ghost.Health - 5;
            ghost.Sleep = ghost.Sleep - 10;
            return ghost.Sleep;
        }
        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            CheckParametrs(ghost.FoodReturn());
            ToolsForms.ChooseFoodWindow chooseFoodWindow = new ToolsForms.ChooseFoodWindow();
            chooseFoodWindow.Show();
        }

        private void btnSleep_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnHealth_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            CheckParametrs(ghost.HealthReturn());
            ghost.Healthing();
        }
        private void btnHappy_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            CheckParametrs(ghost.HappyReturn());
            ToolsForms.ChooseGameWindow chooseGameWindow = new ToolsForms.ChooseGameWindow();
            chooseGameWindow.Show();
        }

        private void btnGames_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.GamesWindow gamesWindow = new ToolsForms.GamesWindow();
            gamesWindow.Show();
        }

        private void btnAddName_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghostName = new Ghost();
            Name = tbAddGhostName.Text;
            tbGhostName.Text = Name;
            spName.Visibility = Visibility.Hidden;

        }
        private void CheckParametrs(int i)
        {
            if (i <100)
            { return; }
            if (i >= 100)
            { MessageBox.Show("Limit!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }
    }
}
