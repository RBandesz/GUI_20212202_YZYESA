using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Classes
{
    class Diamond
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Point position { get; set; }
        public System.Windows.Rect hitbox { get; set; }

        public bool Alive { get; set; }

        public Diamond(Point position)
        {
            this.Width = 20;
            this.Height = 20;
            this.position = position;
            hitbox = new System.Windows.Rect(position.Y-15, position.X-30, 30, 45);
            this.Alive = true;
        }

        public void Move()
        {
            hitbox = new System.Windows.Rect(position.Y - 15, position.X - 30, 30, 45);
        }
    }
}
