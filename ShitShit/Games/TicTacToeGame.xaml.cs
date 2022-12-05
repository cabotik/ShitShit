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
    /// Логика взаимодействия для TicTacToeGame.xaml
    /// </summary>
    public partial class TicTacToeGame : Window
    {
        public TicTacToeGame()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.GamesWindow gamesWindow = new ToolsForms.GamesWindow();
            gamesWindow.Show();
            Close();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
