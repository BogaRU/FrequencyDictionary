using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnitLite;

namespace TextAnalysis
{
    internal static class Program
    {
        static string filePath;
        static int wordsNumber;
        public static void Main(string[] args)
        {
            Initialize();

            Console.WriteLine("Пожалуйста, подождите...");
            var text = File.ReadAllText(filePath);
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            Console.Clear();

            Console.WriteLine("Введите любое слово/предложение:\n");
            while (true)
                Console.WriteLine("\nЧастотный словарь говорит:\n\n" + TextGeneratorTask.ContinuePhrase(frequency, Console.ReadLine(), wordsNumber) + "\n\nВведите любое слово/предложение:\n");
        }

        static void Initialize()
        {
            Console.WriteLine("Введите источник текста:");
            Console.WriteLine("1. TXT файл\r\n2. JSON файл\n");

            while (true)
            {
                string tmp = Console.ReadLine();
                if (tmp == "1" || tmp == "2")
                {
                    Console.WriteLine("\nВведите путь к файлу:\n");
                    filePath = Console.ReadLine();
                    if (tmp == "2")
                    {
                        Console.WriteLine("\nВведите Id диалога:\n");
                        parseNewFromTelegram(Convert.ToInt32(Console.ReadLine()));
                    }
                    Console.WriteLine("\nВведите количество выводимых слов с наибольшей частотностью:\n");
                    wordsNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    break;
                }
            }
        }

        public static bool isCorrect(string text)
        {
            if (text.Length < 7) return true;
            int invalidCounter = 0;
            foreach (var c in text)
            {
                if ((c < 176 || c > 239) && (c < 65 || c > 122)) invalidCounter++;
            }
            return (float)invalidCounter / (float)text.Length < 0.4f;
        }

        // Метод парсит файл result.json, полученный через экспорт диалогов в телеграме, складывает все сообщения в txt-файл, который затем используется в частотном словаре.
        public static void parseNewFromTelegram(int N)
        {
            // 0 - Gym, 5 - Bin, 3 - Jen, 14 - Svt
            string jsonText = File.ReadAllText("result.json");
            Telegram telegram = JsonConvert.DeserializeObject<Telegram>(jsonText);
            string filePath = "parsedDialog" + telegram.chats.list[N].name + ".txt";
            if (File.Exists(filePath))
            {
                Program.filePath = filePath;
                return;
            }
            StringBuilder parsedText = new StringBuilder("");
            foreach (var mes in telegram.chats.list[N].messages)
            {
                if (!(mes.text is string) || mes.text == "") continue;
                var tmp = mes.text.ToString();
                if (isCorrect(tmp)) parsedText.Append(tmp + " ");
            }
            File.WriteAllText(filePath, parsedText.ToString());
            Program.filePath = "./" + filePath;
        }
    }
}