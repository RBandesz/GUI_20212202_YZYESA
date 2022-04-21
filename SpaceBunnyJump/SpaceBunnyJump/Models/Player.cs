using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBunnyJump.Models
{
    public class Player : ObservableObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Alive { get; set; }

        private int ammunition;
        public int Ammunition
        {
            get { return ammunition; }
            set { SetProperty(ref ammunition, value); }
        }

        private int score;
        public int Score
        {
            get { return score; }
            set { SetProperty(ref score, value); }
        }

        private int xposition;
        public int xPosition
        {
            get { return xposition; }
            set { SetProperty(ref xposition, value); }
        }

        private int yposition;
        public int yPositon
        {
            get { return yposition; }
            set { SetProperty(ref yposition, value); }
        }

        //public Player()
        //{
        //    this.Height = 100;
        //    this.Width = 60;
        //    this.Alive = true;
        //    this.Ammunition = 5;
        //    this.Score = 0;
        //    this.xPosition = 250;
        //    this.yPositon= 100;
        //}
    }
}
