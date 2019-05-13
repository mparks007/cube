using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolver.Enums
{
    enum Face
    {
        [Description("Upper Face")]
        Upper,
        [Description("Right Face")]
        Right,
        [Description("Down Face")]
        Down,
        [Description("Left Face")]
        Left,
        [Description("Front Face")]
        Front,
        [Description("Back Face")]
        Back
    }
}
