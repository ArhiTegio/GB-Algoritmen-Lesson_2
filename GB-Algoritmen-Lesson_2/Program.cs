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
            { "3", new Calculator() },
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
                    "2.-Реализовать функцию возведения числа a в степень b: " + Environment.NewLine +
                    "     a.Без рекурсии." + Environment.NewLine +
                    "     b.Рекурсивно." + Environment.NewLine +
                    "     c.*Рекурсивно, используя свойство чётности степени." + Environment.NewLine +
                    "  -**Исполнитель «Калькулятор» преобразует целое число, записанное на экране.У исполнителя две команды, каждой присвоен номер: " + Environment.NewLine +
                    "      1.Прибавь 1." + Environment.NewLine +
                    "      2.Умножь на 2." + Environment.NewLine +
                    "3.-Первая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза. Определить, сколько существует программ, которые преобразуют число 3 в число 20:" + Environment.NewLine +
                    "      а.С использованием массива." + Environment.NewLine +
                    "      b.*С использованием рекурсии." + Environment.NewLine +
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
            WriteLine($"Без рекурси: { ExponentNotRecuresion(number, degree) }");
            WriteLine($"С рекурсией: { ExponentRecuresion(number, degree) }");
            WriteLine($"Рекурсивно, используя свойство чётности степени: { ExponentRecuresion2(number, degree) }");
        }

        private string ExponentNotRecuresion(int number, int degree)
        {
            var n = number;
            while (degree >= 2)
            {
                number *= n;
                degree--;
            }

            return number.ToString();
        }

        private string ExponentRecuresion(int number, int degree) => Recuresion(number, ref number, degree).ToString();
        
        private int Recuresion(int number, ref int numberAnswer, int degree)
        {
            numberAnswer *= number;
            degree--;
            if(degree > 1) Recuresion(number,ref numberAnswer, degree);
            return numberAnswer;
        }

        private string ExponentRecuresion2(int number, int degree) => Recuresion2(number, ref number, degree).ToString();
        private int Recuresion2(int number, ref int numberAnswer, int degree)
        {
            if (degree == 1) return numberAnswer;
            if (degree % 2 != 0)
            {
                degree--;
                numberAnswer = Recuresion2(number, ref numberAnswer, degree);
                return numberAnswer *= number;
            }
            else
            {
                numberAnswer *= numberAnswer;
                return Recuresion2(number, ref numberAnswer, degree /= 2);
            }
        }
    }

    class Calculator : Act
    {
        public override void Work()
        {
            WriteLine($"С использованием массива: { Massiv(20) }");
            int t = 0;
            WriteLine($"С использованием рекурсии: { Recuresion(20, ref t) }");
        }

        private string Massiv(int n)
        {
            var mass = new HashSet<int[]>();
            for (int i = 0; i< n; ++i)
            {
                for (int j = 0; j < )
            }
            
            return "";
        }

        Func<IEnumerable<int>, IEnumerable<IEnumerable<int>>> getAllSubsets = xs =>
            (xs == null || !xs.Any()) ? Enumerable.Empty<IEnumerable<int>>()
        :  xs.Skip(1).Any()
        ? getAllSubsets(xs.Skip(1))
                .SelectMany(ys => new [] { ys, xs.Take(1).Concat(ys) })
            : new [] { Enumerable.Empty<int>(), xs.Take(1) };

private string Recuresion(int n, ref int step)
        {
            if (n <= 0)
            {
                if (n == 0) step++;
            }
            else
            {
                Recuresion(n - 1, ref step);
                Recuresion(n / 2, ref step);
            }
            return step.ToString();
        }
    }
}