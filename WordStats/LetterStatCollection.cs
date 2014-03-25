using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterStats
{
    public class LetterStatCollection : SortedList<char, LetterStat>
    {
        public LetterStatCollection() { }

        public LetterStatCollection(string[] words)
        {
            foreach (var word in words)
            {
                AddWord(word);
            }
        }

        public LetterStatCollection(string word)
        {
            AddWord(word);
        }

        public void Add(string word)
        {
            AddWord(word);
        }

        void AddWord(string word)
        {
            var beginLetter = word[0];
            var endLetter = word[word.Length - 1];

            if (!this.ContainsKey(beginLetter))
            {
                var l = new LetterStat(beginLetter, word);
                this.Add(beginLetter, l);
            }
            else
            {
                var l = this[beginLetter];
                l.BeginWith++;
                l.TotalLength += word.Length;
                l.WordCount++;

                if (string.IsNullOrEmpty(l.ShortestWord) || l.ShortestWord.Length > word.Length)
                    l.ShortestWord = word;

                if (l.LongestWord.Length < word.Length)
                    l.LongestWord = word;
            }

            if (!this.ContainsKey(endLetter))
            {
                var l = new LetterStat(endLetter);
                l.EndWith = 1;
                this.Add(endLetter, l);
            }
            else
            {
                var l = this[endLetter];
                l.EndWith++;
            }
        }
    }
}