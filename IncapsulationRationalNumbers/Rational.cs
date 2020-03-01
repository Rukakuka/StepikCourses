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

            Verify(this.Numerator, this.Denominator);
            if (!this.IsNan && this.Numerator != 0)
                Simplify();
        }
        public Rational(int Numerator) : this(Numerator, 1) {}
        private void Verify(int Numerator, int Denominator)
        {
            if (Denominator == 0)
                this.IsNan = true;
            if (Numerator == 0 && !this.IsNan)
                this.Denominator = 1;
        }
        public Rational()
        {
            IsNan = true; 
        }
        public static implicit operator double(Rational R)
        {
            if (R.Denominator==0)
            {
                return double.NaN;
            }
            return ((double)R.Numerator)/((double)R.Denominator);
        }
        public static implicit operator int(Rational R)
        {
            if (R.Denominator == 0)
            {
                throw new ArgumentException();
            }

            if ((R.Numerator % R.Denominator) != 0)
            {
                throw new ArgumentException();
            }

            return R.Numerator / R.Denominator;
        }
        public static implicit operator Rational(int i)
        {
            return new Rational(i);
        }

        public static Rational operator+ (Rational A, Rational B)
        {
            int CommonNumerator = A.Numerator * B.Denominator + B.Numerator * A.Denominator;
            int CommonDenominator = A.Denominator * B.Denominator;            
            return Simplify(new Rational(CommonNumerator, CommonDenominator));
        }

        public static Rational operator *(Rational A, Rational B)
        {
            int CommonNumerator = A.Numerator * B.Numerator;
            int CommonDenominator = A.Denominator * B.Denominator;
            return Simplify(new Rational(CommonNumerator, CommonDenominator));
        }

        public static Rational operator -(Rational A, Rational B)
        {
            int CommonNumerator = A.Numerator * B.Denominator - B.Numerator * A.Denominator;
            int CommonDenominator = A.Denominator * B.Denominator;             
            return Simplify(new Rational(CommonNumerator, CommonDenominator));
        }

        public static Rational operator /(Rational A, Rational B)
        {
            if (B.IsNan || A.IsNan)
                return new Rational();
            int CommonNumerator = A.Numerator * B.Denominator;
            int CommonDenominator = A.Denominator * B.Numerator;

            return Simplify(new Rational(CommonNumerator, CommonDenominator));
        }

        private void Simplify()
        {
            if (this.IsNan)
                return;
            if (this.Numerator == 0)
                return;
            if (this.Numerator == this.Denominator)
            {
                this.Numerator = 1;
                this.Denominator = 1;
            }

            int greatestCommonDivisor = GreatestCommonDivisor(this.Numerator, this.Denominator);

            this.Numerator /= greatestCommonDivisor;
            this.Denominator /= greatestCommonDivisor;

            // 1/-2 -> -1/2 No practical use but for test to pass 
            if ((this.Denominator < 0 && this.Numerator >= 0) || (this.Denominator < 0 && this.Numerator <= 0))
            {
                this.Denominator = -this.Denominator;
                this.Numerator = -this.Numerator;
            }

            // http://en.wikipedia.org/wiki/Euclidean_algorithm
            int GreatestCommonDivisor(int num, int den)
            {
                return (den == 0) ? num : GreatestCommonDivisor(den, num % den);
            }
        }
        public static Rational Simplify(Rational R)
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

            
            // 1/-2 -> -1/2 No practical use but for test to pass 

            if ((R.Denominator < 0 && R.Numerator >= 0) || (R.Denominator < 0 && R.Numerator <= 0))
            {
                R.Denominator = -R.Denominator;
                R.Numerator = -R.Numerator;
            }

            return new Rational(R.Numerator / greatestCommonDivisor, R.Denominator / greatestCommonDivisor);

            // http://en.wikipedia.org/wiki/Euclidean_algorithm
            int GreatestCommonDivisor(int num, int den)
            {
                return (den == 0) ? num : GreatestCommonDivisor(den, num % den);
            }
        }
    }
}
