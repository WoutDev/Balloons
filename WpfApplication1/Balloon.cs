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
    class Balloon
    {
        // First we define the PRIVATE parts of the Balloon.

        private int x = 10;
        private int y = 10;
        private int diameter = 10;
        private String text;

        const int growAmount = 10;
        const int moveAmount = 10;

        Ellipse ellipse = new Ellipse();
        TextBlock block;
        Brush bgBrush = new LinearGradientBrush(Colors.Red, Colors.Pink, 90);
        Brush strokeBrush = Brushes.Red;

        /*
         * This method uses the class variables x, y and diameter
         * to update the WPF-controls included in this class.
         */
        private void UpdateBalloon()
        {
            ellipse.Width = diameter;
            ellipse.Height = diameter;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Stroke = strokeBrush;
            ellipse.Fill = bgBrush;
        }


        // BELOW this point, you will find the PUBLIC interface to the Balloon

        /*
         * This constructor uses another constructor to specify default values for
         * height and xpos.
         */ 
        public Balloon(Canvas canvas, int diameter) : this(canvas, diameter, 10, 10)
        { }

        /*
         * This constructor allows choosing the diameter, height and xpos of the balloon
         */ 
        public Balloon(Canvas canvas, int diameter, int height, int xpos)
        {
            this.diameter = diameter;
            x = xpos;
            y = height;
            
            ellipse.Width = diameter;
            ellipse.Height = diameter;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Stroke = new SolidColorBrush(Colors.Red);

            text = "Happy Birthday";
            
            block = new TextBlock();
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.TextAlignment = TextAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            updateBlock();
            ellipse.Fill = bgBrush;
            UpdateBalloon();
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
            diameter += growAmount;
            ellipse.Width = diameter;
            ellipse.Height = diameter;
        }

        public void Move()
        {
            y -= moveAmount;
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

        public Brush Background
        {
            get
            {
                return bgBrush;
            }
            set
            {
                bgBrush = value;
                UpdateBalloon();
            }
        }
    }
}
