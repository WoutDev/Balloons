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

        Ellipse ellipse = new Ellipse();
       
        static Random rndGen = new Random();

        public Balloon(Canvas canvas) : this(canvas, rndGen.Next(10, 30)) { }

        public Balloon(Canvas canvas, int diameter) : this(canvas, diameter, rndGen.Next(10, 300), rndGen.Next(10, 200)) {}

        public Balloon(Canvas canvas, int diameter, int height) : this(canvas, diameter, height, rndGen.Next(10, 200)) {}

        public Balloon(Canvas canvas, int diameter, int height, int xpos)
        {
            this.diameter = diameter;
            x = xpos;
            y = height;

            ellipse.Width = diameter;
            ellipse.Height = diameter;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Stroke = new SolidColorBrush(Colors.Red);
            canvas.Children.Add(ellipse);
        }

        public void Grow()
        {
            diameter += 10;
            ellipse.Width = diameter;
            ellipse.Height = diameter;
        }

        public void Move()
        {
            y -= 10;
            ellipse.Margin = new Thickness(x, y, 0, 0);
        }
    }
}
