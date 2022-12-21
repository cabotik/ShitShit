using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Логика взаимодействия для RunnerGame.xaml
    /// </summary>
    public partial class RunnerGame : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Rect playerHitBox;
        Rect groundHitBox;
        Rect obstacleHitBox;

        bool jump;
        int force = 20;
        int speed = 5;

        Random random = new Random();

        bool gameOver;

        ImageBrush playerSprite = new ImageBrush();
        ImageBrush bgSprite = new ImageBrush();
        ImageBrush obstacleSprite = new ImageBrush();
        int[] obstaclePosition = {320, 310, 300, 305, 315 };
        int score = 0;

        public RunnerGame()
        {
            InitializeComponent();
            cvRG.Focus();
            timer.Tick += GameEngine;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            bgSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/rungamebg.png"));
            playerSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/flyghost_icon.png"));
            player.Fill = playerSprite;
            bg.Fill = bgSprite;
            secondBg.Fill = bgSprite;

            MessageBox.Show("Space for control. For exit press esc.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            Thread.Sleep(1000);
            StartGame();

        }

        private void StartGame()
        {
            Canvas.SetLeft(bg, 0);
            Canvas.SetLeft(secondBg, 1262);

            Canvas.SetLeft(player, 100);
            Canvas.SetTop(player, 140);

            Canvas.SetLeft(obstacle, 950);
            Canvas.SetTop(obstacle, 310);
            obstacleSprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/ruincolumn_icoon.png"));
            obstacle.Fill = obstacleSprite;
            jump = false;
            gameOver = false;   
            score = 0;
            tbScore.Text = "Score: " + score;
            timer.Start();
        }

        private void GameEngine(object sender, EventArgs e)
        {
            Canvas.SetLeft(bg, Canvas.GetLeft(bg) - 3);
            Canvas.SetLeft(secondBg, Canvas.GetLeft(secondBg) - 3);
            if (Canvas.GetLeft(bg) < -1262)
            {
                Canvas.SetLeft(bg, Canvas.GetLeft(secondBg) + secondBg.Width );
            }
            if (Canvas.GetLeft(secondBg) < -1262)
            {
                Canvas.SetLeft(secondBg, Canvas.GetLeft(bg) + bg.Width);
            }

            Canvas.SetTop(player, Canvas.GetTop(player) + speed);
            Canvas.SetLeft(obstacle, Canvas.GetLeft(obstacle) - 12);
            tbScore.Text = "Score: " + score;

            playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width - 15, player.Height);
            obstacleHitBox = new Rect(Canvas.GetLeft(obstacle), Canvas.GetTop(obstacle), obstacle.Width, obstacle.Height);
            groundHitBox = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground), ground.Width, ground.Height);
            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                speed = 0;
                Canvas.SetTop(player, Canvas.GetTop(ground) - player.Height);
                jump = false;
                
            }
            if (jump == true)
            {
                speed = -9;
                force -= 1;
            }
            else { speed = 12; }
            if (force < 0) { jump = false; }
            if (Canvas.GetLeft(obstacle) < -50)
            {
                Canvas.SetLeft(obstacle, 950);
                Canvas.SetTop(obstacle, obstaclePosition[random.Next(0, obstaclePosition.Length)]);
                score += 1;
            }
            if (playerHitBox.IntersectsWith(obstacleHitBox))
            {
                gameOver = true;
                timer.Stop();
            }
            if (gameOver == true)
            {
                obstacle.Stroke = Brushes.Black;
                obstacle.StrokeThickness = 1;
                tbScore.Text = "Score: " + score + " Press R to restart";
            }
            else 
            {
                player.StrokeThickness = 0;
                obstacle.StrokeThickness = 0;
            }
        }

        private void cvRG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R && gameOver == true)
            {
                StartGame();
            }
        }

        private void cvRG_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && jump == false && Canvas.GetTop(player) > 260)
            {
                jump = true;
                force= 15;
                speed = -12;
                
            }
        }

        private void cvRG_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                ToolsForms.GamesWindow gamesWindow = new ToolsForms.GamesWindow();
                gamesWindow.Show();
                Close();
            }
        }
    }
}
