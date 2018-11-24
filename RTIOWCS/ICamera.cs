using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS
{
    interface ICamera
    {
        Ray GetRay(float u, float v);
        Vector3 Origin { get; set; }
        Vector3 LowerLeftCorner { get; set;}
        Vector3 Horizontal { get; set; }
        Vector3 Vertical { get; set; }
    }
}
