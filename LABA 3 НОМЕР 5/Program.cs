using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_3_НОМЕР_5
{
    internal class Program
    {
        public struct Team 
        {
            private string nameOfTeam;
            private int raiting;
            private int pointsScored;// забитые очки 
            private int pointsMissed;// пропущенные очки
            private int countOfWinnings;
            private int countDraw;// количесвто ничья 
            private int losses;


            public Team(string _nameOfTeam, int _pointsScored, int _pointsMissed, int _countOfWinnings, int _countDraw, int _losses) 
            {
                nameOfTeam = _nameOfTeam;
                raiting = 0;// просто заполнила поле 
                pointsScored = _pointsScored;
                pointsMissed = _pointsMissed;
                countOfWinnings = _countOfWinnings;
                countDraw = _countDraw;
                losses = _losses;
            }

            public string NameOfTeam
            {
                get { return nameOfTeam; } 
                private set { nameOfTeam = value; } 


            }

            public int PointsScored
            {
                get { return pointsScored; }
                private set { pointsScored = value; }
            }
            public int PointsMissed
            {
                get { return pointsMissed; }
                private set { pointsMissed = value; }
            }
            public int Raiting
            {
                get { return raiting; }
                private set { raiting = value; }
            }
            public int CountOfWinnings
            {
                get { return countOfWinnings; }
                private set { countOfWinnings = value; }
            }
            public int CountDraw
            {
                get { return countDraw; }
                private set { countDraw = value; }
            }
            public int Losses
            {
                get { return losses; }
                private set { losses = value; }
            }

            public void PrintInf() // метод вывода информации о команде 
            {

                Console.WriteLine(raiting + " " + nameOfTeam + " " + pointsScored + " " + pointsMissed + " " + countOfWinnings + " " + countDraw + " " + losses + " ");

            }



            static void Main(string[] args)
            {
                Team[] teams =
                {
             new Team("Адмирал",10,3,100,4,1),
             new Team("Мох",5,6,50,4,7 ),
             new Team("Hop",2,7,1,3,5 ),
             new Team("Nop", 9, 300, 2, 4, 1)
            };
                Sort(teams);

                for (int i = 0; i < teams.Length; i++)
                {
                    teams[i].Raiting = i + 1; //чтобы у нолевого нашего объекта был рейтинг первый и т.д

                }

                for (int i = 0; i < teams.Length; i++)
                {
                    teams[i].PrintInf();
                }
            }
            public static void Sort(Team[] teams)
            {

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].CountOfWinnings + teams[j].CountDraw < teams[j + 1].CountOfWinnings + teams[j + 1].CountDraw) //по количеству выйгранных игр 
                        {
                            var temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        if (teams[j].CountOfWinnings + teams[j].CountDraw == teams[j + 1].CountOfWinnings + teams[j + 1].CountDraw) // если выйгранных игр одинаковое количсево, то сортируем по количеству пропущенных и забитых очков 
                        {
                            if (teams[j].PointsScored - teams[j].PointsMissed < teams[j + 1].PointsScored - teams[j + 1].PointsMissed) // по колтчсеву забитых и пропущенных очков 
                            {
                                var temp = teams[j];
                                teams[j] = teams[j + 1];
                                teams[j + 1] = temp;
                            }

                        }
                    }


                }

            }

        }
    }
}
