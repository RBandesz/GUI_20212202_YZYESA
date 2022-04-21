using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBunnyJump.Models;

namespace SpaceBunnyJump.Logic
{
    internal  class GameLogic : IGameModel
    {
        public event EventHandler Changed;
        public event EventHandler GameOver;
        Player players = new Player();
        
        System.Windows.Size area;

        public GameLogic()
        {
            GameMap = new GameItems[500, 800];
            MapMatrix = new GameItems[500, 800];
            GameMap = TestMapMaker(GameMap, MapMatrix);

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
            jump, left, right
        }
        public GameItems[,] GameMap { get; set; }
        public GameItems[,] MapMatrix { get; set; }


        private GameItems[,] TestMapMaker(GameItems[,] GameMap, GameItems[,] MapMatrix)
        {
            for (int i = 0; i < GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < GameMap.GetLength(1); j++)
                {
                    if (i % 250 == 0 && j % 250 == 0)
                    {
                        GameMap[i, j] = GameItems.platform;
                        MapMatrix[i, j] = GameItems.platform;
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
            for (int i = 0; i < MapMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < MapMatrix.GetLength(1); j++)
                {
                    if (MapMatrix[i, j] == GameItems.player)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }
        public void Move(Directions direction)
        {
            var coords = WhereAmI();
            int i = coords[0];
            int j = coords[1];
            int old_i = i;
            int old_j = j;
            switch (direction)
            {
                case Directions.jump:
                    if (i - 1 >= 0)
                    {
                        i--;
                    }
                    break;
                case Directions.left:
                    if (j - 1 >= 0)
                    {
                        j--;
                    }
                    break;
                case Directions.right:
                    if (j + 1 < MapMatrix.GetLength(1))
                    {
                        j++;
                    }
                    break;
                default:
                    break;
            }
            //if (MapMatrix[i, j] == GameItems.platform)
            //{
            //    MapMatrix[i, j] = GameItems.player;
            //    MapMatrix[old_i, old_j] = GameItems.platform;
            //}
            //else if (MapMatrix[i, j] == GameItems.door)
            //{
            //    //todo level vége
            //    if (levels.Count > 0)
            //    {
            //        LoadNext(levels.Dequeue());
            //    }

            //}
        }
    }
}
