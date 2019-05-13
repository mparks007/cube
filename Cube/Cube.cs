using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CubeSolver
{
    public class Cube
    {
        private Piece[,,] pieces;                       // the entire puzzle's piece layout (z by x by y)
        private Color outlineColor;                     // thin grid line around pieces
        private Color highlightColor;                   // thicker line around the selected piece
        private Color[] priorFaceColors = new Color[6]; // to store color pattern in case changing to new one
        private Random rand = new Random();
        private Array planes = Enum.GetValues(typeof(Plane));
        private Array directions = Enum.GetValues(typeof(Direction));

        public int Size { get; set; }
        public int SelectedPieceZ { get; set; }
        public int SelectedPieceX { get; set; }
        public int SelectedPieceY { get; set; }

        public Cube(int cubeSize, int pieceSize, Color upperColor, Color rightColor, Color downColor, Color leftColor, Color frontColor, Color backColor, Color outlineColor, Color highlightColor)
        {
            Size = cubeSize;
            pieces = new Piece[cubeSize, cubeSize, cubeSize];

            SelectedPieceZ = -1;
            SelectedPieceX = -1;
            SelectedPieceY = -1;

            SetupPieces(upperColor, rightColor, downColor, leftColor, frontColor, backColor, outlineColor, highlightColor);
        }

        public void SetupPieces(Color upperColor, Color rightColor, Color downColor, Color leftColor, Color frontColor, Color backColor, Color outlineColor, Color highlightColor, bool atCreationTime = true)
        {
            this.outlineColor = outlineColor;
            this.highlightColor = highlightColor;

            // flags to track if any of the faces on individual pieces should get a color or not (if not visible to the eye, then no color)
            bool isUpperFace = false;
            bool isDownFace = false;
            bool isLeftFace = false;
            bool isRightFace = false;
            bool isFrontFace = false;
            bool isBackFace = false;

            for (int z = 0; z < Size; z++)
            {
                //// creation needs to actually allocate memory for the layers on each z
                //if (atCreationTime)
                //    pieces[z] = new Piece[Size, Size];

                for (int x = 0; x < Size; x++)
                    for (int y = 0; y < Size; y++)
                    {
                        if (atCreationTime)
                        {
                            isUpperFace = (z == 0);
                            isDownFace = (z == Size - 1);
                            isLeftFace = (x == 0);
                            isRightFace = (x == Size - 1);
                            isFrontFace = (y == Size - 1);
                            isBackFace = (y == 0);

                            #region tempcoloring
                            //// TEMP BEGIN
                            //if (Size > 3)
                            //{
                            //    for (int i = 0; i < (Size / 2) + (Size % 2); i++)
                            //    {
                            //        if ((x == i && y == i))
                            //        {
                            //            upperColor = Color.HotPink;
                            //            downColor = Color.HotPink;
                            //            break;
                            //        }
                            //        else
                            //        {
                            //            upperColor = Color.White;
                            //            downColor = Color.Yellow;
                            //        }
                            //    }
                            //}
                            //else
                            //    upperColor = Color.White;
                            //// TEMP END
                            #endregion

                            pieces[z,x, y] = new Piece(upperColor, rightColor, downColor, leftColor, frontColor, backColor, isUpperFace, isDownFace, isLeftFace, isRightFace, isFrontFace, isBackFace);
                        }
                        else
                            pieces[z,x, y].ChangeFaceColors(priorFaceColors, new Color[] { upperColor, rightColor, downColor, leftColor, frontColor, backColor});
                    }
            }

            // store colors after color setup so we can know what the prior was if we do a color change
            priorFaceColors[(int)Face.Upper] = upperColor;
            priorFaceColors[(int)Face.Right] = rightColor;
            priorFaceColors[(int)Face.Down] = downColor;
            priorFaceColors[(int)Face.Left] = leftColor;
            priorFaceColors[(int)Face.Front] = frontColor;
            priorFaceColors[(int)Face.Back] = backColor;
        }

        public void Draw(ref Bitmap primaryImage, ref Bitmap maskImage, DrawType drawType, int pieceSize)
        {
            if (primaryImage != null)
                primaryImage.Dispose();

            switch (drawType)
            {
                case DrawType.ThreeD:
                    Draw3D(ref primaryImage, ref maskImage, pieceSize);
                    break;
                case DrawType.Grid:
                    DrawGrid(ref primaryImage, ref maskImage, pieceSize);
                    break;
                case DrawType.SplitStack:
                    DrawSplitStack(ref primaryImage, ref maskImage, pieceSize);
                    break;
                case DrawType.Unfold:
                    DrawUnfold(ref primaryImage, ref maskImage, pieceSize);
                    break;
            }
        }

        private void Draw3D(ref Bitmap primaryImage, ref Bitmap maskImage, int pieceSize)
        {
            // drawing the entire left and right faces as angled and the center and back as a square
            int width = (Size * pieceSize * 4);
            // drawing the upper and down faces as angled and the front as a square
            int height = (Size * pieceSize * 3);

            primaryImage = new Bitmap(width, height);
            maskImage = new Bitmap(width, height);

            // draw back and front
            for (int z = 0; z < Size; z++)
            {
                for (int x = 0; x < Size; x++)
                {
                    DrawFaceAsSquare(primaryImage, maskImage, (int)(Size * pieceSize * 1.7) + (x * pieceSize) + (Size * pieceSize), (z * pieceSize), pieces[z, x, 0].Faces[(int)Face.Back], z, x, 0, pieceSize);
                    DrawFaceAsSquare(primaryImage, maskImage, (Size * pieceSize) + (x * pieceSize), (Size * pieceSize) + (z * pieceSize), pieces[z, x, Size - 1].Faces[(int)Face.Front], z, x, Size - 1, pieceSize);
                }
            }
            // left and right face
            for (int y = Size - 1; y >= 0; y--)
            {
                for (int z = 0; z < Size; z++)
                {

                    DrawFaceAsParellelogram(primaryImage, maskImage, (int)(pieceSize * .5), (int)(Size * pieceSize / 3) + (int)(y * pieceSize * .5), (Size * pieceSize) + (z * pieceSize) - (y * pieceSize / 2), pieces[z, 0, Size - 1 - y].Faces[(int)Face.Left], z, 0, Size - 1 - y, isVertical: true);
                    DrawFaceAsParellelogram(primaryImage, maskImage, (int)(pieceSize * .5), (Size * pieceSize * 2) + (int)(y * pieceSize * .5), (Size * pieceSize) + (z * pieceSize) - (y * pieceSize / 2), pieces[z, Size - 1, Size - 1 - y].Faces[(int)Face.Right], z, Size - 1, Size - 1 - y, isVertical: true);
                }
            }

            // draw upper and down
            for (int x = 0; x < Size; x++)
                for (int y = Size - 1; y >= 0; y--)
                {
                    DrawFaceAsParellelogram(primaryImage, maskImage, (int)(pieceSize * .5), (Size * pieceSize) + (int)(x * pieceSize) + (int)(y * pieceSize * .5), (Size * pieceSize - (int)(pieceSize * .5)) - (int)(y * pieceSize * .5), pieces[0, x, Size - 1 - y].Faces[(int)Face.Upper], 0, x, Size - 1 - y);
                    DrawFaceAsParellelogram(primaryImage, maskImage, (int)(pieceSize * .5), (Size * pieceSize) + (int)(x * pieceSize) + (int)(y * pieceSize * .5), (int)(Size * pieceSize * 2.7 - (int)(pieceSize * .5)) - (int)(y * pieceSize * .5), pieces[Size - 1,x, Size - 1 - y].Faces[(int)Face.Down], Size - 1, x, Size - 1 - y);
                }
        }

        private void DrawGrid(ref Bitmap primaryImage, ref Bitmap maskImage, int pieceSize)
        {
            // grid spreads out all 6 faces (pieceSize * 6) of each piece of a column on a full layer
            int width = Size * (pieceSize * 6);
            int height = Size * Size * pieceSize;

            primaryImage = new Bitmap(width, height);
            maskImage = new Bitmap(width, height);

            int xPos = 0;
            int yPos = 0;
            for (int z = 0; z < Size; z++)
                for (int x = 0; x < Size; x++)
                    for (int y = 0; y < Size; y++)
                    {
                        // for each layer, spread out a column as a row across then the other columns stacked below that
                        for (int f = 0; f < 6; f++)
                        {
                            xPos = (f * pieceSize) + (y * 6 * pieceSize);
                            yPos = (z * Size * pieceSize) + (x * pieceSize);

                            DrawFaceAsSquare(primaryImage, maskImage, xPos, yPos, pieces[z, x, y].Faces[f], z, x, y, pieceSize);
                        }
                    }
        }

        private void DrawSplitStack(ref Bitmap primaryImage, ref Bitmap maskImage, int pieceSize)
        {
            // drawing the side edges of a layer spread out flat so we have to cover the center (Size * pieceSize) plus the left and right extra width (pieceSize * 2)
            int width = (Size * pieceSize) + (pieceSize * 2);
            // drawing the side edges spread out flat so have to cover the center (Size * pieceSize) plus the front and back extra width plus the space between each drawn layer
            int height = (((Size * pieceSize) + (pieceSize * 2)) + pieceSize) * Size;

            primaryImage = new Bitmap(width, height);
            maskImage = new Bitmap(width, height);

            int xPos = 0;
            int yPos = 0;
            int spacer = 0;
            for (int z = 0; z < Size; z++)
                for (int x = 0; x < Size; x++)
                    for (int y = 0; y < Size; y++)
                    {
                        yPos = (y * pieceSize);
                        xPos = (x * pieceSize);
                        spacer = (z * ((pieceSize * Size) + (pieceSize * 2) + (pieceSize)));

                        // spread the side face colors out flat around the center
                        if (y == 0)
                            DrawFaceAsSquare(primaryImage, maskImage, xPos + pieceSize, yPos + spacer, pieces[z, x, y].Faces[(int)Face.Back], z, x, y, pieceSize);
                        if (x == 0)
                            DrawFaceAsSquare(primaryImage, maskImage, xPos, yPos + pieceSize + spacer, pieces[z, x, y].Faces[(int)Face.Left], z, x, y, pieceSize);
                        if (x == Size - 1)
                            DrawFaceAsSquare(primaryImage, maskImage, Size * pieceSize + pieceSize, yPos + pieceSize + spacer, pieces[z, x, y].Faces[(int)Face.Right], z, x, y, pieceSize);
                        if (y == Size - 1)
                            DrawFaceAsSquare(primaryImage, maskImage, xPos + pieceSize, Size * pieceSize + pieceSize + spacer, pieces[z, x, y].Faces[(int)Face.Front], z, x, y, pieceSize);

                        // show the uppor color for the upper, but show the down color for the final layer since the color above that is undefined
                        if (z == Size - 1)
                            DrawFaceAsSquare(primaryImage, maskImage, xPos + pieceSize, yPos + pieceSize + spacer, pieces[z, x, y].Faces[(int)Face.Down], z, x, y, pieceSize);
                        else
                            DrawFaceAsSquare(primaryImage, maskImage, xPos + pieceSize, yPos + pieceSize + spacer, pieces[z, x, y].Faces[(int)Face.Upper], z, x, y, pieceSize);
                    }
        }


        private void DrawUnfold(ref Bitmap primaryImage, ref Bitmap maskImage, int pieceSize)
        {
            // drawing the entire left and right faces spread out flat so have to cover three full faces (left/center/right)
            int width = (Size * pieceSize * 3);
            // below center, drawing the back, upper, front, and down faces unrolled so have to cover four full faces
            int height = (Size * pieceSize * 4);

            primaryImage = new Bitmap(width, height);
            maskImage = new Bitmap(width, height);

            for (int z = Size - 1; z >= 0; z--)
            {
                // draw back and front
                for (int x = 0; x < Size; x++)
                {
                    DrawFaceAsSquare(primaryImage, maskImage, (Size * pieceSize) + (x * pieceSize), ((Size - 1 - z) * pieceSize), pieces[z, x, 0].Faces[(int)Face.Back], z, x, 0, pieceSize);
                    DrawFaceAsSquare(primaryImage, maskImage, (Size * pieceSize) + (x * pieceSize), (z * pieceSize) + (Size * pieceSize * 2), pieces[z, x, Size - 1].Faces[(int)Face.Front], z, x, Size - 1, pieceSize);
                }
                // draw left and right faces
                for (int y = 0; y < Size; y++)
                {
                    DrawFaceAsSquare(primaryImage, maskImage, ((Size - 1 - z) * pieceSize), (Size * pieceSize) + (y * pieceSize), pieces[z, 0, y].Faces[(int)Face.Left], z, 0, y, pieceSize);
                    DrawFaceAsSquare(primaryImage, maskImage, (Size * pieceSize * 3) - ((Size - z) * pieceSize), (Size * pieceSize) + (y * pieceSize), pieces[z, Size - 1, y].Faces[(int)Face.Right], z, Size - 1, y, pieceSize);
                }
            }
            // draw upper and down
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                {
                    DrawFaceAsSquare(primaryImage, maskImage, (Size * pieceSize) + (x * pieceSize), (Size * pieceSize) + (y * pieceSize), pieces[0, x, y].Faces[(int)Face.Upper], 0, x, y, pieceSize);
                    DrawFaceAsSquare(primaryImage, maskImage, (Size * pieceSize) + (x * pieceSize), (Size * pieceSize * 3) + (y * pieceSize), pieces[Size - 1, x, Size - 1 - y].Faces[(int)Face.Down], Size - 1, x, Size - 1 - y, pieceSize);
                }
        }

        private void DrawFaceAsSquare(Bitmap primaryImage, Bitmap maskImage, int xDrawCoord, int yDrawCoord, Color color, int z, int x, int y, int pieceSize)
        {
            Graphics primaryGraphics = Graphics.FromImage(primaryImage);
            Graphics maskGraphics = null;

            if (maskImage != null)
                maskGraphics = Graphics.FromImage(maskImage);

            Rectangle pieceFace;

            // draw a piece's face
            using (SolidBrush myBrush = new SolidBrush(color))
            {
                pieceFace = new Rectangle(xDrawCoord + 1, yDrawCoord + 1, pieceSize, pieceSize);
                primaryGraphics.FillRectangle(myBrush, pieceFace);
            }

            // if drawing the primary image, maskImage should come in not null
            if (maskImage != null)
            {
                // store the z/x/y coords in a hidden mask image to determine color on click later
                using (SolidBrush myBrush = new SolidBrush(Color.FromArgb(z, x, y)))
                {
                    maskGraphics.FillRectangle(myBrush, pieceFace);
                }

                if (IsSelected(z, x, y))
                {
                    using (Pen myPen = new Pen(highlightColor, pieceSize / 18))
                    {
                        int sizeOffset = Math.Max((int)(pieceSize * .10), 1);

                        primaryGraphics.DrawRectangle(myPen, new Rectangle(pieceFace.X + (sizeOffset), pieceFace.Y + (sizeOffset), pieceFace.Width - (sizeOffset * 2), pieceFace.Height - (sizeOffset * 2)));
                    }
                }
            }

            // why not put a little box around it too
            using (Pen myPen = new Pen(new SolidBrush(outlineColor), 1))
            {

                primaryGraphics.DrawRectangle(myPen, pieceFace);
            }
        }

        private void DrawFaceAsParellelogram(Bitmap primaryImage, Bitmap maskImage, int pieceSize, int xDrawCoord, int yDrawCoord, Color color, int z, int x, int y, bool isVertical = false)
        {
            Graphics primaryGraphics = Graphics.FromImage(primaryImage);
            Graphics maskGraphics = null;

            if (maskImage != null)
                maskGraphics = Graphics.FromImage(maskImage);

            Point[] pieceFacePoints;

            // draw a piece's face
            using (SolidBrush myBrush = new SolidBrush(color))
            {
                // if vertical face, make the pieces skinnier
                if (isVertical)
                {
                    pieceFacePoints = new Point[] { new Point { X = xDrawCoord + 1, Y = yDrawCoord + 1 }, 
                                                    new Point { X = xDrawCoord + 1 + pieceSize, Y = yDrawCoord + 1 - pieceSize }, 
                                                    new Point { X = xDrawCoord + 1 + pieceSize, Y = yDrawCoord + 1 + pieceSize }, 
                                                    new Point { X = xDrawCoord + 1, Y = yDrawCoord + 1 + pieceSize + pieceSize } };
                }
                else  // horizontal face, make the pieces flatter
                {
                    pieceFacePoints = new Point[] { new Point { X = xDrawCoord + 1 + pieceSize, Y = yDrawCoord + 1 }, 
                                                    new Point { X = xDrawCoord + 1 + pieceSize + pieceSize + pieceSize, Y = yDrawCoord + 1 }, 
                                                    new Point { X = xDrawCoord + 1 + pieceSize + pieceSize, Y = yDrawCoord + 1 + pieceSize }, 
                                                    new Point { X = xDrawCoord + 1, Y = yDrawCoord + 1 + pieceSize } };
                }

                primaryGraphics.FillPolygon(myBrush, pieceFacePoints);
            }

            // if drawing the primary image, maskImage should come in not null
            if (maskImage != null)
            {
                // store the z/x/y coords in a hidden mask image to determine color on click later
                using (SolidBrush myBrush = new SolidBrush(Color.FromArgb(z, x, y)))
                {
                    maskGraphics.FillPolygon(myBrush, pieceFacePoints);
                }

                if (IsSelected(z, x, y))
                {
                    using (Pen myPen = new Pen(new SolidBrush(highlightColor), pieceSize / 10))
                    {
                        Point[] hightPoints;
                        int sizeOffset = Math.Max((int)(pieceSize * .10), 1);

                        if (isVertical)
                        {
                            hightPoints = new Point[] { new Point { X = pieceFacePoints[0].X + sizeOffset, Y = pieceFacePoints[0].Y + sizeOffset }, 
                                                            new Point { X = pieceFacePoints[1].X - sizeOffset , Y = pieceFacePoints[1].Y + (sizeOffset * 3) }, 
                                                            new Point { X = pieceFacePoints[2].X - sizeOffset, Y = pieceFacePoints[2].Y - sizeOffset }, 
                                                            new Point { X = pieceFacePoints[3].X + sizeOffset, Y = pieceFacePoints[3].Y - (sizeOffset * 3) } };
                        }
                        else
                        {
                            hightPoints = new Point[] { new Point { X = pieceFacePoints[0].X + sizeOffset, Y = pieceFacePoints[0].Y + sizeOffset }, 
                                                            new Point { X = pieceFacePoints[1].X - (sizeOffset * 3), Y = pieceFacePoints[1].Y + sizeOffset }, 
                                                            new Point { X = pieceFacePoints[2].X - sizeOffset, Y = pieceFacePoints[2].Y - sizeOffset }, 
                                                            new Point { X = pieceFacePoints[3].X + (sizeOffset * 3), Y = pieceFacePoints[3].Y - sizeOffset } };
                        }

                        primaryGraphics.DrawPolygon(myPen, hightPoints);
                    }
                }
            }

            // why not put a little box around it too
            using (Pen myPen = new Pen(new SolidBrush(outlineColor), 1))
            {
                primaryGraphics.DrawPolygon(myPen, pieceFacePoints);
            }
        }

        private bool IsSelected(int z, int x, int y)
        {
            return (SelectedPieceZ == z && SelectedPieceX == x && SelectedPieceY == y);
        }

        public void DrawSelectedPiece(ref Bitmap selectedPieceImage, int width, int height, int z, int x, int y)
        {
            selectedPieceImage = new Bitmap(width, height);
            Graphics selectedImageGraphics = Graphics.FromImage(selectedPieceImage);

            DrawFaceAsSquare(selectedPieceImage, null, 80, 5, pieces[z, x, y].Faces[(int)Face.Back], 0, 0, 0, 30);
            DrawFaceAsParellelogram(selectedPieceImage, null, 15, 10, 30, pieces[z, x, y].Faces[(int)Face.Left], 0, 0, 0, isVertical: true);
            DrawFaceAsParellelogram(selectedPieceImage, null, 15, 30, 15, pieces[z, x, y].Faces[(int)Face.Upper], 0, 0, 0);
            DrawFaceAsSquare(selectedPieceImage, null, 30, 30, pieces[z, x, y].Faces[(int)Face.Front], 0, 0, 0, 30);
            DrawFaceAsParellelogram(selectedPieceImage, null, 15, 60, 30, pieces[z, x, y].Faces[(int)Face.Right], 0, 0, 0, isVertical: true);
            DrawFaceAsParellelogram(selectedPieceImage, null, 15, 30, 65, pieces[z, x, y].Faces[(int)Face.Down], 0, 0, 0);
        }

        public void Scramble()
        {
            for (int i = 0; i < Size * 10; i++)
            {
                Plane plane = (Plane)planes.GetValue(rand.Next(planes.Length));
                Direction direction = (Direction)directions.GetValue(rand.Next(directions.Length));

                Rotate(rand.Next(0, Size), rand.Next(0, Size), rand.Next(0, Size), plane, direction);
            }
        }

        public bool IsSolved()
        {
            bool isSolved = true;
            Color upperColor = Piece.CoreColor;
            Color rightColor = Piece.CoreColor;
            Color downColor = Piece.CoreColor;
            Color leftColor = Piece.CoreColor;
            Color frontColor = Piece.CoreColor;
            Color backColor = Piece.CoreColor;
            bool checkUpper = true;
            bool checkRight = true;
            bool checkDown = true;
            bool checkLeft = true;
            bool checkFront = true;
            bool checkBack = true;

            for (int z = 0; z < Size && isSolved; z++)
                for (int x = 0; x < Size && isSolved; x++)
                    for (int y = 0; y < Size && isSolved; y++)
                    {
                        if (z == 0)
                        {
                            if (y == 0)
                            {
                                if (x == 0)
                                {
                                    // get the easy colors since on the first peice being checked (0, 0, 0)
                                    upperColor = pieces[z, x, y].Faces[(int)Face.Upper];
                                    leftColor = pieces[z, x, y].Faces[(int)Face.Left];
                                    backColor = pieces[z, x, y].Faces[(int)Face.Back];
                                    
                                    // no need to check more since this is the first peice being checked (nothing to compare against)
                                    continue;
                                }
                                else if (x == Size - 1) // finally at the back/right piece so can determine the required right face color
                                    rightColor = pieces[z, x, y].Faces[(int)Face.Right];
                            }
                            else if (x == 0 && y == Size - 1) // finally at front/left piece so can determine the required front face color
                                frontColor = pieces[z, x, y].Faces[(int)Face.Front];
                        }
                        else if (z == Size - 1 && x == 0 && y == 0)  // finally at down/back/left piece so can determine the required down face color
                            downColor = pieces[z, x, y].Faces[(int)Face.Down];

                        // to ignore coloring check if checking the non-visible faces
                        checkUpper = (z == 0);
                        checkRight = (x == Size - 1);
                        checkDown = (z == Size - 1);
                        checkLeft = (x == 0);
                        checkFront = (y == Size - 1);
                        checkBack = (y == 0);

                        isSolved = pieces[z, x, y].IsSolved((checkUpper ? upperColor : Piece.CoreColor),
                                                            (checkRight ? rightColor : Piece.CoreColor),
                                                            (checkDown ? downColor : Piece.CoreColor),
                                                            (checkLeft ? leftColor : Piece.CoreColor),
                                                            (checkFront ? frontColor : Piece.CoreColor),
                                                            (checkBack ? backColor : Piece.CoreColor));
                    }
                    
            return isSolved;
        }

        public TreeView CreateTree(TreeView tree)
        {
            TreeNode zNode;
            TreeNode pieceNode;

            tree.Nodes.Clear();

            for (int z = 0; z < Size; z++)
            {
                zNode = new TreeNode(String.Format("[z:{0}]", z));
                tree.Nodes.Add(zNode);
                
                for (int x = 0; x < Size; x++)
                {
                    for (int y = 0; y < Size; y++)
                    {
                        pieceNode = new TreeNode(String.Format("Piece [z:{0}][x:{1},y:{2}]", z, x, y));
                        zNode.Nodes.Add(pieceNode);

                        for (int f = 0; f < 6; f++)
                            pieceNode.Nodes.Add(String.Format("{0} Face -- {1}", (Face)f, (pieces[z, x, y].Faces[f]) == Piece.CoreColor ? "n/a" : pieces[z, x, y].Faces[f].ToString()));
                    }
                }
            }
            return tree;
        }

        public void Rotate(int zDimension, int xDimension, int yDimension, Plane plane, Direction direction)
        {
            if (Size == 1)
                pieces[0, 0, 0].Rotate(plane, direction);
            else
            {
                int max = Size;
                int min = -1;
                Piece tempPiece;

                for (int offset = 0; offset < (Size / 2) + (Size % 2); offset++)
                {
                    // these offsets will slowly shrink the grid size to rotate (allows the inner inner centers of cubes to be rotated)
                    min++;
                    max--;

                    switch (plane)
                    {
                        #region Horizontal
                        case Plane.Horizontal:
                            switch (direction)
                            {
                                #region Clockwise
                                case Direction.Clockwise:
                                    // loop to cover all BUT ONE peice along the edge since the next side rotated in will start at the one skipped
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        // store off the first piece that will have something rotated in on this pass
                                        tempPiece = pieces[zDimension, max - i, min];

                                        // the other three pieces rotate around
                                        PieceSwapAndRotate(plane, direction, zDimension, min, min + i, zDimension, max - i, min);
                                        PieceSwapAndRotate(plane, direction, zDimension, min + i, max, zDimension, min, min + i);
                                        PieceSwapAndRotate(plane, direction, zDimension, max, max - i, zDimension, min + i, max);

                                        // now for the first piece location that was lost due to the first rotation in this pass
                                        pieces[zDimension, max, max - i] = tempPiece;
                                        pieces[zDimension, max, max - i].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                                #region CounterClockwise
                                case Direction.Counterclockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[zDimension, min + i, min];

                                        PieceSwapAndRotate(plane, direction, zDimension, max, min + i, zDimension, min + i, min);
                                        PieceSwapAndRotate(plane, direction, zDimension, max - i, max, zDimension, max, min + i);
                                        PieceSwapAndRotate(plane, direction, zDimension, min, max - i, zDimension, max - i, max);

                                        pieces[zDimension, min, max - i] = tempPiece;
                                        pieces[zDimension, min, max - i].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                            }
                            break;
                        #endregion
                        #region Vertical
                        case Plane.VerticalWidth:
                            switch (direction)
                            {
                                #region Clockwise
                                case Direction.Clockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[min, max - i, yDimension];

                                        PieceSwapAndRotate(plane, direction, min + i, min, yDimension, min, max - i, yDimension);
                                        PieceSwapAndRotate(plane, direction, max, min + i, yDimension, min + i, min, yDimension);
                                        PieceSwapAndRotate(plane, direction, max - i, max, yDimension, max, min + i, yDimension);

                                        pieces[max - i, max, yDimension] = tempPiece;
                                        pieces[max - i, max, yDimension].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                                #region CounterClockwise
                                case Direction.Counterclockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[min, min + i, yDimension];

                                        PieceSwapAndRotate(plane, direction, min + i, max, yDimension, min, min + i, yDimension);
                                        PieceSwapAndRotate(plane, direction, max, max - i, yDimension, min + i, max, yDimension);
                                        PieceSwapAndRotate(plane, direction, max - i, min, yDimension, max, max - i, yDimension);

                                        pieces[max - i, min, yDimension] = tempPiece;
                                        pieces[max - i, min, yDimension].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                            }
                            break;
                        case Plane.VerticalDepth:
                            switch (direction)
                            {
                                #region Clockwise
                                case Direction.Clockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[min, xDimension, min + i];

                                        PieceSwapAndRotate(plane, direction, min + i, xDimension, max, min, xDimension, min + i);
                                        PieceSwapAndRotate(plane, direction, max, xDimension, max - i, min + i, xDimension, max);
                                        PieceSwapAndRotate(plane, direction, max - i, xDimension, min, max, xDimension, max - i);

                                        pieces[max - i, xDimension, min] = tempPiece;
                                        pieces[max - i, xDimension, min].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                                #region CounterClockwise
                                case Direction.Counterclockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[min, xDimension, max - i];

                                        PieceSwapAndRotate(plane, direction, min + i, xDimension, min, min, xDimension, max - i);
                                        PieceSwapAndRotate(plane, direction, max, xDimension, min + i, min + i, xDimension, min);
                                        PieceSwapAndRotate(plane, direction, max - i, xDimension, max, max, xDimension, min + i);

                                        pieces[max - i, xDimension, max] = tempPiece;
                                        pieces[max - i, xDimension, max].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                            }
                            break;
                        #endregion
                    }
                }
            }
        }
    
        private void PieceSwapAndRotate(Plane planeTurning, Direction direction, int sourceZ, int sourceX, int sourceY, int destZ, int destX, int destY)
        {
            pieces[destZ, destX, destY] = pieces[sourceZ, sourceX, sourceY];
            pieces[destZ, destX, destY].Rotate(planeTurning, direction);
        }

        public Color GetRandomFaceColor()
        {
            return priorFaceColors[rand.Next(6)];
        }
    }
}