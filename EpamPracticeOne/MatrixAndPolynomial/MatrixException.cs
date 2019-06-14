using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAndPolynomial
{
    class MatrixException:Exception
    {
        public MatrixException() : base() { }
        public MatrixException(string v) : base(v) { }
        public MatrixException(string v, Exception exception):base (v, exception) { }
    }
}
