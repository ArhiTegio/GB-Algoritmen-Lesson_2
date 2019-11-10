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
            { "1", new TranslationToBinary() },
            { "2", new Exponentiation() },
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
                    "1.-Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию." + Environment.NewLine +
                    "  -Реализовать функцию возведения числа a в степень b: " + Environment.NewLine +
                    "2.   a.Без рекурсии." + Environment.NewLine +
                    "3.   b.Рекурсивно." + Environment.NewLine +
                    "4.   c.*Рекурсивно, используя свойство чётности степени." + Environment.NewLine +
                    "  -**Исполнитель «Калькулятор» преобразует целое число, записанное на экране.У исполнителя две команды, каждой присвоен номер: " + Environment.NewLine +
                    "      1.Прибавь 1." + Environment.NewLine +
                    "      2.Умножь на 2." + Environment.NewLine +
                    "    Первая к оманда увеличивает число на экране на 1, вторая увеличивает его в 2 раза. Определить, сколько существует программ, которые преобразуют число 3 в число 20:" + Environment.NewLine +
                    "5.    а.С использованием массива." + Environment.NewLine +
                    "6.    b. * С использованием рекурсии." + Environment.NewLine +
                    "0. Нажмите для выхода из программы.");

                n = q.Question<int>("Ваша команда ", new HashSet<char>() { '0', '1', '2', '3', '4' }, true);
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

    class TranslationToBinary : Act
    {
        public override void Work() => WriteLine($"Двоичным представлением числа будет: { ToBinary(int.Parse((new Questions()).Question<int>("Введите число:", new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, true))) }");
        
        public string ToBinary(double num) => Convert(new StringBuilder(), (int)Math.Sqrt(num), ref num).ToString();
        
        private StringBuilder Convert(StringBuilder txt, int step, ref double number)
        {
            if (number <= 0 && step <= 0) return txt;
            var t = step * step;
            if (t == 0) t = 1;
            var answer = "0";
            if (t <= number)
            {
                answer = "1";
                number -= t;
            }
            step--;
            txt.Append(answer);
            Convert(txt, step, ref number);
            return txt;
        }
    }

    class Exponentiation : Act
    {
        public override void Work()
        {
            var number = int.Parse((new Questions()).Question<int>("Введите число:", new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, true));
            var degree = int.Parse((new Questions()).Question<int>("Введите степень:", new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, true));
            WriteLine($" {ExponentNotRecuresion(number, degree)}");
        }

        private string ExponentNotRecuresion(int number, int degree)
        {
            var n = number;
            var d = 1;
            while(true)
            {
                d = d + 2;
                if (degree < d) break;
                number = number * number;
                degree -= d;
            }             
         
            while(degree > 0)
            {
                number = number * n;
                degree--;
            }

            return number.ToString();
        }
    }
}