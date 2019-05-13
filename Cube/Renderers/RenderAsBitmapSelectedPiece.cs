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
    class RenderAsBitmapSelectedPiece : RenderAsBitmapBase
    {
        public RenderAsBitmapSelectedPiece(Cube cube, int pieceSize, int width, int height)
            : base(cube, pieceSize)
        {
            if (primaryBitmap != null)
                primaryBitmap.Dispose();

            primaryBitmap = new Bitmap(width, height);
        }

        public override void Render()
        {
            Piece selectedPiece = cube.SelectedPiece;

            if (selectedPiece != null)
            {
                DrawFaceAsSquare(80, 5, selectedPiece.Faces[(int)Face.Back], 0, 0, 0);
                DrawFaceAsParellelogram(10, 30, selectedPiece.Faces[(int)Face.Left], 0, 0, 0, isVertical: true);
                DrawFaceAsParellelogram(30, 15, selectedPiece.Faces[(int)Face.Upper], 0, 0, 0);
                DrawFaceAsSquare(30, 30, selectedPiece.Faces[(int)Face.Front], 0, 0, 0);
                DrawFaceAsParellelogram(60, 30, selectedPiece.Faces[(int)Face.Right], 0, 0, 0, isVertical: true);
                DrawFaceAsParellelogram(30, 65, selectedPiece.Faces[(int)Face.Down], 0, 0, 0);
            }
        }

        public void UpdateCube(Cube cube)
        {
            this.cube = cube;
        }
    }
}
