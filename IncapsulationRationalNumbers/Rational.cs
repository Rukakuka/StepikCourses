using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public bool IsNan { get; private set; }
        public Rational (int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            this.IsNan = false;

            CheckForNan(this.Denominator);
            CheckForZero(this.Numerator);
        }
        public Rational(int Numerator)
        {
            this.Numerator = Numerator;
            this.Denominator = 1;
            this.IsNan = false;

            CheckForNan(this.Denominator);
            CheckForZero(this.Numerator);
        }
        public Rational()
        {
            IsNan = false; 
        }
        public static implicit operator double(Rational R)
        {
            return ((double)R.Numerator)/((double)R.Denominator);
        }
        public static implicit operator Rational(int i)
        {
            return new Rational(i);
        }
        private void CheckForNan(int Denominator)
        {
            if (Denominator == 0)
                this.IsNan = true;
        }
        private void CheckForZero(int Numerator)
        {
            if (Numerator == 0)
                this.Denominator = 1;
        }

        private Rational Simplify(Rational R)
        {
            if (R.IsNan)
                return R;
            if (R.Numerator == 0)
                return R;
            if (R.Numerator == R.Denominator)
            {
                R.Numerator = 1;
                R.Denominator = 1;
                return R;
            }

            int greatestCommonDivisor = GreatestCommonDivisor(R.Numerator, R.Denominator);

            return new Rational(R.Numerator/greatestCommonDivisor, R.Denominator/greatestCommonDivisor);

            int GreatestCommonDivisor(int num, int den)
            {
                return (den == 0) ? num : GreatestCommonDivisor(den, num % den);
            }
        }
    }
}
