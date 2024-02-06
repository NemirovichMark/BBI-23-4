using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Markup;

namespace _7th_Lab
{
    class Grandfather
    {
        public string Name;
        protected int _whealth;
        private bool _isGreedy = true;
        public bool IsGreedy => _isGreedy;
        public Grandfather(string name, int money)
        {
            Name = name;
            _whealth = money;
            Random rand = new Random();
            _isGreedy = rand.NextDouble() / 2 > 0.5;
        }
    }
    class Father : Grandfather
    {
        public string SecondName;
        public Father(string name, int money, int inheritance) : base(name, inheritance)
        {
            Name = name;
            SecondName = $"{name}ov";
            _whealth = money + _whealth;
            Say();
        }
        protected virtual void Say()
        {
            Console.WriteLine($"Good afternoon! I'm {Name}");
        }
    }

    class Son : Father
    {
        public Son(string name, int money = 0, int inheritance = 0) : base(name, money, inheritance)
        {
            
        }
        protected sealed override void Say() // sealed prevent it from overriding in the future by heirs.
        {
            Console.WriteLine("Hello, man.");
        }
    }
    class Daughter : Father
    {
        public Daughter(string name, int money = 0, int inheritance = 0) : base(name, money, inheritance)
        {
            SecondName = $"{name}ova";
        }
        protected override void Say()
        {
            base.Say();
            Console.WriteLine("How are you doing?");
        }
    }
    class Theory
    {
        static void Main(string[] args)
        {
            /* Difference from the structures
             * When we using the structures, we operate with links to each memory allocation. 
             * When we send a structure as a method parameter we create a copy and method works with a copy (except ref modification).
             * If we send a class, we send a link to it's allocation. Sending the element of the class as like a always ref - sending. 
             * So, structure - the value (with under-values). Class - the reference to the aggregate of values (have additional parameters in the memory).
             * 
             */
            /* Inheritance
             * One class can be inherited from another one and get all fields, properties and methods of base class.
             * Any protected or public method can be modified with override operator (only for virtual base methods - that can be changed).
             * Any protected or public method can be rewritten with new operator. 
             * It allows to change behavior of different children with common properties. 
             * 
             */

            /* Up-cast
             * Child class can be up-casted to base class for ENCAPSULATING the fields, properties and methods of this class. 
             * For users will be shown only that fields and others.
             * that available from base class but with modification of child class! 
             * And references to child fields, properties and methods from that (base) methods) too.
             * 
             */

            /* Is & As
             * You can check is the object can be used as a particular class or not.
             * And you can convert it. If success - you will get a class you expected. In another case - null.
             */

            Grandfather Peter = new Grandfather("Petr", 10000);
            Console.WriteLine();
            Father Pan = new Father("Pan", 12345, Peter.IsGreedy? 0 : 10000);
            // Father Dan = new Grandfather("Denis", 1234); // cannot, because here we try to create a here with basic parameters (without need fields)
            Console.WriteLine();
            Grandfather Dan = new Father("Denis", 1000, 1234); // we create a father object, but some of the parameters are hidden. But!!! The constructor from Father class, he said Denis!
            Console.WriteLine(); 
            Son Jim = new Son("Jim"); // if something identified in the parameter, we can skip it here. Here we override the method and he hide his name.
            Console.WriteLine(); 
            Daughter Marry = new Daughter("Marry"); // use firstly method from base class and next - own new features (you can swap it)


            // Try to find where is up-cast and how encapsulation here presented.
        }
    }
}
