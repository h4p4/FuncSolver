using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solver.DataTypes
{
    public class FunctionalVector2
    {
        public FunctionalVector2(float x, float y, float result)
        {
            X = x; Y = y;
            Result = result;
        }
        public float X { get; set; }
        public float Y { get; set; }
        public float Result { get; set; }
    }
}
