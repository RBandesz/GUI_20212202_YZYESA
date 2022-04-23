using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Classes
{
    public class Transform
    {
        public Point position;
        public Size size;

        public Transform(Point position, Size size)
        {
            this.position = position;
            this.size = size;
        }
    }
}
