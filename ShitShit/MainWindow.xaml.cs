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
            Ghost ghost = new Ghost();
            ghost.Health = 60;
            ghost.Happy = 100;
            ghost.Food = 100;
            ghost.Sleep = 90;
            tbFoodPercent.Text = $"{Convert.ToString(ghost.Food)}%";
            tbHappyPercent.Text = $"{Convert.ToString(ghost.Happy)}%";
            tbHealthPercent.Text = $"{Convert.ToString(ghost.Health)}%";
            tbSleepPercent.Text = $"{Convert.ToString(ghost.Sleep)}%";
            TimerCallback tm = new TimerCallback(ReducingParametersTimer);
            Timer timer = new Timer(tm, 0, 0, 2000);
            
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

        }

        private void btnSleep_Click(object sender, RoutedEventArgs e)
        {
            Sleep();
        }
        private int Sleep()
        {
            spBlack.Visibility = Visibility.Visible;
            spSleep.Visibility = Visibility.Visible;
            spNormal.Visibility = Visibility.Hidden;
            TimerCallback tm = new TimerCallback(IncreaseSleep);
            Timer timer = new Timer(tm, 0, 0, 15000);
            Ghost ghost = new Ghost();
            if (ghost.Sleep >= 100)
            {
                timer.Dispose();
                spBlack.Visibility = Visibility.Hidden;
                spSleep.Visibility = Visibility.Hidden;
                spNormal.Visibility = Visibility.Visible;
            }
            if(ghost.Sleep < 100)
            {
                while (ghost.Sleep >= 100)
                {
                    ghost.Sleep = ghost.Sleep + 10;
                }
                
            }
            return ghost.Sleep;
        }
        private void IncreaseSleep(object obj)
        {
            Ghost ghost = new Ghost();
            if(ghost.Sleep <100)
            { ghost.Sleep = ghost.Sleep + 10; }
            return;
        }

        private void btnHealth_Click(object sender, RoutedEventArgs e)
        {
            Health();
        }
        private int Health()
        {
            Ghost ghost = new Ghost();
            if (ghost.Health < 100)
            {
                ghost.Health = ghost.Health + 10;
            }
            return ghost.Health;
        }

        private void btnHappy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGames_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddName_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghostName = new Ghost();
            Name = tbAddGhostName.Text;
            tbGhostName.Text = Name;
            spName.Visibility = Visibility.Hidden;

        }
    }
}
