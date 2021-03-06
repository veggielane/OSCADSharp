﻿using OSCADSharp.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp.Solids
{
    /// <summary>
    /// A Cube geometry
    /// </summary>
    public class Cube : OSCADObject
    {
        #region Attributes
        /// <summary>
        /// The Size of the cube in terms of X/Y/Z units
        /// </summary>
        public Vector3 Size { get; set; } = new Vector3(1, 1, 1);

        /// <summary>
        /// If True, the center of the cube will be at 0, 0, 0
        /// 
        /// If False (default) one corner will be centered at 0,0, 0, with the cube extending into the positive octant (positive X/Y/Z)
        /// </summary>
        public bool Center { get; set; } = false;
    
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new cube object with the default initialization values
        /// </summary>
        public Cube()
        {
        }

        /// <summary>
        /// Creates a new Cube object
        /// </summary>
        /// <param name="size">The Size of the cube in terms of X/Y/Z dimensions</param>
        /// <param name="center">Indicates whether the cube should be centered on the origin</param>
        public Cube(Vector3 size = null, bool center = false)
        {
            this.Size = size ?? new Vector3(1, 1, 1);
            this.Center = center;
        }

        /// <summary>
        /// Creates a new Cube object with Length/Width/Height
        /// </summary>
        /// <param name="length">Size on the X axis</param>
        /// <param name="width">Size on the Y axis</param>
        /// <param name="height">Size on the Z axis</param>
        /// <param name="center">Indicates whether the cube should be centered on the origin</param>
        public Cube(double length, double width, double height, bool center = false)
        {
            this.Size.X = length;
            this.Size.Y = width;
            this.Size.Z = height;

            this.Center = center;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Converts this object to an OpenSCAD script
        /// </summary>
        /// <returns>Script for this object</returns>
        public override string ToString()
        {
            return String.Format("cube(size = {0}, center = {1}); {2}", this.Size.ToString(), this.Center.ToString().ToLower(), Environment.NewLine);
        }

        /// <summary>
        /// Gets a copy of this object that is a new instance
        /// </summary>
        /// <returns></returns>
        public override OSCADObject Clone()
        {
            var clone = new Cube()
            {
                Name = this.Name,
                Size = this.Size.Clone(),
                Center = this.Center,
            };

            return clone;
        }

        /// <summary>
        /// Gets the position of this object's center (origin) in
        /// world space
        /// </summary>
        /// <returns></returns>
        public override Vector3 Position()
        {
            Vector3 position;
            if (this.Center == false)
            {
                position = new Vector3(this.Size.X / 2, this.Size.Y / 2, this.Size.Z / 2);
            }
            else
            {
                position = new Vector3();
            }

            return position;
        }

        /// <summary>
        /// Returns the approximate boundaries of this OpenSCAD object
        /// </summary>
        /// <returns></returns>
        public override Bounds Bounds()
        {
            if (Center == false)
            {
                return new Bounds(new Vector3(), new Vector3(this.Size.X, this.Size.Y, this.Size.Z));
            }
            else
            {
                return new Bounds(new Vector3(-this.Size.X / 2, -this.Size.Y / 2, -this.Size.Z / 2),
                                  new Vector3(this.Size.X / 2, this.Size.Y / 2, this.Size.Z / 2));
            }
        }
        #endregion
    }
}
