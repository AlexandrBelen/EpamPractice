using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixAndPolynomial;

namespace EpamPracticeOne
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPolynom();
            Console.ReadKey();
        }

        public static void TestMatrix()
        {
            int[,] arr = new int[2, 2];
            int[,] arr1 = new int[2, 2];
            Matrix matrix1 = new Matrix(arr);
            Matrix matrix2 = new Matrix(arr1);

            #region Plus
            Console.WriteLine("Plus");
            foreach (var el in matrix1)
                Console.Write(el + " ");
            Console.WriteLine("\n" + new string('-', 50));
            foreach (var el in matrix2)
                Console.Write(el + " ");
            Console.WriteLine("\n" + new string('-', 50));
            Matrix matrix3 = matrix1 + matrix2;
            foreach (var el in matrix3)
                Console.Write(el + " ");
            Console.WriteLine("\n\n");
            #endregion

            #region Minus
            Console.WriteLine("Minus");
            foreach (var el in matrix3)
                Console.Write(el + " ");
            Console.WriteLine("\n" + new string('-', 50));
            foreach (var el in matrix2)
                Console.Write(el + " ");
            Console.WriteLine("\n" + new string('-', 50));
            Matrix matrix4 = matrix3 - matrix2;
            foreach (var el in matrix4)
                Console.Write(el + " ");
            #endregion
        }

        public static void TestPolynom()
        {
            Polynomial polynomial1 = new Polynomial(new int[] { 3, 2, 7, 6, 10, 15, -375 });
            Polynomial polynomial2 = new Polynomial(new int[] { 2, 4, 7 });
            Polynomial polynomial3 = new Polynomial(new int[] { 4, 6, 10, 123, 356, 234, 543 });
            Polynomial polynomial4 = new Polynomial(new int[] { 3, 1, 1, 2 });

            Console.WriteLine("Polynomial1");
            Console.WriteLine(polynomial1.GetPolynom());
            Console.WriteLine();

            Console.WriteLine("Polynomial2");
            Console.WriteLine(polynomial2.GetPolynom());
            Console.WriteLine();

            Console.WriteLine("Polynomial3");
            Console.WriteLine(polynomial3.GetPolynom());
            Console.WriteLine();

            Console.WriteLine("Polynomial4");
            Console.WriteLine(polynomial4.GetPolynom());
            Console.WriteLine();

            Console.WriteLine("Polynomial1 + Polynomial2");
            Polynomial polynomialad = polynomial1 + polynomial2;
            Console.WriteLine(polynomialad.GetPolynom());
            Console.WriteLine();


            Console.WriteLine("Polynomial3 - Polynomial2");
            Polynomial polynomialmin = polynomial3 - polynomial2;
            Console.WriteLine(polynomialmin.GetPolynom());
            Console.WriteLine();

            Console.WriteLine("Polynomia4 * Polynomia2");
            Polynomial polynomialmult = new Polynomial(new int[] { 1 });
            polynomialmult = polynomial4 * polynomial2;
            Console.WriteLine(polynomialmult.GetPolynom());
            Console.ReadKey();
        }
    }
}
