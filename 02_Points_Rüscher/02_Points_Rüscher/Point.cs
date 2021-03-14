using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Points_Rüscher
{
    public class Point
    {
        //fields
        int x = 0;
        int y = 0;

        //properties
        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }

        //Methoden
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "x: " + x + " y: " + y;
        }

        public double DistanceToPoint(Point other)
        {
            int a = other.x - this.x;
            int b = other.y - this.y;

            double c = Math.Sqrt(a * a + b * b);
            return c;
        }
    }
}
