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

namespace ShitShit.ToolsForms
{
    /// <summary>
    /// Логика взаимодействия для ChooseFoodWindow.xaml
    /// </summary>
    public partial class ChooseFoodWindow : Window
    {
        public ChooseFoodWindow()
        {
            InitializeComponent();
        }

        private void btnEatFear_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            ghost.EatFear();
            MainWindow mainWindow = new MainWindow();
            mainWindow.PersentReturn();
        }

        private void btnEatRatSoul_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            ghost.EatRatsSoul();
            MainWindow mainWindow = new MainWindow();
            mainWindow.PersentReturn();
        }

        private void btnEatSoul_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            ghost.EatPersonsSoul();
            MainWindow mainWindow = new MainWindow();
            mainWindow.PersentReturn();
        }
    }
}
