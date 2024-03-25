using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public abstract class Task
{
    public abstract string ToString(string input);
}


public class Task1 : Task
{

    public override string ToString(string input)
    {
        Dictionary<char, double> lettersFrequency = new Dictionary<char, double>();
        
        string russianLettersPattern = "[а-я]";// Русский нижний алфавит
        
        int totalLettersCount = input.Count(char.IsLetter);

        
        foreach (char letter in input)
        {
            if (Regex.IsMatch(letter.ToString(), russianLettersPattern, RegexOptions.IgnoreCase))
            {
                char lowerLetter = char.ToLower(letter);
                if (!lettersFrequency.ContainsKey(lowerLetter))
                    lettersFrequency[lowerLetter] = 0;
                lettersFrequency[lowerLetter]++;
            }
        }

        foreach (var kvp in lettersFrequency)
        {
            lettersFrequency[kvp.Key] = kvp.Value / totalLettersCount;
        }

        
        var sortedLettersFrequency = lettersFrequency.OrderByDescending(x => x.Value);

        
        string result = "Задача 1:\n";
        foreach (var kvp in sortedLettersFrequency)
        {
            result += $"{kvp.Key}: {kvp.Value:F4}{Environment.NewLine}";
        }

        return result;
    }
}


public class Task3 : Task
{
    public override string ToString(string input)
    {
        string result = "Задача 3:\n";
        int maxLength = 50;
        string[] words = input.Split(' ');
        string currentLine = "";
        foreach (string word in words)
        {
            if ((currentLine + word).Length > maxLength)
            {
                result += currentLine.Trim() + Environment.NewLine;
                currentLine = "";
            }
            currentLine += word + " ";
        }
        result += currentLine.Trim();
        return result;
    }
}
public class Task6 : Task
{
    public override string ToString(string input)
    {
        Dictionary<int, int> syllableCount = new Dictionary<int, int>();
        string[] words = input.Split(' ');
        foreach (string word in words)
        {
            int syllables = CountSyllables(word); 
            if (!syllableCount.ContainsKey(syllables))
                syllableCount[syllables] = 0;
            syllableCount[syllables]++;
        }

        string result = "Задача 6:\n";
        foreach (var kvp in syllableCount.OrderBy(x => x.Key))
        {
            result += $"{kvp.Key} слогов: {kvp.Value} слов{Environment.NewLine}";
        }

        return result;
    }

    private int CountSyllables(string word)
    {
        int syllables = 0;
        word = word.ToLower().Trim();

        foreach (char c in word)
        {
            if ("аеёиоуыэюя".Contains(c))
            {
                
                    syllables++;
                
            }
            
        }

            return syllables;
    }
}
public class Task12 : Task
{
    public override string ToString(string input)
    {
        Dictionary<string, string> wordCodes = new Dictionary<string, string>();
        string[] lines = input.Split(Environment.NewLine);
        string text = "Задача 12:\n";
        foreach (var line in lines)
        {
            if (line.Contains(":"))
            {
                string[] parts = line.Split(":");
                wordCodes[parts[1].Trim()] = parts[0].Trim();
            }
            else
            {
                text += line + " ";
            }
        }

        
        wordCodes["раз"] = "#$@^"; //или наоборот, не важно
        wordCodes["два"] = "*@!&";
        wordCodes["банан"] = "!@#$%";
        wordCodes["три"] = "%^&*(";
        wordCodes["что"] = "&*()!";
        wordCodes["сказать"] = "^%$#@";
        wordCodes["мне"] = "@#$%^";
        wordCodes["окей"] = "*(^%$";
        wordCodes["Bruh"] = "#@$%^";
        wordCodes["слово"] = "$%^&*";

        foreach (var code in wordCodes)
        {
            text = text.Replace(code.Key, code.Value);
        }

        return text.Trim();
    }
}

public class Task13 : Task
{
    public override string ToString(string input)
    {
        Dictionary<char, int> lettersCount = new Dictionary<char, int>();
        string[] words = Regex.Split(input, @"\W+");
        int totalWords = words.Length;

        foreach (var word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                char firstLetter = char.ToLower(word[0]);
                if (!lettersCount.ContainsKey(firstLetter))
                    lettersCount[firstLetter] = 0;
                lettersCount[firstLetter]++;
            }
        }

        string result = "Задача 13: \n";
        foreach (var kvp in lettersCount.OrderBy(x => x.Key))
        {
            double percentage = (double)kvp.Value / totalWords * 100;
            result += $"{kvp.Key}: {percentage:F2}%{Environment.NewLine}";
        }

        return result;
    }
}

public class Task15 : Task
{
    public override string ToString(string input)
    {
        int sum = 0;
        string[] words = Regex.Split(input, @"\W+");
        foreach (var word in words)
        {
            if (int.TryParse(word, out int num))
            {
                sum += num;
            }
        }
        return "Задача 15:\n"+ sum.ToString();
    }

    class Program
    {
        static void Main(string[] args)
        {
            string text = "После многолетних исследований Bruh ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. раз Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. \r\nДвигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.\r\n1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.\r\nФьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.\r\nWilliam Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.\r\nПервое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.\r\n";
            Task[] tasks = new Task[] {
            new Task1(),
            new Task3(),
            new Task6(),
            new Task12(),
            new Task13(),
            new Task15()
        };

            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine(tasks[i].ToString(text));
                Console.WriteLine();
            }
        }
    }
}
