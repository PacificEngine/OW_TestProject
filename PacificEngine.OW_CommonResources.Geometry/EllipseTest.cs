using NUnit.Framework;
using OWML.Common;
using PacificEngine.OW_CommonResources.Game;
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
        public const float ERROR_PERCENTAGE = 0.00025f;

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

        public static IEnumerable<TestCaseData> generateEllipses
        {
            get
            {
                for (float eccentricity = 0; eccentricity < 1; eccentricity += 0.05f)
                {
                    for (float semiMajorRadius = 5; semiMajorRadius < 500; semiMajorRadius += 50)
                    {
                        yield return new TestCaseData(semiMajorRadius, eccentricity);
                    }
                }
            }
        }

        [TestCaseSource("fromPolarData")]
        public void fromPolar(float angle, Vector2 radius, Vector2 expected)
        {
            compare(expected, Ellipse.fromMajorRadiusAndMinorRadius(radius.x, radius.y).getCoordinatesFromCenterAngle(angle));
        }


        [TestCaseSource("toPolarData")]
        public void toPolar(Vector2 coordinates, Vector2 radius, float expected)
        {
            Assert.AreEqual(expected, Ellipse.fromMajorRadiusAndMinorRadius(radius.x, radius.y).getCenterAngle(coordinates), ERROR_PERCENTAGE);
        }

        [TestCaseSource("generateEllipses")]
        public void fromMajorRadiusAndMinorRadius(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMajorRadiusAndMinorRadius", ellipse, () => Ellipse.fromMajorRadiusAndMinorRadius(ellipse.semiMajorRadius, ellipse.semiMinorRadius));
        }

        [TestCaseSource("generateEllipses")]
        public void fromMajorRadiusAndLatusRectum(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMajorRadiusAndLatusRectum", ellipse, () => Ellipse.fromMajorRadiusAndLatusRectum(ellipse.semiMajorRadius, ellipse.semiLatusRectum));
        }

        [TestCaseSource("generateEllipses")]
        public void fromMajorRadiusAndEccentricity(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMajorRadiusAndEccentricity", ellipse, () => Ellipse.fromMajorRadiusAndEccentricity(ellipse.semiMajorRadius, ellipse.eccentricity));
        }


        [TestCaseSource("generateEllipses")]
        public void fromMajorRadiusAndFoci(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMajorRadiusAndFoci", ellipse, () => Ellipse.fromMajorRadiusAndFoci(ellipse.semiMajorRadius, ellipse.foci));
        }

        [TestCaseSource("generateEllipses")]
        public void fromMajorRadiusAndApogee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMajorRadiusAndApogee", ellipse, () => Ellipse.fromMajorRadiusAndApogee(ellipse.semiMajorRadius, ellipse.apogee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromMajorRadiusAndPerigee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMajorRadiusAndPerigee", ellipse, () => Ellipse.fromMajorRadiusAndPerigee(ellipse.semiMajorRadius, ellipse.perigee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromMinorRadiusAndLatusRectum(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMinorRadiusAndLatusRectum", ellipse, () => Ellipse.fromMinorRadiusAndLatusRectum(ellipse.semiMinorRadius, ellipse.semiLatusRectum));
        }

        [TestCaseSource("generateEllipses")]
        public void fromMinorRadiusAndEccentricity(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMinorRadiusAndEccentricity", ellipse, () => Ellipse.fromMinorRadiusAndEccentricity(ellipse.semiMinorRadius, ellipse.eccentricity));
        }

        [TestCaseSource("generateEllipses")]
        public void fromMinorRadiusAndFoci(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMinorRadiusAndFoci", ellipse, () => Ellipse.fromMinorRadiusAndFoci(ellipse.semiMinorRadius, ellipse.foci));
        }

        /*
        [TestCaseSource("generateEllipses")]
        public void fromMinorRadiusAndApogee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMinorRadiusAndApogee", ellipse, () => Ellipse.fromMinorRadiusAndApogee(ellipse.semiMinorRadius, ellipse.apogee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromMinorRadiusAndPerigee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromMinorRadiusAndPerigee", ellipse, () => Ellipse.fromMinorRadiusAndPerigee(ellipse.semiMinorRadius, ellipse.perigee));
        }
        */

        [TestCaseSource("generateEllipses")]
        public void fromLatusRectumAndEccentricity(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromLatusRectumAndEccentricity", ellipse, () => Ellipse.fromLatusRectumAndEccentricity(ellipse.semiLatusRectum, ellipse.eccentricity));
        }

        /*
        [TestCaseSource("generateEllipses")]
        public void fromLatusRectumAndFoci(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromLatusRectumAndFoci", ellipse, () => Ellipse.fromLatusRectumAndFoci(ellipse.semiLatusRectum, ellipse.foci));
        }
        */

        [TestCaseSource("generateEllipses")]
        public void fromLatusRectumAndApogee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromLatusRectumAndApogee", ellipse, () => Ellipse.fromLatusRectumAndApogee(ellipse.semiLatusRectum, ellipse.apogee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromLatusRectumAndPerigee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromLatusRectumAndPerigee", ellipse, () => Ellipse.fromLatusRectumAndPerigee(ellipse.semiLatusRectum, ellipse.perigee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromEccentricityAndFoci(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            if (eccentricity > 0)
            {
                var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
                compare("fromEccentricityAndFoci", ellipse, () => Ellipse.fromEccentricityAndFoci(ellipse.eccentricity, ellipse.foci));
            }
        }

        [TestCaseSource("generateEllipses")]
        public void fromEccentricityAndApogee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromEccentricityAndApogee", ellipse, () => Ellipse.fromEccentricityAndApogee(ellipse.eccentricity, ellipse.apogee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromEccentricityAndPerigee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromEccentricityAndPerigee", ellipse, () => Ellipse.fromEccentricityAndPerigee(ellipse.eccentricity, ellipse.perigee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromFociAndApogee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromFociAndApogee", ellipse, () => Ellipse.fromFociAndApogee(ellipse.foci, ellipse.apogee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromFociAndPerigee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromFociAndPerigee", ellipse, () => Ellipse.fromFociAndPerigee(ellipse.foci, ellipse.perigee));
        }

        [TestCaseSource("generateEllipses")]
        public void fromApogeeAndPerigee(float semiMajorRadius, float eccentricity)
        {
            Helper.helper = new MockModHelper();

            var ellipse = Ellipse.fromMajorRadiusAndEccentricity(semiMajorRadius, eccentricity);
            compare("fromApogeeAndPerigee", ellipse, () => Ellipse.fromApogeeAndPerigee(ellipse.apogee, ellipse.perigee));
        }

        private void compare(Vector2 expected, Vector2 actual)
        {
            Assert.AreEqual(expected.x, actual.x, Math.Max(expected.x * ERROR_PERCENTAGE, ERROR_PERCENTAGE), "Does not match Expected (" + expected.x + "," + expected.y + ") Actual (" + actual.x + "," + actual.y + ")");
            Assert.AreEqual(expected.y, actual.y, Math.Max(expected.y * ERROR_PERCENTAGE, ERROR_PERCENTAGE), "Does not match Expected (" + expected.x + "," + expected.y + ") Actual (" + actual.x + "," + actual.y + ")");
        }

        private void compare(string name, Ellipse expected, Func<Ellipse> createEllipse)
        {
            compare($"{name} Semi-Major Radius does not Match", expected, createEllipse.Invoke(), (ellipse) => ellipse.semiMajorRadius);
            compare($"{name} Semi-Minor Radius does not Match", expected, createEllipse.Invoke(), (ellipse) => ellipse.semiMinorRadius);
            compare($"{name} Semi-Lactus Rectum does not Match", expected, createEllipse.Invoke(), (ellipse) => ellipse.semiLatusRectum);
            compare($"{name} Eccentricity does not Match", expected, createEllipse.Invoke(), (ellipse) => ellipse.eccentricity);
            compare($"{name} Foci does not Match", expected, createEllipse.Invoke(), (ellipse) => ellipse.foci);
            compare($"{name} Apogee does not Match", expected, createEllipse.Invoke(), (ellipse) => ellipse.apogee);
            compare($"{name} Perigee does not Match", expected, createEllipse.Invoke(), (ellipse) => ellipse.perigee);
        }

        private void compare(string message, Ellipse expected, Ellipse actual, Func<Ellipse, float> tester)
        {
            Assert.AreEqual(tester.Invoke(expected), tester.Invoke(actual), Math.Max(tester.Invoke(expected) * ERROR_PERCENTAGE, ERROR_PERCENTAGE), $"{message} Expected: {expected}, Actual: {actual}");
        }
    }
}
