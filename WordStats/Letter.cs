using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordStats
{
    public class LetterStats
    {
        public LetterStats(char letter)
        {
            this.Letter = letter;
            this.BeginWith = 0;
            this.EndWith = 0;
            this.ShortestWord = "";
            this.LongestWord = "";
            this.TotalLength = 0;
            this.WordCount = 0;
        }

        public char Letter { get; private set; }
        public int BeginWith { get; set; }
        public int EndWith { get; set; }
        public string ShortestWord { get; set; }
        public string LongestWord { get; set; }

        public int TotalLength { get; set; }
        public int WordCount { get; set; }

        public double AverageLength { get { return (double)TotalLength / WordCount; } }
    }
}
