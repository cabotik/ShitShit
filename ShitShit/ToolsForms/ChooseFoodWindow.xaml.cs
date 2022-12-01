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
        Ghost ghost = new Ghost();
        public ChooseFoodWindow()
        {
            InitializeComponent();
        }

        private void btnEatFear_Click(object sender, RoutedEventArgs e)
        {
            ghost.EatFear();
            Close();
        }

        private void btnEatRatSoul_Click(object sender, RoutedEventArgs e)
        {
            ghost.EatRatsSoul();
            Close();
        }

        private void btnEatSoul_Click(object sender, RoutedEventArgs e)
        {
            ghost.EatPersonsSoul();
            Close();
        }
    }
}
