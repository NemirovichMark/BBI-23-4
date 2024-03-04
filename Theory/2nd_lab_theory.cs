using System;

namespace _2nd_Lab
{
    class Theory
    {
        static void Main(string[] args)
        {
            #region Booleans Logic
            bool truth = true, failure; // can have only 2 values
            failure = false;
            truth = 5 > 2; // can take a result of inequality
            truth = (1 == 0) || ((1 > 0) && true); // logic sum & multiply going from left to right (and braces change the order as usual)
            failure = !truth; // reverting (NOT)

            // when you use if operator with several conditions
            // if you use a multiply &&, it will go till first false condition or all conditions would checked (that take part in multi)
            // if you use a sum ||, it will go till first true condition or all conditions would checked (that take part in sum)

            if (1 == 0 || 5 < 2 || "a" == "abc" || 1 * 78 > 5 / 2)
            {
                // will be done, because 4th condition provide true
            }

            if (1 == 0 && (5 < 2 || "a" == "abc" || 1 * 78 > 5 / 2))
            {
                // never will be done because 1st condition is false
            }

            if ((1 == 0 && (5 < 2 || "a" == "abc")) || (1 * 78 > 5 / 2 && false))
            {
                // will be checked 1st condition (1==0) than 4th (1 * 78 > 5 / 2) and than 5th (false) and go to else block
            }
            else
            {
                // do work
            }

            #endregion

            #region Nested conditions
            string request = "I want to divide";
            if (request.Length > 5)
            {
                if (request.StartsWith('I'))
                {
                    // positive result
                    if (request.EndsWith('!'))
                    {
                        // very positive result
                    }
                }
                else
                {
                    // negative result
                }
                // addition work
            }

            // Try to use <= 3 levels of nesting (include cycles!)
            // You can miss else block if it is not needed

            #endregion

            #region If/Else for smart students
            // if variable changes both in if and else blocks, we can make program faster by changing order.
            var a = 10;
            if (new Random().NextDouble() > 0.5)
            {
                a = 20;
            }
            else
            {
                a = 30;
            }
            // Better to transform to:
            a = 30;
            if (new Random().NextDouble() > 0.5)
            {
                a = 20;
            }

            /* This hocus-pocus can be done if: 
             * 1) if variables we change don't take part in condition 
             * 2) an error should not occur 
             */

            #endregion

            #region If/Else for smart students Part 2
            // If block else contain 1 if term, it can be merged to one line:
            if (0 != 0)
            {

            }
            else
            {
                if (1 == (int)'a')
                {

                }
            }

            // Transforming to

            if (0 != 0)
            {

            }
            else if (1 == (int)'a')
            {

            }

            // But if int this else can be more than 1 if operator, do not do so!
            #endregion

            #region Switch
            // Many people hate this block, but it is very effective & sharp weapon Clever man will do good job with it, but other people cut themselves.
            // So! Use it very carefully. When another methods too difficult.
            // But we cannot to use ranges in the cases (1 - 9 => -8) or (1:9 => 0)

            switch ((int)Console.ReadLine().Length)
            {
                case 0:
                    Console.WriteLine("Cannot be empty");
                    break;
                case 11: // select some
                    request = "Good job!";
                    break;
                case 4:   // merge
                case 5:   // merge
                case 13:    // with this one
                    request += "!!!";
                    break;
                default:
                    Console.WriteLine("No suitable condition above");
                    break;
            }
            Console.WriteLine(request);

            #endregion

            #region Switch for smart students
            // if you sure that you have to use switch and it have to return some value, you can make it shorter:
            var mark = request.Length / 2 switch
            {
                0 => 0,
                1 => 0,
                2 => 1,
                3 => 2,
                4 => 4,
                _ => 5 // any other input(!) value (default)
            };

            #endregion
        }
    }
}
