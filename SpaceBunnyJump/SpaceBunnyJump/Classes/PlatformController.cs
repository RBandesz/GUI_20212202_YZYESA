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

        public static void AddPlatform(Point position)
        {
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }

        public static void GenerateStartSequence()
        {
            Point position1 = new Point(700, 250);
            Platform platform1 = new Platform(position1);
            platforms.Add(platform1);
            Random r = new Random();
            int x = 650;
            for (int i = 0; i < 9; i++)
            {
                Point position = new Point(x, r.Next(5, 420));
                Platform platform = new Platform(position);

                if (i == 5)
                {
                    platform.bonus = Platform.BonusItem.alien;
                }
                if (i == 3)
                {
                    platform.bonus = Platform.BonusItem.carrot;
                }

                platforms.Add(platform);

                x = x - 80;
            }

            //Random r = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    int x = r.Next(100, 900);
            //    int y = r.Next(100, 500);
            //    startPlatformPosY -= y;
            //    Point position = new Point(x, startPlatformPosY);
            //    Platform platform = new Platform(position);
            //    platforms.Add(platform);
            //}
        }


    }
}
