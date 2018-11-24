﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS.Material
{
    interface IMaterial
    {
        Vector3 GetColor(Ray ray);
    }
}
