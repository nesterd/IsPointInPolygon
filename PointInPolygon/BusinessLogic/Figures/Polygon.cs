
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Figures
{
    public class Polygon
    {
        IEnumerable<Point> _vertices;
        IEnumerable<Line> _edges;

        public IEnumerable<Point> Vertices { get { return _vertices; } }

        public Polygon(IEnumerable<Point> vertices)
        {
            _vertices = vertices;
            _edges = EdgesInitializer(vertices);
        }

        IEnumerable<Line> EdgesInitializer(IEnumerable<Point> vertices)
        {
            var edges = new List<Line>();

            for (int i = 0; i < vertices.Count(); i++)
            {
                var j = (i == vertices.Count() - 1) ? 0 : i + 1;//замыкает последнюю точку на первую
                edges.Add(new Line((vertices as List<Point>)[i], (vertices as List<Point>)[j]));
            }

            return edges;
        }

        public bool IsPointInPolygon(Point point)
        {
            if (point == null)
                return false;
            if (IsPointInOneOfEdges(point))
                return true;
            
            Line ray = GetRayFromPoint(point);

            return GetCrossCount(ray) % 2 != 0;
        }

        // Метод считает пересечения луча и ребер полигона(при возникновении случаев неопределенности, таких как пересечение с вершиной фигуры или 
        // если луч лежит на одной прямой с ребром полигона, происходит изменение направления луча( координата "y" конечной точки +10) и проверяется еще раз.
        int GetCrossCount(Line ray)
        {
            bool error = true;
            int crossCount = 0;
            CrossPoint crossPoint;
            while (error)
            {
                error = false;
                crossCount = 0;

                foreach (var edge in _edges)
                {
                    if (ray.IsEqual(edge))//условие неопределенности если луч и ребро лежат на одной прямой
                    {
                        error = true;
                        ray.Change();
                        break;
                    }
                    if (ray.IsCrossedByLine(edge, out crossPoint))
                    {
                        if (_vertices.Any(point => crossPoint.IsEqual(point)))//условие неопределенности если пересечение происходит с вершиной полигона
                        {
                            error = true;
                            ray.Change();
                            break;
                        }
                        crossCount++;
                    }
                }
            }
            return crossCount;
        }

        //метод возвращающий Луч, направленный из исследуемой точки вдоль оси X в положительном направлении
        Line GetRayFromPoint(Point point)
        {
            return new Line(point, new Point { X = 1000, Y = point.Y });
        }
        
        bool IsPointInOneOfEdges(Point point)
        {
            foreach (var edge in _edges)
            {
                if (edge.IsPointInLine(point))
                    return true;
            }
            return false;
        }
    }
}
