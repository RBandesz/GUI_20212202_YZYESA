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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SpaceBunnyJump.Classes;
using SpaceBunnyJump.Logic;
using SpaceBunnyJump.Models;

namespace SpaceBunnyJump
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLogic logic;
        GameEngine engine = new GameEngine();
        PlayerMovement movement;
        DispatcherTimer gameTimer = new DispatcherTimer();
        Player player;

        

        public MainWindow()
        {
            InitializeComponent();
        }
        private void StartGame()
        {
            engine.Start();
            gameTimer.Start();
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {

            engine.GameRunner();
            logic.TimeUpdate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new GameLogic();

            logic.GameOver += Logic_GameOver;

            display.SetupModel(logic);
            movement = new PlayerMovement(logic);


            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
            StartGame();

            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.SetupSizes(new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight));

            
        }

        private void Logic_GameOver(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("You Died! Score: " + logic.player.Score);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            movement.KeyPressed(e.Key);
            display.InvalidateVisual();
        }








    }

}
