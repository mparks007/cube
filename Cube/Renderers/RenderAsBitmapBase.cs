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
    abstract class RenderAsBitmapBase : RenderBase, IDisposable
    {
        protected Bitmap primaryBitmap;
        public virtual Bitmap PrimaryBitmap
        {
            get { return primaryBitmap; }
        }

        protected Bitmap maskBitmap;
        public virtual Bitmap MaskBitmap
        {
            get { return maskBitmap; }
        }
        
        public RenderAsBitmapBase(Cube cube, int pieceSize)
            : base(cube, pieceSize)
        {

        }

        protected void DrawFaceAsSquare(int xDrawCoord, int yDrawCoord, Color colorOfPieceBeingDrawn, int zOfPieceBeingDrawn, int xOfPieceBeingDrawn, int yOfPieceBeingDrawn)
        {
            Graphics primaryGraphics = Graphics.FromImage(primaryBitmap);

            Rectangle pieceFace;

            // draw a piece's face
            using (SolidBrush myBrush = new SolidBrush(colorOfPieceBeingDrawn))
            {
                pieceFace = new Rectangle(xDrawCoord + 1, yDrawCoord + 1, pieceSize, pieceSize);
                primaryGraphics.FillRectangle(myBrush, pieceFace);
            }

            // if drawing the primary image, maskImage should come in not null
            if (maskBitmap != null)
            {
                // store the z/x/y coords in a hidden mask image to determine color on click later
                using (SolidBrush myBrush = new SolidBrush(Color.FromArgb(zOfPieceBeingDrawn, xOfPieceBeingDrawn, yOfPieceBeingDrawn)))
                {
                    Graphics.FromImage(maskBitmap).FillRectangle(myBrush, pieceFace);
                }

                if (cube.IsSelectedAtCoordinates(zOfPieceBeingDrawn, xOfPieceBeingDrawn, yOfPieceBeingDrawn))
                {
                    using (Pen myPen = new Pen(cube.HighlightColor, pieceSize / 18))
                    {
                        int sizeOffset = Math.Max((int)(pieceSize * .10), 1);

                        primaryGraphics.DrawRectangle(myPen, new Rectangle(pieceFace.X + (sizeOffset), pieceFace.Y + (sizeOffset), pieceFace.Width - (sizeOffset * 2), pieceFace.Height - (sizeOffset * 2)));
                    }
                }
            }

            // why not put a little box around it too
            using (Pen myPen = new Pen(new SolidBrush(cube.OutlineColor), 1))
            {

                primaryGraphics.DrawRectangle(myPen, pieceFace);
            }
        }

        protected void DrawFaceAsParellelogram(int xDrawCoord, int yDrawCoord, Color colorOfPieceBeingDrawn, int zOfPieceBeingDrawn, int xOfPieceBeingDrawn, int yOfPieceBeingDrawn, bool isVertical = false)
        {
            Graphics primaryGraphics = Graphics.FromImage(primaryBitmap);

            Point[] pieceFacePoints;

            int modifiedPieceSize = (int)(pieceSize * .5);  // the parallelogram faces must be shorter (or narrower if vertical) to not draw so deep

            // draw a piece's face
            using (SolidBrush myBrush = new SolidBrush(colorOfPieceBeingDrawn))
            {

                // if vertical face, make the pieces skinnier
                if (isVertical)
                {
                    pieceFacePoints = new Point[] { new Point { X = xDrawCoord + 1, Y = yDrawCoord + 1 }, 
                                                    new Point { X = xDrawCoord + 1 + modifiedPieceSize, Y = yDrawCoord + 1 - modifiedPieceSize }, 
                                                    new Point { X = xDrawCoord + 1 + modifiedPieceSize, Y = yDrawCoord + 1 + modifiedPieceSize }, 
                                                    new Point { X = xDrawCoord + 1, Y = yDrawCoord + 1 + modifiedPieceSize + modifiedPieceSize } };
                }
                else  // horizontal face, make the pieces flatter
                {
                    pieceFacePoints = new Point[] { new Point { X = xDrawCoord + 1 + modifiedPieceSize, Y = yDrawCoord + 1 }, 
                                                    new Point { X = xDrawCoord + 1 + modifiedPieceSize + modifiedPieceSize + modifiedPieceSize, Y = yDrawCoord + 1 }, 
                                                    new Point { X = xDrawCoord + 1 + modifiedPieceSize + modifiedPieceSize, Y = yDrawCoord + 1 + modifiedPieceSize }, 
                                                    new Point { X = xDrawCoord + 1, Y = yDrawCoord + 1 + modifiedPieceSize } };
                }

                primaryGraphics.FillPolygon(myBrush, pieceFacePoints);
            }

            // if drawing the primary image, maskImage should come in not null
            if (maskBitmap != null)
            {
                // store the z/x/y coords in a hidden mask image to determine color on click later
                using (SolidBrush myBrush = new SolidBrush(Color.FromArgb(zOfPieceBeingDrawn, xOfPieceBeingDrawn, yOfPieceBeingDrawn)))
                {
                    Graphics.FromImage(maskBitmap).FillPolygon(myBrush, pieceFacePoints);
                }

                if (cube.IsSelectedAtCoordinates(zOfPieceBeingDrawn, xOfPieceBeingDrawn, yOfPieceBeingDrawn))
                {
                    using (Pen myPen = new Pen(new SolidBrush(cube.HighlightColor), modifiedPieceSize / 10))
                    {
                        Point[] highlightPoints;
                        int sizeOffset = Math.Max((int)(modifiedPieceSize * .10), 1);

                        if (isVertical)
                        {
                            highlightPoints = new Point[] { new Point { X = pieceFacePoints[0].X + sizeOffset, Y = pieceFacePoints[0].Y + sizeOffset }, 
                                                            new Point { X = pieceFacePoints[1].X - sizeOffset , Y = pieceFacePoints[1].Y + (sizeOffset * 3) }, 
                                                            new Point { X = pieceFacePoints[2].X - sizeOffset, Y = pieceFacePoints[2].Y - sizeOffset }, 
                                                            new Point { X = pieceFacePoints[3].X + sizeOffset, Y = pieceFacePoints[3].Y - (sizeOffset * 3) } };
                        }
                        else
                        {
                            highlightPoints = new Point[] { new Point { X = pieceFacePoints[0].X + sizeOffset, Y = pieceFacePoints[0].Y + sizeOffset }, 
                                                            new Point { X = pieceFacePoints[1].X - (sizeOffset * 3), Y = pieceFacePoints[1].Y + sizeOffset }, 
                                                            new Point { X = pieceFacePoints[2].X - sizeOffset, Y = pieceFacePoints[2].Y - sizeOffset }, 
                                                            new Point { X = pieceFacePoints[3].X + (sizeOffset * 3), Y = pieceFacePoints[3].Y - sizeOffset } };
                        }

                        primaryGraphics.DrawPolygon(myPen, highlightPoints);
                    }
                }
            }

            // why not put a little box around it too
            using (Pen myPen = new Pen(new SolidBrush(cube.OutlineColor), 1))
            {
                primaryGraphics.DrawPolygon(myPen, pieceFacePoints);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (primaryBitmap != null)
                        primaryBitmap.Dispose();

                    if (maskBitmap != null)
                        maskBitmap.Dispose();
                }

                disposed = true;
            }
        }
    }
}
