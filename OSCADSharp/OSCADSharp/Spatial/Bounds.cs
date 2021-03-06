﻿using OSCADSharp.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp.Spatial
{
    /// <summary>
    /// A set of boundaries
    /// </summary>
    public class Bounds
    {
        /// <summary>
        /// Creates a set of boundaries with the corners specified 
        /// to define its extremities
        /// </summary>
        /// <param name="bottomLeft"></param>
        /// <param name="topRight"></param>
        public Bounds(Vector3 bottomLeft, Vector3 topRight)
        {
            this.BottomLeft = bottomLeft;
            this.TopRight = topRight;
        }

        #region Public Properties
        /// <summary>
        /// Represents the top-right corner of the bounds (prior to any transforms)
        /// </summary>
        public Vector3 TopRight { get; private set; }

        /// <summary>
        /// Represents the bottom-left corner of the bounds  (prior to any transforms)
        /// </summary>
        public Vector3 BottomLeft { get; private set; }

        /// <summary>
        /// X position with the greatest value
        /// </summary>
        public double XMax { get { return TopRight.X > BottomLeft.X ? TopRight.X : BottomLeft.X; } }

        /// <summary>
        /// X position with the smallest value
        /// </summary>
        public double XMin { get { return TopRight.X < BottomLeft.X ? TopRight.X : BottomLeft.X; } }

        /// <summary>
        /// Y position with the greatest value
        /// </summary>
        public double YMax { get { return TopRight.Y > BottomLeft.Y ? TopRight.Y : BottomLeft.Y; } }

        /// <summary>
        /// Y position with the smallest value
        /// </summary>
        public double YMin { get { return TopRight.Y < BottomLeft.Y ? TopRight.Y : BottomLeft.Y; } }

        /// <summary>
        /// Z position with the greatest value
        /// </summary>
        public double ZMax { get { return TopRight.Z > BottomLeft.Z ? TopRight.Z : BottomLeft.Z; } }

        /// <summary>
        /// Z position with the smallest value
        /// </summary>
        public double ZMin { get { return TopRight.Z < BottomLeft.Z ? TopRight.Z : BottomLeft.Z; } }

        /// <summary>
        /// Size on the X axis
        /// </summary>
        public double Length { get { return this.XMax - this.XMin; } }

        /// <summary>
        /// Size on the Y axis
        /// </summary>
        public double Width { get { return this.YMax - this.YMin; } }

        /// <summary>
        /// Size on the Z axis
        /// </summary>
        public double Height { get { return this.ZMax - this.ZMin; } }
        #endregion

        #region Overrides
        /// <summary>
        /// Compares a set of bounds to another object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == this.GetHashCode();
        }

        /// <summary>
        /// Gets a hashcode based on the string representation of the vectors
        /// that make up this set of bounds
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return String.Format("TR: {0}, BL: {1}", this.TopRight.ToString(), this.BottomLeft.ToString()).GetHashCode();
        }
        #endregion
    }
}
