﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Reflection;
using OSCADSharp.Spatial;
using OSCADSharp.Utility;

namespace OSCADSharp.Solids
{
    /// <summary>
    /// A Sphere geometry
    /// </summary>
    public class Sphere : OSCADObject
    {
        #region Attributes
        /// <summary>
        /// This is the radius of the sphere
        /// </summary>
        public double Radius { get; set; } = 1;

        /// <summary>
        /// This is the diameter of the sphere
        /// </summary>
        public double Diameter
        {
            get { return this.Radius * 2; }
            set { this.Radius = value / 2; }
        }

        /// <summary>
        /// Minimum angle (in degrees) of each cylinder fragment.
        /// ($fa in OpenSCAD)
        /// </summary>
        public int? MinimumAngle { get; set; }

        /// <summary>
        /// Fragment size in mm
        /// ($fs in OpenSCAD)
        /// </summary>
        public int? MinimumFragmentSize { get; set; }

        /// <summary>
        /// Number of fragments in 360 degrees. Values of 3 or more override MinimumAngle and MinimumCircumferentialLength
        /// ($fn in OpenSCAD)
        /// </summary>
        public int? Resolution { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a sphere with the default initialization values
        /// </summary>
        public Sphere()
        {
        }

        /// <summary>
        /// Creates a sphere of the specified diameter
        /// </summary>
        /// <param name="diameter">Diameter of the sphere</param>
        public Sphere(double diameter)
        {
            this.Diameter = diameter;
        }        
        #endregion

        #region Overrides
        /// <summary>
        /// Converts this object to an OpenSCAD script
        /// </summary>
        /// <returns>Script for this object</returns>
        public override string ToString()
        {
            StatementBuilder sb = new StatementBuilder();
            sb.Append("sphere(");
            sb.AppendValuePairIfExists("r", this.Radius);
            sb.AppendValuePairIfExists("$fn", this.Resolution, true);
            sb.AppendValuePairIfExists("$fa", this.MinimumAngle, true);
            sb.AppendValuePairIfExists("$fs", this.MinimumFragmentSize, true);
            sb.Append(");");
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

        /// <summary>
        /// Gets a copy of this object that is a new instance
        /// </summary>
        /// <returns></returns>
        public override OSCADObject Clone()
        {
            return new Sphere()
            {
                Name = this.Name,
                Resolution = this.Resolution,
                MinimumAngle = this.MinimumAngle,
                MinimumFragmentSize = this.MinimumFragmentSize,
                Radius = this.Radius
            };
        }

        /// <summary>
        /// Gets the position of this object's center (origin) in
        /// world space
        /// </summary>
        /// <returns></returns>
        public override Vector3 Position()
        {
            return new Vector3();
        }

        /// <summary>
        /// Returns the approximate boundaries of this OpenSCAD object
        /// </summary>
        /// <returns></returns>
        public override Bounds Bounds()
        {
            return new Bounds(new Vector3(-this.Radius, -this.Radius, -this.Radius),
                              new Vector3(this.Radius, this.Radius, this.Radius));
        }
        #endregion
    }
}
