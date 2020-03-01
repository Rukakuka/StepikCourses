using System;
using System.Collections.Generic;
using System.Text;

namespace ULearnCourses.Lesson1
{
    public class Task5
    {
        public static void VasyaEdinichka()
        {
            string doubleNumber = "894376.243643";
            double number = Double.Parse(doubleNumber); // Вася уверен, что ошибка где-то тут
            Console.WriteLine(number + 1);
        }
    }
}
