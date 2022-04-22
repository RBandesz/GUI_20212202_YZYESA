using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpaceBunnyJump.Logic.GameLogic;

namespace SpaceBunnyJump.Logic
{
    internal interface IGameControl
    {
        void HorizontalMove(Directions directions);
        void Jump(bool jump);
        void Shoot(bool shoot);
    }
}
