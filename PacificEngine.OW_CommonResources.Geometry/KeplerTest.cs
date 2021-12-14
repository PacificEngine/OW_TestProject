using NUnit.Framework;
using PacificEngine.OW_CommonResources.Geometry.Orbits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacificEngine.OW_CommonResources.Geometry
 {
    [TestFixture]
    public class KeplerTest
    {
        public const float ERROR_PERCENTAGE = 0.001f;

        public static IEnumerable<TestCaseData> trueAnomalyTests
        {
            get
            {
                for (float eccentricity = 0f; eccentricity < 1f; eccentricity += 0.09f)
                {
                    for (float angle = 0f; angle < 360f; angle += 5f)
                    {
                        yield return new TestCaseData(eccentricity, angle).SetName($"True Anomaly: {Math.Round(eccentricity, 3).ToString("G3")},{angle}");
                    }
                }
            }
        }


        public static IEnumerable<TestCaseData> eccentricAnomalyTests
        {
            get
            {
                for (float eccentricity = 0f; eccentricity < 1f; eccentricity += 0.09f)
                {
                    for (float angle = 0f; angle < 360f; angle += 5f)
                    {
                        yield return new TestCaseData(eccentricity, angle).SetName($"Eccentric Anomaly: {Math.Round(eccentricity, 3).ToString("G3")},{angle}");
                    }
                }
            }
        }


        public static IEnumerable<TestCaseData> meanAnomalyTests
        {
            get
            {
                for (float eccentricity = 0f; eccentricity < 1f; eccentricity += 0.09f)
                {
                    for (float angle = 0f; angle < 360f; angle += 5f)
                    {
                        yield return new TestCaseData(eccentricity, angle).SetName($"Mean Anomaly: {Math.Round(eccentricity, 3).ToString("G3")},{angle}");
                    }
                }
            }
        }

        [TestCaseSource("trueAnomalyTests")]
        public void trueAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromTrueAnomaly(eccentricity, 100, 100, 100, 100, expected);
            var actual = inbetween.trueAnomaly;


            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.trueAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }

        [TestCaseSource("eccentricAnomalyTests")]
        public void eccentricAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromEccentricAnomaly(eccentricity, 100, 100, 100, 100, expected);
            var actual = inbetween.esccentricAnomaly;


            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.trueAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }

        [TestCaseSource("meanAnomalyTests")]
        public void meanAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromMeanAnomaly(eccentricity, 100, 100, 100, 100, expected);
            var actual = inbetween.meanAnomaly;


            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.trueAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }
    }
}
