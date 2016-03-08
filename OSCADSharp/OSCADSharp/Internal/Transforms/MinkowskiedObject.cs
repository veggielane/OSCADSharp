﻿using OSCADSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSCADSharp.Spatial;

namespace OSCADSharp.Transforms
{
    /// <summary>
    /// Creates an object that's the minkowski sum of child objects
    /// </summary>
    internal class MinkowskiedObject : MultiStatementObject
    {
        
        public MinkowskiedObject(IEnumerable<OSCADObject> children) : base("minkowski()", children)
        {
        }

        public override Vector3 Position()
        {
            throw new NotSupportedException("Position is not supported on Minkowskied objects.");
        }

        public override Bounds Bounds()
        {
            throw new NotSupportedException("Bounds is not supported on Minkowskied objects.");
        }
    }
}