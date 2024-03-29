﻿using System;
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
    /// Логика взаимодействия для GamesWindow.xaml
    /// </summary>
    public partial class GamesWindow : Window
    {
        public GamesWindow()
        {
            InitializeComponent();
        }

        private void btnGameRPS_Click(object sender, RoutedEventArgs e)
        {
            Games.RockPaperScissorsGame rockPaperScissorsGame = new Games.RockPaperScissorsGame();
            rockPaperScissorsGame.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }

        private void btnGameFP_Click(object sender, RoutedEventArgs e)
        {
            Games.FlappyGhostGame flappyGhostGame = new Games.FlappyGhostGame();
            flappyGhostGame.Show();
            Close();
        }

        private void btnGameCP_Click(object sender, RoutedEventArgs e)
        {
            Games.CatchBonesGame catchBonesGame = new Games.CatchBonesGame();   
            catchBonesGame.Show();
            Close();
        }

        private void btnGameTTT_Click(object sender, RoutedEventArgs e)
        {
            Games.TicTacToeGame ticTacToeGame = new Games.TicTacToeGame();
            ticTacToeGame.Show();
            Close();
        }

        private void btnGameRunner_Click(object sender, RoutedEventArgs e)
        {
            Games.RunnerGame runnerGame = new Games.RunnerGame();
            runnerGame.Show();
            Close();
        }
    }
}
