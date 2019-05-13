using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using CubeSolver.Enums;

namespace CubeSolver.Core
{
    public class Cube : IDisposable
    {
        public static readonly Color CoreColor = Color.FromArgb(1, 1, 1);

        private bool disposed = false;
        private Piece[][,] pieces;                          // the entire puzzle's piece layout (z by x by y)
        private Color[] storedFaceColors = new Color[6];    // to store color pattern when changing colors post-creation
        private Piece corePiece = new Piece();              // piece to use for all the non-visible pieces

        // for scramble
        private Random rand = new Random();
        private Array planes = Enum.GetValues(typeof(Plane));
        private Array directions = Enum.GetValues(typeof(Direction));

        private int selectedPieceZ = -1;
        public int SelectedPieceZ { get { return selectedPieceZ; } }
        private int selectedPieceX = -1;
        public int SelectedPieceX { get { return selectedPieceX; } }
        private int selectedPieceY = -1;
        public int SelectedPieceY { get { return selectedPieceY; } }

        // only the constructor should be setting the size
        private int size;
        public int Size
        {
            get { return size; }
        }

        // thicker lines around the selected piece's faces (only the ctor or a color change call should set this)
        private Color highlightColor;
        public Color HighlightColor
        {
            get { return highlightColor; }
        }

        // thin grid line around each piece (only the ctor or a color change call should set this)
        private Color outlineColor;
        public Color OutlineColor
        {
            get { return outlineColor; }
        }

        public Piece SelectedPiece
        {
            get
            {
                if (SelectedPieceZ > -1 && SelectedPieceX > -1 && SelectedPieceY > -1)
                    return pieces[SelectedPieceZ][SelectedPieceX, SelectedPieceY];
                else
                    return null;
            }
        }

        public Piece this[int z, int x, int y]
        {
            get { return pieces[z][x, y]; }
        }

        public Cube(int cubeSize, int pieceSize, Color upperColor, Color rightColor, Color downColor, Color leftColor, Color frontColor, Color backColor, Color outlineColor, Color highlightColor)
        {
            size = cubeSize;
            pieces = new Piece[Size][,];

            SetupPieces(upperColor, rightColor, downColor, leftColor, frontColor, backColor, outlineColor, highlightColor, atCreationTime: true);
        }

        public void SetupPieces(Color upperColor, Color rightColor, Color downColor, Color leftColor, Color frontColor, Color backColor, Color outlineColor, Color highlightColor, bool atCreationTime = false)
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

            for (int z = 0; z < size; z++)
            {
                // creation needs to actually allocate memory for the layers on each z
                if (atCreationTime)
                {
                    pieces[z] = new Piece[Size, Size];
                }
                
                for (int x = 0; x < size; x++)
                    for (int y = 0; y < size; y++)
                    {
                        if (atCreationTime)
                        {
                            isUpperFace = (z == 0);
                            isDownFace = (z == size - 1);
                            isLeftFace = (x == 0);
                            isRightFace = (x == size - 1);
                            isFrontFace = (y == size - 1);
                            isBackFace = (y == 0);

                            #region tempcoloring
                            // TEMP BEGIN
                            if (size > 3)
                            {
                                for (int i = 0; i < (size / 2) + (size % 2); i++)
                                {
                                    if ((x == i && y == i))
                                    {
                                        upperColor = Color.HotPink;
                                        downColor = Color.HotPink;
                                        break;
                                    }
                                    else
                                    {
                                        upperColor = Color.White;
                                        downColor = Color.Yellow;
                                    }
                                }
                            }
                            else
                                upperColor = Color.White;
                            // TEMP END
                            #endregion

                            // if at a core piece (not visible) just use the same core piece placeholder
                            if (!(isUpperFace || isDownFace || isLeftFace || isRightFace || isFrontFace || isBackFace))
                                pieces[z][x, y] = corePiece;
                            else
                                pieces[z][x, y] = new Piece(upperColor, rightColor, downColor, leftColor, frontColor, backColor, isUpperFace, isDownFace, isLeftFace, isRightFace, isFrontFace, isBackFace);
                        }
                        else
                            pieces[z][x, y].ChangeFaceColors(storedFaceColors, new Color[] { upperColor, rightColor, downColor, leftColor, frontColor, backColor });
                    }
            }

            // store colors after color setup so we can know what the prior was if we do a color change
            storedFaceColors[(int)Face.Upper] = upperColor;
            storedFaceColors[(int)Face.Right] = rightColor;
            storedFaceColors[(int)Face.Down] = downColor;
            storedFaceColors[(int)Face.Left] = leftColor;
            storedFaceColors[(int)Face.Front] = frontColor;
            storedFaceColors[(int)Face.Back] = backColor;
        }

        public void SetSelectedPiece(int z, int x, int y)
        {
            selectedPieceZ = z;
            selectedPieceX = x;
            selectedPieceY = y;
        }

        public Color GetRandomFaceColor()
        {
            return storedFaceColors[rand.Next(6)];
        }

