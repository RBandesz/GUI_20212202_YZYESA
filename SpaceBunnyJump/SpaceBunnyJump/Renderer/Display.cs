using SpaceBunnyJump.Classes;
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

        Size size; //= new Size(800, 500);
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
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model != null && size.Width > 50 && size.Height > 50)
            {
                double rectWidth = size.Width / model.VisualMap.GetLength(1);
                double rectHeight = size.Height / model.VisualMap.GetLength(0);

                drawingContext.DrawRectangle(SpaceBrush, null, new Rect(0, 0, size.Width, size.Height));
                //drawingContext.DrawRectangle(Alien, null, new Rect(400, 600, 60, 100));
                //drawingContext.DrawRectangle(Platform, null, new Rect(0, 120, 80, 30));
                //drawingContext.DrawRectangle(Player, null, new Rect(0, 120, 60, 100));

                for (int i = 0; i < model.VisualMap.GetLength(0); i++)
                {
                    for (int j = 0; j < model.VisualMap.GetLength(1); j++)
                    {
                        ImageBrush brush = new ImageBrush();
                        switch (model.VisualMap[i, j])
                        {
                            case GameLogic.GameItems.platform:
                                drawingContext.DrawRectangle(Platform, null, new Rect(j, i, 80, 30));
                                break;
                            case GameLogic.GameItems.player:
                                drawingContext.DrawRectangle(Player, null, new Rect(j, i, 60, 100));
                                break;
                        }

                        
                    }
                }



                //drawingContext.Pop();

            }
        }

    }
}
