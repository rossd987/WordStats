﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//http://www.puzzlers.org/pub/wordlists/enable1.txt
//http://www.puzzlers.org/dokuwiki/doku.php?id=solving%3awordlists%3aabout%3astart

namespace LetterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = System.IO.File.ReadAllLines(@"..\..\App_Data\enable1.txt");

            var collection = new LetterStatCollection(words);

            Console.Write(collection.ToString());

            Console.ReadLine();
        }
    }
}
