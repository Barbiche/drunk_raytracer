using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS
{
    interface IShape
    {
        bool IsHit(Ray ray);
    }
}
