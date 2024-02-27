using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_лабораторная_работа
{

    struct SurveyResponse
    {
        public string Response;
        public double Percentage;
    }

    class Program
    {
        static void Main()
        {
            // Представим, что у нас есть массив данных с ответами
            string[] surveyResponses = {
            "Иван",
            "Мария",
            "Петр",
            "Иван",
            "Ольга",
            "Иван",
            "Алексей",
            "Мария",
            "Петр",
            "Иван"
        };

            Dictionary<string, int> responseCounts = new Dictionary<string, int>();

            // Подсчитываем количество каждого ответа
            foreach (string response in surveyResponses)
            {
                if (responseCounts.ContainsKey(response))
                {
                    responseCounts[response]++;
                }
                else
                {
                    responseCounts[response] = 1;
                }
            }

            // Сортируем ответы по количеству встречаемости
            var sortedResponses = responseCounts.OrderByDescending(x => x.Value);

            int totalResponses = surveyResponses.Length;
            List<SurveyResponse> topResponses = new List<SurveyResponse>();

            // Находим топ-5 ответов и их процентное отношение к общему числу ответов
            int i = 0;
            foreach (var item in sortedResponses)
            {
                double percentage = (item.Value * 100.0) / totalResponses;
                topResponses.Add(new SurveyResponse { Response = item.Key, Percentage = percentage });

                i++;
                if (i == 5)
                    break;
            }

            // Выводим результаты
            Console.WriteLine("Наиболее часто встречающиеся ответы и их доли:");
            foreach (var response in topResponses)
            {
                Console.WriteLine($"Ответ: {response.Response}, Доля: {response.Percentage}%");
            }
        }
    }
}
