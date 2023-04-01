using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static char[] separators = { '.', '?', '!', ';', ':', '(', ')' };
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            string sentence = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (!CharIsSeparator(text[i])) sentence += text[i];
                else if (sentence.Length != 0)
                {
                    var tempSentenceList = ParseWords(sentence);
                    if (tempSentenceList.Count != 0) sentencesList.Add(tempSentenceList);
                    sentence = "";
                }
            }
            if (sentence.Length != 0) sentencesList.Add(ParseWords(sentence));
            return sentencesList;
        }
        public static bool CharIsSeparator(char sym)
        {
            for (int i = 0; i < separators.Length; i++)
                if (sym == separators[i]) return true;
            return false;
        }
        public static List<string> ParseWords(string sentence)
        {
            var words = new List<string>();
            string word = "";
            for (int i = 0; i < sentence.Length; i++)
            {
                if (char.IsLetter(sentence[i]) || sentence[i] == '\'')
                    word += CheckRegister(sentence[i]);
                else if (word.Length != 0)
                {
                    words.Add(word);
                    word = "";
                }
            }
            if (word.Length != 0) words.Add(word);
            return words;
        }
        public static char CheckRegister (char sym)
        {
            if (sym > 64 && sym < 91) return Convert.ToChar(sym + 32);
            else return sym;
        }
    }
}