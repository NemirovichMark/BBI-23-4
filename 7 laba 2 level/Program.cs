using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_laba_2_level
{
    internal class Program
    {

        public abstract class Player
        {

            private string surname;
            private List<int> numberMinutes;
            public Player(string _surname, List<int> _numberMinutes)
            {
                surname = _surname;
                numberMinutes = _numberMinutes;
            }
            public Player(string _surname)
            {
                surname = _surname;
            }
            public string Surname
            {
                get { return surname; }
                private set { surname = value; }
            }
            public List<int> NumberMinutes
            {
                get { return numberMinutes; }
                private set { numberMinutes = value; }
            }
            public abstract void PrintPlayerInfo();


        }

        public class IgrokVHokkey : Player
        {
            public IgrokVHokkey(string _surname, List<int> _numberMinutes) : base(_surname, _numberMinutes)
            {

            }
            public override void PrintPlayerInfo()  // переопределяем метод  
            {
                Console.Write(Surname + " ");
                for (int i = 0; i < NumberMinutes.Count; i++)
                {
                    Console.Write(NumberMinutes[i] + " ");
                }
                Console.WriteLine();
            }
            public int DobavitShtraf(IgrokVHokkey[] players)
            {
                int count = 0; // скольтко играков получило больше 10 штрафных минут  
                for (int i = 0; i < players.Length; i++)
                {
                    if (SumationOfPoints(players[i].NumberMinutes) >= 10)
                    {
                        count++;
                    }
                }
                return count;
            }

        }

        public class IgrokVBasketbol : Player
        {
            private List<int> kolichestvoFolov;

            public IgrokVBasketbol(string _surname, List<int> _kolichestvoFolov) : base(_surname)
            {
                kolichestvoFolov = _kolichestvoFolov; // дописываем дополнительное поле 
            }

            public List<int> KolichestvoFolov { get { return kolichestvoFolov; } private set { kolichestvoFolov = value; } }
            public override void PrintPlayerInfo()  // переопределяем метод  
            {
                Console.Write(Surname + " ");
                for (int i = 0; i < KolichestvoFolov.Count; i++)
                {
                    Console.Write(KolichestvoFolov[i] + " ");
                }
                Console.WriteLine();
            }
            public static int DobavitShtraf(IgrokVBasketbol[] players)
            {
                int count = 0; // скольтко играков получило больше 10 штрафных минут  
                for (int i = 0; i < players.Length; i++)
                {
                    if (SumationOfPoints(players[i].kolichestvoFolov) >= 5)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        static void Main(string[] args)
        {
            IgrokVBasketbol[] playersBasketbol =
            {
          new IgrokVBasketbol ( "Иванов", new List<int> { 0, 2, 0}),
          new IgrokVBasketbol ("Захаров", new List<int> { 5, 2, 0}),
          new IgrokVBasketbol ("Мох", new List<int> { 5, 5, 0}),
          new IgrokVBasketbol ( "Петров", new List<int> { 1, 1, 1}),
            };

            IgrokVHokkey[] playersHokkey =
            {
          new IgrokVHokkey ("Пупкин" , new List<int> { 2, 0, 10}),
          new IgrokVHokkey ("Власов" , new List<int> { 0, 0, 0}),
          new IgrokVHokkey ("Сергеев" , new List<int> { 2, 0, 1})
            };

            Console.WriteLine();
            Console.WriteLine("Рейтинг игроков в баскетбол  ");
            Sort(playersBasketbol);


            int count = IgrokVBasketbol.DobavitShtraf(playersBasketbol);
            Player[] players2 = new Player[playersBasketbol.Length - count];

            for (int i = 0; i < players2.Length; i++)
            {
                players2[i] = playersBasketbol[i];
            }
            for (int i = 0; i < players2.Length; i++)
            {
                players2[i].PrintPlayerInfo();
            }

            Console.WriteLine();
            Console.WriteLine("Рейтинг игроков в хоккей ");
            Sort(playersHokkey);
            int count2 = playersHokkey[0].DobavitShtraf(playersHokkey);
            Player[] players3 = new Player[playersHokkey.Length - count2];

            for (int i = 0; i < players3.Length; i++)
            {
                players3[i] = playersHokkey[i];
            }

            for (int i = 0; i < players3.Length; i++)
            {
                players3[i].PrintPlayerInfo();
            }
        }

        public static int SumationOfPoints(List<int> points) // суммируем  штрафные минуты сколько всего набрал штравных минут за все игры  
        {
            int sum = 0;
            for (int i = 0; i < points.Count; i++)
            {
                sum += points[i];
            }
            return sum; // возвр  
        }


        public static void Sort(Player[] players)
        {
            for (int i = 0; i < players.Length - 1; i++)
            {
                for (int j = 0; j < players.Length - 1 - i; j++)
                {
                    if (players[i] is IgrokVHokkey)
                    {
                        if (SumationOfPoints(players[j].NumberMinutes) > SumationOfPoints(players[j + 1].NumberMinutes))
                        {
                            var temp = players[j];
                            players[j] = players[j + 1];
                            players[j + 1] = temp;
                        }
                    }
                    else if (players[i] is IgrokVBasketbol)
                    {
                        if (SumationOfPoints(((IgrokVBasketbol)players[j]).KolichestvoFolov) > SumationOfPoints(((IgrokVBasketbol)players[j + 1]).KolichestvoFolov))
                        {
                            var temp = players[j];
                            players[j] = players[j + 1];
                            players[j + 1] = temp;
                        }
                    }

                }
            }
        }
    }
}
