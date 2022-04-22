using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    internal class PlayerMovement : ObservableRecipient
    {
        IGameControl control;
        GameLogic gameLogic = new GameLogic();
        public PlayerMovement()
        {

        }

        public PlayerMovement(IGameControl control)
        {
            this.control = control;
        }

        private bool jump;

        public bool Jump
        {
            get { return jump; }
            set { SetProperty(ref jump, value); }
        }

        private bool shoot;

        public bool Shoot
        {
            get { return shoot; }
            set { SetProperty(ref shoot, value); }
        }

        public void KeyPressed(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    Jump = true;
                    control.Jump(Jump);
                    break;
                case Key.Space:
                    Shoot = true;
                    control.Shoot(Shoot);
                    break;
                    //case Key.Up:
                    //    control.Move(GameLogic.Directions.jump);
                    //break;
                case Key.Left:
                    control.HorizontalMove(GameLogic.Directions.left);
                    break;
                case Key.Right:
                    control.HorizontalMove(GameLogic.Directions.right);
                    break;
                    
            }
        }
    }
}
