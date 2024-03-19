  using System;

public struct Number
        {
            public int RealPart;

            public Number(int realPart)
            {
                RealPart = realPart;
            }

            public static Number Add(Number num1, Number num2)
            {
                return new Number(num1.RealPart + num2.RealPart);
            }

            public static Number Subtract(Number num1, Number num2)
            {
                return new Number(num1.RealPart - num2.RealPart);
            }

            public static Number Multiply(Number num1, Number num2)
            {
                return new Number(num1.RealPart * num2.RealPart);
            }

            public static Number Divide(Number num1, Number num2)
            {
                if (num2.RealPart == 0)
                    throw new DivideByZeroException("Не может быть 0");
                return new Number(num1.RealPart / num2.RealPart);
            }

            public override string ToString()
            {
                return $"Number = {RealPart}";
            }
        }

        class Program
        {
            static void Main()
            {
                Number num1 = new Number(1);
                Number num2 = new Number(0);

                Number sum = Number.Add(num1, num2);
                Number difference = Number.Subtract(num1, num2);
                Number product = Number.Multiply(num1, num2);
                Number quotient = Number.Divide(num1, num2);

                Console.WriteLine(num1);
                Console.WriteLine(num2);
                Console.WriteLine(sum);
                Console.WriteLine(difference);
                Console.WriteLine(product);
                Console.WriteLine(quotient);
            }
        }


 
