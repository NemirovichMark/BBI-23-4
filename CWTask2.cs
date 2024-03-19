using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Lab_6th
{
    internal class CWTask2
    {
        abstract class Embrasure
        {
            protected int length = 0;
            protected int width = 0;
            protected int thickness = 0;
            protected string name = "";
            public int Length { get { return length; } }
            public int Width { get { return width; } }
            public int Thicness { get { return thickness; } }
            public string Name { get { return name; } }
            protected Embrasure(int _length, int _width, int _thickness, string _name)
            {
                this.length = _length;
                this.width = _width;
                this.thickness = _thickness;
                this.name = _name;
            }
            virtual public int Calculate()
            {
                return 0;
            }
            virtual public void Write()
            {
                Console.WriteLine("U");
            }
        }
        class Window : Embrasure
        {
            private int layers = 0;
            public Window(int _length, int _width, int _thickness, int _layers, string _name) : base(_length, _width, _thickness, _name)
            {
                layers= _layers;
            }
            public override int Calculate()
            {
                return (length + width) * (thickness + layers);
            }
            public override void Write()
            {
                Console.WriteLine($"{name}: ширина - {width}, длина - {length}, толщина - {thickness}, цена - {Calculate()}");
            }
        }
        class Door : Embrasure
        {
            private bool pattern = false;
            private bool glass = false;
            public Door(int _length, int _width, int _thickness, bool _Glass, bool _Pattern, string _name) : base(_length, _width, _thickness, _name)
            {
                pattern = _Pattern;
                glass = _Glass;
            }
            public override int Calculate()
            {
                int n = 0;
                if (pattern) { n++; }
                if (glass) { n++; }
                return (length + width) * (thickness + n);
            }
            public override void Write() { Console.WriteLine($"{name}: ширина - {width}, длина - {length}, толщина - {thickness}, цена - {Calculate()}");}
        }
        static void Main(string[] args)
        {
            void Quicksort(Embrasure[] embrasure, int LeftIndex, int RightIndex)
            {
                int i = LeftIndex;
                int j = RightIndex;
                int pivot = embrasure[i].Calculate();
                while(i <= j)
                {
                    while (embrasure[i].Calculate() < pivot) { i++; }
                    while (embrasure[j].Calculate() > pivot) { j--; }
                    if (i <= j)
                    {
                        Embrasure a = embrasure[i];
                        embrasure[i] = embrasure[j];
                        embrasure[j] = a;
                        i++;
                        j--;
                    }
                }
                if (LeftIndex < j) { Quicksort(embrasure, LeftIndex, j); }
                if (i < RightIndex) { Quicksort(embrasure, i, RightIndex); }
            }
            String[] Names = { "Цыганочка", "Фараон", "Ганзалес", "Выдра", "Слонобой" };
            String[] Names1 = { "Хоромы", "Султанские", "Перчинка", "Блестяще", "Пендель" };
            Window[] Windows = new Window[5];
            for (int i = 0; i < 5; i++) { Windows[i] = new Window(new Random().Next(1, 10), new Random().Next(1, 10), new Random().Next(1, 5), new Random().Next(1, 3), Names1[i]); }
            Door[] Doors = new Door[5];
            for (int i = 0; i < 5; i++)
            {
                bool ar = false;
                bool br = false;
                if (new Random().Next(1, 2) == 1) { ar = false; }
                else { ar = true; }
                if (new Random().Next(1, 2) == 1) { br = false; }
                else { br = true; }
                Doors[i] = new Door(new Random().Next(1, 10), new Random().Next(1, 10), new Random().Next(1, 5), ar, br, Names[i]);
            }
            Quicksort(Doors, 0, Doors.Length - 1);
            Quicksort(Windows, 0, Windows.Length - 1);
            Console.WriteLine("Список дверей:");
            for (int i = 0; i < 5; i++) { Doors[i].Write(); }
            Console.WriteLine();
            Console.WriteLine("Список окон:");
            for (int i = 0; i < 5; i++) { Windows[i].Write(); }
            Console.WriteLine();
            Embrasure[] Embrasures = new Embrasure[10];
            for (int i = 0; i < 5; i++) {Embrasures[i] = Doors[i]; }
            int n = 5;
            for (int i = 0; i < 5; i++) { Embrasures[n] = Windows[i]; n++; }
            Quicksort(Embrasures, 0, 9);
            Console.WriteLine("Конечный список:");
            for (int i = 0; i < 10; i++) { Embrasures[i].Write(); }
        }
    }
}