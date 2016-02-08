﻿using OSCADSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp.Transforms
{
    /// <summary>
    /// An object with rotation applied
    /// </summary>
    internal class RotatedObject : OSCADObject
    {
        /// <summary>
        /// The angle to rotate, in terms of X/Y/Z euler angles
        /// </summary>
        internal Vector3 Angle { get; set; } = new Vector3();
        private OSCADObject obj;

        /// <summary>
        /// Creates an object with rotation applied
        /// </summary>
        /// <param name="obj">The object being rotated</param>
        /// <param name="angle">The angle to rotate</param>
        internal RotatedObject(OSCADObject obj, Vector3 angle)
        {
            this.obj = obj;
            this.Angle = angle;
        }

        public override string ToString()
        {
            string rotateCommand = String.Format("rotate([{0}, {1}, {2}])",
                this.Angle.X.ToString(), this.Angle.Y.ToString(), this.Angle.Z.ToString());
            var formatter = new BlockFormatter(rotateCommand, this.obj.ToString());
            return formatter.ToString();
        }

        public override OSCADObject Clone()
        {
            return new RotatedObject(this.obj, this.Angle);
        }
    }
}
