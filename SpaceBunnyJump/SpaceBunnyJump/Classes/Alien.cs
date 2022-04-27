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

        public bool Alive { get; set; }

        public bool Moving { get; set; }
        public bool Side { get; set; }

        Random r = new Random();

        public Alien(Point position)
        {
            this.Width = 120;
            this.Height = 100;
            this.position = position;
            hitbox = new System.Windows.Rect(position.Y + 5, position.X + 5, 60, 90);
            this.Alive = true;
            ;
            if (r.Next(0,11) > 7)
            {
                this.Moving = true;
            }
            else
            {
                this.Moving = false;
            }
            this.Side = true;
        }

        public void Move()
        {
            hitbox = new System.Windows.Rect(position.Y + 5, position.X + 5, 60, 90);
        }

    }
}
