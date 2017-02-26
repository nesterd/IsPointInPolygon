using BusinessLogic.Figures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class PolygonWithVertices_10_10_40_10_40_40_10_40_Test
    {
        Polygon polygon;

        [SetUp]
        public void Init()
        {
            var vertex1 = new Point(10, 10);
            var vertex2 = new Point(40, 10);
            var vertex3 = new Point(40, 40);
            var vertex4 = new Point(10, 40);

            var vertices = new List<Point> { vertex1, vertex2, vertex3, vertex4 };

            polygon = new Polygon(vertices);
        }

        [Test]
        public void IsPoint_30_30_InPolygon_Test()
        {
            var point = new Point(30, 30);
            Assert.IsTrue(polygon.IsPointInPolygon(point));
        }

        [Test]
        public void IsPoint_40_30_InPolygon_Test()
        {
            var point = new Point(40, 30);
            Assert.IsTrue(polygon.IsPointInPolygon(point));
        }

        [Test]
        public void IsPoint_40_10_InPolygon_Test()
        {
            var point = new Point(40, 10);
            Assert.IsTrue(polygon.IsPointInPolygon(point));
        }

        [Test]
        public void IsPoint_30_10_InPolygon_Test()
        {
            var point = new Point(30, 10);
            Assert.IsTrue(polygon.IsPointInPolygon(point));
        }

        [Test]
        public void IsPoint_41_10_OutsidePolygon_Test()
        {
            var point = new Point(41, 10);
            Assert.IsFalse(polygon.IsPointInPolygon(point));
        }

        [Test]
        public void IsPoint_9_10_OutsidePolygon_Test()
        {
            var point = new Point(9, 10);
            Assert.IsFalse(polygon.IsPointInPolygon(point));
        }

        [Test]
        public void IsPoint_5_30_OutsidePolygon_Test()
        {
            var point = new Point(5, 30);
            Assert.IsFalse(polygon.IsPointInPolygon(point));
        }

        [Test]
        public void IsPoint_41_30_OutsidePolygon_Test()
        {
            var point = new Point(41, 30);
            Assert.IsFalse(polygon.IsPointInPolygon(point));
        }

        [Test]
        public void IsPoint_50_50_OutsidePolygon_Test()
        {
            var point = new Point(50, 50);
            Assert.IsFalse(polygon.IsPointInPolygon(point));
        }
    }
}
