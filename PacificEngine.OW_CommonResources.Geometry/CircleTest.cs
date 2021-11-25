using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacificEngine.OW_CommonResources.Geometry
{
    [TestFixture]
    public class CircleTest
    {
        public static IEnumerable<TestCaseData> getPointOnCircleData
        {
            get
            {
                yield return new TestCaseData(Vector2.zero, 1f, 0f, new Vector2(1,0)).SetName("getPointOnCircle_Right");
                yield return new TestCaseData(Vector2.zero, 1f, 90f, new Vector2(0, 1)).SetName("getPointOnCircle_Up");
                yield return new TestCaseData(Vector2.zero, 1f, 180f, new Vector2(-1, 0)).SetName("getPointOnCircle_Left");
                yield return new TestCaseData(Vector2.zero, 1f, 270f, new Vector2(0, -1)).SetName("getPointOnCircle_Down");
                yield return new TestCaseData(Vector2.zero, 1f, 360f, new Vector2(1, 0)).SetName("getPointOnCircle_FullRight");
                yield return new TestCaseData(Vector2.zero, 1f, -90f, new Vector2(0, -1)).SetName("getPointOnCircle_NegativeDown");
                yield return new TestCaseData(Vector2.zero, 1f, -180, new Vector2(-1, 0)).SetName("getPointOnCircle_NegativeLeft");
                yield return new TestCaseData(Vector2.zero, 1f, -270f, new Vector2(0, 1)).SetName("getPointOnCircle_NegativeUp");
                yield return new TestCaseData(Vector2.zero, 1f, -360f, new Vector2(1, 0)).SetName("getPointOnCircle_NegativeRight");
            }
        }

        [TestCaseSource("getPointOnCircleData")]
        public void getPointOnCircle(Vector2 center, float radius, float arcAngle, Vector2 expected)
        {
            compare(expected, Circle.getPointOnCircle(ref center, radius, arcAngle));
        }


        private void compare(Vector2 expected, Vector2 actual)
        {
            Assert.AreEqual(expected.x, actual.x, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + ") Actual (" + actual.x + "," + actual.y + ")");
            Assert.AreEqual(expected.y, actual.y, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + ") Actual (" + actual.x + "," + actual.y + ")");
        }
    }
}
