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
        //public System.Drawing.Point Center { get; set; }

        //public System.Drawing.Size platformSize { get; set; }


        //public Platform()
        //{
        //    platformSize = new System.Drawing.Size(80, 30);
        //}

        public Transform transform;
        public int sizeX;
        public int sizeY;
        public bool isTouchedByPlayer;
        public System.Drawing.Rectangle hitbox;

        public Platform(PointF pos)
        {
            sizeX = 60;
            sizeY = 12;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            isTouchedByPlayer = false;

        }



    }
}



