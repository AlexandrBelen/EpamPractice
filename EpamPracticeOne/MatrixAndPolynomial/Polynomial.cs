using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAndPolynomial
{
    public static class Coeff
    {
        private static Dictionary<int, string> coeff=new Dictionary<int, string>()
            { { 0,"⁰"},{1,"¹"}, {2,"²"},{3,"³"},{4,"⁴" },{5,"⁵"},{6,"⁶" },{7,"⁷"},{8,"⁸" }, {9,"⁹"} };

        public static string GetCoeff(int key)
        {
            string value = "";
            
            if (key <= 9)
            {
                if(coeff.TryGetValue(key, out value))
                {
                    return value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                string num = key.ToString();
                for(int i = 0; i < num.Length; i++)
                {
                    if(coeff.TryGetValue(int.Parse(num[i].ToString()),out string newStr))
                    {
                        value += newStr;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }
            return value;
        }
    }
    public class Polynomial
    {
        public int Degree { get; set; }
        private int[] coefficients;
        public Polynomial(int[] Coefficients)
        {
            coefficients = Coefficients;
            Degree = Coefficients.Length;
        }
        public Polynomial(int Degree)
        {
            this.Degree = Degree;
            coefficients = new int[Degree];
        }

        public int this[int Element]
        {
            get
            {
                if (Element < 0 || Element > this.Degree)
                    throw new PolynomialException("Out of range polynomial");
                return coefficients[Element];
            }
            set
            {
                coefficients[Element] = value;
            }
        }
        public Polynomial Copy()
        {
            return new Polynomial(this.coefficients);
        }
        public void ChangeCoeff(int DegreeCoeff, int NewCoefff)
        {
            if (DegreeCoeff < 0 || DegreeCoeff > this.Degree)
            {
                throw new PolynomialException("Out");
            }
            this[DegreeCoeff] = NewCoefff;
        }

        private delegate int PlusOrMinus(int first, int second);
        private static Polynomial PlusOrMinusPolynomial(Polynomial first, Polynomial second, PlusOrMinus Calculation)
        {
            Polynomial newPolynom;
            if (first == null || second == null)
                throw new PolynomialException("Polynom is not initialized");
            if(first.Degree >= second.Degree)
            {
                newPolynom = new Polynomial(first.coefficients);
                for(int i = 0; i < second.Degree; i++)
                {
                    newPolynom[i] = Calculation(first[i], second[i]);
                }
                return newPolynom;
            }
            else if (first.Degree <= second.Degree)
            {
                return PlusOrMinusPolynomial(first, second, Calculation);
            }
            else
            {
                throw new PolynomialException("Errorka");
            }
        }

        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            return PlusOrMinusPolynomial(first, second, (x, y) => x + y);
        }
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            return PlusOrMinusPolynomial(first, second, (x, y) => x - y);
        }
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            if (first == null || second == null)
                throw new PolynomialException("Polynom is not initialized");
            Polynomial polynomial = new Polynomial(first.Degree + second.Degree);
            for(int i = 0; i < first.Degree; i++)
            {
                for(int j = 0; j < second.Degree; j++)
                {
                    polynomial[i + j] += first[i] * second[j];
                }
            }
            return polynomial;
        }

        public string GetPolynom()
        {
            string myStr = "";
            for (int i = 0; i < this.Degree; i++)
                if (this[i] != 0)
                {
                    if (i == 0) myStr += this[i].ToString();
                    else
                    if (this[i] > 0 && i != 0) myStr += "+" + this[i].ToString() + "x" + Coeff.GetCoeff(i);
                    else myStr += this[i].ToString() + "x" + Coeff.GetCoeff(i);
                }
            return myStr;
        }
    }
}
