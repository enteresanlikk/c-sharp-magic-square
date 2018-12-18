using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare
{

    class Square
    {
        public int[,] square;
        public int size;
        public int row;
        public int column;
        public int lastRow;
        public int lastColumn;
        public int matrixSize;

        public Square(int s)
        {
            size = s;
            square = new int[size, size];
            row = 0;
            column = size / 2;
            matrixSize = size * size;
            square[row, column] = 1;
        }

        public void Solve()
        {
            for (int i = 2; i < matrixSize + 1; i++)
            {
                if (row - 1 < 0) row = size - 1;
                else row--;

                if (column + 1 == size) column = 0;
                else column++;

                if (square[row, column] == 0) square[row, column] = i;
                else
                {
                    row = lastRow;
                    column = lastColumn;
                    if (row + 1 == 0) row = 0;
                    else row++;
                    square[row, column] = i;
                }
                lastRow = row;
                lastColumn = column;
            }
            WriteSquare();
        }

        public void WriteSquare()
        {
            int i = 1;
            foreach (var item in square)
            {
                Console.Write(item + "\t");
                if (i % size == 0) Console.WriteLine();
                i++;
            }
        }
    }

    class MagicSquare
    {
        static void Main(string[] args)
        {
            int size = 3;
            while (true)
            {

                try
                {
                    Console.Write("Magic Square boyutu ne olsun? (3, 5, 7) ");
                    size = Math.Abs(int.Parse(Console.ReadLine()));
                    if (size > 2 && size % 2 == 1)
                    {
                        Square magicSquare = new Square(size);
                        magicSquare.Solve();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı boyut girdiniz!");
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
