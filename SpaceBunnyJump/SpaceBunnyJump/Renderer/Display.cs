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
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Textures", "background.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model != null && size.Width > 50 && size.Height > 50)
            {
                drawingContext.DrawRectangle(SpaceBrush, null, new Rect(0, 0, size.Width, size.Height));

                //drawingContext.Pop();
            }
        }

    }
}
