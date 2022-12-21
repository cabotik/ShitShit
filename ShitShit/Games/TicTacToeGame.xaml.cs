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
        int btn0;
        int btn1;
        int btn2;
        int btn3;
        int btn4;
        int btn5;
        int btn6;
        int btn7;
        int btn8;
        public TicTacToeGame()
        {
            InitializeComponent();
        }

        private void OpponentStep()
        {
            int[] btn = new int[9];
            btn[0] = 0;
            btn[1] = 1;
            btn[2] = 2;
            btn[3] = 3;
            btn[4] = 4;
            btn[5] = 5;
            btn[6] = 6;
            btn[7] = 7;
            btn[8] = 8;
            Random random = new Random();
            int opponentBtn = random.Next(8);
            int opponent = btn[opponentBtn];
               
                switch (opponent)
                {
                    case 0:
                        if (btn0 == 0)
                        {
                            btn0 = 2;
                            ImageOneOne.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        if (btn0 != 0)
                        {
                            return;
                        }
                        break;
                    case 1:
                        if (btn1 == 0)
                        {
                            btn1 = 2;
                            ImageOneTwo.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        if (btn0 != 0)
                        {
                            return;
                        }
                        break;
                    case 2:
                        if (btn2 == 0)
                        {
                            btn2 = 2;
                            ImageOneThree.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        else { return; }
                        break;
                    case 3:
                        if (btn3 == 0)
                        {
                            btn3 = 2;
                            ImageTwoOne.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        else { return; }
                        break;
                    case 4:
                        if (btn4 == 0)
                        {
                            btn4 = 2;
                            ImageTwoTwo.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        else { return; }
                        break;
                    case 5:
                        if (btn5 == 0)
                        {
                            btn5 = 2;
                            ImageTwoThree.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        else { return; }
                        break;
                    case 6:
                        if (btn6 == 0)
                        {
                            btn6 = 2;
                            ImageThreeOne.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        else { return; }
                        break;
                    case 7:
                        if (btn7 == 0)
                        {
                            btn7 = 2;
                            ImageThreeTwo.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        else { return; }
                        break;
                    case 8:
                        if (btn8 == 0)
                        {
                            btn8 = 2;
                            ImageThreeThree.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/crossbones_icon.png"));
                        }
                        else { return; }
                        break;
                }

                if (btn0 == 1 && btn1 == 1 && btn2 == 1 || btn3 == 1 && btn4 == 1 && btn5 == 1 || btn6 == 1 && btn7 == 1 && btn8 == 1)
                {
                    MessageBox.Show("WIN!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refreash();
                }
                if (btn0 == 1 && btn3 == 1 && btn6 == 1 || btn1 == 1 && btn4 == 1 && btn7 == 1 || btn2 == 1 && btn5 == 1 && btn8 == 1)
                {
                    MessageBox.Show("WIN!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refreash();
                }
                if (btn0 == 1 && btn4 == 1 && btn8 == 1 || btn2 == 1 && btn4 == 1 && btn6 == 1)
                {
                    MessageBox.Show("WIN!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refreash();
                }

                if (btn0 == 2 && btn1 == 2 && btn2 == 2 || btn3 == 2 && btn4 == 2 && btn5 == 2 || btn6 == 2 && btn7 == 2 && btn8 == 2)
                {
                    MessageBox.Show("LOSE!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refreash();
                }
                if (btn0 == 2 && btn3 == 2 && btn6 == 2 || btn1 == 2 && btn4 == 2 && btn7 == 2 || btn2 == 2 && btn5 == 2 && btn8 == 2)
                {
                    MessageBox.Show("LOSE!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refreash();
                }
                if (btn0 == 2 && btn4 == 2 && btn8 == 2 || btn2 == 2 && btn4 == 2 && btn6 == 2)
                {
                    MessageBox.Show("LOSE!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Refreash();
                }
              
            
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.GamesWindow gamesWindow = new ToolsForms.GamesWindow();
            gamesWindow.Show();
            Close();
        }
        private void Refreash()
        {
            Games.TicTacToeGame ticTacToeGame = new TicTacToeGame();
            Application.Current.MainWindow = ticTacToeGame;
            ticTacToeGame.Show();
            this.Close();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refreash();
        }
        private void bntOneOne_Click(object sender, RoutedEventArgs e)
        {
            if (btn0 == 0)
            {
                btn0 = 1;
                ImageOneOne.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
        private void bntOneTwo_Click(object sender, RoutedEventArgs e)
        {
            if (btn1 == 0)
            {
                btn1 = 1;
                ImageOneTwo.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
        private void bntOneThree_Click(object sender, RoutedEventArgs e)
        {
            if (btn2 == 0)
            {
                btn2 = 1;
                ImageOneThree.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
        private void bntTwoOne_Click(object sender, RoutedEventArgs e)
        {
            if (btn3 == 0)
            {
                btn3 = 1;
                ImageTwoOne.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void bntTwoTwo_Click(object sender, RoutedEventArgs e)
        {
            if (btn4 == 0)
            {
                btn4 = 1;
                ImageTwoTwo.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void bntTwoThree_Click(object sender, RoutedEventArgs e)
        {
            if (btn5 == 0)
            {
                btn5 = 1;
                ImageTwoThree.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void bntThreeOne_Click(object sender, RoutedEventArgs e)
        {
            if (btn6 == 0)
            {
                btn6 = 1;
                ImageThreeOne.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void bntThreeTwo_Click(object sender, RoutedEventArgs e)
        {
            if (btn7 == 0)
            {
                btn7 = 1;
                ImageThreeTwo.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void bntThreeThree_Click(object sender, RoutedEventArgs e)
        {
            if (btn8 == 0)
            {
                btn8 = 1;
                ImageThreeThree.Source = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                OpponentStep();

            }
            else
            { MessageBox.Show("Еhis cell is occupied!", "Information", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
    }
}
