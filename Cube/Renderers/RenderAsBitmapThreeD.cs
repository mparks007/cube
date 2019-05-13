using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using CubeSolver.Core;
using CubeSolver.Enums;

namespace CubeSolver.Renderers
{
    class RenderAsBitmapThreeD : RenderAsBitmapBase
    {
        public RenderAsBitmapThreeD(Cube cube, int pieceSize)
            : base(cube, pieceSize) 
        {

        }

        public override void Render()
        {
            // drawing the entire left and right faces as angled and the center and back as a square
            int width = (cube.Size * pieceSize * 4);
            // drawing the upper and down faces as angled and the front as a square
            int height = (cube.Size * pieceSize * 3);

            if (primaryBitmap != null)
                primaryBitmap.Dispose();
            primaryBitmap = new Bitmap(width, height);

            if (maskBitmap != null)
                maskBitmap.Dispose();
            maskBitmap = new Bitmap(width, height);

            // draw back and front
            for (int z = 0; z < cube.Size; z++)
            {
                for (int x = 0; x < cube.Size; x++)
                {
                    DrawFaceAsSquare((int)(cube.Size * pieceSize * 1.7) + (x * pieceSize) + (cube.Size * pieceSize), (z * pieceSize), cube[z, x, 0].Faces[(int)Face.Back], z, x, 0);
                    DrawFaceAsSquare((cube.Size * pieceSize) + (x * pieceSize), (cube.Size * pieceSize) + (z * pieceSize), cube[z, x, cube.Size - 1].Faces[(int)Face.Front], z, x, cube.Size - 1);
                }
            }
            
            // left and right face
            for (int y = cube.Size - 1; y >= 0; y--)
            {
                for (int z = 0; z < cube.Size; z++)
                {

                    DrawFaceAsParellelogram((int)(cube.Size * pieceSize / 3) + (int)(y * pieceSize * .5), (cube.Size * pieceSize) + (z * pieceSize) - (y * pieceSize / 2), cube[z, 0, cube.Size - 1 - y].Faces[(int)Face.Left], z, 0, cube.Size - 1 - y, isVertical: true);
                    DrawFaceAsParellelogram((cube.Size * pieceSize * 2) + (int)(y * pieceSize * .5), (cube.Size * pieceSize) + (z * pieceSize) - (y * pieceSize / 2), cube[z, cube.Size - 1, cube.Size - 1 - y].Faces[(int)Face.Right], z, cube.Size - 1, cube.Size - 1 - y, isVertical: true);
                }
            }

            // draw upper and down
            for (int x = 0; x < cube.Size; x++)
                for (int y = cube.Size - 1; y >= 0; y--)
                {
                    DrawFaceAsParellelogram((cube.Size * pieceSize) + (int)(x * pieceSize) + (int)(y * pieceSize * .5), (cube.Size * pieceSize - (int)(pieceSize * .5)) - (int)(y * pieceSize * .5), cube[0, x, cube.Size - 1 - y].Faces[(int)Face.Upper], 0, x, cube.Size - 1 - y);
                    DrawFaceAsParellelogram((cube.Size * pieceSize) + (int)(x * pieceSize) + (int)(y * pieceSize * .5), (int)(cube.Size * pieceSize * 2.7 - (int)(pieceSize * .5)) - (int)(y * pieceSize * .5), cube[cube.Size - 1, x, cube.Size - 1 - y].Faces[(int)Face.Down], cube.Size - 1, x, cube.Size - 1 - y);
                }
        }
    }
}
