using SpaceBunnyJump.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Classes
{
    public class Physics
    {
        public Transform transform;
        float gravity;
        float a;

        public float dx;
        bool usedBonus = false;

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            a = 0.4f;
            dx = 0;
        }

        public void ApplyPhysics()
        {
            CalculatePhysics();
        }

        public void CalculatePhysics()
        {
            bool onPlatform = false;
            if (onPlatform = false)
            {
                transform.position.Y = transform.position.Y - 1;
            }

        }



    }
}
