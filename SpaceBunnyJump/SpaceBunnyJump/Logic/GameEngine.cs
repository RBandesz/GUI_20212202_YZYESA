using SpaceBunnyJump.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Logic
{
    public class GameEngine
    {
        GameLogic logic = new GameLogic();
        PlayerMovement playerMovement = new PlayerMovement();
        Player player = new Player();
        public void GameRunner()
        {
            logic.Jump(playerMovement.Jump);
            logic.Gravity();
        }

        public void Start()
        {
            playerMovement.Jump = false;
            // set game over to false
            player.Alive = true;
            // set score to 0
            player.Score = 0;
            // set the score text to the score integer

        }
    }
}
