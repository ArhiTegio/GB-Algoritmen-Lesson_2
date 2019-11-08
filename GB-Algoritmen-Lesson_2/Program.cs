using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFastDecisions;
using static System.Console;
using System.Reflection;

namespace GB_Algoritmen_Lesson_2
{
    class Program
    {
        static Dictionary<string, Act> dict = new Dictionary<string, Act>
        {
            { "1", new Act },
        };  

        static void Main(string[] args)
        {
            var ex = new Extension();
            var q = new Questions();
            var n = "";
            WriteLine("С# - Алгоритмы и структуры данных. Задание 2.");
            WriteLine("Кузнецов");
            while (n != "0")
            {
                WriteLine("Введите номер интересующей вас задачи:" + Environment.NewLine +
                    "1.	Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию." + Environment.NewLine +
                    "2.Реализовать функцию возведения числа a в степень b: " + Environment.NewLine +
                    "a.Без рекурсии." + Environment.NewLine +
                    "b.Рекурсивно." + Environment.NewLine +
                    "c.  * Рекурсивно, используя свойство чётности степени." + Environment.NewLine +
                    "3.  * *Исполнитель «Калькулятор» преобразует целое число, записанное на экране.У исполнителя две команды, каждой присвоен номер: " + Environment.NewLine +
                    "      1.Прибавь 1." + Environment.NewLine +
                    "      2.Умножь на 2." + Environment.NewLine +
                    "   Первая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза.Определить, сколько существует программ, которые преобразуют число 3 в число 20:" + Environment.NewLine +
                    "      а.С использованием массива." + Environment.NewLine +
                    "      b. * С использованием рекурсии." + Environment.NewLine +
                    "0. Нажмите для выхода из программы.");

                n = q.Question<int>("Введите ", new HashSet<char>() { '0', '1', '2', '3', '4' }, true);
                if (n == "0") break;
                dict[n].Work();
            }

            Console.ReadKey();
        }
    }

    abstract class Act
    {
        public abstract void Work();
    }
}
