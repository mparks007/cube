using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using CubeSolver.Core;

namespace CubeSolver.Renderers
{
    class RenderAsBitmapUglyGrid : RenderAsBitmapBase
    {
        public RenderAsBitmapUglyGrid(Cube cube, int pieceSize)
            : base(cube, pieceSize) 
        {

        }

        public override void Render()
        {
            // grid spreads out all 6 faces (pieceSize * 6) of each piece of a column on a full layer
            int width = cube.Size * (pieceSize * 6);
            int height = cube.Size * cube.Size * pieceSize;

            if (primaryBitmap != null)
                primaryBitmap.Dispose();
            primaryBitmap = new Bitmap(width, height);

            if (maskBitmap != null)
                maskBitmap.Dispose();
            maskBitmap = new Bitmap(width, height);

            int xPos = 0;
            int yPos = 0;
            for (int z = 0; z < cube.Size; z++)
                for (int x = 0; x < cube.Size; x++)
                    for (int y = 0; y < cube.Size; y++)
                    {
                        // for each layer, spread out a column as a row across then the other columns stacked below that
                        for (int f = 0; f < 6; f++)
                        {
                            xPos = (f * pieceSize) + (y * 6 * pieceSize);
                            yPos = (z * cube.Size * pieceSize) + (x * pieceSize);

                            DrawFaceAsSquare(xPos, yPos, cube[z, x, y].Faces[f], z, x, y);
                        }
                    }
        }
    }
}
