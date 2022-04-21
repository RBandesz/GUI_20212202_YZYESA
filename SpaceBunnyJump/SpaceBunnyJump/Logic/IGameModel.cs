using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpaceBunnyJump.Logic.GameLogic;

namespace SpaceBunnyJump.Logic
{
    internal interface IGameModel
    {
        GameItems[,] VisualMap { get; set; }
        event EventHandler Changed;
        void Move(Directions directions);
    }
}
