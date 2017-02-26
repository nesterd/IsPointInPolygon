using BusinessLogic.Figures;
using BusinessLogic.Helpers.Painters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PolygonService
    {
        //Реализация паттерна Singleton//
        private static PolygonService instance;
        private static object syncRoot = new Object();

        private PolygonService()
        {
            _random = new Random();
            _points = new List<Point>();
        }

        public static PolygonService GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new PolygonService();
                }
            }

            return instance;
        }
        //Реализация паттерна Singleton//


        int minNumberOfVertices = PolygonPainterSettings.MinNumberOfVertices;
        Polygon _polygon;
        Random _random;
        IEnumerable<Point> _points;
        
        public IEnumerable<Point> Points { get { return _points; } }

        //public PolygonService()
        //{
        //    _random = new Random();
        //    _points = new List<Point>();
        //}

        public void AddPoint(Point pointToAdd)
        {
            (_points as List<Point>).Add(pointToAdd);
        }

        public void DeletePoint()
        {
            if (_points.Count() > 0)
                (_points as List<Point>).RemoveAt(_points.Count() - 1);
        }

        public void ClearPoints()
        {
            (_points as List<Point>).Clear();
        }

        public IEnumerable<Point> GetPolygonsVertices()
        {
            return _polygon.Vertices;
        }

        public void CreatePolygon()
        {
            if(_points.Count() >= minNumberOfVertices)
            {
                CreatePolygon(_points);
            }
            
        }

        public void CreatePolygon(IEnumerable<Point> points)
        {
            _polygon = new Polygon(points);
            ClearPoints();
        }

        
        //Для заданной точки:
        public bool CheckPoint(Point point)
        {
            if(point != null && _polygon != null)
            {
                return _polygon.IsPointInPolygon(point);
            }

            return false;
        }

        //Для случайной точки:
        public bool CheckPoint( out Point randomPoint)
        {
            randomPoint = GetRandomPoint(PolygonPainterSettings.ImageSize0XForPoint, PolygonPainterSettings.ImageSize0YForPoint);
            return CheckPoint(randomPoint);
        }

        

        Point GetRandomPoint(int xMax, int yMax)
        {
            return new Point(_random.Next(xMax), _random.Next(yMax));
        }

        //int GetRandomNumberOfVertices(int maxNumberOfVertices)
        //{
        //    return _random.Next(minNumberOfVertices, maxNumberOfVertices);
        //}

        //IEnumerable<Point> GetRandomVertices(int numberOfVertices, int xMax, int yMax)
        //{
        //    var vertices = new List<Point>();
        //    for (int i = 0; i < numberOfVertices; i++)
        //    {
        //        var vertex = new Point(_random.Next(xMax), _random.Next(yMax));
        //        if (!vertices.Contains(vertex))
        //            vertices.Add(vertex);
        //    }

        //    return vertices;
        //}
        //public void CreateRandomPolygon(int numberOfVertices, int xMax, int yMax)
        //{
        //    CreatePolygon(GetRandomVertices(numberOfVertices, xMax, yMax)) ;
        //    ClearPoints();
        //}

        //public void CreateRandomPolygonWithRandomNumberOfVertices(int maxNumberOfVertices, int xMax, int yMax)
        //{
        //    CreateRandomPolygon(GetRandomNumberOfVertices(maxNumberOfVertices), xMax, yMax);
        //    ClearPoints();
        //}
    }
}
