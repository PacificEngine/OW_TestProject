using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacificEngine.OW_CommonResources.Geometry
{
    [TestFixture]
    public class SphereTest
    {
        public static IEnumerable<TestCaseData> getRadiusOnSphereData
        {
            get
            {
                yield return new TestCaseData(180f, 1f, 0f).SetName("getRadiusOnSphereData_North");
                yield return new TestCaseData(0f, 1f, 0f).SetName("getRadiusOnSphereData_South");
                yield return new TestCaseData(90f, 1f, 1f).SetName("getRadiusOnSphereData_Equator");
                yield return new TestCaseData(135f, 1f, 1f / (float)Math.Sqrt(2)).SetName("getRadiusOnSphereData_HalfNorth");
                yield return new TestCaseData(22.5f, 1f, 0.38268336653709412f).SetName("getRadiusOnSphereData_3/4South");
            }
        }

        public static IEnumerable<TestCaseData> getPointOnSphereData
        {
            get
            {
                yield return new TestCaseData(Vector3.zero, 0f, 180f, 1f, new Vector3(0, 0, 1)).SetName("getPointOnSphere_North");
                yield return new TestCaseData(Vector3.zero, 180f, 180f, 1f, new Vector3(0, 0, 1)).SetName("getPointOnSphere_North+180");
                yield return new TestCaseData(Vector3.zero, 0f, 0f, 1f, new Vector3(0, 0, -1)).SetName("getPointOnSphere_South");
                yield return new TestCaseData(Vector3.zero, 90f, 0f, 1f, new Vector3(0, 0, -1)).SetName("getPointOnSphere_South+90");
                yield return new TestCaseData(Vector3.zero, 0f, 90f, 1f, new Vector3(0, 1, 0)).SetName("getPointOnSphere_Forward");
                yield return new TestCaseData(Vector3.zero, 90f, 90f, 1f, new Vector3(1, 0, 0)).SetName("getPointOnSphere_Right");
                yield return new TestCaseData(Vector3.zero, 180f, 90f, 1f, new Vector3(0, -1, 0)).SetName("getPointOnSphere_Back");
                yield return new TestCaseData(Vector3.zero, 270f, 90f, 1f, new Vector3(-1, 0, 0)).SetName("getPointOnSphere_Left");
            }
        }

        [TestCaseSource("getRadiusOnSphereData")]
        public void getRadiusOnSphere(float latitude, float radius, float expected)
        {
            Assert.AreEqual(expected, Sphere.getRadiusOnSphere(latitude, radius), 0.005f);
        }


        [TestCaseSource("getPointOnSphereData")]
        public void getPointOnSphere(Vector3 center, float longitude, float latitude, float radius, Vector3 expected)
        {
            compare(expected, Sphere.getPointOnSphere(ref center, longitude, latitude, radius));
        }


        private void compare(Vector3 expected, Vector3 actual)
        {
            Assert.AreEqual(expected.x, actual.x, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.y, actual.y, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.z, actual.z, 0.005f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
        }
    }
}
