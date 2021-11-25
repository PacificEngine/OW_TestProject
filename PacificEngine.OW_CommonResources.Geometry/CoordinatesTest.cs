using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacificEngine.OW_CommonResources.Geometry
{
    [TestFixture]
    public class CoordinatesTest
    {
        [Test]
        public void nearestPoint_HappyPath()
        {
            var points = Coordinates.nearestPoint(new Vector3(3, 3, 6), new Vector3(1, 1, 1), new Vector3(-100, -100, -100), new Vector3(-4, 7, -16), new Vector3(1, 2, 1));

            Assert.AreEqual(4, points.Length);
            compare(new Vector3(1, 2, 1), points[0]);
            compare(new Vector3(1, 1, 1), points[1]);
            compare(new Vector3(-4, 7, -16), points[2]);
            compare(new Vector3(-100, -100, -100), points[3]);
        }

        [Test]
        public void furthestPoint_HappyPath()
        {
            var points = Coordinates.furthestPoint(new Vector3(3, 3, 6), new Vector3(1, 1, 1), new Vector3(-100, -100, -100), new Vector3(-4, 7, -16), new Vector3(1, 2, 1));

            Assert.AreEqual(4, points.Length);
            compare(new Vector3(-100, -100, -100), points[0]);
            compare(new Vector3(-4, 7, -16), points[1]);
            compare(new Vector3(1, 1, 1), points[2]);
            compare(new Vector3(1, 2, 1), points[3]);
        }

        [Test]
        public void nearestPoints_HappyPath()
        {
            var points = Coordinates.nearestPoints(new Vector3(1, 1, 1), new Vector3(-100, -100, -100), new Vector3(-4, 7, -16), new Vector3(1, 2, 1));

            Assert.AreEqual(2, points.Length);
            compare(new Vector3(1, 1, 1), points[0]);
            compare(new Vector3(1, 2, 1), points[1]);
        }

        [Test]
        public void furthestPoints_HappyPath()
        {
            var points = Coordinates.furthestPoints(new Vector3(1, 1, 1), new Vector3(-100, -100, -100), new Vector3(-4, 7, -16), new Vector3(1, 2, 1));

            Assert.AreEqual(2, points.Length);
            compare(new Vector3(-100, -100, -100), points[0]);
            compare(new Vector3(1, 2, 1), points[1]);
        }

        public static IEnumerable<TestCaseData> angleXYZTestCases
        {
            get
            {
                yield return new TestCaseData(Vector3.zero, Vector3.zero, Vector3.zero).SetName("angleXYZ_zero");
                yield return new TestCaseData(Vector3.zero, Vector3.right, Vector3.zero).SetName("angleXYZ_right");
                yield return new TestCaseData(Vector3.zero, Vector3.left, Vector3.zero).SetName("angleXYZ_left");
                yield return new TestCaseData(Vector3.zero, Vector3.up, Vector3.zero).SetName("angleXYZ_up");
                yield return new TestCaseData(Vector3.zero, Vector3.down, Vector3.zero).SetName("angleXYZ_down");
                yield return new TestCaseData(Vector3.zero, Vector3.forward, Vector3.zero).SetName("angleXYZ_forward");
                yield return new TestCaseData(Vector3.zero, Vector3.back, Vector3.zero).SetName("angleXYZ_back");

                yield return new TestCaseData(Vector3.up, Vector3.right, 270f * Vector3.forward).SetName("angleXYZ_up_to_right");
                yield return new TestCaseData(Vector3.one, -1f * Vector3.one, 180f * Vector3.one).SetName("angleXYZ_full_turn");

                yield return new TestCaseData(Vector3.forward, new Vector3(1, 0, 1), 315f * Vector3.up).SetName("angleXYZ_forward_halfX");
                yield return new TestCaseData(Vector3.forward, new Vector3(0, 1, 1), 315f * Vector3.right).SetName("angleXYZ_forward_halfY");

                yield return new TestCaseData(Vector3.up, new Vector3(1, 1, 0), 315f * Vector3.forward).SetName("angleXYZ_up_halfX");
                yield return new TestCaseData(Vector3.up, new Vector3(0, 1, 1), 45f * Vector3.right).SetName("angleXYZ_up_halfZ");

                yield return new TestCaseData(Vector3.right, new Vector3(1, 1, 0), 45f * Vector3.forward).SetName("angleXYZ_right_halfY");
                yield return new TestCaseData(Vector3.right, new Vector3(1, 0, 1), 45f * Vector3.up).SetName("angleXYZ_right_halfZ");


                yield return new TestCaseData(Vector3.up + Vector3.right, Vector3.right, 315f * Vector3.forward).SetName("angleXYZ_45_right");
                yield return new TestCaseData(Vector3.one, Vector3.right, 315f * (Vector3.up + Vector3.forward)).SetName("angleXYZ_45_to_right");
                yield return new TestCaseData(Vector3.up, Vector3.one, new Vector3(45f, 0, 315f)).SetName("angleXYZ_up_to_45");
                yield return new TestCaseData(Vector3.up, -1f * Vector3.one, new Vector3(225f, 0, 315f)).SetName("angleXYZ_up_to_-45");
            }
        }

        public static IEnumerable<TestCaseData> angle3DTestCases
        {
            get
            {
                yield return new TestCaseData(Vector3.zero, Vector3.zero, 0f).SetName("angle3D_zero");
                yield return new TestCaseData(Vector3.zero, Vector3.right, 0f).SetName("angle3D_right");
                yield return new TestCaseData(Vector3.zero, Vector3.left, 0f).SetName("angle3D_left");
                yield return new TestCaseData(Vector3.zero, Vector3.up, 0f).SetName("angle3D_up");
                yield return new TestCaseData(Vector3.zero, Vector3.down, 0f).SetName("angle3D_down");
                yield return new TestCaseData(Vector3.zero, Vector3.forward, 0f).SetName("angle3D_forward");
                yield return new TestCaseData(Vector3.zero, Vector3.back, 0f).SetName("angle3D_back");

                yield return new TestCaseData(Vector3.up, Vector3.right, 90f).SetName("angle3D_up_to_right");
                yield return new TestCaseData(Vector3.up + Vector3.right, Vector3.right, 45f).SetName("angle3D_45_right");
                yield return new TestCaseData(Vector3.one, Vector3.right, 54.7346582f).SetName("angle3D_45_to_right");
                yield return new TestCaseData(Vector3.up, Vector3.one, 54.7346582f).SetName("angle3D_up_to_45");
                yield return new TestCaseData(Vector3.up, -1f * Vector3.one, 125.265763f).SetName("angle3D_up_to_-45");
                yield return new TestCaseData(Vector3.one, -1f * Vector3.one, 180f).SetName("angle3D_full_turn");
            }
        }

        public static IEnumerable<TestCaseData> rotatePointTestCases
        {
            get
            {
                yield return new TestCaseData(Vector3.zero, Vector3.zero, Vector3.zero).SetName("rotatePoint_zero");
                yield return new TestCaseData(Vector3.right, Vector3.up * 90f, Vector3.back).SetName("rotatePoint_right_to_up");
                yield return new TestCaseData(Vector3.up, Vector3.right * 90f, Vector3.forward).SetName("rotatePoint_up_to_right");
                yield return new TestCaseData(Vector3.left, Vector3.down * 90f, Vector3.back).SetName("rotatePoint_left_to_down");
                yield return new TestCaseData(Vector3.right, Vector3.down * 90f, Vector3.forward).SetName("rotatePoint_right_to_down");
                yield return new TestCaseData(Vector3.back, Vector3.down * 90f, Vector3.right).SetName("rotatePoint_back_to_down");
            }
        }

        [TestCaseSource("angleXYZTestCases")]
        public void angleXYZ(Vector3 start, Vector3 end, Vector3 expected)
        {
            var rotation = Coordinates.angleXYZ(start, end);
            compare(expected, rotation);
        }

        [TestCaseSource("angle3DTestCases")]
        public void angle3D(Vector3 start, Vector3 end, float expected)
        {
            var actual = Coordinates.angle(start, end);
            Assert.AreEqual(expected, actual, 0.005f);
        }

        [TestCaseSource("rotatePointTestCases")]
        public void rotatePoint(Vector3 start, Vector3 end, Vector3 expected)
        {
            var rotation = Coordinates.rotatePoint(ref start, ref end);
            compare(expected, rotation);
        }

        private void compare(Vector3 expected, Vector3 actual)
        {
            Assert.AreEqual(expected.x, actual.x, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.y, actual.y, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.z, actual.z, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
        }

        private void compare(Quaternion expected, Quaternion actual)
        {
            Assert.AreEqual(expected.x, actual.x, 0.005f, "Does not match Expected (" + expected.w + "," + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + expected.w + "," + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.y, actual.y, 0.005f, "Does not match Expected (" + expected.w + "," + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + expected.w + "," + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.z, actual.z, 0.005f, "Does not match Expected (" + expected.w + "," + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + expected.w + "," + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.w, actual.w, 0.005f, "Does not match Expected (" + expected.w + "," + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + expected.w + "," + actual.x + "," + actual.y + "," + actual.z + ")");
        }
    }
}
