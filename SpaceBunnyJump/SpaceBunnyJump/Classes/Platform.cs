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

        public Platform(PointF pos)
        {
            platform = Image.FromFile("Textures/platform.png");
            Xsize = 60;
            Ysize = 12;
            transform = new Transform(pos, new Size(Xsize, Ysize));
            isTouchedByPlayer = false;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(platform, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }
}
