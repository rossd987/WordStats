/*******************
 * Ross Dougherty
 * 2014-03-25
 ******************/

using System;

namespace LetterStats
{
    /// <summary>
    /// This class keeps word statistics for a single letter
    /// </summary>
    public class LetterStatistics
    {
        /// <summary>
        /// Creates a LetterStatistics object for the a given letter
        /// </summary>
        /// <param name="letter">The letter to keep statistics for</param>
        public LetterStatistics(char letter)
        {
            this.Letter = letter;
            this.BeginWith = 0;
            this.EndWith = 0;
            this.WordCount = 0;
            this.ShortestWord = "";
            this.LongestWord = "";
            this._average = 0;
        }

        /// <summary>
        /// Creates a LetterStatistics object for a given letter and initializes it
        /// with a given word
        /// </summary>
        /// <param name="letter">The letter to keep statistics for</param>
        /// <param name="word">A word to initialize the class with</param>
        public LetterStatistics(char letter, string word)
        {
            if (!string.IsNullOrEmpty(word) && word[0] != letter)
            {
                throw new ArgumentException("First letter of word does not match letter.");
            }

            this.Letter = letter;
            this.ShortestWord = word;
            this.LongestWord = word;
            this.WordCount = 1;
            this.BeginWith = 1;
            this._average = word.Length;
        }

        public char Letter { get; private set; }
        public int BeginWith { get; set; }
        public int EndWith { get; set; }
        public string ShortestWord { get; set; }
        public string LongestWord { get; set; }
        public int WordCount { get; set; }

        double _average;
        public double AverageLength
        {
            get { return _average; }
        }

        public void UpdateAverage(int length)
        {
            _average += (length - _average) / (double)this.WordCount;
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
