using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAndPolynomial
{
    public class Matrix
    {
        private delegate int PlusOrMinus(int first, int second);

        public int Col { get; set; }
        public int Row { get; set; }

        private int[,] myMatrix;

        public Matrix(int[,] mass)
        {
            myMatrix = mass;
            Row = mass.GetLength(0);
            Col = mass.GetLength(1);
            //Random random = new Random();
            //for(int i = 0; i < Row; i++)
            //{
            //    for(int j = 0; j < Col; j++)
            //    {
            //        myMatrix[i, j] = random.Next(100);
            //    }
            //}
            Init(mass);
        }
        public Matrix(int row, int col)
        {
            if (Col < 0 || Row < 0)
                throw new MatrixException("Matrix must have at least one line or column");
            this.Row = row;
            this.Col = col;
            myMatrix = new int[Row, Col];
        }

        public void Init(int[,] mass)
        {
            Console.WriteLine("Input elements of matrix: ");
            for (int i = 0; i < Row; i++)
            {
                for(int j = 0; j < Col; j++)
                {
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
 
        public int this[int Columns, int Rows]
        {
            get
            {
                if (Columns < 0 || Rows < 0 || this.Col < Columns || this.Row < Rows)
                    throw new MatrixException("Out of range matrix");
                return myMatrix[Columns, Rows];
            }
            set
            {
                myMatrix[Columns, Rows] = value;
            }
        }
        private static Matrix PlusOrMinusMatrix(Matrix first, Matrix second, PlusOrMinus Calculation)
        {
            if (first == null || second == null)
                throw new MatrixException("Matrix is not initialized");
            if (first.Col != second.Col || first.Row != second.Row)
                throw new MatrixException("Matrices must have the same number of columns and rows.");
            Matrix matrix = new Matrix(first.Row, second.Col);
            for (int i = 0; i < matrix.Row; i++)
                for (int j = 0; j < matrix.Col; j++)
                    matrix[i, j] = Calculation(first[i, j], second[i, j]);
            return matrix;
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            return PlusOrMinusMatrix(first, second, (x, y) => x + y);
        }
        public static Matrix operator -(Matrix first, Matrix second)
        {
            return PlusOrMinusMatrix(first, second, (x, y) => x - y);
        }
        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first == null || second == null)
                throw new MatrixException("Matrix not initialized");
            if (first.Col != second.Row)
                throw new MatrixException("Matrices must have the same number of columns and rows.");
            Matrix matrix = new Matrix(first.Row, second.Col);
            for (int i = 0; i < first.Row; i++)
            {
                for (int j = 0; j < second.Col; j++)
                {
                    for (int k = 0; k < second.Row; k++)
                    {
                        matrix[i, j] += first[i, k] * second[k, j];
                    }
                }
            }
            return matrix;
        }
        public static bool operator ==(Matrix first, Matrix second)
        {
            if ((object)first == null && (object)second == null)
                return true;
            if (((object)first) == null || ((object)second) == null)
                return false;
            if (first.Col != second.Col || first.Row != second.Row)
                throw new MatrixException("Matrices must have the same number of columns and rows.");
            for (int i = 0; i < first.Row; i++)
                for (int j = 0; j < second.Col; j++)
                    if (second[i, j] != first[i, j]) return false;
            return true;
        }
        public static bool operator !=(Matrix first, Matrix second)
        {
            if ((object)first == null && (object)second == null)
                return true;
            if (((object)first) == null || ((object)second) == null)
                return false;
            if (first.Col != second.Col || first.Row != second.Row)
                throw new MatrixException("Matrices must have the same number of columns and rows.");
            for (int i = 0; i < first.Row; i++)
                for (int j = 0; j < second.Col; j++)
                    if (second[i, j] != first[i, j]) return true;
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return myMatrix.GetEnumerator();
        }
        public Matrix Copy()
        {
            return new Matrix(this.myMatrix);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
