using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp16
{
    [LastModified("10 fEB 2010","IFormattable interface")]
    public class Vector : IFormattable, IEnumerable<double>
    {
        public double X { get; }

        public double Y { get; }

        public double Z { get; }

        public Vector(double x,double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<double> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
