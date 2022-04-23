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

namespace SpaceBunnyJump.Logic
{
    internal class GameLogic : IGameModel, IGameControl
    {
        public event EventHandler Changed;
        public event EventHandler GameOver;

        public System.Collections.Generic.List<Platform> Platforms { get; set; }

        public System.Windows.Size area { get; set; }
        public System.Drawing.Rectangle playerHitbox { get; set; }

        public Player player { get; set; }


        public GameLogic()
        {
            VisualMap = new GameItems[800, 500];
            LogicMap = new GameItems[800, 500];
            //VisualMap = TestMapMaker(VisualMap, LogicMap);
            Platforms = new List<Platform>();
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            PlatformController.startPlatformPosY = 400;
            PlatformController.score = 0;
            PlatformController.GenerateStartSequence();
            Platforms = PlatformController.platforms;


            this.player = new Player();

        }
        public void Gravity()
        {
            //player.physics.ApplyPhysics

            int[] coords = new int[] { ((int)player.position.Y), ((int)player.position.X), };
            int i = coords[0];
            int j = coords[1];
            
            if (j < 750)
            {
                j = j + 1;
            }

            
            player.position = new PointF(j, i);

            Changed?.Invoke(this, null);
        }
        public void Hitbox()
        {
            System.Drawing.Rectangle playerHitbox = new System.Drawing.Rectangle();

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
            left, right, //jump
        }
        


        public int force = 20;
        public int grav = 5;
        public GameItems[,] VisualMap { get; set; }
        public GameItems[,] LogicMap { get; set; }

        //private GameItems[,] TestMapMaker(GameItems[,] VisualMap, GameItems[,] LogicMap)
        //{
        //    for (int i = 0; i < VisualMap.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < VisualMap.GetLength(1); j++)
        //        {
        //            if (i % 250 == 0 && j % 250 == 0)
        //            {
        //                VisualMap[i, j] = GameItems.platform;
        //            }
        //            else if (i == 400 && j == 250)
        //            {
        //                VisualMap[i, j] = GameItems.player;
        //            }
        //            else
        //            {
        //                VisualMap[i, j] = GameItems.air;
        //            }
        //        }
        //    }
        //    return VisualMap;
        //}
        //private int[] WhereAmI()
        //{
        //    for (int i = 0; i < VisualMap.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < VisualMap.GetLength(1); j++)
        //        {
        //            if (VisualMap[i, j] == GameItems.player)
        //            {
        //                return new int[] { i, j };
        //            }
        //        }
        //    }
        //    return new int[] { -1, -1 };
        //}

        public void HorizontalMove(Directions direction)
        {
            //var coords = WhereAmI();
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
                    break;
                case Directions.right:
                    if (i + 40 < LogicMap.GetLength(1))
                    {
                        i = i + 40;
                    }
                    break;
                default:
                    break;
            }
            player.position = new PointF(j, i);

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

            if (jump && j - 80 >= 0)
            {
                //j = j - 80;
                //force--;
                //if (force < 0)
                //{
                //    jump = false;
                //}
                for (int a = 0; a < 10; a++)
                {
                    j = j - 4;
                }

            }
            if (jump)
            {
                grav = -9;
                force--;
            }
            else
            {
                grav = 12;
            }

            // if force is less than 0 
            if (force < 0)
            {
                // set jumping boolean to false
                jump = false;
            }
            //if (VisualMap[i, j] == GameItems.air)
            //{
            //    VisualMap[i, j] = GameItems.player;
            //    VisualMap[old_i, old_j] = GameItems.air;
            //}
            player.position = new PointF(j, i);
        }
        

        public void PlatformPositions()
        {

        }

        public void Shoot(bool shoot)
        {
            throw new NotImplementedException();
        }
    }
}
