using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace WpfApplication1
{
    // ENCAPSULATIE

    class Balloon
    {
        private int x = 10;
        private int y = 10;
        private int diameter = 10;
        private String text;

        Ellipse ellipse = new Ellipse();
        TextBlock block;

        public Balloon(Canvas canvas) : this(canvas, 10) { }

        public Balloon(Canvas canvas, int diameter) : this(canvas, diameter, 50) {}

        public Balloon(Canvas canvas, int diameter, int height) : this(canvas, diameter, height, 50) {}

        public Balloon(Canvas canvas, int diameter, int height, int xpos)
        {
            this.diameter = diameter;
            x = xpos;
            y = height;

            ellipse.Width = diameter;
            ellipse.Height = diameter;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Stroke = new SolidColorBrush(Colors.Red);
            ellipse.Fill = new SolidColorBrush(Colors.Aqua);

            text = "Happy Birthday";

            block = new TextBlock();
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.TextAlignment = TextAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            updateBlock();

            canvas.Children.Add(ellipse);
            canvas.Children.Add(block);
        }

        private void updateBlock()
        {
            block.Text = Text;
            block.Margin = ellipse.Margin;
        }

        public void Grow()
        {
            diameter += 10;
            block.FontSize += 2.50;
            ellipse.Width = diameter;
            ellipse.Height = diameter;
        }

        public void Move()
        {
            y -= 10;
            ellipse.Margin = new Thickness(x, y, 0, 0);

            updateBlock();
        }

        public String Text
        {
            get
            {
                return text;
            }
            set
            {
                this.text = value;
                updateBlock();
            }
        }
    }
}
