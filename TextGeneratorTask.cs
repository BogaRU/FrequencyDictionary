using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            string result = phraseBeginning.ToLower();
            for (int i = 0; i < wordsCount; i++)
            {
                string[] words = result.Split(' ');
                if (words.Length == 0) continue;
                if (words.Length > 1 && nextWords.ContainsKey(words[words.Length - 2] + " " + words[words.Length - 1]))
                    result += " " + nextWords[words[words.Length - 2] + " " + words[words.Length - 1]];
                else if (nextWords.ContainsKey(words[words.Length - 1]))
                    result += " " + nextWords[words[words.Length - 1]];
                else
                    return result;
            }
            return result;
        }
    }
}