using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PacificEngine.OW_CommonResources.Geometry
{
    [TestFixture]
    public class OrbitTest
    {

        public static IEnumerable<TestCaseData> toKeplerCoordinatesTestCases
        {
            get
            {
                var sunMass = (float)4.0005E+11;
                var hourglassMass = 800000f; // Mass / 2d (beacuase it is twice as far)
                var timberHearthMass = 3000000f;
                var brittleHollowMass = 3000000f;
                var giantDeepMass = 21780000f;
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(0.0f, 0.0f, -2296.0f), new Vector3(417.4f, 0.0f, 0.0f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_SunStationExample");
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(-2867.9f, 0.0f, 4095.8f), new Vector3(-231.7f, 0.0f, -162.2f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_HourglassTwinsExample");
                yield return new TestCaseData((float)0.001, (float)hourglassMass, 1f, 0f, new Vector3(204.8f, 0.0f, 143.4f), new Vector3(16.2f, 0.0f, -23.2f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_AshTwinExample");
                yield return new TestCaseData((float)0.001, (float)hourglassMass, 1f, 0f, new Vector3(-204.8f, 0.0f, -143.4f), new Vector3(-16.2f, 0.0f, 23.2f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_EmberTwinExample");
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(1492.2f, 0.0f, -8462.5f), new Vector3(212.5f, 0.0f, 37.5f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_TimberHearthExample");
                yield return new TestCaseData((float)0.001, (float)timberHearthMass, 1f, 0f, new Vector3(886.3f, 0.0f, 156.3f), new Vector3(-9.5f, 0.0f, 53.9f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_AttlerockExample");
                yield return new TestCaseData((float)0.001, (float)timberHearthMass, 1f, 0f, new Vector3(-344.8f, 0.0f, -60.8f), new Vector3(9.5f, 0.0f, -53.9f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_TimberHearthProbeExample");
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(11513.3f, 0.0f, -2030.1f), new Vector3(32.1f, 0.0f, 182.2f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_BrittleHollowExample");
                yield return new TestCaseData((float)0.001, (float)brittleHollowMass, 1f, 0f, new Vector3(984.8f, 0.0f, -173.6f), new Vector3(9.5f, 0.0f, 53.9f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_HollowLanternExample");
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(3421.7f, 0.0f, -16098.0f), new Vector3(152.5f, 0.0f, 32.4f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_GiantsDeepExample");
                yield return new TestCaseData((float)0.001, (float)giantDeepMass, 1f, 0f, new Vector3(-1006.4f, 0.0f, 653.6f), new Vector3(80.4f, 0.0f, 123.8f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_ProbeCannonExample");
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(-3473.0f, 0.0f, 19696.2f), new Vector3(-139.3f, 0.0f, -24.6f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_DarkBrambleExample");
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(-24100.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 54.8f), new Orbit.KeplerCoordinates(0.82f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_InterloperExample");
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(41999.8f, 5001.7f, -22499.9f), new Vector3(-46.9f, 28.1f, 24.7f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_BackerSatiliteExample");
                yield return new TestCaseData((float)0.001, (float)sunMass, 2f, 0f, new Vector3(24732.5f, -6729.5f, 4361.0f), new Vector3(31.6f, 119.8f, 5.6f), new Orbit.KeplerCoordinates(0f, 200, 0, 0, 0, 0)).SetName("toKeplerCoordinates_MapSatiliteExample");
            }
        }

        public static IEnumerable<TestCaseData> getPositionAndVelocityTestCases
        {
            get
            {
                yield return new TestCaseData((float)6.67408e-11, (float)6.0456e24, 2f, 0f, new Vector3(6371000 + 600000, 0, 10000), new Vector3(0, 6500, 0)).SetName("toKeplerCoordinates_toCartesian_EarthExample");
                yield return new TestCaseData((float)6.67408e-11, (float)6.0456e24, 1f, 0f, new Vector3(6371000 + 600000, 0, 10000), new Vector3(0, 6500, 0)).SetName("toKeplerCoordinates_toCartesian_EarthExample_Linear");
                yield return new TestCaseData((float)6.67408e-11, (float)6.0456e24, 2f, 1000f, new Vector3(6371000 + 600000, 0, 10000), new Vector3(0, 6500, 0)).SetName("toKeplerCoordinates_toCartesian_EarthExample_MuchLater");
            }
        }

        [TestCaseSource("toKeplerCoordinatesTestCases")]
        public void toKeplerCoordinates_toCartesian(float gravityConstant, float mass, float exponent, float timeSinceStart, Vector3 startPosition, Vector3 startVelocity, Orbit.KeplerCoordinates expected)
        {
            compare(expected, Orbit.toKeplerCoordinates(gravityConstant, mass, exponent, timeSinceStart, startPosition, startVelocity));
        }

        [TestCaseSource("getPositionAndVelocityTestCases")]
        public void toKeplerCoordinates_toCartesian(float gravityConstant, float mass, float exponent, float timeSinceStart, Vector3 startPosition, Vector3 startVelocity)
        {
            var kepler = Orbit.toKeplerCoordinates(gravityConstant, mass, exponent, timeSinceStart, startPosition, startVelocity);
            var actual = Orbit.toCartesian(gravityConstant, mass, exponent, timeSinceStart, kepler);
            compare(Tuple.Create(startPosition, startVelocity), actual);
        }

        private void compare(Tuple<Vector3, Vector3> expected, Tuple<Vector3, Vector3> actual)
        {
            var errorMessage = "Does not match Expected (" + expected.Item1.x + ", " + expected.Item1.y + ", " + expected.Item1.z + ")(" + expected.Item2.x + ", " + expected.Item2.y + ", " + expected.Item2.z + ") Actual (" + actual.Item1.x + ", " + actual.Item1.y + ", " + actual.Item1.z + ")(" + actual.Item2.x + ", " + actual.Item2.y + ", " + actual.Item2.z + ")";

            Assert.AreEqual(expected.Item1.x, actual.Item1.x, Math.Min(expected.Item1.x, actual.Item1.x) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.Item1.y, actual.Item1.y, Math.Min(expected.Item1.y, actual.Item1.y) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.Item1.z, actual.Item1.z, Math.Min(expected.Item1.z, actual.Item1.z) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.Item2.x, actual.Item2.x, Math.Min(expected.Item2.x, actual.Item2.x) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.Item2.y, actual.Item2.y, Math.Min(expected.Item2.y, actual.Item2.y) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.Item2.z, actual.Item2.z, Math.Min(expected.Item2.z, actual.Item2.z) * 0.0001f, errorMessage);
        }

        private void compare(Orbit.KeplerCoordinates expected, Orbit.KeplerCoordinates actual)
        {
            var errorMessage = "Does not match Expected " + expected + " Actual + " + actual;

            Assert.AreEqual(expected.eccentricity, actual.eccentricity, Math.Max(expected.eccentricity, 1f) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.semiMajorRadius, actual.semiMajorRadius, Math.Max(expected.semiMajorRadius, 1f) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.inclinationAngle, actual.inclinationAngle, Math.Max(expected.inclinationAngle, 1f) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.periapseAngle, actual.periapseAngle, Math.Max(expected.periapseAngle, 1f) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.ascendingAngle, actual.ascendingAngle, Math.Max(expected.ascendingAngle, 1f) * 0.0001f, errorMessage);
            Assert.AreEqual(expected.timeSincePeriapse, actual.timeSincePeriapse, Math.Max(expected.timeSincePeriapse, 1f) * 0.0001f, errorMessage);
        }
    }
}
