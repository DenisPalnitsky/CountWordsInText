using CountWordsInText;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWordsInTextTest
{
    [TestFixture]
    public class WordsCounterTest
    {
        // There might be lots of tests covering cases like carry-over, words that are connected by hyphen  etc.
        // Probbably some cases are language and culture specific. I assume that all that is not in scope 
        // of current task 
                
        [Test]
        public void CountWords_returns_number_of_words_for_basic_scenario()
		{
			// Arrange
            WordsCounter counter = new WordsCounter();
            
			// Act
            var result = counter.CountWords("Aa bb aa."); 			  
			  
			// Assert			  
            Assert.AreEqual(2, result["aa"]);
            Assert.AreEqual(1, result["bb"]);
		}

        [Test]
        public void CountWords_ignores_end_of_line()
        {
            // Arrange
            WordsCounter counter = new WordsCounter();

            // Act
            var result = counter.CountWords(@"Aa 
                                            bb 
                                            aa.");

            // Assert			  
            Assert.AreEqual(2, result["aa"]);
            Assert.AreEqual(1, result["bb"]);
        }

        [Test]
        public void CountWords_ignores_punctuation()
        {
            // Arrange
            WordsCounter counter = new WordsCounter();

            // Act
            var result = counter.CountWords(@"a,a;a.a.a(a)a,a:a""a""    a");

            // Assert			  
            Assert.AreEqual(11, result["a"]);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void CountWords_returns_empty_result_set_for_empty_string()
        {
            // Arrange
            WordsCounter counter = new WordsCounter();

            // Act
            var result = counter.CountWords(@"");

            // Assert			  
            Assert.AreEqual(0, result.Count);            
        }


        [Test]        
        public void CountWords_count_MandMs_case_as_single_word()
        {
            // Arrange
            WordsCounter counter = new WordsCounter();

            // Act
            var result = counter.CountWords(@"M&Ms");

            // Assert			  
            Assert.AreEqual(1, result["m&ms"]);            
        }

        

        [Test]
        public void CountWords_treat_ampersand_as_separate_AND_and_ignores_it()
        {
            // Arrange
            WordsCounter counter = new WordsCounter();

            // Act
            var result = counter.CountWords(@"Divide & conquer");

            // Assert			  
            Assert.That(!result.ContainsKey("&"));
        }

        [Test]
        // As there are no requirements for handling shortenings, we keep it simple and 
        // count both parts as separate words.
        public void CountWords_takes_apostrophe_into_account()
        {
            // Arrange
            WordsCounter counter = new WordsCounter();

            // Act
            var result = counter.CountWords(@"I've tested this");

            // Assert			  
            Assert.AreEqual(1, result["I"]);
            Assert.AreEqual(1, result["ve"]);
            
        }
        
    }
}
