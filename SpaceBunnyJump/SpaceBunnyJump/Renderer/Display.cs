using SpaceBunnyJump.Classes;
using SpaceBunnyJump.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public Brush Carrot
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "carrot.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Diamond
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "diamond.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush Shield
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "shield.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush Shoe
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "shoe.png"), UriKind.RelativeOrAbsolute)));
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
                drawingContext.DrawRectangle(SpaceBrush, null, new Rect(0, 0, size.Width, size.Height));
                drawingContext.DrawRectangle(Carrot, null, new Rect(440, 0, 40, 40));
                //drawingContext.DrawRectangle(Alien, null, new Rect(100, 150, 120, 100));
                //drawingContext.DrawRectangle(Platform, null, new Rect(0, 120, 80, 30));
                //drawingContext.DrawRectangle(Player, null, new Rect(0, 120, 60, 100));

                foreach (var item in model.Platforms)
                {
                    drawingContext.DrawEllipse(Platform, null, new Point(item.transform.position.Y, item.transform.position.X), item.sizeX, item.sizeY);
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }
                foreach (var item in model.Aliens)
                {
                    drawingContext.DrawRectangle(Alien, null, new Rect(item.position.Y, item.position.X, item.Width, item.Height));
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }
                foreach (var item in model.Carrots)
                {
                    drawingContext.DrawRectangle(Carrot, null, new Rect(item.position.Y, item.position.X, item.Width, item.Height));
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }

                foreach (var item in model.Shots)
                {
                    drawingContext.DrawEllipse(Bullet, null, new Point(item.position.Y, item.position.X), item.Width, item.Height);
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }
                foreach (var item in model.Diamonds)
                {
                    drawingContext.DrawEllipse(Diamond, null, new Point(item.position.Y, item.position.X), item.Width, item.Height);
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }
                foreach (var item in model.Shields)
                {
                    drawingContext.DrawRectangle(Shield, null, new Rect(item.position.Y, item.position.X, item.Width, item.Height));
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }
                foreach (var item in model.Shoes)
                {
                    drawingContext.DrawRectangle(Shoe, null, new Rect(item.position.Y, item.position.X, item.Width, item.Height));
                    //drawingContext.DrawRectangle(HitboxTest, null, item.hitbox);//hitbox teszt
                }
                //drawingContext.DrawRectangle(HitboxTest, null, model.player.hitbox); //hitbox teszt
                drawingContext.DrawEllipse(Player, null, new Point(model.player.position.Y, model.player.position.X), model.player.Width, model.player.Height);

                //HUD
                if (model.player.Shield)
                {
                    drawingContext.DrawRectangle(Shield, null, new Rect(350, 0, 30, 30));
                }
                if (model.player.Shoe > 0)
                {
                    drawingContext.DrawRectangle(Shoe, null, new Rect(300, 0, 30, 30));
                }

                drawingContext.DrawRectangle(Carrot, null, new Rect(440, 0, 40, 40));
                drawingContext.DrawText(new FormattedText(Convert.ToString(model.player.Ammo),
                                CultureInfo.GetCultureInfo("en-us"),
                                FlowDirection.LeftToRight,
                                new Typeface("Verdana"),
                                36, System.Windows.Media.Brushes.Orange),
                                new System.Windows.Point(410, 0));

                drawingContext.DrawText(new FormattedText(Convert.ToString(model.player.Score),
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                36, System.Windows.Media.Brushes.White),
                new System.Windows.Point(0, 0));
                

            }
        }

    }
}
