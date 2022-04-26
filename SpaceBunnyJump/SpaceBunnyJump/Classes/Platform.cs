using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace SpaceBunnyJump.Classes
{
    public class Platform
    {
        public Transform transform;
        public int sizeX;
        public int sizeY;
        //public bool isTouchedByPlayer;

        public bool visible { get; set; }

        public enum BonusItem 
        {
            alien, carrot, nothing
        } 

        public BonusItem bonus { get; set; }

        public bool containAlien { get; set; }
        public System.Windows.Rect hitbox { get; set; }

        public Platform(Point pos)
        {
            sizeX = 60;
            sizeY = 12;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            //isTouchedByPlayer = false;
            this.hitbox = new System.Windows.Rect(transform.position.Y - 55, transform.position.X - 6, 110, 12);
            bonus = BonusItem.nothing;
            visible = true;

        }
        public void Move()
        {
            this.hitbox = new System.Windows.Rect(transform.position.Y - 55, transform.position.X - 6, 110, 12);
        }

    }
}



