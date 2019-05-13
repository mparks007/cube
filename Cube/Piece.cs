using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CubeSolver
{
    class Piece
    {
        public Color[] Faces { get; set; }
        public static readonly Color CoreColor = Color.FromArgb(1, 1, 1);

        public Piece(Color upperColor, Color rightColor, Color downColor, Color leftColor, Color frontColor, Color backColor, bool isUpperFace, bool isDownFace, bool isLeftFace, bool isRightFace, bool isFrontFace, bool isBackFace)
        {
            // allocate six faces on the piece (assuming will only being doing cubes in this app)
            Faces = new Color[6];

            // build out the color scheme around the piece's faces (not coloring faces that wouldn't be visible to the eye)
            Faces[(int)Face.Upper] = (isUpperFace ? upperColor : CoreColor);
            Faces[(int)Face.Right] = (isRightFace ? rightColor : CoreColor);
            Faces[(int)Face.Down] = (isDownFace ? downColor: CoreColor);
            Faces[(int)Face.Left] = (isLeftFace ? leftColor : CoreColor);
            Faces[(int)Face.Front] = (isFrontFace ? frontColor : CoreColor);
            Faces[(int)Face.Back] = (isBackFace ? backColor : CoreColor);
        }

        public void ChangeFaceColors(Color[] priorFaceColors, Color[] newFaceColors)
        {
            if (Faces != null)
            {
                // swap face colors if necessary (check every face against every incoming prior face colors)
                for (int f = 0; f < 6; f++)
                    for (int c = 0; c < 6; c++)
                        if (Faces[f] == priorFaceColors[c])
                            Faces[(int)f] = newFaceColors[c];
            }
        }

        public void Rotate(Plane planeTurning, Direction direction)
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

        private void FaceSwaps(Face one, Face two, Face three, Face four)
        {
            Color temp = Faces[(int)one];
            Faces[(int)one] = Faces[(int)two];
            Faces[(int)two] = Faces[(int)three];
            Faces[(int)three] = Faces[(int)four];
            Faces[(int)four] = temp;
        }

        public bool IsSolved(Color upperColor, Color rightColor, Color downColor, Color leftColor, Color frontColor, Color backColor)
        {
            // see if all my faces match those considered solved
            return (Faces[(int)Face.Upper] == upperColor &&
                    Faces[(int)Face.Right] == rightColor &&
                    Faces[(int)Face.Down] == downColor &&
                    Faces[(int)Face.Left] == leftColor &&
                    Faces[(int)Face.Front] == frontColor &&
                    Faces[(int)Face.Back] == backColor);
        }
    }
}
