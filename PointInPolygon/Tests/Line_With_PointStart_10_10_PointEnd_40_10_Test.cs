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
    class Line_With_PointStart_10_10_PointEnd_40_10_Test
    {
        Line line;

        [SetUp]
        public void Init()
        {
            var pointStart = new Point(10, 10);
            var pointEnd = new Point(40, 10);
            line = new Line(pointStart, pointEnd);
        }

        [Test]
        public void IsPoint_20_10_InLine_Test()
        {
            var point = new Point(20, 10);
            Assert.IsTrue(line.IsPointInLine(point));
            
        }

        [Test]
        public void IsPoint_41_10_OutLine_Test()
        {
            var point = new Point(41, 10);
            Assert.IsFalse(line.IsPointInLine(point));

        }

        [Test]
        public void IsLineGetsRightCoefficients_A_0_B_1_C__10_Test()
        {
            Assert.AreEqual(line.A, 0);
            Assert.AreEqual(line.B, 1);
            Assert.AreEqual(line.C, -10);
        }

        [Test]
        public void IsLineGetsRightCoefficients_A__1_B_3_C__20_AfterChangeTest()
        {
            line.Change();
            Assert.AreEqual(line.A, -1);
            Assert.AreEqual(line.B, 3);
            Assert.AreEqual(line.C, -20);
        }

        [Test]
        public void IsEqualWithLine_PointStart_50_10_PointEnd_1000_10_Test()
        {
            var testLine = new Line(new Point(50, 10), new Point(1000, 10));
            Assert.IsTrue(line.IsEqual(testLine));
        }

        [Test]
        public void IsNotEqualWithLine_PointStart_50_20_PointEnd_1000_20_Test()
        {
            var testLine = new Line(new Point(50, 20), new Point(1000, 20));
            Assert.IsFalse(line.IsEqual(testLine));
        }

        [Test]
        public void IsCrossedByLineWith_PointStart_30_5_PointEnd_30_50_Test()
        {
            CrossPoint crossPoint;
            var testLine = new Line(new Point(30, 5), new Point(30, 50));
            Assert.IsTrue(line.IsCrossedByLine(testLine, out crossPoint)); 
        }

        [Test]
        public void IsCrossedByLineWith_PointStart_30_5_PointEnd_30_50_InPoint_30_10_Test()
        {
            CrossPoint crossPoint;
            var testLine = new Line(new Point(30, 5), new Point(30, 50));
            line.IsCrossedByLine(testLine, out crossPoint);
            Assert.AreEqual(30, crossPoint.X);
            Assert.AreEqual(10, crossPoint.Y);
        }

        [Test]
        public void IsNotCrossedByLineWith_PointStart_10_20_PointEnd_40_20_Test()
        {
            CrossPoint crossPoint;
            var testLine = new Line(new Point(10, 20), new Point(40, 20));
            Assert.IsFalse(line.IsCrossedByLine(testLine, out crossPoint));
        }

        [Test]
        public void IsNotCrossedByLineWith_PointStart_41_5_PointEnd_41_50_Test()
        {
            CrossPoint crossPoint;
            var testLine = new Line(new Point(41, 5), new Point(41, 50));
            Assert.IsFalse(line.IsCrossedByLine(testLine, out crossPoint));
        }

        


    }
}
