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
    /// Логика взаимодействия для ChooseGameWindow.xaml
    /// </summary>
    public partial class ChooseGameWindow : Window
    {
        public ChooseGameWindow()
        {
            InitializeComponent();
        }

        private void btnPlayWithBouns_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            ghost.PlayWithBones();
            MainWindow mainWindow = new MainWindow();
            mainWindow.PersentReturn();
        }

        private void btnPlayWithRats_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            ghost.PlayWithRats();
            MainWindow mainWindow = new MainWindow();
            mainWindow.PersentReturn();
        }

        private void btnPlayWithPerson_Click(object sender, RoutedEventArgs e)
        {
            Ghost ghost = new Ghost();
            ghost.PlayWithPerson();
            MainWindow mainWindow = new MainWindow();
            mainWindow.PersentReturn();
        }
    }
}
