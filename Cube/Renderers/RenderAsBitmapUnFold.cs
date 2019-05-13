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
    class RenderAsBitmapUnFold : RenderAsBitmapBase
    {
        public RenderAsBitmapUnFold(Cube cube, int pieceSize)
            : base(cube, pieceSize) 
        {

        }

        public override void Render()
        {
            // drawing the entire left and right faces spread out flat so have to cover three full faces (left/center/right)
            int width = (cube.Size * pieceSize * 3);
            // below center, drawing the back, upper, front, and down faces unrolled so have to cover four full faces
            int height = (cube.Size * pieceSize * 4);

            if (primaryBitmap != null)
                primaryBitmap.Dispose();
            primaryBitmap = new Bitmap(width, height);

            if (maskBitmap != null)
                maskBitmap.Dispose();
            maskBitmap = new Bitmap(width, height);

            for (int z = cube.Size - 1; z >= 0; z--)
            {
                // draw back and front
                for (int x = 0; x < cube.Size; x++)
                {
                    DrawFaceAsSquare((cube.Size * pieceSize) + (x * pieceSize), ((cube.Size - 1 - z) * pieceSize), cube[z, x, 0].Faces[(int)Face.Back], z, x, 0);
                    DrawFaceAsSquare((cube.Size * pieceSize) + (x * pieceSize), (z * pieceSize) + (cube.Size * pieceSize * 2), cube[z, x, cube.Size - 1].Faces[(int)Face.Front], z, x, cube.Size - 1);
                }
                // draw left and right faces
                for (int y = 0; y < cube.Size; y++)
                {
                    DrawFaceAsSquare(((cube.Size - 1 - z) * pieceSize), (cube.Size * pieceSize) + (y * pieceSize), cube[z, 0, y].Faces[(int)Face.Left], z, 0, y);
                    DrawFaceAsSquare((cube.Size * pieceSize * 3) - ((cube.Size - z) * pieceSize), (cube.Size * pieceSize) + (y * pieceSize), cube[z, cube.Size - 1, y].Faces[(int)Face.Right], z, cube.Size - 1, y);
                }
            }
            // draw upper and down
            for (int x = 0; x < cube.Size; x++)
                for (int y = 0; y < cube.Size; y++)
                {
                    DrawFaceAsSquare((cube.Size * pieceSize) + (x * pieceSize), (cube.Size * pieceSize) + (y * pieceSize), cube[0, x, y].Faces[(int)Face.Upper], 0, x, y);
                    DrawFaceAsSquare((cube.Size * pieceSize) + (x * pieceSize), (cube.Size * pieceSize * 3) + (y * pieceSize), cube[cube.Size - 1, x, cube.Size - 1 - y].Faces[(int)Face.Down], cube.Size - 1, x, cube.Size - 1 - y);
                }
        }
    }
}
