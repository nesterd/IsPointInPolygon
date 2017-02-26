using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Figures
{
    public class CrossPoint
    {
        double _x;
        double _y;

        public CrossPoint(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X { get { return _x; }}
        public double Y { get { return _y; }}

        public bool IsEqual(Point point)
        {
            return _x == point.X && _y == point.Y;
        }

        public override string ToString()
        {
            return $"({_x}, {_y})";
        }
    }
}
