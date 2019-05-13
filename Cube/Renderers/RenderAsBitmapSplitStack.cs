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
    class RenderAsBitmapSplitStack : RenderAsBitmapBase
    {
        public RenderAsBitmapSplitStack(Cube cube, int pieceSize)
            : base(cube, pieceSize) 
        {

        }

        public override void Render()
        {
            // drawing the side edges of a layer spread out flat so we have to cover the center (size * pieceSize) plus the left and right extra width (pieceSize * 2)
            int width = (cube.Size * pieceSize) + (pieceSize * 2);
            // drawing the side edges spread out flat so have to cover the center (size * pieceSize) plus the front and back extra width plus the space between each drawn layer
            int height = (((cube.Size * pieceSize) + (pieceSize * 2)) + pieceSize) * cube.Size;

            if (primaryBitmap != null)
                primaryBitmap.Dispose();
            primaryBitmap = new Bitmap(width, height);

            if (maskBitmap != null)
                maskBitmap.Dispose();
            maskBitmap = new Bitmap(width, height);

            int xPos = 0;
            int yPos = 0;
            int spacer = 0;
            for (int z = 0; z < cube.Size; z++)
                for (int x = 0; x < cube.Size; x++)
                    for (int y = 0; y < cube.Size; y++)
                    {
                        yPos = (y * pieceSize);
                        xPos = (x * pieceSize);
                        spacer = (z * ((pieceSize * cube.Size) + (pieceSize * 2) + (pieceSize)));

                        // spread the side face colors out flat around the center
                        if (y == 0)
                            DrawFaceAsSquare(xPos + pieceSize, yPos + spacer, cube[z, x, y].Faces[(int)Face.Back], z, x, y);
                        if (x == 0)
                            DrawFaceAsSquare(xPos, yPos + pieceSize + spacer, cube[z, x, y].Faces[(int)Face.Left], z, x, y);
                        if (x == cube.Size - 1)
                            DrawFaceAsSquare(cube.Size * pieceSize + pieceSize, yPos + pieceSize + spacer, cube[z, x, y].Faces[(int)Face.Right], z, x, y);
                        if (y == cube.Size - 1)
                            DrawFaceAsSquare(xPos + pieceSize, cube.Size * pieceSize + pieceSize + spacer, cube[z, x, y].Faces[(int)Face.Front], z, x, y);

                        // show the uppor color for the upper, but show the down color for the final layer since the color above that is undefined
                        if (z == cube.Size - 1)
                            DrawFaceAsSquare(xPos + pieceSize, yPos + pieceSize + spacer, cube[z, x, y].Faces[(int)Face.Down], z, x, y);
                        else
                            DrawFaceAsSquare(xPos + pieceSize, yPos + pieceSize + spacer, cube[z, x, y].Faces[(int)Face.Upper], z, x, y);
                    }
        }
    }
}
