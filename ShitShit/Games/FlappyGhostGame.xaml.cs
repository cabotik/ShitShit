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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ShitShit.Games
{
    /// <summary>
    /// Логика взаимодействия для FlappyGhostGame.xaml
    /// </summary>
    public partial class FlappyGhostGame : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int score;
        int gravity = 8;
        bool gameOver;
        Rect flappyGhostHitBox;
        public FlappyGhostGame()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            MessageBox.Show("Space for control. For exit press T.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            Thread.Sleep(1000);
            StartGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tbScore.Text = "Score:" + score.ToString();
            flappyGhostHitBox = new Rect(Canvas.GetLeft(imageFlappyGhost), Canvas.GetTop(imageFlappyGhost),imageFlappyGhost.Width - 12, imageFlappyGhost.Height);
            Canvas.SetTop(imageFlappyGhost, Canvas.GetTop(imageFlappyGhost) + gravity);
            if (Canvas.GetTop(imageFlappyGhost) < -30 || Canvas.GetTop(imageFlappyGhost) + imageFlappyGhost.Height > 460)
            {
                StopGame();
            }
            foreach (var x in cvFlappyGhost.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1" ||  (string)x.Tag == "obs2" ||  (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);
                    if (Canvas.GetLeft(x) < -100)
                    {
                        Canvas.SetLeft(x, 800);
                        score += 5;
                    }
                    Rect PillarHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (flappyGhostHitBox.IntersectsWith(PillarHitBox))
                    {
                        StopGame();
                    }
                }
            }
        }

        private void cvFlappyGhost_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                imageFlappyGhost.RenderTransform = new RotateTransform(-20, imageFlappyGhost.Width / 2, imageFlappyGhost.Height / 2);
                gravity = -8;
            }
            if (e.Key == Key.R && gameOver == true)
            { StartGame(); }
            if (e.Key == Key.T)
            {
                ToolsForms.GamesWindow gamesWindow = new ToolsForms.GamesWindow();
                gamesWindow.Show();
                Close();
            }
        }

        private void cvFlappyGhost_KeyUp(object sender, KeyEventArgs e)
        {
            imageFlappyGhost.RenderTransform = new RotateTransform(5, imageFlappyGhost.Width / 2, imageFlappyGhost.Height / 2);
            gravity = 8;
        }
        private void StartGame()
        {
            cvFlappyGhost.Focus();
            score = 0;
            gameOver = false;
            Canvas.SetTop(imageFlappyGhost, 190);
            foreach (var x in cvFlappyGhost.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                if ((string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if ((string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1100);
                }
            }
            timer.Start();
        }
        private void StopGame() 
        {
            timer.Stop();
            gameOver = true;
            tbScore.Text += "GAME OVER! Press R to restart";
        }
    }
}
