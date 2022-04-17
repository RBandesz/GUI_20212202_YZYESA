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
        Image platform;
        public Transform transform;
        public int Xsize;
        public int Ysize;
        public bool isTouchedByPlayer;

        public Platform(PointF position)
        {
            platform = Image.FromFile("Textures/platform.png");
            Xsize = 60;
            Ysize = 12;
            transform = new Transform(position, new Size(Xsize, Ysize));
            isTouchedByPlayer = false;
        }

        public void DrawSprite(Graphics graphics)
        {
            graphics.DrawImage(platform, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }
}
