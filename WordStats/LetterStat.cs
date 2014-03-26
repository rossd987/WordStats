using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterStats
{
    public class LetterStat
    {
        public LetterStat(char letter)
            
        {
            this.Letter = letter;
            this.BeginWith = 0;
            this.EndWith = 0;
            this.TotalLength = 0;
            this.WordCount = 0;
            this.ShortestWord = "";
            this.LongestWord = "";
        }

        public LetterStat(char letter, string word)
        {
            if (!string.IsNullOrEmpty(word) && word[0] != letter)
            {
                throw new ArgumentException("First letter of word does not match letter.");
            }

            this.Letter = letter;
            this.ShortestWord = word;
            this.LongestWord = word;
            this.WordCount = 1;
            this.TotalLength = word.Length;
            this.BeginWith = 1;
        }

        public char Letter { get; private set; }
        public int BeginWith { get; set; }
        public int EndWith { get; set; }
        public string ShortestWord { get; set; }
        public string LongestWord { get; set; }
        public int TotalLength { get; set; }
        public int WordCount { get; set; }
        public double AverageLength
        {
            get { return (double)TotalLength / WordCount; }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5:0.00}",
                    this.Letter,
                    this.BeginWith,
                    this.EndWith,
                    this.ShortestWord,
                    this.LongestWord,
                    this.AverageLength
                    );
        }
    }
}
