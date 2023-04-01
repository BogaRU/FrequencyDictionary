using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        static Dictionary<string, List<KeyValuePair<string, int>>> frequencyDict
            = new Dictionary<string, List<KeyValuePair<string, int>>>();

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            SetFreqDicts(text);
            var result = GetResult();
            frequencyDict.Clear();
            return result;
        }

        public static void SetFreqDicts(List<List<string>> text)
        {
            foreach (var sentence in text)
            {
                if (sentence.Count < 3)
                {
                    if (sentence.Count == 2) FreqDictUpdate(sentence[0], sentence[1]);
                    continue;
                }
                for (int j = 2; j < sentence.Count; j++)
                {
                    FreqDictUpdate(sentence[j - 2], sentence[j - 1]);
                    if (j == sentence.Count - 1) FreqDictUpdate(sentence[j-1], sentence[j]);
                    FreqDictUpdate(sentence[j - 2] + " " + sentence[j - 1], sentence[j]);
                }
            }
        }

        public static void FreqDictUpdate(string firstWord, string secondWord)
        {
            if (frequencyDict.ContainsKey(firstWord))
            {
                bool secondWordExist = false;
                for (int i = 0; i < frequencyDict[firstWord].Count; i++)
                {
                    if (frequencyDict[firstWord][i].Key == secondWord)
                    {
                        frequencyDict[firstWord][i] = new KeyValuePair<string, int>(secondWord, frequencyDict[firstWord][i].Value + 1);
                        secondWordExist = true;
                        break;
                    }
                }
                if (!secondWordExist) frequencyDict[firstWord].Add(new KeyValuePair<string, int>(secondWord, 1));
            }
            else frequencyDict.Add(firstWord, new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>(secondWord, 1) });
        }

        public static Dictionary<string, string> GetResult()
        {
            var result = new Dictionary<string, string>();
            foreach (var key in frequencyDict.Keys)
                result.Add(key, GetBiggestPair(key).Key);
            return result;
        }

        public static KeyValuePair<string, int> GetBiggestPair(string key)
        {
            KeyValuePair<string, int> biggestPair = new KeyValuePair<string, int>("", 0);
            foreach (var pair in frequencyDict[key])
            {
                if (pair.Value >= biggestPair.Value)
                {
                    if (pair.Value == biggestPair.Value && string.CompareOrdinal(pair.Key, biggestPair.Key) >= 0) continue;
                    biggestPair = pair;
                }
            }
            return biggestPair;
        }
    }
}