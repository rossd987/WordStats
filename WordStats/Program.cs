/*******************
 * Ross Dougherty
 * 2014-03-25
 ******************/

using System;

namespace LetterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            //This word list was obtained from
            //http://www.puzzlers.org/pub/wordlists/enable1.txt
            var words = System.IO.File.ReadAllLines(@"..\..\App_Data\enable1.txt");

            //Create the statistics collection and print it out
            var collection = new LetterStatCollection(words);
            Console.Write(collection.ToString());

            Console.ReadLine();
        }
    }
}
