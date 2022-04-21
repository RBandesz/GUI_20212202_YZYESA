using SpaceBunnyJump.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SpaceBunnyJump.Models
{
    internal class PlayerMovement
    {
        IGameModel control;

        public PlayerMovement(IGameModel control)
        {
            this.control = control;
        }


        public void KeyPressed(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    control.Move(GameLogic.Directions.jump);
                    break;
                case Key.Left:
                    control.Move(GameLogic.Directions.left);
                    break;
                case Key.Right:
                    control.Move(GameLogic.Directions.right);
                    break;
            }
        }
    }
}