        public bool IsSelected()
        {
            return (SelectedPieceZ > -1 && SelectedPieceX > -1 && SelectedPieceY > -1);
        }

        public bool IsSelectedAtCoordinates(int z, int x, int y)
        {
            return (SelectedPieceZ == z && SelectedPieceX == x && SelectedPieceY == y);
        }

        public void Scramble()
        {
            Plane plane;
            Direction direction;

            for (int i = 0; i < size * 10; i++)
            {
                plane = (Plane)planes.GetValue(rand.Next(planes.Length));
                direction = (Direction)directions.GetValue(rand.Next(directions.Length));

                Rotate(rand.Next(0, size), rand.Next(0, size), rand.Next(0, size), plane, direction);
            }
        }

        public bool IsSolved()
        {
            bool isSolved = true;
            Color upperColor = Cube.CoreColor;
            Color rightColor = Cube.CoreColor;
            Color downColor = Cube.CoreColor;
            Color leftColor = Cube.CoreColor;
            Color frontColor = Cube.CoreColor;
            Color backColor = Cube.CoreColor;
            bool checkUpper = true;
            bool checkRight = true;
            bool checkDown = true;
            bool checkLeft = true;
            bool checkFront = true;
            bool checkBack = true;

            for (int z = 0; z < size && isSolved; z++)
                for (int x = 0; x < size && isSolved; x++)
                    for (int y = 0; y < size && isSolved; y++)
                    {
                        if (z == 0)
                        {
                            if (y == 0)
                            {
                                if (x == 0)
                                {
                                    // get the easy colors since on the first peice being checked (0, 0, 0)
                                    upperColor = pieces[z][x, y].Faces[(int)Face.Upper];
                                    leftColor = pieces[z][x, y].Faces[(int)Face.Left];
                                    backColor = pieces[z][x, y].Faces[(int)Face.Back];
                                    
                                    // no need to check more since this is the first peice being checked (nothing to compare against)
                                    continue;
                                }
                                else if (x == size - 1) // finally at the back/right piece so can determine the required right face color
                                    rightColor = pieces[z][x, y].Faces[(int)Face.Right];
                            }
                            else if (x == 0 && y == size - 1) // finally at front/left piece so can determine the required front face color
                                frontColor = pieces[z][x, y].Faces[(int)Face.Front];
                        }
                        else if (z == size - 1 && x == 0 && y == 0)  // finally at down/back/left piece so can determine the required down face color
                            downColor = pieces[z][x, y].Faces[(int)Face.Down];

                        // to ignore coloring check if checking the non-visible faces
                        checkUpper = (z == 0);
                        checkRight = (x == size - 1);
                        checkDown = (z == size - 1);
                        checkLeft = (x == 0);
                        checkFront = (y == size - 1);
                        checkBack = (y == 0);

                        isSolved = pieces[z][x, y].IsSolved((checkUpper ? upperColor : Cube.CoreColor),
                                                            (checkRight ? rightColor : Cube.CoreColor),
                                                            (checkDown ? downColor : Cube.CoreColor),
                                                            (checkLeft ? leftColor : Cube.CoreColor),
                                                            (checkFront ? frontColor : Cube.CoreColor),
                                                            (checkBack ? backColor : Cube.CoreColor));
                    }
                    
            return isSolved;
        }

