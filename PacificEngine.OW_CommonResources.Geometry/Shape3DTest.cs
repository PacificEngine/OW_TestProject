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
        [Test] // Inside-out
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

        [Test] // Inside-out
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

        [Test]
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

        [Test]
        public void drawBox_LeftUp()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.left + Vector3.up, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1f * root2, -1f * root2, -1f),
                new Vector3(1f * root2, 1f * root2, -1f),
                new Vector3(-1f * root2,-1f * root2, 1f),
                new Vector3(1f * root2, 1f * root2, 1f),
                new Vector3(-1f - 1f * root2, 1f - 1f * root2, -1f),
                new Vector3(-1f + 1f * root2, 1f + 1f * root2, -1f),
                new Vector3(-1f - 1f * root2, 1f - 1f * root2, 1f),
                new Vector3(-1f + 1f * root2, 1f + 1f * root2, 1f),
            }, vertices);
        }

        [Test]
        public void drawBox_RightDown()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.right + Vector3.down, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-1f * root2, -1f * root2, -1f),
                new Vector3(1f * root2, 1f * root2, -1f),
                new Vector3(-1f * root2,-1f * root2, 1f),
                new Vector3(1f * root2, 1f * root2, 1f),
                new Vector3(1f - 1f * root2, -1f - 1f * root2, -1f),
                new Vector3(1f + 1f * root2, -1f + 1f * root2, -1f),
                new Vector3(1f - 1f * root2, -1f - 1f * root2, 1f),
                new Vector3(1f + 1f * root2, -1f + 1f * root2, 1f),
            }, vertices);
        }

        [Test]
        public void drawBox_LeftDown()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), Vector3.left + Vector3.down, new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(1f * root2, -1f * root2, -1f),
                new Vector3(-1f * root2, 1f * root2, -1f),
                new Vector3(1f * root2,-1f * root2, 1f),
                new Vector3(-1f * root2, 1f * root2, 1f),
                new Vector3(-1f - 1f * root2, -1f + 1f * root2, -1f),
                new Vector3(-1f + 1f * root2, -1f - 1f * root2, -1f),
                new Vector3(-1f - 1f * root2, -1f + 1f * root2, 1f),
                new Vector3(-1f + 1f * root2, -1f - 1f * root2, 1f),
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

        [Test] // Inside-out
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

        [Test]
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

        [Test]
        public void drawBox_RightUpForward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), new Vector3(1, 1, 1), new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-0.5f + root2,  0f + root2, -0.5f - root2),
                new Vector3( 0.5f + root2,  0f - root2,  0.5f - root2),
                new Vector3(-0.5f - root2,  0f + root2, -0.5f + root2),
                new Vector3( 0.5f - root2,  0f - root2,  0.5f + root2),
                new Vector3( 0.5f + root2,  1f + root2,  0.5f - root2),
                new Vector3( 1.5f + root2,  1f - root2,  1.5f - root2),
                new Vector3( 0.5f - root2,  1f + root2,  0.5f + root2),
                new Vector3( 1.5f - root2,  1f - root2,  1.5f + root2),
            }, vertices);
        }

        [Test]
        public void drawBox_RightUpBack()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), new Vector3(1, 1, -1), new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-0.5f + root2,  0f + root2,  0.5f + root2),
                new Vector3( 0.5f + root2,  0f - root2, -0.5f + root2),
                new Vector3(-0.5f - root2,  0f + root2,  0.5f - root2),
                new Vector3( 0.5f - root2,  0f - root2, -0.5f - root2),
                new Vector3( 0.5f + root2,  1f + root2, -0.5f + root2),
                new Vector3( 1.5f + root2,  1f - root2, -1.5f + root2),
                new Vector3( 0.5f - root2,  1f + root2, -0.5f - root2),
                new Vector3( 1.5f - root2,  1f - root2, -1.5f - root2),
            }, vertices);
        }

        [Test]
        public void drawBox_RightDownForward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), new Vector3(1, -1, 1), new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3( 0.5f + root2,  0f + root2,  0.5f - root2),
                new Vector3(-0.5f + root2,  0f - root2, -0.5f - root2),
                new Vector3( 0.5f - root2,  0f + root2,  0.5f + root2),
                new Vector3(-0.5f - root2,  0f - root2, -0.5f + root2),
                new Vector3( 1.5f + root2, -1f + root2,  1.5f - root2),
                new Vector3( 0.5f + root2, -1f - root2,  0.5f - root2),
                new Vector3( 1.5f - root2, -1f + root2,  1.5f + root2),
                new Vector3( 0.5f - root2, -1f - root2,  0.5f + root2),
            }, vertices);
        }

        [Test]
        public void drawBox_RightDownBack()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), new Vector3(1, -1, -1), new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3( 0.5f + root2,  0f + root2, -0.5f + root2),
                new Vector3(-0.5f + root2,  0f - root2,  0.5f + root2),
                new Vector3( 0.5f - root2,  0f + root2, -0.5f - root2),
                new Vector3(-0.5f - root2,  0f - root2,  0.5f - root2),
                new Vector3( 1.5f + root2, -1f + root2, -1.5f + root2),
                new Vector3( 0.5f + root2, -1f - root2, -0.5f + root2),
                new Vector3( 1.5f - root2, -1f + root2, -1.5f - root2),
                new Vector3( 0.5f - root2, -1f - root2, -0.5f - root2),
            }, vertices);
        }

        [Test]
        public void drawBox_LeftUpForward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), new Vector3(-1, 1, 1), new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3( 0.5f + root2,  0f + root2, -0.5f + root2),
                new Vector3(-0.5f + root2,  0f - root2,  0.5f + root2),
                new Vector3( 0.5f - root2,  0f + root2, -0.5f - root2),
                new Vector3(-0.5f - root2,  0f - root2,  0.5f - root2),
                new Vector3(-0.5f + root2,  1f + root2,  0.5f + root2),
                new Vector3(-1.5f + root2,  1f - root2,  1.5f + root2),
                new Vector3(-0.5f - root2,  1f + root2,  0.5f - root2),
                new Vector3(-1.5f - root2,  1f - root2,  1.5f - root2),
            }, vertices);
        }

        [Test]
        public void drawBox_LeftUpBack()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), new Vector3(-1, 1, -1), new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3( 0.5f + root2,  0f + root2,  0.5f - root2),
                new Vector3(-0.5f + root2,  0f - root2, -0.5f - root2),
                new Vector3( 0.5f - root2,  0f + root2,  0.5f + root2),
                new Vector3(-0.5f - root2,  0f - root2, -0.5f + root2),
                new Vector3(-0.5f + root2,  1f + root2, -0.5f - root2),
                new Vector3(-1.5f + root2,  1f - root2, -1.5f - root2),
                new Vector3(-0.5f - root2,  1f + root2, -0.5f + root2),
                new Vector3(-1.5f - root2,  1f - root2, -1.5f + root2),
            }, vertices);
        }

        [Test]
        public void drawBox_LeftDownForward()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), new Vector3(-1, -1, 1), new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-0.5f + root2,  0f + root2,  0.5f + root2),
                new Vector3( 0.5f + root2,  0f - root2, -0.5f + root2),
                new Vector3(-0.5f - root2,  0f + root2,  0.5f - root2),
                new Vector3( 0.5f - root2,  0f - root2, -0.5f - root2),
                new Vector3(-0.5f + root2, -1f - root2,  0.5f + root2),
                new Vector3(-1.5f + root2, -1f + root2,  1.5f + root2),
                new Vector3(-0.5f - root2, -1f - root2,  0.5f - root2),
                new Vector3(-1.5f - root2, -1f + root2,  1.5f - root2),
            }, vertices);
        }

        [Test]
        public void drawBox_LeftDownBack()
        {
            var shape = new Shapes3D();
            shape.drawBox(Vector3.zero, new Vector2(2f, 2f), new Vector3(-1, -1, -1), new Vector2(2f, 2f), 0f, 0f);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(8, vertices.Length);
            matches(new Vector3[] {
                new Vector3(-0.5f + root2,  0f + root2, -0.5f - root2),
                new Vector3( 0.5f + root2,  0f - root2,  0.5f - root2),
                new Vector3(-0.5f - root2,  0f + root2, -0.5f + root2),
                new Vector3( 0.5f - root2,  0f - root2,  0.5f + root2),
                new Vector3(-1.5f + root2, -1f + root2, -1.5f - root2),
                new Vector3(-0.5f + root2, -1f - root2, -0.5f - root2),
                new Vector3(-1.5f - root2, -1f + root2, -1.5f + root2),
                new Vector3(-0.5f - root2, -1f - root2, -0.5f + root2),
            }, vertices);
        }

        //var angles1z = Coordinates.angleXYZ(Vector3.forward, difference); /* Works: Back, Down, Forward, Left, Right, Up, DownForward, UpForward */
        //var angles1y = Coordinates.angleXYZ(Vector3.up, difference); /* Works: DownBack, DownForward */
        //var angles1x = Coordinates.angleXYZ(Vector3.right, difference);  /* Works: RightBack, RightForward */
        //var angles2z = new Vector3(angles1z.x, Math.Abs(angles1z.y)); /* Works: Back, Down, Forward, Left, Right, Up, DownForward, UpForward, RightBack, RightForward */
        //var angles3z = Coordinates.angleXYZ(difference, Vector3.forward); /* Works: Back, Down, Forward, Left, Right, Up, DownBack, LeftBack, RightBack, RightForward, UpBack  */
        //var angles3y = Coordinates.angleXYZ(difference, Vector3.up); /* Works: UpBack, UpForward */
        //var angles3x = Coordinates.angleXYZ(difference, Vector3.right); /* Works: LeftBack, LeftForward,  */
        //var angles4 = new Vector3(angles1z.x, angles3z.y); /* Works: Back, Down, Forward, Left, Right, Up, DownForward, UpForward, LeftBack, LeftForward, RightBack, RightForward */
        //var angles5 = angles3z + angles3x; /* Works: Left, Right, LeftDown, LeftUp, RightDown, RightUp */
        //var angles6 = new Vector3(angles1z.x, angles3z.y, angles3y.z); /* Works: Back, Down, Forward, Up, DownBack, UpForward */
        //var angles7 = new Vector3(angles1y.x, angles3z.y); /* Works: Left, Right, DownBack, UpBack */
        //var angles8z = Coordinates.angleXYZ(Vector3.back, difference); /* Works: Back, Down, Forward, Left, Right, Up, UpBack, DownBack  */
        //var angles8y = Coordinates.angleXYZ(Vector3.down, difference); /* Works: UpBack, UpForward */
        //var angles8x = Coordinates.angleXYZ(Vector3.left, difference); /* Works: LeftBack, LeftForward,  */

        /*Boxes with compass
            coordinates.drawBox(Vector3.one, new Vector2(0.125f, 0.125f), Vector3.one + Vector3.right, new Vector2(0.125f, 0.125f), 0f, 0f);
            coordinates.drawBox(Vector3.one, new Vector2(0.50f, 0.50f), Vector3.one + Vector3.up, new Vector2(0.50f, 0.50f), 0f, 0f);
            coordinates.drawBox(Vector3.one, new Vector2(0.25f, 0.25f), Vector3.one + Vector3.forward, new Vector2(0.25f, 0.25f), 0f, 0f);

            // Q1 = Right, Up, Forward
            // Q2 = Right, Up, Back
            // Q3 = Right, Down, Forward
            // Q4 = Left, Up, Forward
            // Q5 = Right, Down, Back    = Q4
            // Q6 = Left, Up, Back       = Q3
            // Q7 = Left, Down, Forward  = Q2
            // Q8 = Left, Down, Back     = Q1
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.right, new Vector2(0.25f, 0.4f), 0f, 0f); // Inside -out
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.left, new Vector2(0.25f, 0.4f), 0f, 0f); // Inside -out
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.up, new Vector2(0.25f, 0.4f), 0f, 0f);
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.down, new Vector2(0.25f, 0.4f), 0f, 0f);
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.forward, new Vector2(0.25f, 0.4f), 0f, 0f);
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.back, new Vector2(0.25f, 0.4f), 0f, 0f);

            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.forward + Vector3.right, new Vector2(0.25f, 0.4f), 0f, 0f);// Q1|Q3 
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.back + Vector3.left, new Vector2(0.25f, 0.4f), 0f, 0f);    // Q1|Q3 (Q6|Q8)
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.back + Vector3.right, new Vector2(0.25f, 0.4f), 0f, 0f);   // Q2|Q4 (Q2|Q5)
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.up + Vector3.back, new Vector2(0.25f, 0.4f), 0f, 0f);      // Q2|Q3 (Q2|Q6)
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.down + Vector3.back, new Vector2(0.25f, 0.4f), 0f, 0f);    // Q1|Q4 (Q5|Q8)
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.down + Vector3.forward, new Vector2(0.25f, 0.4f), 0f, 0f); // Q2|Q3 (Q3|Q7)
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.up + Vector3.forward, new Vector2(0.25f, 0.4f), 0f, 0f);   // Q1|Q4
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.up + Vector3.back, new Vector2(0.25f, 0.4f), 0f, 0f);      // Q2|Q3 (Q2|Q6)
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.forward + Vector3.left, new Vector2(0.25f, 0.4f), 0f, 0f); // Q2|Q4 (Q4|Q7)  Inside-out
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.up + Vector3.left, new Vector2(0.25f, 0.4f), 0f, 0f);   // Q3|Q4 (Q4|Q6)
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.up + Vector3.right, new Vector2(0.25f, 0.4f), 0f, 0f);  // Q1|Q2
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.down + Vector3.left, new Vector2(0.25f, 0.4f), 0f, 0f); // Q1|Q2 (Q7|Q8)
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), Vector3.zero + Vector3.down + Vector3.right, new Vector2(0.25f, 0.4f), 0f, 0f);// Q3|Q4 (Q3|Q5)
            
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), new Vector3(1, 1, 1), new Vector2(0.25f, 0.4f), 0f, 0f);    // Q1 // Broken
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), new Vector3(1, 1, -1), new Vector2(0.25f, 0.4f), 0f, 0f);   // Q2
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), new Vector3(1, -1, 1), new Vector2(0.25f, 0.4f), 0f, 0f);   // Q3
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), new Vector3(-1, 1, 1), new Vector2(0.25f, 0.4f), 0f, 0f);   // Q4
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), new Vector3(1, -1, -1), new Vector2(0.25f, 0.4f), 0f, 0f);  // Q5
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), new Vector3(-1, 1, -1), new Vector2(0.25f, 0.4f), 0f, 0f);  // Q6
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), new Vector3(-1, -1, 1), new Vector2(0.25f, 0.4f), 0f, 0f);  // Q7
            coordinates.drawBox(Vector3.zero, new Vector2(0.25f, 0.25f), new Vector3(-1, -1, -1), new Vector2(0.25f, 0.4f), 0f, 0f); // Q8 // Broken






            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.right, 0.25f, 0.25f, 25);
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.left, 0.25f, 0.25f, 25);
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.up, 0.25f, 0.25f, 25);
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.down, 0.25f, 0.25f, 25);
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.forward, 0.25f, 0.25f, 25);
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.back, 0.25f, 0.25f, 25);

            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.forward + Vector3.right, 0.25f, 0.25f, 25);// Q1|Q3 
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.back + Vector3.left, 0.25f, 0.25f, 25);    // Q1|Q3 (Q6|Q8)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.back + Vector3.right, 0.25f, 0.25f, 25);   // Q2|Q4 (Q2|Q5)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.up + Vector3.back, 0.25f, 0.25f, 25);      // Q2|Q3 (Q2|Q6)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.down + Vector3.back, 0.25f, 0.25f, 25);    // Q1|Q4 (Q5|Q8)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.down + Vector3.forward, 0.25f, 0.25f, 25); // Q2|Q3 (Q3|Q7)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.up + Vector3.forward, 0.25f, 0.25f, 25);   // Q1|Q4
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.up + Vector3.back, 0.25f, 0.25f, 25);      // Q2|Q3 (Q2|Q6)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.forward + Vector3.left, 0.25f, 0.25f, 25); // Q2|Q4 (Q4|Q7)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.up + Vector3.left, 0.25f, 0.25f, 25);   // Q3|Q4 (Q4|Q6)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.up + Vector3.right, 0.25f, 0.25f, 25);  // Q1|Q2
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.down + Vector3.left, 0.25f, 0.25f, 25); // Q1|Q2 (Q7|Q8)
            coordinates.drawCylinder(Vector3.zero, Vector3.zero + Vector3.down + Vector3.right, 0.25f, 0.25f, 25);// Q3|Q4 (Q3|Q5)

            coordinates.drawCylinder(Vector3.zero, new Vector3(1, 1, 1), 0.25f, 0.25f, 25);    // Q1 // Broken
            coordinates.drawCylinder(Vector3.zero, new Vector3(1, 1, -1), 0.25f, 0.25f, 25);   // Q2
            coordinates.drawCylinder(Vector3.zero, new Vector3(1, -1, 1), 0.25f, 0.25f, 25);   // Q3
            coordinates.drawCylinder(Vector3.zero, new Vector3(-1, 1, 1), 0.25f, 0.25f, 25);   // Q4
            coordinates.drawCylinder(Vector3.zero, new Vector3(1, -1, -1), 0.25f, 0.25f, 25);  // Q5
            coordinates.drawCylinder(Vector3.zero, new Vector3(-1, 1, -1), 0.25f, 0.25f, 25);  // Q6
            coordinates.drawCylinder(Vector3.zero, new Vector3(-1, -1, 1), 0.25f, 0.25f, 25);  // Q7
            coordinates.drawCylinder(Vector3.zero, new Vector3(-1, -1, -1), 0.25f, 0.25f, 25); // Q8 // Broken
        */

        [Test]
        public void drawSphere_1Level()
        {
            var shape = new Shapes3D();
            shape.drawSphere(Vector3.zero, 1f, 9);

            var vertices = shape.vertices;
            var root2 = 1f / (float)Math.Sqrt(2);

            Assert.AreEqual(6, vertices.Length);
            matches(new Vector3[] {
                new Vector3(0.1044484f, 0.18091f, 0.97793777f),
                new Vector3(-0.2088969f, 0f, 0.97793777f),
                new Vector3(0.1044484f, -0.18091f, 0.97793777f),
                new Vector3(0.2088969f, 0, -0.97793777f),
                new Vector3(0.1044484f, 0.18091f, -0.97793777f),
                new Vector3(0.1044484f, -0.18091f, -0.97793777f),
            }, vertices);
        }

        private void matches(Vector3[] expected, Vector3[] actual)
        {
            foreach (Vector3 a in actual)
            {
                contains(expected, a);
            }
            foreach (Vector3 e in expected)
            {
                contains(actual, e);
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