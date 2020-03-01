// <Summary>
// https://ulearn.me/ - Основы программирования - Наследование - Склейка массивов
// Реализуйте метод Combine, который возвращает массив, собранный из переданных массивов.
// Для того, чтобы создать новый массив, используйте статический метод Array.CreateInstance, принимающий тип элемента массива.
// Для того, чтобы узнать тип элементов в переданном массиве, используйте myArray.GetType().GetElementType().
// Проверьте, что типы элементов совпадают во всех переданных массивах!
// Если результирующий массив создать нельзя, возвращайте null.
// </Summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace ULearnCourses
{
    class Lesson13_2
    {
        public static void ArrayExample()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }

        static Array Combine(params Array[] arrays)
        {
            if (arrays.Length == 0)
                return null;

            int length = 0;
            var type = arrays.GetValue(0).GetType().GetElementType();

            foreach (var array in arrays)
            {
                if (!array.GetType().GetElementType().Equals(type))
                    return null;
                length += array.Length;
            }
            Array concatenated = Array.CreateInstance(type, length);
            int count = 0;
            for (int j = 0; j < arrays.Length; j++)
                for (int i = 0; i < arrays[j].Length; i++)
                {
                    concatenated.SetValue(arrays[j].GetValue(i), count);
                    count++;
                }
            return concatenated;
        }

        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array.GetValue(i));
            Console.WriteLine();
        }

    }
}
