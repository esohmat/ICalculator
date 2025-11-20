
using System;

namespace ICalculator
{
    public interface ICalculator
    {
        double Add(double a, double b);
    }

    public class SimpleCalculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    class Program
    {
        public static void Main()
        {
            ICalculator calculator = new SimpleCalculator();

            Console.WriteLine("=== Мини калькулятор ===");
            Console.WriteLine("Программа складывает два числа");

            try
            {
                Console.Write("Введите первое число: ");
                string input1 = Console.ReadLine();
                double number1 = ParseNumber(input1, "первое число");

                Console.Write("Введите второе число: ");
                string input2 = Console.ReadLine();
                double number2 = ParseNumber(input2, "второе число");

                double result = calculator.Add(number1, number2);

                Console.WriteLine($"\nРезультат: {number1} + {number2} = {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"\nОшибка формата: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"\nОшибка переполнения: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nНеожиданная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\n=== Работа программы завершена ===");
                Console.WriteLine("Нажмите любую клавишу для выхода");
                Console.ReadKey();
            }
        }

        private static double ParseNumber(string input, string fieldName)
        {
            try
            {
                return double.Parse(input);
            }
            catch (FormatException)
            {
                throw new FormatException($"Некорректный формат для {fieldName}. Введите число в правильном формате (например: 15,5 или 20.5).");
            }
            catch (OverflowException)
            {
                throw new OverflowException($"Слишком большое или слишком маленькое значение для {fieldName}.");
            }
        }
    }
}
