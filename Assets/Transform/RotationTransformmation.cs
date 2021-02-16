using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TransformTest
{

    public class RotationTransformmation : Transformation
    {
        public Vector3 ratation;

        public override Vector3 Apply(Vector3 point)
        {
            float radX = ratation.x * Mathf.Deg2Rad;
            float radY = ratation.y * Mathf.Deg2Rad;
            float radZ = ratation.z * Mathf.Deg2Rad;

            float sinX = Mathf.Sin(radX);
            float cosX = Mathf.Cos(radX);
            float sinY = Mathf.Sin(radY);
            float cosY = Mathf.Cos(radY);
            float sinZ = Mathf.Sin(radZ);
            float cosZ = Mathf.Cos(radZ);

            Vector3 xAxis = new Vector3(
                cosY*cosZ,
                cosX*sinZ + sinX*sinY*cosZ,
                sinX*sinZ - cosX*sinY*cosZ);
            Vector3 yAxis = new Vector3(
                -cosY * sinZ,
                cosX * cosZ - sinX * sinY * sinZ,
                sinX * cosZ + cosX * sinY * sinZ);
            Vector3 zAxis = new Vector3(
                sinY,
                -sinX * cosY,
                cosX * cosY);
            return xAxis * point.x + yAxis * point.y + zAxis * point.z;
        }

        // 绕z轴旋转公式
        public Vector3 ApplyZ(Vector3 point)
        {
            float radZ = ratation.z * Mathf.Deg2Rad;
            float sinZ = Mathf.Sin(radZ);
            float cosZ = Mathf.Cos(radZ);

            return new Vector3(
                point.x *cosZ - point.y*sinZ,
                point.x*sinZ + point.y*cosZ,
                point.z);
        }
    }
}
