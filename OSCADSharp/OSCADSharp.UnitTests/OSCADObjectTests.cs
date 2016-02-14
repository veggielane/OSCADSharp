﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSCADSharp.Solids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp.UnitTests
{
    [TestClass]
    public class OSCADObjectTests
    {
        [TestMethod]
        public void OSCADObject_ChildrenForSimpleStructureYieldsAllChildren()
        {
            var cube = new Cube();
            var translatedCube = cube.Translate(1, 2, 5);

            //Should contain both translation and Cube
            var coloredTranslatedCube = translatedCube.Color("Red");
            List<OSCADObject> expectedChildren = new List<OSCADObject>() { cube, translatedCube };

            var children = coloredTranslatedCube.Children();

            Assert.IsTrue(children.Contains(cube));
            Assert.IsTrue(children.Contains(translatedCube));
            Assert.IsFalse(children.Contains(coloredTranslatedCube));
        }

        [TestMethod]
        public void OSCADObject_ClonesContainChildren()
        {
            var text = new Text3D("Hi").Rotate(90, 0, 0);

            var clone = text.Clone();

            //Clone has a child, and it should be the same thing
            Assert.IsTrue(clone.Children().Count() == 1);
            Assert.IsTrue(clone.Children().FirstOrDefault().GetType() == text.Children().FirstOrDefault().GetType());

            //But the child should be a different instance
            Assert.IsFalse(clone.Children().FirstOrDefault() == text.Children().FirstOrDefault());
        }

        [TestMethod]
        public void OSCADObject_MimickedObjectHasSameTransform()
        {
            var cube = new Cube(null, true).Translate(10, 0, 5);
            var sphere = new Sphere().Mimic(cube);

            Assert.IsTrue(sphere.GetType() == cube.GetType());
            Assert.IsTrue(cube.ToString().StartsWith("translate("));
            Assert.IsTrue(sphere.ToString().StartsWith("translate("));
        }

        [TestMethod]
        public void OSCADObject_MimicTakesMultipleTransformsFromObject()
        {
            var cube = new Cube(null, true)
                .Translate(10, 0, 5).Rotate(0, 30, 0).Scale(1, 1.5, 1);
            var sphere = new Sphere().Mimic(cube);


            Assert.IsTrue(sphere.GetType() == cube.GetType());
            var mimicedChildren = sphere.Children();

            Assert.IsTrue(mimicedChildren.ElementAt(0).ToString().StartsWith("rotate("));
            Assert.IsTrue(mimicedChildren.ElementAt(1).ToString().StartsWith("translate("));
            Assert.IsTrue(mimicedChildren.ElementAt(2).ToString().StartsWith("sphere("));
        }

        [TestMethod]
        public void OSCADObject_MimicDoesNothingOnObjectWithNoTransforms()
        {
            var cube = new Cube(null, true);
            var sphere = new Sphere().Mimic(cube);

            Assert.IsFalse(sphere.GetType() == cube.GetType());
            Assert.AreEqual(0, sphere.Children().Count());
        }
    }
}