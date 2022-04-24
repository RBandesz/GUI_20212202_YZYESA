using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SpaceBunnyJump.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpaceBunnyJump.Classes;
using System.Drawing;
using Point = System.Drawing.Point;

namespace SpaceBunnyJump.Logic
{
    internal class GameLogic : IGameModel, IGameControl
    {
        public event EventHandler Changed;
        public event EventHandler GameOver;

        public System.Collections.Generic.List<Platform> Platforms { get; set; }

        public System.Collections.Generic.List<Bullet> Shots { get; set; }

        public System.Collections.Generic.List<Alien> Aliens { get; set; }

        public System.Windows.Size area { get; set; }
        //public System.Drawing.Rectangle playerHitbox { get; set; }


        public Player player { get; set; }


        public GameLogic()
        {
            VisualMap = new GameItems[800, 500];
            LogicMap = new GameItems[800, 500];
            //VisualMap = TestMapMaker(VisualMap, LogicMap);
            Platforms = new List<Platform>();
            Shots = new List<Bullet>();
            Aliens = new List<Alien>();
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            PlatformController.startPlatformPosY = 400;
            PlatformController.score = 0;
            PlatformController.GenerateStartSequence();
            Platforms = PlatformController.platforms;
            platformExtra();

            this.player = new Player();

        }
        public void TimeUpdate()
        {
            //player.physics.ApplyPhysics
            int[] coords = new int[] { ((int)player.position.Y), ((int)player.position.X), };
            int i = coords[0];
            int j = coords[1];
            if (j < 750 && !PlatformHitbox())
            {
                j = j + 5;
            }

            player.position = new Point(j, i);
            player.Move();

            BulletTravel();
            BulletFlyOut();

            Changed?.Invoke(this, null);
        }
        public bool PlatformHitbox()
        {
            bool platformstatus = false;
            int i = 0;
            while (platformstatus == false && i < Platforms.Count)
            {
                if (
                    player.hitbox.IntersectsWith(Platforms[i].hitbox) &&
                    //player.hitbox.Bottom == Platforms[i].hitbox.Top
                    player.hitbox.BottomLeft.Y < Platforms[i].hitbox.BottomLeft.Y     
                    )
                {
                    platformstatus = true;
                }
                else
                {
                    platformstatus = false;
                }
                i++;
                
            }
            return platformstatus;
        }

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;

 
        }
        public enum GameItems
        {
            player, platform, enemy, bonus, air
        }


        public enum Directions
        {
            left, right, space//jump
        }
        


        public int force = 20;
        public int grav = 5;
        public GameItems[,] VisualMap { get; set; }
        public GameItems[,] LogicMap { get; set; }

        public void HorizontalMove(Directions direction)
        {
            int[] coords = new int[] { ((int)player.position.Y), ((int)player.position.X), };
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            switch (direction)
            {
                //case Directions.jump:
                //    if (j - 1 >= 0)
                //    {
                //        j = j - 80;
                //    }
                //    break;
                case Directions.left:
                    if (i - 40 >= 0)
                    {
                        i = i - 40;
                    }
                    else
                    {
                        i = i - 40;
                        i = (int)area.Width + i;
                    }
                    break;
                case Directions.right:
                    if (i + 40 < area.Width)
                    {
                        i = i + 40;
                    }
                    else
                    {
                        i = i + 40;
                        i = i - (int)area.Width;
                    }
                    break;
                default:
                    break;
            }
            player.position = new Point(j, i);
            player.Move();

            //if (VisualMap[i, j] == GameItems.air)
            //{
            //    VisualMap[i, j] = GameItems.player;
            //    VisualMap[old_i, old_j] = GameItems.air;
            //}
        }


        public void Jump(bool jump)
        {
            //var coords = WhereAmI();
            int[] coords = new int[] { ((int)player.position.Y), ((int)player.position.X), };
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            force = 15;
            grav = -12;
            if (PlatformHitbox())
            {
                if (jump && j - 80 >= 0)
                {
                    j = j - 160;

                }

                player.position = new Point(j, i);
                player.Move();
            }
        }


        public void PlatformPositions()
        {

        }

        public void Shoot(bool shoot)
        {
            if (player.Ammo > 0)
            {
                
                Shots.Add(new Bullet(player.position));
                player.Ammo = player.Ammo - 1;

            }
        }
        public void BulletTravel()
        {
            foreach (var item in Shots)
            {
                int shotlocation = item.position.X;
                if (shotlocation > 0)
                {
                    shotlocation = shotlocation - 10;
                    item.position = new Point(shotlocation, item.position.Y);
                    item.Move();
                }
                else
                {
                    item.flyOut = true;
                }

            }
        }
        public void BulletFlyOut()
        {
            for (int i = Shots.Count - 1; i >= 0; i--)
            {
                if (Shots[i].flyOut)
                    Shots.RemoveAt(i);
            }
        }

        public void platformExtra()
        {
            foreach (var item in Platforms)
            {
                if (item.containAlien)
                {
                    Aliens.Add(new Alien(new Point(item.transform.position.X - 100, item.transform.position.Y- 40)));
                }
            }
        }
    }
}
