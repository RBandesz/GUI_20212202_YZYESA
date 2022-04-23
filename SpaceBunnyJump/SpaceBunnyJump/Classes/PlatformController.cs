using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Classes
{
    public static class PlatformController
    {
        public static List<Platform> platforms;
        public static int startPlatformPosY = 400;
        public static int score = 0;

        public static void AddPlatform(PointF position)
        {
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }

        public static void GenerateStartSequence()
        {
            PointF position1 = new PointF(700, 250);
            Platform platform1 = new Platform(position1);
            platforms.Add(platform1);
            Random r = new Random();
            int x = 650;
            for (int i = 0; i < 9; i++)
            {
                PointF position = new PointF(x, r.Next(5, 420));
                Platform platform = new Platform(position);
                platforms.Add(platform);
                x = x - 80;
            }

            //Random r = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    int x = r.Next(100, 900);
            //    int y = r.Next(100, 500);
            //    startPlatformPosY -= y;
            //    PointF position = new PointF(x, startPlatformPosY);
            //    Platform platform = new Platform(position);
            //    platforms.Add(platform);
            //}
        }


    }
}
