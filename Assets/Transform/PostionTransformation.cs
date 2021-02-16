using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TransformTest
{
    public class PostionTransformation : Transformation
    {
        public Vector3 position;

        public override Vector3 Apply(Vector3 point)
        {
            return point + position;
        }
    }
}


