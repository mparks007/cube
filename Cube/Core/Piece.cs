using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CubeSolver.Enums;

namespace CubeSolver.Core
{
    public class Piece : IDisposable
    {
        private bool disposed = false; 

        public Color[] Faces { get; set; }

        public Piece() 
            : this (Cube.CoreColor, Cube.CoreColor, Cube.CoreColor, Cube.CoreColor, Cube.CoreColor, Cube.CoreColor, isUpperFace: false, isDownFace: false, isLeftFace: false, isRightFace: false, isFrontFace: false, isBackFace: false)
        {
        }
        
        public Piece(Color upperColor, Color rightColor, Color downColor, Color leftColor, Color frontColor, Color backColor, bool isUpperFace, bool isDownFace, bool isLeftFace, bool isRightFace, bool isFrontFace, bool isBackFace)
        {
            // allocate six faces on the piece (assuming will only being doing cubes in this app)
            Faces = new Color[6];

            // build out the color scheme around the piece's faces (not coloring faces that wouldn't be visible to the eye)
            Faces[(int)Face.Upper] = (isUpperFace ? upperColor : Cube.CoreColor);
            Faces[(int)Face.Right] = (isRightFace ? rightColor : Cube.CoreColor);
            Faces[(int)Face.Down] = (isDownFace ? downColor: Cube.CoreColor);
            Faces[(int)Face.Left] = (isLeftFace ? leftColor : Cube.CoreColor);
            Faces[(int)Face.Front] = (isFrontFace ? frontColor : Cube.CoreColor);
            Faces[(int)Face.Back] = (isBackFace ? backColor : Cube.CoreColor);
        }

        public void ChangeFaceColors(Color[] priorFaceColors, Color[] newFaceColors)
        {
            if (Faces != null)
            {
                // swap face colors if necessary (check every face against every incoming prior face color)
                for (int f = 0; f < 6; f++)
                    for (int c = 0; c < 6; c++)
                        if (Faces[f] == priorFaceColors[c])
                            Faces[f] = newFaceColors[c];
            }
        }

        public void Rotate(Plane planeTurning, Direction direction)
        {
            if (Faces != null)
            {
                switch (planeTurning)
                {
                    case Plane.VerticalDepth:
                        switch (direction)
                        {
                            case Direction.Clockwise:
                                FaceSwaps(Face.Upper, Face.Front, Face.Down, Face.Back);
                                break;
                            case Direction.Counterclockwise:
                                FaceSwaps(Face.Upper, Face.Back, Face.Down, Face.Front);
                                break;
                        }
                        break;
                    case Plane.VerticalWidth:
                        switch (direction)
                        {
                            case Direction.Clockwise:
                                FaceSwaps(Face.Upper, Face.Left, Face.Down, Face.Right);
                                break;
                            case Direction.Counterclockwise:
                                FaceSwaps(Face.Upper, Face.Right, Face.Down, Face.Left);
                                break;
                        }
                        break;
                    case Plane.Horizontal:
                        switch (direction)
                        {
                            case Direction.Clockwise:
                                FaceSwaps(Face.Front, Face.Right, Face.Back, Face.Left);
                                break;
                            case Direction.Counterclockwise:
                                FaceSwaps(Face.Front, Face.Left, Face.Back, Face.Right);
                                break;
                        }
                        break;
                }
            }
        }

        private void FaceSwaps(Face one, Face two, Face three, Face four)
        {
            // do basic swap steps
            if (Faces != null)
            {
                Color temp = Faces[(int)one];
                
                Faces[(int)one] = Faces[(int)two];
                Faces[(int)two] = Faces[(int)three];
                Faces[(int)three] = Faces[(int)four];
             
                Faces[(int)four] = temp;
            }
        }

        public bool IsSolved(Color correctUpperColor, Color correctRightColor, Color correctDownColor, Color correctLeftColor, Color correctFrontColor, Color correctBackColor)
        {
            // see if all my faces match those considered solved
            return (Faces[(int)Face.Upper] == correctUpperColor &&
                    Faces[(int)Face.Right] == correctRightColor &&
                    Faces[(int)Face.Down] == correctDownColor &&
                    Faces[(int)Face.Left] == correctLeftColor &&
                    Faces[(int)Face.Front] == correctFrontColor &&
                    Faces[(int)Face.Back] == correctBackColor);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // not much to dispose further
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
