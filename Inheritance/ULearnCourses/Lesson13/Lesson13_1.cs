// <Summary>
// https://ulearn.me/ - Основы программирования - Наследование - Всем печать!
// Напишите метод, который печатает все, что угодно, через запятую.
// </Summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace ULearnCourses
{
    class Lesson13_1
    {
        public static void PrintForAll()
        {
            Print(1, 2);
            Print("a", 'b');
            Print(1, "a");
            Print(true, "a", 1);
        }
        public static void Print(params object[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(obj.GetValue(i).ToString());
            }
            Console.WriteLine();
        }
    }
}
