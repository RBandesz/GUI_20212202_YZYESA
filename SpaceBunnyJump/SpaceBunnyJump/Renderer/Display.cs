﻿using SpaceBunnyJump.Classes;
using SpaceBunnyJump.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpaceBunnyJump.Renderer
{
    internal class Display : FrameworkElement
    {

        Size size; 
        IGameModel model;
        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }
        public void SetupSizes(Size area)
        {
            this.size = area;
            this.InvalidateVisual();
        }
        public Brush SpaceBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "background.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Player
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "player.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Platform
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "platform.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Alien
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "alien.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Bullet
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "bullet.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush HitboxTest
        {
            get
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            }
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model != null && size.Width > 50 && size.Height > 50)
            {
                double rectWidth = size.Width / model.VisualMap.GetLength(1);
                double rectHeight = size.Height / model.VisualMap.GetLength(0);

                drawingContext.DrawRectangle(SpaceBrush, null, new Rect(0, 0, size.Width, size.Height));
                drawingContext.DrawEllipse(Bullet, null, new Point(100, 150), 15, 30);
                //drawingContext.DrawRectangle(Alien, null, new Rect(400, 600, 60, 100));
                //drawingContext.DrawRectangle(Platform, null, new Rect(0, 120, 80, 30));
                //drawingContext.DrawRectangle(Player, null, new Rect(0, 120, 60, 100));

                foreach (var item in model.Platforms)
                {
                    drawingContext.DrawEllipse(Platform, null, new Point(item.transform.position.Y, item.transform.position.X), item.sizeX, item.sizeY);
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }

                foreach (var item in model.Shots)
                {
                    drawingContext.DrawEllipse(Bullet, null, new Point(item.position.Y, item.position.X), item.Width, item.Height);
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }
                //drawingContext.DrawRectangle(HitboxTest, null, model.player.hitbox); //hitbox teszt
                drawingContext.DrawEllipse(Player, null, new Point(model.player.position.Y, model.player.position.X), model.player.Width, model.player.Height);
                

                //drawingContext.Pop();

            }
        }

    }
}
