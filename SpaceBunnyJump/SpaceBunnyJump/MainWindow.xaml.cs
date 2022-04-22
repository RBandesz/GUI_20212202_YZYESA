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
        public MainWindow()
        {
            InitializeComponent();
            logic = new GameLogic();
            display.SetupModel(logic);
            movement = new PlayerMovement(logic);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();
        }
        private void StartGame()
        {
            engine.Start();
            gameTimer.Start();
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            engine.GameRunner();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.SetupSizes(new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
           
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            movement.KeyPressed(e.Key);
            display.InvalidateVisual();
        }


    }
}
