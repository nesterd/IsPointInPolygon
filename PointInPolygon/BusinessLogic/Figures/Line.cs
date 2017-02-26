using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Figures
{
    public class Line
    {
        Point _pointStart;
        Point _pointEnd;

        //Уравнение прямой: A * x + B * y + C = 0;
        double a;
        double b;
        double c;

        public double A { get { return a; } }
        public double B { get { return b; } }
        public double C { get { return c; } }


        public Line(Point pointStart, Point pointEnd)
        {
            _pointStart = pointStart;
            _pointEnd = pointEnd;

            CalcСoefficients();
        }

        void CalcСoefficients()
        {
            // A = y1 - y2
            // B = x2 - x1
            // C = x1*y2 - x2*y1
            a = _pointStart.Y - _pointEnd.Y;
            b = _pointEnd.X - _pointStart.X;
            c = _pointStart.X * _pointEnd.Y - _pointEnd.X * _pointStart.Y;

            //приведение коэффициентов
            double min;
            min = a != 0 ? Math.Abs(a) : Math.Abs(b);
            if (Math.Abs(b) < min && b != 0)
                min = b;
            if (Math.Abs(c) < min && c != 0)
                min = c;
            a = a / min;
            b = b / min;
            c = c / min;
        }

        public bool IsCrossedByLine(Line line, out CrossPoint crossPoint)
        {
            crossPoint = null;
            if (IsParallelWithLine(line))
                return false;

            crossPoint = GetCrossPointWithLine(line);

            return IsCrossPointInLine(crossPoint) && line.IsCrossPointInLine(crossPoint);
        }

        CrossPoint GetCrossPointWithLine(Line line)
        {
            double x = (line.b * c - line.c * b) / (b * line.a - line.b * a);
            double y = -(c + a * x) / b;

            return new CrossPoint(x, y);
        }

        bool IsParallelWithLine(Line line)
        {
            return a * line.b == b * line.a; 
        }

        bool IsCrossPointInLineOX(CrossPoint crossPoint)
        {
            return crossPoint.X <= _pointStart.X && crossPoint.X >= _pointEnd.X || crossPoint.X >= _pointStart.X && crossPoint.X <= _pointEnd.X;
        }

        bool IsCrossPointInLineOY(CrossPoint crossPoint)
        {
            return crossPoint.Y <= _pointStart.Y && crossPoint.Y >= _pointEnd.Y || crossPoint.Y >= _pointStart.Y && crossPoint.Y <= _pointEnd.Y;
        }

        bool IsCrossPointInLine(CrossPoint crossPoint)
        {
            return IsCrossPointInLineOX(crossPoint) && IsCrossPointInLineOY(crossPoint);
        }
          
        public bool IsEqual(Line line)
        {
            return a == line.a && b == line.b && c == line.c;
        }

        //метод изменяет угол луча исходящего из исследуемой точки, при случае неопределенности
        public void Change()
        {
            _pointEnd.Y += 10;
            CalcСoefficients();
        }

        public bool IsPointInLine(Point point)
        {
            var x = point.X;
            var y = point.Y;

            return x * a + y * b + c == 0 && IsCrossPointInLine(new CrossPoint(x, y));
        }
    }
}
 
