using System;

struct Separate
{
    public int VisiableValue; // There is a common agreement in c# developers to name public variables with Upper case
    private int _hiddenValue; // And private variables with _ + Lower case
}

namespace _6th_Lab
{
    public struct External
    {
        public int VisiableValue; // There is a common agreement in c# developers to name public variables with Upper case
        private int _hiddenValue; // And private variables with _ + Lower case

        //     public Theory.Internal _smallBrother; impossible, because it is hidden from this object
    }
   /* private struct Hidden  impossible to hide on this level
    {
    }
    */
    class Theory
    {
        private struct Internal
        {
            public int VisiableValue; // If there is the same name in another object, it is OK
            private int _hiddenValue; // We still can name it the same

            public External _bigBrother;
            private Separate _cousin;
        }

        private struct RealUsefulStruct
        {
            private int _nooneShouldKnowAboutMe;

            public int AutoProperty { get; private set; }
            public int OnlyGetProperty => _nooneShouldKnowAboutMe;
            public int ExtendedProperty
            {
                get
                {
                    return _nooneShouldKnowAboutMe * _nooneShouldKnowAboutMe / 2;
                }
                set
                {
                    try
                    {
                        if (value > 0)
                        {
                            AutoProperty = value;
                        }
                        else
                        {
                            _nooneShouldKnowAboutMe += value;
                        }
                        _nooneShouldKnowAboutMe++;
                    }
                    catch
                    {
                        throw new Exception("I work with int-type. And you provide something strange");
                    }
                }
            }
            public void ReadEverything()
            {
                string localValiable = "just for you :)"; // There is a common agreement in c# developers to name local variables with Lower case
                Console.WriteLine($"_nooneShouldKnowAboutMe:{_nooneShouldKnowAboutMe}\nAutoProperty:{AutoProperty}\nOnlyGetProperty:{OnlyGetProperty}\n" +
                    $"ExtendedProperty:{ExtendedProperty}\nlocalValiable:{localValiable}");
            }
            
            public void TellAboutYourself()
            {
                Console.WriteLine($"I can tell you that i have field _nooneShouldKnowAboutMe that contains {_nooneShouldKnowAboutMe} but you not able to find it :) ");
                OnlyStructureCanCallMe();
            }
            
            private void OnlyStructureCanCallMe()
            {
                Console.WriteLine("I am encapsulated method. It is so cool to be like me!!! You even cannot to call me directly from the Main() ");
            }
        }

        static void Main(string[] args)
        {
            #region Area of visibility

            /* Encapsulation claims that your program gets the necessary information only.
             * 
             * static modification is very rude and you have to avoid it (almost as goto). Because PC keep the link to this method during all time you program works
             * So better to get some data, save them and forgot about them till some situation when they need.
             * It can be realized with methods. But static methods cannot call non-static directly. So we have to encapsulate it with class or structure
             * 
             * Structure is easier because it is a big composite variable and you use it as you wish
             * 
             * 
             * You cannot connect the structure as a separate .cs file, because it is just a place for data keeping and processing
             * 
             * So now you have to use the structures as a collection of data with methods to work with them
             * Use private structures in the your main class (default: Program)
             * Or public structures outside this class
             * 
             */

            External externalStructure;
            Internal internalStructure;
            Separate separateStructure;
            separateStructure.VisiableValue = 100;
            externalStructure.VisiableValue = 10;
            internalStructure.VisiableValue = 20;
            internalStructure._bigBrother.VisiableValue = 5;
            Console.WriteLine(internalStructure._bigBrother.VisiableValue);

            #endregion

            #region Fields & Properties (difference)

            /* The field keep the data (or link)
             * 
             * The property can do the same if they are AutoProperty but generally it is a method
             * + make different area of visibility for reading what it keep and writing
             * + it can make some rules for output when your read it or write
             * It is like a combination of field and method 
             * 
             */

            RealUsefulStruct fieldsPropertiesMethods;
            // Console.WriteLine(fieldsPropertiesMethods.AutoProperty); // you have to init all public fields before get them
            fieldsPropertiesMethods = new RealUsefulStruct(); // you can set all fields with default values (zeros and nulls)
            Console.WriteLine(fieldsPropertiesMethods.AutoProperty);
            fieldsPropertiesMethods.ExtendedProperty = 10;
            fieldsPropertiesMethods.ReadEverything();
            Console.WriteLine(fieldsPropertiesMethods.OnlyGetProperty);
            
            // Let's get private information
            fieldsPropertiesMethods.TellAboutYourself();
            #endregion
        }
    }
}
