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
        //public static int startPlatformPosY = 400;
        //public static int score = 0;

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
                Point position = new Point(x, r.Next(30, 450));
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

                x = x - r.Next(60,80);
            }

            
        }

        public static Platform GenerateRandomPlatform(int lastPlatPos)
        {
            Random r = new Random();
            Platform platform;      
            lastPlatPos -= r.Next(60, 80);
            Point position = new Point(lastPlatPos, r.Next(30, 450));
            platform = new Platform(position);
            int random = r.Next(0, 101);
            if (random > 95 )
            {
                platform.bonus = Platform.BonusItem.alien;
            }
            else if (random > 70 && random < 76)
            {
                platform.bonus = Platform.BonusItem.carrot;
            }
            else if (random > 75 && random < 81)
            {
                platform.bonus = Platform.BonusItem.diamond;
            }
            else if (random > 80 && random < 86)
            {
                platform.bonus = Platform.BonusItem.shield;
            }
            else if (random > 85 && random < 91)
            {
                platform.bonus = Platform.BonusItem.shoe;
            }

            return platform;
        }


    }
}
