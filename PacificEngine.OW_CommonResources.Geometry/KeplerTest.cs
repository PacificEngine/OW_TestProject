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

        public static IEnumerable<TestCaseData> anomalyTests
        {
            get
            {
                for (float eccentricity = 0f; eccentricity < 1f; eccentricity += 0.09f)
                {
                    for (float angle = 0f; angle < 360f; angle += 5f)
                    {
                        yield return new TestCaseData(eccentricity, angle);
                    }
                }
            }
        }

        [TestCaseSource("anomalyTests")]
        public void trueAnomalyViaEccentriAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromTrueAnomaly(eccentricity, 100, 100, 100, 100, expected);
            inbetween = KeplerCoordinates.fromEccentricAnomaly(eccentricity, 100, 100, 100, 100, inbetween.esccentricAnomaly);
            var actual = inbetween.trueAnomaly;

            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.esccentricAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }

        [TestCaseSource("anomalyTests")]
        public void trueAnomalyViaMeanAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromTrueAnomaly(eccentricity, 100, 100, 100, 100, expected);
            inbetween = KeplerCoordinates.fromMeanAnomaly(eccentricity, 100, 100, 100, 100, inbetween.meanAnomaly);
            var actual = inbetween.trueAnomaly;

            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.meanAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }

        [TestCaseSource("anomalyTests")]
        public void eccentricAnomalyViaTrueAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromEccentricAnomaly(eccentricity, 100, 100, 100, 100, expected);
            inbetween = KeplerCoordinates.fromTrueAnomaly(eccentricity, 100, 100, 100, 100, inbetween.trueAnomaly);
            var actual = inbetween.esccentricAnomaly;


            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.trueAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }

        [TestCaseSource("anomalyTests")]
        public void eccentricAnomalyViaMeanAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromEccentricAnomaly(eccentricity, 100, 100, 100, 100, expected);
            inbetween = KeplerCoordinates.fromMeanAnomaly(eccentricity, 100, 100, 100, 100, inbetween.meanAnomaly);
            var actual = inbetween.esccentricAnomaly;


            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.meanAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }

        [TestCaseSource("anomalyTests")]
        public void meanAnomalyViaTrueAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromMeanAnomaly(eccentricity, 100, 100, 100, 100, expected);
            inbetween = KeplerCoordinates.fromTrueAnomaly(eccentricity, 100, 100, 100, 100, inbetween.trueAnomaly);
            var actual = inbetween.meanAnomaly;

            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.trueAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }

        [TestCaseSource("anomalyTests")]
        public void meanAnomalyViaEccentricAnomaly(float eccentricity, float expected)
        {
            var inbetween = KeplerCoordinates.fromMeanAnomaly(eccentricity, 100, 100, 100, 100, expected);
            inbetween = KeplerCoordinates.fromEccentricAnomaly(eccentricity, 100, 100, 100, 100, inbetween.esccentricAnomaly);
            var actual = inbetween.meanAnomaly;

            var errorMessage = $"{eccentricity}: {expected} -> {inbetween.esccentricAnomaly} -> {actual}";

            Assert.AreEqual(expected, actual, Math.Max(expected, 1f) * ERROR_PERCENTAGE, errorMessage);
        }
    }
}
