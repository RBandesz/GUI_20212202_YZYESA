using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Logic
{
    internal class GameLogic : IGameModel
    {
        public event EventHandler Changed;
        public event EventHandler GameOver;

        System.Windows.Size area;

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
        public GameLogic()
        {
            GameMap = new GameItems[500, 800];
            GameMap = TestMapMaker(GameMap);

        }
    }
}
