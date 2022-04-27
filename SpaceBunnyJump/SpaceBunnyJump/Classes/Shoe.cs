using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Classes
{
    public class Shoe
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point position { get; set; }
        public System.Windows.Rect hitbox { get; set; }

        public bool Alive { get; set; }

        public Shoe(Point position)
        {
            this.Width = 55;
            this.Height = 55;
            this.position = position;
            hitbox = new System.Windows.Rect(position.Y + 5, position.X + 5, 30, 45);
            this.Alive = true;
        }

        public void Move()
        {
            hitbox = new System.Windows.Rect(position.Y + 5, position.X + 5, 30, 45);
        }
    }
}
