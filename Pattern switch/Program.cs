using System;

namespace Pattern_switch
{
    class Program
    {
        public static double Add(double a, double b) => a + b;

        public static double Sub(double a, double b) => a - b;

        public static double Mult(double a, double b) => a * b;

        public static double Div(double a, double b) => a / b;

        public static double Calculator(double a, double b, string action)
        {
            double result = 0;
            switch (action)
            {
                case "Add":
                    result = Add(a, b);
                    break;
                case "Sub":
                    result = Sub(a, b);
                    break;
                case "Mult":
                    result = Mult(a, b);
                    break;
                case "Div":
                    result = Div(a, b);
                    break;
                default:
                    throw new Exception("Некорректный выбор!");
            }
            return result;
        }

        // C# 8.0 позволяет сократить конструкцию switch, которая возвращает значение
        public static double CalculatorWithPatternSwitch(double a, double b, string action) =>
            action switch
            {
                "Add" => Add(a, b),
                "Sub" => Sub(a, b),
                "Mult" => Mult(a, b),
                "Div" => Div(a, b),
                _ => throw new Exception("Некорректный выбор!")
            };

        public static double Discount(double Price, double Quantity)
        {
            double Sum = Price * Quantity;

            if (Sum < 100)
                Sum = 0;
            else if (Sum >= 100 && Sum < 200)
                Sum = Sum / 100 * 3;
            else if (Sum >= 200 && Sum < 300)
                Sum =  Sum / 100 * 5;
            else if (Sum >= 300)
                Sum = Sum / 100 * 7;

            return Sum;
        }

        // В C# 9.0 были добавлены реляционный (relational pattern) и логический (logical pattern) паттерны
        public static double Discount_relational_logical_pattern(double Price, double Quantity)
        {
            double Sum = Price * Quantity;
            return Sum switch
            {
                < 100 => 0,
                >= 100 and < 200 => Sum / 100 * 3,
                >= 200 and < 300 => Sum / 100 * 5,
                _ => Sum / 100 * 7
            };
        }



        static void Main(string[] args)
        {
            try
            {
                double a, b, result;
                Console.WriteLine("Введите первое число: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите второе число: ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Выберите действие (Add, Sub, Mult, Div): ");
                string action = Console.ReadLine();
                result = Calculator(a, b, action);
                result = CalculatorWithPatternSwitch(a, b, action);
                Console.WriteLine("Результат: " + result);

                double Price, Sum, Quantity;
                Console.WriteLine("Введите стоимость единицы товара: ");
                Price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите количество товара: ");
                Quantity = Convert.ToDouble(Console.ReadLine());
                Sum = Discount(Price, Quantity);
                Sum = Discount_relational_logical_pattern(Price, Quantity);
                Console.WriteLine($"Скидка составляет: {Sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
