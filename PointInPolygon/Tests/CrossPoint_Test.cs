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
    class CrossPoint_Test
    {
        CrossPoint crossPoint;
        
        [Test]
        public void IsCrossPoint_50_50_EqualWithPoint_50_50_Test()
        {
            crossPoint = new CrossPoint(50, 50);
            Point point = new Point(50, 50);
            Assert.IsTrue(crossPoint.IsEqual(point));
        }


        [Test]
        public void IsCrossPoint_49_9_50_3_Not_EqualWithPoint_50_50_Test()
        {
            crossPoint = new CrossPoint(49.9, 50.3);
            Point point = new Point(50, 50);
            Assert.IsFalse(crossPoint.IsEqual(point));
        }
    }
}
