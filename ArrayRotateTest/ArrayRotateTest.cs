using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ArrayRotateTest
    {
        static void Main(string[] args)
        {
            int size = 4;
            int[][,] a = new int[size][,];

            BuildArray(size, ref a);
            PrintArray(a);

            Console.Write("Press Enter to Rotate");
            Console.ReadLine();

            RotateArray(a, 0, 0, 0);
            PrintArray(a);
            
            Console.Write("Press Enter to Exit");
            Console.ReadLine();
        }

        static void BuildArray(int size, ref int[][,] a)
        {
            a = new int[size][,];
            int num;

            for (int z = 0; z < size; z++)
            {
                num = 1;
                a[z] = new int[size, size];

                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        a[z][x, y] = num++;
                    }
                }
            }
        }

        static void RotateArray(int[][,] a, int z, int x, int y)
        {
            int min = -1;
            int max = a.GetLength(0) + 1;
            int temp;

            for (int offset = 0; offset < max / 2; offset++)
            {
                min++;
                max--;

                if (max < min)
                    break;

                //for (int z = min; z < max; z++)
                {
                  //  for (int x = min; x < max; x++)
                    {
                    //    for (int y = min; y < max; y++)
                        {
                               // move and rotate corners
                                temp = a[z][max - 1, min];

                                // if not on the center cube (let temp deal with the rotation)
                                if (min != max - 1)
                                {
                                    a[z][max - 1, min] = a[z][min, min];
                                    a[z][min, min] = a[z][min, max - 1];
                                    a[z][min, max - 1] = a[z][max - 1, max - 1];
                                }

                                a[z][max -1, max -1] = temp;

                                // store off array of temp edges
                                // todo                        
                        }
                    }
                }
            }
        }

        static void PrintArray(int[][,] a)
        {
            int max = a.GetLength(0);

            for (int z = 0; z < max; z++)
            {
                for (int y = 0; y < max; y++) 
                {
                    for (int x = 0; x < max; x++)
                    {
                        Console.Write(String.Format(" {0,2}", a[z][x, y]));
                    }
                    Console.Write(Environment.NewLine);
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
