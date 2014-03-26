/*******************
 * Ross Dougherty
 * 2014-03-25
 ******************/

using System;
using System.IO;
using System.Linq;

namespace LetterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            //This word list was obtained from
            //http://www.puzzlers.org/pub/wordlists/enable1.txt
            var path = @"..\..\App_Data\enable1.txt";

            var collection = new LetterStatCollection();
            
            //Read in data from the file and add it to the statistics collection

            #region Stream Variables
            var buffersize = 1048576;  //1 MB buffer size
            var buffer = new char[buffersize];
            int count = 1;
            string prepend = "";
            string[] pieces;

            //Common whitespace characters to split the string that is read in
            char[] splitChars = { ' ', '\n', '\t', '\r' };
            #endregion

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                while (count > 0)
                {
                    //Read in a chunk of data from the file
                    count = sr.Read(buffer, 0, buffersize);

                    //Convert it to a string
                    string readinstring = new String(buffer, 0, count);

                    //Split that string into individual words
                    pieces = readinstring.Split(splitChars);

                    //Prepend the remainder of the last loop to the first item
                    pieces[0] = prepend + pieces[0];

                    //Since the last word may have been cut off, add all but the last
                    //word to the collection
                    collection.Add(pieces.Take(pieces.Length - 1).ToArray());
                    
                    //Save the last word for the next iteration
                    prepend = pieces[pieces.Length - 1];
                }
            }

            //Add the last word
            collection.Add(prepend);

            //Print the collection
            Console.Write(collection.ToString());

            Console.ReadLine();
        }
    }
}
