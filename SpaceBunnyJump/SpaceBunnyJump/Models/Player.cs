using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Models
{
    public class Player : ObservableRecipient
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Alive { get; set; }

        public int Ammo { get; set; }

        public System.Windows.Rect hitbox { get; set; }

        //public Physics physics;

        public Point position { get; set; }




        private int score;
        public int Score
        {
            get { return score; }
            set { SetProperty(ref score, value); }
        }
        

        public Player()
        {
            this.Height = 80;
            this.Width = 50;
            this.Alive = true;
            this.Ammo = 5;
            this.Score = 0;
            this.position = new Point(630, 250);
            hitbox = new System.Windows.Rect(position.Y - 30, position.X - 30, 60, 90);

        }
        public void Move()
        {
            hitbox = new System.Windows.Rect(position.Y - 30, position.X - 30, 60, 90);
        }

    }
}
