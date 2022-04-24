using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceBunnyJump.Classes
{
    public class Bullet
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point position { get; set; }
        public System.Windows.Rect hitbox { get; set; }

        public bool flyOut { get; set; }


        public Bullet(Point position)
        {
            this.Width = 15;
            this.Height = 30;
            this.position = position;
            flyOut = false;

        }
        public void Move()
        {
            //hitbox = new System.Windows.Rect(position.Y - 30, position.X - 30, 60, 90);
        }
    }
}
