/*******************
 * Ross Dougherty
 * 2014-03-25
 ******************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LetterStats;

namespace LetterStatsTests
{
    [TestClass]
    public class LetterStatsTest
    {
        [TestMethod]
        public void Blank()
        {
            string[] words = { "a", "", "b" };

            var collection = new LetterStatCollection(words);

            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void SingleLetter()
        {
            var word = "a";
            var collection = new LetterStatCollection(word);

            Assert.AreEqual("a", collection['a'].LongestWord);
            Assert.AreEqual("a", collection['a'].ShortestWord);
            Assert.AreEqual(1, collection['a'].BeginWith);
            Assert.AreEqual(1, collection['a'].EndWith);
            Assert.AreEqual(1, collection['a'].AverageLength);
        }

        [TestMethod]
        public void SingleWord()
        {
            var word = "aa";
            var collection = new LetterStatCollection(word);

            Assert.AreEqual("aa", collection['a'].LongestWord);
            Assert.AreEqual("aa", collection['a'].ShortestWord);
            Assert.AreEqual(1, collection['a'].BeginWith);
            Assert.AreEqual(1, collection['a'].EndWith);
            Assert.AreEqual(2, collection['a'].AverageLength);
        }

        [TestMethod]
        public void ATest()
        {
            string[] words = { "aa", "aah", "aahed", "aahing", "aahs", "aal", "aalii",
                               "aaliis", "aals", "aardvark", "aardvarks", "aardwolf",
                               "aardwolves", "aargh", "aarrgh", "aarrghh", "aas", 
                               "aasvogel", "aasvogels" };

            var collection = new LetterStatCollection(words);

            Assert.AreEqual("aardwolves", collection['a'].LongestWord);
            Assert.AreEqual("aa", collection['a'].ShortestWord);
            Assert.AreEqual(19, collection['a'].BeginWith);
            Assert.AreEqual(1, collection['a'].EndWith);
            Assert.AreEqual(5.84, Math.Round(collection['a'].AverageLength, 2));
            Assert.AreEqual(4, collection['h'].EndWith);
            Assert.AreEqual(1, collection['d'].EndWith);
            Assert.AreEqual(1, collection['g'].EndWith);
            Assert.AreEqual(7, collection['s'].EndWith);
            Assert.AreEqual(2, collection['l'].EndWith);
            Assert.AreEqual(1, collection['i'].EndWith);
            Assert.AreEqual(1, collection['k'].EndWith);
            Assert.AreEqual(1, collection['f'].EndWith);
        }

        [TestMethod]
        public void ABTest()
        {
            string[] words = { "azure", "aab", "azures", "azurite", "azurites", "azygos", 
                               "azygoses", "azygous", "ba", "baa", "baaed", 
                               "baaing", "baal", "baalim", "baalism", "baalisms" };

            var collection = new LetterStatCollection(words);

            Assert.AreEqual("azurites", collection['a'].LongestWord);
            Assert.AreEqual("aab", collection['a'].ShortestWord);
            Assert.AreEqual(8, collection['a'].BeginWith);
            Assert.AreEqual(2, collection['a'].EndWith);
            Assert.AreEqual(6.25, Math.Round(collection['a'].AverageLength, 2));

            Assert.AreEqual("baalisms", collection['b'].LongestWord);
            Assert.AreEqual("ba", collection['b'].ShortestWord);
            Assert.AreEqual(8, collection['b'].BeginWith);
            Assert.AreEqual(1, collection['b'].EndWith);
            Assert.AreEqual(5.12, Math.Round(collection['b'].AverageLength, 2));
        }
    }
}
