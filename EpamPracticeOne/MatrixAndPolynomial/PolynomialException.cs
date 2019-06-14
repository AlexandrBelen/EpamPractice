using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAndPolynomial
{
    class PolynomialException:Exception
    {
        public PolynomialException() : base() { }
        public PolynomialException(string v) : base(v) { }
        public PolynomialException(string v, Exception exception) : base(v, exception) { }
    }
}
