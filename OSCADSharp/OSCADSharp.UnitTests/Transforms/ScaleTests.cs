﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSCADSharp.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp.UnitTests.Transforms
{
    [TestClass]
    public class ScaleTests
    {
        [TestMethod]
        public void Scale_TranslateRotateScaleStillYieldsCorrectPosition()
        {
            var obj = new Cube(5, 5, 20)
                   .Translate(30, 0, 0).Rotate(0, 90, 0).Scale(2, 2, 2);
            
            Assert.AreEqual(new Vector3(20, 5, -65), obj.Position());
        }

        [TestMethod]
        public void Scale_BoundsScaleWithObject()
        {
            var obj = new Cube(5, 5, 5).Scale(2, 2, 3);

            var bounds = obj.Bounds();
            Assert.AreEqual(bounds.XMax, 10);
            Assert.AreEqual(bounds.YMax, 10);
            Assert.AreEqual(bounds.ZMax, 15);

            Assert.AreEqual(bounds.XMin, 0);
            Assert.AreEqual(bounds.YMin, 0);
            Assert.AreEqual(bounds.ZMin, 0);
        }

        [TestMethod]
        public void Scale_CanBindScaleValue()
        {
            var cube = new Cube().Scale(2, 2, 2);
            var scaleVar = new Variable("scaleVar", new Vector3(5, 1, 2));

            cube.Bind("scale", scaleVar);

            string script = cube.ToString();
            Assert.IsTrue(script.Contains("v = scaleVar"));
        }

        [TestMethod]
        public void Scale_CanBindParameterizedScaleValue()
        {
            var x = new Variable("xS", 3);
            var y = new Variable("yS", 4);
            var z = new Variable("zS", 3);

            var cube = new Cube().Scale(x, y, z);

            string script = cube.ToString();
            Assert.IsTrue(script.Contains("v = [xS, yS, zS]"));
        }
    }
}
