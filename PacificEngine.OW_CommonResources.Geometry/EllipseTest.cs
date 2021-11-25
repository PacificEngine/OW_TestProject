using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PacificEngine.OW_CommonResources.Geometry
{
    [TestFixture]
    public class EllipseTest
    {
        public static IEnumerable<TestCaseData> fromPolarData
        {
            get
            {
                yield return new TestCaseData(-360f, new Vector2(5, 4), new Vector2(5, 0)).SetName("fromPolarData_NegativeRight");
                yield return new TestCaseData(-270f, new Vector2(5, 4), new Vector2(0, 4)).SetName("fromPolarData_NegativeUp");
                yield return new TestCaseData(-180f, new Vector2(5, 4), new Vector2(-5, 0)).SetName("fromPolarData_NegativeLeft");
                yield return new TestCaseData(-90f, new Vector2(5, 4), new Vector2(0, -4)).SetName("fromPolarData_NegativeDown");
                yield return new TestCaseData(0f, new Vector2(5,4), new Vector2(5, 0)).SetName("fromPolarData_Right");
                yield return new TestCaseData(90f, new Vector2(5, 4), new Vector2(0, 4)).SetName("fromPolarData_Up");
                yield return new TestCaseData(180f, new Vector2(5, 4), new Vector2(-5, 0)).SetName("fromPolarData_Left");
                yield return new TestCaseData(270f, new Vector2(5, 4), new Vector2(0, -4)).SetName("fromPolarData_Down");
                yield return new TestCaseData(360f, new Vector2(5, 4), new Vector2(5, 0)).SetName("fromPolarData_DoubleRight");
                yield return new TestCaseData(450f, new Vector2(5, 4), new Vector2(0, 4)).SetName("fromPolarData_DoubleUp");
                yield return new TestCaseData(540f, new Vector2(5, 4), new Vector2(-5, 0)).SetName("fromPolarData_DoubleLeft");
                yield return new TestCaseData(630f, new Vector2(5, 4), new Vector2(0, -4)).SetName("fromPolarData_DoubleDown");
                yield return new TestCaseData(25f, new Vector2(5, 4), new Vector2(4.531539f, 1.690473f)).SetName("fromPolarData_25");
                yield return new TestCaseData(85f, new Vector2(5, 4), new Vector2(0.43578f, 3.98478f)).SetName("fromPolarData_85");
            }
        }

        public static IEnumerable<TestCaseData> toPolarData
        {
            get
            {
                yield return new TestCaseData(new Vector2(5 ,0), new Vector2(5,4), 0f).SetName("toPolarData_Right");
                yield return new TestCaseData(new Vector2(3.5355339059f, 2.82842712472f), new Vector2(5, 4), 45f).SetName("toPolarData_45");
                yield return new TestCaseData(new Vector2(0, 4), new Vector2(5, 4), 90f).SetName("toPolarData_Up");
                yield return new TestCaseData(new Vector2(-3.5355339059f, 2.82842712472f), new Vector2(5, 4), 135f).SetName("toPolarData_135");
                yield return new TestCaseData(new Vector2(-5, 0), new Vector2(5, 4), 180f).SetName("toPolarData_Left");
                yield return new TestCaseData(new Vector2(-3.5355339059f, -2.82842712472f), new Vector2(5, 4), 225f).SetName("toPolarData_225");
                yield return new TestCaseData(new Vector2(0, -4), new Vector2(5, 4), 270f).SetName("toPolarData_Down");
                yield return new TestCaseData(new Vector2(3.5355339059f, -2.82842712472f), new Vector2(5, 4), 315f).SetName("toPolarData_315");
                yield return new TestCaseData(new Vector2(4.531539f, 1.690473f), new Vector2(5, 4), 25f).SetName("toPolarData_25");
                yield return new TestCaseData(new Vector2(0.43578f, 3.98478f), new Vector2(5, 4), 85f).SetName("toPolarData_85");
            }
        }

        [TestCaseSource("fromPolarData")]
        public void fromPolar(float angle, Vector2 radius, Vector2 expected)
        {
            compare(expected, Ellipse.fromPolar(angle, radius));
        }


        [TestCaseSource("toPolarData")]
        public void toPolar(Vector2 coordinates, Vector2 radius, float expected)
        {
            Assert.AreEqual(expected, Ellipse.toPolar(coordinates, radius), 0.005f);
        }



        private void compare(Vector2 expected, Vector2 actual)
        {
            Assert.AreEqual(expected.x, actual.x, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + ") Actual (" + actual.x + "," + actual.y + ")");
            Assert.AreEqual(expected.y, actual.y, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + ") Actual (" + actual.x + "," + actual.y + ")");
        }
    }
}
