using SpaceBunnyJump.Classes;
using SpaceBunnyJump.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static SpaceBunnyJump.Logic.GameLogic;

namespace SpaceBunnyJump.Logic
{
    internal interface IGameModel
    {
        event EventHandler Changed;
        public System.Collections.Generic.List<Platform> Platforms { get; set; }

        public System.Collections.Generic.List<Bullet> Shots { get; set; }

        public System.Collections.Generic.List<Alien> Aliens { get; set; }
        public System.Collections.Generic.List<Carrot> Carrots { get; set; }


        public Size area { get; set; }

        public Player player { get; set; }

    }
}
