using NUnit.Framework;
using PacificEngine.OW_CommonResources.Geometry.Orbits;
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
        public const float ERROR_PERCENTAGE = 0.001f;

        public static IEnumerable<TestCaseData> toKeplerCoordinatesTestCases
        {
            get
            {
                var sunGravity = Gravity.of(2, 400000000000);
                var hourGlassTwinGravity = Gravity.of(1, 800000);
                var timberHearthGravity = Gravity.of(1, 3000000);
                var brittleHollowGravity = Gravity.of(1, 3000000);
                var giantsDeepGravity = Gravity.of(1, 21780000);

                yield return new TestCaseData(sunGravity, 0f, new Vector3(0.0f, 0.0f, -2296.0f), new Vector3(417.4f, 0.0f, 0.0f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0, 2296, 90f, 90f, 0, 17.25547f)).SetName("toKeplerCoordinates_SunStationExample");
                yield return new TestCaseData(sunGravity, 0f, new Vector3(-2867.9f, 0.0f, 4095.8f), new Vector3(-231.7f, 0.0f, -162.2f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0, 5000.001f, 90, 305.2348f, 0, 55.46355f)).SetName("toKeplerCoordinates_HourglassTwinsExample");
                yield return new TestCaseData(hourGlassTwinGravity, 0f, new Vector3(204.8f, 0.0f, 143.4f), new Vector3(16.2f, 0.0f, -23.2f), KeplerCoordinates.fromTimeSincePeriapsis(hourGlassTwinGravity, 0, 250, 90, 233.8092f, 180, 41.86327f)).SetName("toKeplerCoordinates_AshTwinExample");
                yield return new TestCaseData(hourGlassTwinGravity, 0f, new Vector3(-204.8f, 0.0f, -143.4f), new Vector3(-16.2f, 0.0f, 23.2f), KeplerCoordinates.fromTimeSincePeriapsis(hourGlassTwinGravity, 0, 250, 90, 53.80923f, 180, 41.86327f)).SetName("toKeplerCoordinates_EmberTwinExample");
                yield return new TestCaseData(sunGravity, 0f, new Vector3(1492.2f, 0.0f, -8462.5f), new Vector3(212.5f, 0.0f, 37.5f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0, 8593.086f, 90, 95.02123f, 0, 125.1692f)).SetName("toKeplerCoordinates_TimberHearthExample");
                yield return new TestCaseData(timberHearthGravity, 0f, new Vector3(-344.8f, 0.0f, -60.8f), new Vector3(9.5f, 0.0f, -53.9f), KeplerCoordinates.fromTimeSincePeriapsis(timberHearthGravity, 0, 350.1f, 90, 72.95632f, 0, 13.03968f)).SetName("toKeplerCoordinates_TimberHearthProbeExample");
                yield return new TestCaseData(timberHearthGravity, 0f, new Vector3(886.3f, 0.0f, 156.3f), new Vector3(-9.5f, 0.0f, 53.9f), KeplerCoordinates.fromTimeSincePeriapsis(timberHearthGravity, 0, 900.0001f, 90, 265.2352f, 0, 29.998f)).SetName("toKeplerCoordinates_AttlerockExample");
                yield return new TestCaseData(sunGravity, 0f, new Vector3(11513.3f, 0.0f, -2030.1f), new Vector3(32.1f, 0.0f, 182.2f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0, 11690.89f, 90, 170.0452f, 0, 198.5069f)).SetName("toKeplerCoordinates_BrittleHollowExample");
                yield return new TestCaseData(brittleHollowGravity, 0f, new Vector3(984.8f, 0.0f, -173.6f), new Vector3(9.5f, 0.0f, 53.9f), KeplerCoordinates.fromTimeSincePeriapsis(brittleHollowGravity, 0, 999.227661f, 90, 122.3145f, 0, 72.51768f)).SetName("toKeplerCoordinates_HollowLanternExample");
                yield return new TestCaseData(sunGravity, 0f, new Vector3(3421.7f, 0.0f, -16098.0f), new Vector3(152.5f, 0.0f, 32.4f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0, 16457.59f, 90, 101.9912f, 0, 331.6218f)).SetName("toKeplerCoordinates_GiantsDeepExample");
                yield return new TestCaseData(giantsDeepGravity, 0f, new Vector3(-1006.4f, 0.0f, 653.6f), new Vector3(80.4f, 0.0f, 123.8f), KeplerCoordinates.fromTimeSincePeriapsis(giantsDeepGravity, 0, 1200, 90, 351.1121f, 180, 5.943623f)).SetName("toKeplerCoordinates_ProbeCannonExample");
                yield return new TestCaseData(sunGravity, 0f, new Vector3(-3473.0f, 0.0f, 19696.2f), new Vector3(-139.3f, 0.0f, -24.6f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0, 20000, 90, 280.0383f, 0, 444.1865f)).SetName("toKeplerCoordinates_DarkBrambleExample");
                yield return new TestCaseData(sunGravity, 0f, new Vector3(-24100.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 54.8f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0.8193752f, 13246.31f, 90, 180, 180, 239.4758f)).SetName("toKeplerCoordinates_InterloperExample");
                yield return new TestCaseData(sunGravity, 0f, new Vector3(41999.8f, 5001.7f, -22499.9f), new Vector3(-46.9f, 28.1f, 24.7f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0.8884588f, 30535.38f, 28.1183f, 81.81603f, 91.35296f, 1253.788f)).SetName("toKeplerCoordinates_BackerSatiliteExample");
                yield return new TestCaseData(sunGravity, 0f, new Vector3(24732.5f, -6729.5f, 4361.0f), new Vector3(31.6f, 119.8f, 5.6f), KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0, 26000, 10, 251.3132f, 270, 672.0341f)).SetName("toKeplerCoordinates_MapSatiliteExample");
            }
        }

        public static IEnumerable<TestCaseData> toKeplerCoordinatestoCartesianTestCases
        {
            get
            {
                yield return new TestCaseData(new Gravity((float)6.67408e-11, 2f, (float)6.0456e24), 0f, new Vector3(6371000 + 600000, 0, 10000), new Vector3(0, 6500, 0)).SetName("toKeplerCoordinates_toCartesian_EarthExample");
                yield return new TestCaseData(new Gravity((float)6.67408e-11, 1f, (float)6.0456e24), 0f, new Vector3(6371000 + 600000, 0, 10000), new Vector3(0, 6500, 0)).SetName("toKeplerCoordinates_toCartesian_EarthExample_Linear");
                yield return new TestCaseData(new Gravity((float)6.67408e-11, 2f, (float)6.0456e24), 1000f, new Vector3(6371000 + 600000, 0, 10000), new Vector3(0, 6500, 0)).SetName("toKeplerCoordinates_toCartesian_EarthExample_MuchLater");
            }
        }

        public static IEnumerable<TestCaseData> toCartesiantoKeplerCoordinatesTestCases
        {
            get
            {
                var sunGravity = Gravity.of(2, 400000000000);
                var hourGlassTwinGravity = Gravity.of(1, 800000);
                var timberHearthGravity = Gravity.of(1, 3000000);
                var brittleHollowGravity = Gravity.of(1, 3000000);
                var giantsDeepGravity = Gravity.of(1, 21780000);

                yield return new TestCaseData(sunGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(sunGravity, 0.1523f, 7752.49512f, 113.7459f, 220.1543f, 341.5999f, 0.88239f)).SetName("toCartesian_toKeplerCoordinates_SunStationRandomExample_1");
                yield return new TestCaseData(sunGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(sunGravity, 0.5115f, 5136.91211f, 18.2608f, 328.5999f, 152.8381f, 107.96543f)).SetName("toCartesian_toKeplerCoordinates_HourglassTwinsRandomExample_1");
                yield return new TestCaseData(hourGlassTwinGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(hourGlassTwinGravity, 0, 250, 90, 233.8092f, 180, 41.86327f)).SetName("toCartesian_toKeplerCoordinates_AshTwinExample");
                yield return new TestCaseData(hourGlassTwinGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(hourGlassTwinGravity, 0, 250, 90, 53.80923f, 180, 41.86327f)).SetName("toCartesian_toKeplerCoordinates_EmberTwinExample");
                yield return new TestCaseData(sunGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(sunGravity, 0.3443f, 623.103638f, 135.8287f, 315.4913f, 267.1545f, 0.50635f)).SetName("toCartesian_toKeplerCoordinates_TimberHearthRandomExample_1");
                yield return new TestCaseData(sunGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(sunGravity, 0.1113f, 540.427429f, 135.7068f, 294.9969f, 267.0781f, 0.94821f)).SetName("toCartesian_toKeplerCoordinates_TimberHearthRandomExample_2");
                yield return new TestCaseData(timberHearthGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(timberHearthGravity, 0.1179f, 637.800293f, 80.5333f, 341.0094f, 94.4544f, 169.08463f)).SetName("toCartesian_toKeplerCoordinates_TimberHearthProbeRandomExample_1");
                yield return new TestCaseData(timberHearthGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(timberHearthGravity, 0.0363f, 630.545593f, 80.5335f, 1.8984f, 94.4488f, 17.42552f)).SetName("toCartesian_toKeplerCoordinates_TimberHearthProbeRandomExample_2");
                yield return new TestCaseData(timberHearthGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(timberHearthGravity, 0.0361f, 675.51178f, 155.9968f, 152.4014f, 65.311f, 118.72765f)).SetName("toCartesian_toKeplerCoordinates_AttlerockRandomExample_1");
                yield return new TestCaseData(sunGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0.0006f, 11690.8877f, 90, 259.9969f, 0, 99.21703f)).SetName("toCartesian_toKeplerCoordinates_BrittleHollowExample_1");
                yield return new TestCaseData(brittleHollowGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(brittleHollowGravity, 0.2025f, 695.317505f, 141.9887f, 193.9186f, 52.5955f, 236.01967f)).SetName("toCartesian_toKeplerCoordinates_HollowLanternRandomExample_1");
                yield return new TestCaseData(brittleHollowGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(brittleHollowGravity, 0.174f, 455.326263f, 109.2665f, 88.6078f, 53.2425f, 10.27084f)).SetName("toCartesian_toKeplerCoordinates_HollowLanternRandomExample_2");
                yield return new TestCaseData(sunGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0.1229f, 4526.54834f, 17.8675f, 3.9356f, 230.6604f, 8.71545f)).SetName("toCartesian_toKeplerCoordinates_GiantsDeepRandomExample_1");
                yield return new TestCaseData(giantsDeepGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(giantsDeepGravity, 0.2787f, 2042.57397f, 0.6094f, 257.7437f, 310.6645f, 1085.22839f)).SetName("toCartesian_toKeplerCoordinates_ProbeCannonRandomExample_1");
                yield return new TestCaseData(sunGravity, 0f, KeplerCoordinates.fromTimeSincePeriapsis(sunGravity,0.0008f, 9852.23438f, 46.3357f, 155.0664f, 128.528f, 1085.7738f)).SetName("toCartesian_toKeplerCoordinates_DarkBrambleRandomExample_1");
            }
        }

        [TestCaseSource("toKeplerCoordinatesTestCases")]
        public void toKeplerCoordinates(Gravity gravity, float timeSinceStart, Vector3 startPosition, Vector3 startVelocity, KeplerCoordinates expected)
        {
            compare(expected, OrbitHelper.toKeplerCoordinates(gravity, timeSinceStart, startPosition, startVelocity));
        }

        [TestCaseSource("toKeplerCoordinatestoCartesianTestCases")]
        public void toKeplerCoordinates_toCartesian(Gravity gravity, float timeSinceStart, Vector3 startPosition, Vector3 startVelocity)
        {
            var kepler = OrbitHelper.toKeplerCoordinates(gravity, timeSinceStart, startPosition, startVelocity);
            var actual = OrbitHelper.toCartesian(gravity, timeSinceStart, kepler);
            compare(Tuple.Create(startPosition, startVelocity), actual);
        }

        [TestCaseSource("toCartesiantoKeplerCoordinatesTestCases")]
        public void toCartesian_toKeplerCoordinates(Gravity gravity, float timeSinceStart, KeplerCoordinates startKepler)
        {
            var cartesian = OrbitHelper.toCartesian(gravity, timeSinceStart, startKepler);
            //var cartesian = OrbitHelper.toCartesianTrueAnomaly(gravity, startKepler.eccentricity, startKepler.semiMajorRadius, startKepler.inclinationAngle, startKepler.periapseAngle, startKepler.ascendingAngle, 150);
            var actual = OrbitHelper.toKeplerCoordinates(gravity, timeSinceStart, cartesian.Item1, cartesian.Item2);
            compare(startKepler, actual);
        }

        private void compare(Tuple<Vector3, Vector3> expected, Tuple<Vector3, Vector3> actual)
        {
            var errorMessage = "Does not match Expected (" + expected.Item1.x + ", " + expected.Item1.y + ", " + expected.Item1.z + ")(" + expected.Item2.x + ", " + expected.Item2.y + ", " + expected.Item2.z + ") Actual (" + actual.Item1.x + ", " + actual.Item1.y + ", " + actual.Item1.z + ")(" + actual.Item2.x + ", " + actual.Item2.y + ", " + actual.Item2.z + ")";

            Assert.AreEqual(expected.Item1.x, actual.Item1.x, Math.Max(expected.Item1.magnitude, 1f) * ERROR_PERCENTAGE, errorMessage);
            Assert.AreEqual(expected.Item1.y, actual.Item1.y, Math.Max(expected.Item1.magnitude, 1f) * ERROR_PERCENTAGE, errorMessage);
            Assert.AreEqual(expected.Item1.z, actual.Item1.z, Math.Max(expected.Item1.magnitude, 1f) * ERROR_PERCENTAGE, errorMessage);
            Assert.AreEqual(expected.Item2.x, actual.Item2.x, Math.Max(expected.Item2.magnitude, 1f) * ERROR_PERCENTAGE, errorMessage);
            Assert.AreEqual(expected.Item2.y, actual.Item2.y, Math.Max(expected.Item2.magnitude, 1f) * ERROR_PERCENTAGE, errorMessage);
            Assert.AreEqual(expected.Item2.z, actual.Item2.z, Math.Max(expected.Item2.magnitude, 1f) * ERROR_PERCENTAGE, errorMessage);
        }

        private void compare(KeplerCoordinates expected, KeplerCoordinates actual)
        {
            var errorMessage = "Does not match Expected " + expected + " Actual + " + actual;

            Assert.AreEqual(expected.eccentricity, actual.eccentricity, Math.Max(expected.eccentricity, 1f) * ERROR_PERCENTAGE, errorMessage);
            Assert.AreEqual(expected.semiMajorRadius, actual.semiMajorRadius, Math.Max(expected.semiMajorRadius, 1f) * ERROR_PERCENTAGE, errorMessage);
            Assert.AreEqual(expected.inclinationAngle, actual.inclinationAngle, Math.Max(expected.inclinationAngle, 1f) * ERROR_PERCENTAGE, errorMessage);
            if (expected.eccentricity > ERROR_PERCENTAGE)
            {
                Assert.AreEqual(expected.periapseAngle, actual.periapseAngle, Math.Max(expected.periapseAngle, 1f) * ERROR_PERCENTAGE, errorMessage);
            }
            Assert.AreEqual(expected.ascendingAngle, actual.ascendingAngle, Math.Max(expected.ascendingAngle, 1f) * ERROR_PERCENTAGE, errorMessage);
            if (expected.eccentricity > ERROR_PERCENTAGE)
            {
                Assert.AreEqual(expected.trueAnomaly, actual.trueAnomaly, Math.Max(expected.trueAnomaly, 1f) * ERROR_PERCENTAGE, errorMessage);
            }
        }
    }
}
