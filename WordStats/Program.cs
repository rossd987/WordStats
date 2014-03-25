using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//http://www.puzzlers.org/pub/wordlists/enable1.txt
//http://www.puzzlers.org/dokuwiki/doku.php?id=solving%3awordlists%3aabout%3astart

namespace WordStats
{
    class Program
    {
        static void Main(string[] args)
        {
            var charList = new SortedList<char, LetterStats>();
            var words = System.IO.File.ReadAllLines(@"..\..\App_Data\enable1.txt");

            foreach (var word in words)
            {
                var beginLetter = word[0];
                var endLetter = word[word.Length - 1];

                if (!charList.ContainsKey(beginLetter))
                {
                    var l = new LetterStats(beginLetter);
                    l.LongestWord = word;
                    l.ShortestWord = word;
                    l.BeginWith = 1;
                    l.EndWith = 0;
                    l.TotalLength = word.Length;
                    l.WordCount = 1;

                    if (endLetter == beginLetter)
                        l.EndWith = 1;

                    charList.Add(beginLetter, l);
                }
                else
                {
                    var l = charList[beginLetter];
                    l.BeginWith++;
                    l.TotalLength += word.Length;
                    l.WordCount++;

                    if (string.IsNullOrEmpty(l.ShortestWord) || l.ShortestWord.Length > word.Length)
                        l.ShortestWord = word;
                    
                    if (l.LongestWord.Length < word.Length)
                        l.LongestWord = word;
                }

                if (!charList.ContainsKey(endLetter))
                {
                    var l = new LetterStats(endLetter);
                    l.BeginWith = 0;
                    l.EndWith = 1;

                    charList.Add(endLetter, l);
                }
                else
                {
                    var l = charList[endLetter];
                    l.EndWith++;
                }

            }

            foreach (var letter in charList)
            {
                Console.WriteLine(string.Format("{0} - {1} - {2} - {3} - {4} - {5}",
                    letter.Value.Letter,
                    letter.Value.BeginWith,
                    letter.Value.EndWith,
                    letter.Value.ShortestWord,
                    letter.Value.LongestWord,
                    letter.Value.AverageLength
            ));
            }

            Console.ReadLine();
        }
    }
}
