using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Logic
{
    internal interface IGameModel
    {
        event EventHandler Changed;
    }
}
