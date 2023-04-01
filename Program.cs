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
        static string TextFile = @"./HarryPotterText.txt";
        public static void Main(string[] args)
        {
            var text = File.ReadAllText(TextFile);
            var sentences = SentencesParserTask.ParseSentences(text);
            var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
            Console.WriteLine("Введи любое слово/предложение:");
            while (true)
                Console.WriteLine("Частотный словарь говорит:\n" + TextGeneratorTask.ContinuePhrase(frequency, Console.ReadLine(), 8) + "\nВведи любое слово/предложение:");
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
        public static void parseNewFromTelegram(int N, string name)
        {
            // 0 - Gym, 5 - Bin, 3 - Jen, 14 - Svt
            string filePath = "parsedDialog" + name + ".txt";
            if (File.Exists(filePath)) return;
            string jsonText = File.ReadAllText("result.json");
            Telegram telegram = JsonConvert.DeserializeObject<Telegram>(jsonText);
            StringBuilder parsedText = new StringBuilder("");
            foreach (var mes in telegram.chats.list[N].messages)
            {
                if (!(mes.text is string) || mes.text == "") continue;
                var tmp = mes.text.ToString();
                if (isCorrect(tmp)) parsedText.Append(tmp + " ");
            }
            File.WriteAllText(filePath, parsedText.ToString());
        }
    }
}