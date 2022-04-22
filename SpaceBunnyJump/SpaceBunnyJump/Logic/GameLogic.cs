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


namespace SpaceBunnyJump.Logic
{
    internal class GameLogic : IGameModel, IGameControl
    {
        public event EventHandler Changed;
        public event EventHandler GameOver;


        System.Windows.Size area;

        public GameLogic()
        {
            VisualMap = new GameItems[500, 800];
            LogicMap = new GameItems[500, 800];
            VisualMap = TestMapMaker(VisualMap, LogicMap);

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


        private GameItems[,] TestMapMaker(GameItems[,] GameMap, GameItems[,] MapMatrix)
        {
            int counter = 0;
            for (int i = 0; i < GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < GameMap.GetLength(1); j++)
                {
                    if (i % 250 == 0 && j % 250 == 0)
                    {
                        GameMap[i, j] = GameItems.platform;
                        MapMatrix[i, j] = GameItems.platform;
                    }
                    else if (i == 250 && j == 600)
                    {
                        GameMap[i, j] = GameItems.player;
                        MapMatrix[i, j] = GameItems.player;
                    }
                    else
                    {
                        GameMap[i, j] = GameItems.air;
                    }
                }
            }
            return GameMap;
        }
        private int[] WhereAmI()
        {
            for (int i = 0; i < VisualMap.GetLength(0); i++)
            {
                for (int j = 0; j < VisualMap.GetLength(1); j++)
                {
                    if (VisualMap[i, j] == GameItems.player)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }

        public void HorizontalMove(Directions direction)
        {
            var coords = WhereAmI();
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
                    if (i - 1 >= 0)
                    {
                        i = i - 40;
                    }
                    break;
                case Directions.right:
                    if (i + 1 < LogicMap.GetLength(1))
                    {
                        i = i + 40;
                    }
                    break;
                default:
                    break;
            }

            if (VisualMap[i, j] == GameItems.air)
            {
                VisualMap[i, j] = GameItems.player;
                VisualMap[old_i, old_j] = GameItems.air;
            }
        }

        public void Jump(bool jump)
        {
            var coords = WhereAmI();
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            force = 15;
            grav = -12;

            if (jump && j - 80 >= 0)
            {
                j = j - 80;
                force--;
                if (force < 0)
                {
                    jump = false;
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
            if (VisualMap[i, j] == GameItems.air)
            {
                VisualMap[i, j] = GameItems.player;
                VisualMap[old_i, old_j] = GameItems.air;
            }
        }

        

        public void Shoot(bool shoot)
        {
            throw new NotImplementedException();
        }
    }
}
