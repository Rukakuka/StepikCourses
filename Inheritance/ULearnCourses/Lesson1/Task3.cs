using System;
using System.Collections.Generic;
using System.Text;

namespace ULearnCourses.Lesson1
{
    public class Task3
    {
        public static void WrongTypes()
        {
            double pi = Math.PI;
            long tenThousand = 10000L;
            decimal tenThousandPi = (decimal)pi * tenThousand;
            long roundedTenThousandPi = (long)Math.Round(tenThousandPi);
            int integerPartOfTenThousandPi = (int)tenThousandPi;
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}
