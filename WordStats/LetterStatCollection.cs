/*******************
 * Ross Dougherty
 * 2014-03-25
 ******************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LetterStats
{
    /// <summary>
    /// Keeps statistics for a collection of letters
    /// </summary>
    public class LetterStatisticsCollection : SortedList<char, LetterStatistics>
    {
        /// <summary>
        /// Initialize an empty LetterStatCollection
        /// </summary>
        public LetterStatisticsCollection() { }

        /// <summary>
        /// Initialize a LetterStatCollection with a set of words
        /// </summary>
        /// <param name="words">An array of words to initilize the collection with</param>
        public LetterStatisticsCollection(string[] words)
        {
            foreach (var word in words)
            {
                AddWord(word);
            }
        }

        /// <summary>
        /// Initialize a LetterStatCollection with a single word
        /// </summary>
        /// <param name="words">An word to initilize the collection with</param>
        public LetterStatisticsCollection(string word)
        {
            AddWord(word);
        }

        /// <summary>
        /// Intigrate an array of words into the collection
        /// </summary>
        public void Add(string[] words)
        {
            foreach (var word in words)
            {
                AddWord(word);
            }
        }

        /// <summary>
        /// Intigrate a word into the collection
        /// </summary>
        public void Add(string word)
        {
            AddWord(word);
        }

        /// <summary>
        /// Get the statistics for this word and update the collection
        /// </summary>
        /// <param name="word"></param>
        void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word)) return;

            var beginLetter = word[0];
            var endLetter = word[word.Length - 1];

            //Add the starting letter if it is not in the collection yet
            if (!this.ContainsKey(beginLetter))
            {
                var l = new LetterStatistics(beginLetter, word);
                this.Add(beginLetter, l);
            }

            //Update the letter with the new word
            else
            {
                var l = this[beginLetter];
                l.BeginWith++;
                l.WordCount++;
                l.UpdateAverage(word.Length);

                if (string.IsNullOrEmpty(l.ShortestWord) || l.ShortestWord.Length > word.Length)
                    l.ShortestWord = word;

                if (l.LongestWord.Length < word.Length)
                    l.LongestWord = word;
            }

            //Update the ending letter statistics
            if (!this.ContainsKey(endLetter))
            {
                var l = new LetterStatistics(endLetter);
                l.EndWith = 1;
                this.Add(endLetter, l);
            }
            else
            {
                var l = this[endLetter];
                l.EndWith++;
            }
        }

        /// <summary>
        /// Convert the collection to a string for printing
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Letter, Start With, End With, Shortest, Longest, Avg Length");
            foreach (var letter in this)
            {
                sb.AppendLine(letter.Value.ToString());
            }

            return sb.ToString();
        }
    }
}