using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacificEngine.OW_CommonResources.Geometry
{
    [TestFixture]
    public class Shape3DTest
    {
        [Test]
        public void drawBox_Right()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.right, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(0, -1, -1),
                new Vector3(0, 1, -1),
                new Vector3(0, -1, 1),
                new Vector3(0, 1, 1),
                new Vector3(1, -1, -1),
                new Vector3(1, 1, -1),
                new Vector3(1, -1, 1),
                new Vector3(1, 1, 1),
            }, vertices);
        }

        [Test]
        public void drawBox_Left()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.left, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(0, -1, -1),
                new Vector3(0, 1, -1),
                new Vector3(0, -1, 1),
                new Vector3(0, 1, 1),
                new Vector3(-1, -1, -1),
                new Vector3(-1, 1, -1),
                new Vector3(-1, -1, 1),
                new Vector3(-1, 1, 1),
            }, vertices);
        }

        [Test]
        public void drawBox_Up()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.up, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1, 0, -1),
                new Vector3(1, 0, -1),
                new Vector3(-1, 0, 1),
                new Vector3(1, 0, 1),
                new Vector3(-1, 1, -1),
                new Vector3(1, 1, -1),
                new Vector3(-1, 1, 1),
                new Vector3(1, 1, 1),
            }, vertices);
        }

        [Test]
        public void drawBox_Down()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.down, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1, 0, -1),
                new Vector3(1, 0, -1),
                new Vector3(-1, 0, 1),
                new Vector3(1, 0, 1),
                new Vector3(-1, -1, -1),
                new Vector3(1, -1, -1),
                new Vector3(-1, -1, 1),
                new Vector3(1, -1, 1),
            }, vertices);
        }

        [Test]
        public void drawBox_Forward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.forward, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1, -1, 0),
                new Vector3(1, -1, 0),
                new Vector3(-1, 1, 0),
                new Vector3(1, 1, 0),
                new Vector3(-1, -1, 1),
                new Vector3(1, -1, 1),
                new Vector3(-1, 1, 1),
                new Vector3(1, 1, 1)
            }, vertices);
        }

        [Test]
        public void drawBox_Back()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.back, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1, -1, 0),
                new Vector3(1, -1, 0),
                new Vector3(-1, 1, 0),
                new Vector3(1, 1, 0),
                new Vector3(-1, -1, -1),
                new Vector3(1, -1, -1),
                new Vector3(-1, 1, -1),
                new Vector3(1, 1, -1)
            }, vertices);
        }

        //[Test]
        public void drawBox_RightUp()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.right + Vector3.up, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(1f * root2, -1f * root2, -1f),
                new Vector3(-1f * root2, 1f * root2, -1f),
                new Vector3(1f * root2,-1f * root2, 1f),
                new Vector3(-1f * root2, 1f * root2, 1f),
                new Vector3(1f - 1f * root2, 1f + 1f * root2, -1f),
                new Vector3(1f + 1f * root2, 1f - 1f * root2, -1f),
                new Vector3(1f - 1f * root2, 1f + 1f * root2, 1f),
                new Vector3(1f + 1f * root2, 1f - 1f * root2, 1f),
            }, vertices);
        }

        //[Test]
        public void drawBox_LeftUp()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.left + Vector3.up, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(1f * root2, -1f * root2, -1f),
                new Vector3(-1f * root2, 1f * root2, -1f),
                new Vector3(1f * root2,-1f * root2, 1f),
                new Vector3(-1f * root2, 1f * root2, 1f),
                new Vector3(1f - 1f * root2, 1f + 1f * root2, -1f),
                new Vector3(1f + 1f * root2, 1f - 1f * root2, -1f),
                new Vector3(1f - 1f * root2, 1f + 1f * root2, 1f),
                new Vector3(1f + 1f * root2, 1f - 1f * root2, 1f),
            }, vertices);
        }

        //[Test]
        public void drawBox_RightDown()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.right + Vector3.down, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(1f * root2, -1f * root2, -1f),
                new Vector3(-1f * root2, 1f * root2, -1f),
                new Vector3(1f * root2,-1f * root2, 1f),
                new Vector3(-1f * root2, 1f * root2, 1f),
                new Vector3(1f - 1f * root2, 1f + 1f * root2, -1f),
                new Vector3(1f + 1f * root2, 1f - 1f * root2, -1f),
                new Vector3(1f - 1f * root2, 1f + 1f * root2, 1f),
                new Vector3(1f + 1f * root2, 1f - 1f * root2, 1f),
            }, vertices);
        }

        //[Test]
        public void drawBox_LeftDown()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.left + Vector3.down, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(0, -1, 1),
                new Vector3(-1f * root2, 1f * root2, -1f),
                new Vector3(1f * root2,-1f * root2, 1f),
                new Vector3(-1f * root2, 1f * root2, 1f),
                new Vector3(1f - 1f * root2, 1f + 1f * root2, -1f),
                new Vector3(1f + 1f * root2, 1f - 1f * root2, -1f),
                new Vector3(1f - 1f * root2, 1f + 1f * root2, 1f),
                new Vector3(1f + 1f * root2, 1f - 1f * root2, 1f),
            }, vertices);
        }

        [Test]
        public void drawBox_RightForward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.right + Vector3.forward, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(1f * root2, -1f, -1f * root2),
                new Vector3(-1f * root2, -1f, 1f * root2),
                new Vector3(1f * root2, 1f, -1f * root2),
                new Vector3(-1f * root2, 1f, 1f * root2),
                new Vector3(1f - 1f * root2, -1f, 1f + 1f * root2),
                new Vector3(1f + 1f * root2, -1f, 1f - 1f * root2),
                new Vector3(1f - 1f * root2, 1f, 1f + 1f * root2),
                new Vector3(1f + 1f * root2, 1f, 1f - 1f * root2),
            }, vertices);
        }

        [Test]
        public void drawBox_LeftForward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.left + Vector3.forward, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(1f * root2, -1f, 1f * root2),
                new Vector3(1f * root2, 1f, 1f * root2),
                new Vector3(-1f * root2, 1f, -1f * root2),
                new Vector3(-1f * root2, -1f, -1f * root2),
                new Vector3(-1f + 1f * root2, -1f, 1f + 1f * root2),
                new Vector3(-1f + 1f * root2, 1f, 1f + 1f * root2),
                new Vector3(-1f - 1f * root2, 1f, 1f - 1f * root2),
                new Vector3(-1f -1f * root2, -1f, 1f - 1f * root2),
            }, vertices);
        }

        [Test] // Inside-out
        public void drawBox_RightBack()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.right + Vector3.back, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(1f * root2, -1f, 1f * root2),
                new Vector3(1f * root2, 1f, 1f * root2),
                new Vector3(-1f * root2, 1f, -1f * root2),
                new Vector3(-1f * root2, -1f, -1f * root2),
                new Vector3(1f + 1f * root2, -1f, -1f + 1f * root2),
                new Vector3(1f + 1f * root2, 1f, -1f + 1f * root2),
                new Vector3(1f - 1f * root2, 1f, -1f - 1f * root2),
                new Vector3(1f -1f * root2, -1f, -1f - 1f * root2),
            }, vertices);
        }

        [Test]
        public void drawBox_LeftBack()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.left + Vector3.back, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(1f * root2, -1f, -1f * root2),
                new Vector3(-1f * root2, -1f, 1f * root2),
                new Vector3(1f * root2, 1f, -1f * root2),
                new Vector3(-1f * root2, 1f, 1f * root2),
                new Vector3(-1f - 1f * root2, -1f, -1f + 1f * root2),
                new Vector3(-1f + 1f * root2, -1f, -1f - 1f * root2),
                new Vector3(-1f - 1f * root2, 1f, -1f + 1f * root2),
                new Vector3(-1f + 1f * root2, 1f, -1f - 1f * root2),
            }, vertices);
        }

        [Test]
        public void drawBox_UpForward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.up + Vector3.forward, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1f, 1f * root2, -1f * root2),
                new Vector3(-1f, -1f * root2, 1f * root2),
                new Vector3(1f, 1f * root2, -1f * root2),
                new Vector3(1f, -1f * root2, 1f * root2),
                new Vector3(-1f, 1f - 1f * root2, 1f + 1f * root2),
                new Vector3(-1f, 1f + 1f * root2, 1f - 1f * root2),
                new Vector3(1f, 1f - 1f * root2, 1f + 1f * root2),
                new Vector3(1f, 1f + 1f * root2, 1f - 1f * root2),
            }, vertices);
        }

        [Test]
        public void drawBox_DownForward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.down + Vector3.forward, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1f, -1f * root2, -1f * root2),
                new Vector3(-1f, 1f * root2, 1f * root2),
                new Vector3(1f, -1f * root2, -1f * root2),
                new Vector3(1f, 1f * root2, 1f * root2),
                new Vector3(-1f, -1f - 1f * root2, 1f - 1f * root2),
                new Vector3(-1f, -1f + 1f * root2, 1f + 1f * root2),
                new Vector3(1f, -1f - 1f * root2, 1f - 1f * root2),
                new Vector3(1f, -1f + 1f * root2, 1f + 1f * root2),
            }, vertices);
        }

        [Test]
        public void drawBox_UpBack()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.up + Vector3.back, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1f, -1f * root2, -1f * root2),
                new Vector3(-1f, 1f * root2, 1f * root2),
                new Vector3(1f, -1f * root2, -1f * root2),
                new Vector3(1f, 1f * root2, 1f * root2),
                new Vector3(-1f, 1f - 1f * root2, -1f - 1f * root2),
                new Vector3(-1f, 1f + 1f * root2, -1f + 1f * root2),
                new Vector3(1f, 1f - 1f * root2, -1f - 1f * root2),
                new Vector3(1f, 1f + 1f * root2, -1f + 1f * root2),
            }, vertices);
        }

        [Test]
        public void drawBox_DownBack()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.down + Vector3.back, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1f, 1f * root2, -1f * root2),
                new Vector3(-1f, -1f * root2, 1f * root2),
                new Vector3(1f, 1f * root2, -1f * root2),
                new Vector3(1f, -1f * root2, 1f * root2),
                new Vector3(-1f, -1f - 1f * root2, -1f + 1f * root2),
                new Vector3(-1f, -1f + 1f * root2, -1f - 1f * root2),
                new Vector3(1f, -1f - 1f * root2, -1f + 1f * root2),
                new Vector3(1f, -1f + 1f * root2, -1f - 1f * root2),
            }, vertices);
        }

        private void matches(Vector3[] expected, Vector3[] actual)
        {
            foreach (Vector3 a in actual)
            {
                contains(expected, a);
            }
        }

        private void contains(Vector3[] expected, Vector3 actual)
        {
            foreach (Vector3 expect in expected)
            {
                if (expect == actual)
                {
                    return;
                }
            }
            Assert.Fail("Could not find (" + actual.x + "," + actual.y + "," + actual.z + ")");
        }

        private void compare(Vector3 expected, Vector3 actual)
        {
            Assert.AreEqual(expected.x, actual.x, 0.05f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.y, actual.y, 0.05f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
            Assert.AreEqual(expected.z, actual.z, 0.05f, "Does not match Expected (" + expected.x + "," + expected.y + "," + expected.z + ") Actual (" + actual.x + "," + actual.y + "," + actual.z + ")");
        }
    }
}