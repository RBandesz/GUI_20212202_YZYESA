using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Classes
{
    class Alien
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point position { get; set; }
        public System.Windows.Rect hitbox { get; set; }



        public Alien(Point position)
        {
            this.Width = 120;
            this.Height = 100;
            this.position = position;
        }


    }
}
