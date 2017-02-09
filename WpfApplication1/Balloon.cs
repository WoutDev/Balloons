﻿using System;
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
        Brush strokeBrush = Brushes.Red;
        Brush bgBrush = new LinearGradientBrush(Colors.Red, Colors.Pink, 90);

        public Balloon(Canvas canvas, int diameter)
        {
            this.diameter = diameter;

            UpdateBalloon(canvas);
        }

        public Balloon(Canvas canvas, int diameter, int height, int xpos)
        {
            this.diameter = diameter;
            x = xpos;
            y = height;

            UpdateBalloon(canvas);
        }
        
        /*
         * This method uses the class variables x, y and diameter
         * to update the WPF-controls included in this class.
         */
        void UpdateBalloon(Canvas canvas)
        {
            ellipse.Width = diameter;
            ellipse.Height = diameter;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Stroke = strokeBrush;
            ellipse.Fill = bgBrush;
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
