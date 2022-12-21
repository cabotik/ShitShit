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
    /// Логика взаимодействия для CatchBonesGame.xaml
    /// </summary>
    public partial class CatchBonesGame : Window
    {
        int records;
        int maxItems= 5;
        int currentItems = 0;
        int score = 0;
        int missed = 0;
        Random random = new Random();
        Rect basketHitBox;
        DispatcherTimer timer = new DispatcherTimer();
        List<Rectangle> itemsRemove = new List<Rectangle>();
        int itemSpeed = 10;
        ImageBrush imageBasket = new ImageBrush();
        
        
        public CatchBonesGame()
        {
            InitializeComponent();

            cvCatchBones.Focus();
            timer.Tick += GameEngine;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            MessageBox.Show("Mouse for control. For exit press esc.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            Thread.Sleep(1000);
            timer.Start();
            imageBasket.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/leftbasket_icon.png"));
            //var uriLeft = new Uri("\\MyImages\\leftbasket_icon.png", UriKind.Relative);
            //imageBasket.ImageSource = new BitmapImage(uriLeft);
            rPlayer.Fill = imageBasket;
            records = Properties.Settings.Default.lastscoreCB;
        }

        private void GameEngine(object sender, EventArgs e)
        {
            tbScore.Text = "Caught: " + score.ToString();
            tbMissed.Text = "Missed: " + missed.ToString();
            tbRecord.Text = "Last score:" + records.ToString();
            if (currentItems < maxItems)
            {
                MakeBones();
                currentItems++;
                itemsRemove.Clear();
            }
            foreach (var x in cvCatchBones.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "drops")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + itemSpeed);
                    if (Canvas.GetTop(x) > 720)
                    {
                        itemsRemove.Add(x);
                        currentItems--;
                        missed++;
                    }
                    Rect bonesHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    basketHitBox = new Rect(Canvas.GetLeft(rPlayer), Canvas.GetTop(rPlayer), rPlayer.Width, rPlayer.Height);
                    if (basketHitBox.IntersectsWith(bonesHitBox))
                    {
                        itemsRemove.Add(x);
                        currentItems--;
                        score++;
                    }
                }
            }
            foreach (var i in itemsRemove)
            { 
                cvCatchBones.Children.Remove(i);
            }
            if (score > 10)
            {
                itemSpeed = 12;
            }
            if (score > 100)
            {
                itemSpeed = 16;
            }
            if (score > 500)
            {
                itemSpeed = 20;
            }
            if (missed > 10)
            {
                timer.Stop();
                Properties.Settings.Default.lastscoreCB = score;
                Properties.Settings.Default.Save();
                tbScore.Text += "GAME OVER! Press R to restart";
               
            }
            
        }


        private void cvCatchBones_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);
            double px = position.X;
            Canvas.SetLeft(rPlayer, px - 10);
            if (Canvas.GetLeft(rPlayer) < 260)
            {
                imageBasket.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/leftbasket_icon.png"));
            }
            else 
            {
                imageBasket.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/rightbasket_icon.png"));
            }
        }
        private void MakeBones()
        { 
            ImageBrush bones= new ImageBrush();
            int ra = random.Next(1,5);
            switch (ra)
            {
                case 1:
                    bones.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/bonesOne_icon.png"));
                    break;
                case 2:
                    bones.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/bonesTwo_icon.png"));
                    break;
                case 3:
                    bones.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/skull_icon.png"));
                    break;
                case 4:
                    bones.ImageSource = new BitmapImage(new Uri("pack://application:,,,/MyImages/cowskull_icon.png"));
                    break;
            }
            Rectangle newRec = new Rectangle
            { 
                Tag = "drops",
                Width = 50,
                Height = 50,
                Fill = bones
            };
            Canvas.SetLeft(newRec, random.Next(10,450));
            Canvas.SetTop(newRec, random.Next(60, 150) * -1);
            cvCatchBones.Children.Add(newRec); 
        }
        private void cvCatchBones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                ToolsForms.GamesWindow gamesWindow = new ToolsForms.GamesWindow();
                gamesWindow.Show();
                Close();
            }
        }
        private void cvCatchBones_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R)
            {
                Games.CatchBonesGame catchBonesGame = new Games.CatchBonesGame();
                //Application.Current.MainWindow = catchBonesGame;
                catchBonesGame.Show();
                this.Close();
            }          
        }
    }
}