        public TreeView CreateTree(TreeView tree)
        {
            TreeNode zNode;
            TreeNode pieceNode;

            tree.Nodes.Clear();

            for (int z = 0; z < size; z++)
            {
                zNode = new TreeNode(String.Format("[z:{0}]", z));
                tree.Nodes.Add(zNode);
                
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        pieceNode = new TreeNode(String.Format("Piece [z:{0}][x:{1},y:{2}]", z, x, y));
                        zNode.Nodes.Add(pieceNode);

                        for (int f = 0; f < 6; f++)
                            pieceNode.Nodes.Add(String.Format("{0} Face -- {1}", (Face)f, (pieces[z][x, y].Faces[f]) == Cube.CoreColor ? "n/a" : pieces[z][x, y].Faces[f].ToString()));
                    }
                }
            }
            return tree;
        }

        public void Rotate(Plane plane, Direction direction)
        {
            Rotate(selectedPieceZ, selectedPieceX, selectedPieceY, plane, direction);
        }

        public void Rotate(int zDimension, int xDimension, int yDimension, Plane plane, Direction direction)
        {
            if (size == 1)
                pieces[0][0, 0].Rotate(plane, direction);
            else
            {
                int max = size;
                int min = -1;
                Piece tempPiece;

                for (int offset = 0; offset < (size / 2) + (size % 2); offset++)
                {
                    // these offsets will slowly shrink the grid size to rotate (allows the inner inner centers of cubes to be rotated)
                    min++;
                    max--;

                    switch (plane)
                    {
                        #region Horizontal
                        case Plane.Horizontal:
                            
                            // if (below the Upper face and above the Down face) and we are now doing the inner center pieces, no need since they are Core Color
                            if ((zDimension > 0 && zDimension < Size - 1) && min > 0)
                                return;

                            switch (direction)
                            {
                                #region Clockwise
                                case Direction.Clockwise:
                                    // loop for the face, but keep shrinking down to cover sub-centers of faces
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        // store off the first piece that will have something rotated in on this pass
                                        tempPiece = pieces[zDimension][max - i, min];

                                        // the other three pieces rotate around
                                        PieceSwapAndRotate(plane, direction, zDimension, min, min + i, zDimension, max - i, min);
                                        PieceSwapAndRotate(plane, direction, zDimension, min + i, max, zDimension, min, min + i);
                                        PieceSwapAndRotate(plane, direction, zDimension, max, max - i, zDimension, min + i, max);

                                        // now for the first piece location that was lost due to the first rotation in this pass
                                        pieces[zDimension][max, max - i] = tempPiece;
                                        pieces[zDimension][max, max - i].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                                #region CounterClockwise
                                case Direction.Counterclockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[zDimension][min + i, min];

                                        PieceSwapAndRotate(plane, direction, zDimension, max, min + i, zDimension, min + i, min);
                                        PieceSwapAndRotate(plane, direction, zDimension, max - i, max, zDimension, max, min + i);
                                        PieceSwapAndRotate(plane, direction, zDimension, min, max - i, zDimension, max - i, max);

                                        pieces[zDimension][min, max - i] = tempPiece;
                                        pieces[zDimension][min, max - i].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                            }
                            break;
                        #endregion
                        #region Vertical
                        case Plane.VerticalWidth:
                        
                            // if (to the right of the Left face and to the left of the Right face) and we are now doing the inner center pieces, no need since they are Core Color
                            if ((yDimension > 0 && yDimension < Size - 1) && min > 0)
                                return;

                            switch (direction)
                            {
                                #region Clockwise
                                case Direction.Clockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[min][max - i, yDimension];

                                        PieceSwapAndRotate(plane, direction, min + i, min, yDimension, min, max - i, yDimension);
                                        PieceSwapAndRotate(plane, direction, max, min + i, yDimension, min + i, min, yDimension);
                                        PieceSwapAndRotate(plane, direction, max - i, max, yDimension, max, min + i, yDimension);

                                        pieces[max - i][max, yDimension] = tempPiece;
                                        pieces[max - i][max, yDimension].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                                #region CounterClockwise
                                case Direction.Counterclockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[min][min + i, yDimension];

                                        PieceSwapAndRotate(plane, direction, min + i, max, yDimension, min, min + i, yDimension);
                                        PieceSwapAndRotate(plane, direction, max, max - i, yDimension, min + i, max, yDimension);
                                        PieceSwapAndRotate(plane, direction, max - i, min, yDimension, max, max - i, yDimension);

                                        pieces[max - i][min, yDimension] = tempPiece;
                                        pieces[max - i][min, yDimension].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                            }
                            break;
                        case Plane.VerticalDepth:

                            // if (in front of the Back face and behind the Front face) and we are now doing the inner center pieces, no need since they are Core Color
                            if ((xDimension > 0 && xDimension < Size - 1) && min > 0)
                                return;

                            switch (direction)
                            {
                                #region Clockwise
                                case Direction.Clockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[min][xDimension, min + i];

                                        PieceSwapAndRotate(plane, direction, min + i, xDimension, max, min, xDimension, min + i);
                                        PieceSwapAndRotate(plane, direction, max, xDimension, max - i, min + i, xDimension, max);
                                        PieceSwapAndRotate(plane, direction, max - i, xDimension, min, max, xDimension, max - i);

                                        pieces[max - i][xDimension, min] = tempPiece;
                                        pieces[max - i][xDimension, min].Rotate(plane, direction);
                                    }
                                    break;
                                #endregion
                                #region CounterClockwise
                                case Direction.Counterclockwise:
                                    for (int i = 0; i < (max - min); i++)
                                    {
                                        tempPiece = pieces[min][xDimension, max - i];

                                        PieceSwapAndRotate(plane, direction, min + i, xDimension, min, min, xDimension, max - i);
                                        PieceSwapAndRotate(plane, direction, max, xDimension, min + i, min + i, xDimension, min);
                                        PieceSwapAndRotate(plane, direction, max - i, xDimension, max, max, xDimension, min + i);

                                        pieces[max - i][xDimension, max] = tempPiece;
                                        pieces[max - i][xDimension, max].Rotate(plane, direction);
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
            pieces[destZ][destX, destY] = pieces[sourceZ][sourceX, sourceY];
            pieces[destZ][destX, destY].Rotate(planeTurning, direction);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // see if this disposal helps a bit on the memory load per piece count
                    for (int z = 0; z < size; z++)
                        for (int x = 0; x < size; x++)
                            for (int y = 0; y < size; y++)
                            {
                                if (pieces[z] != null)
                                    pieces[z][x, y].Dispose();
                            }
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}