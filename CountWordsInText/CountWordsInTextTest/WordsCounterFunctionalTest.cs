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
    class WordsCounterFunctionalTest
    {
        [Test]
        public void Check_if_acceptence_criteria_are_met()
        {
            // Arrange
            WordsCounter counter = new WordsCounter();

            // Act
            var result = counter.CountWords("This is a statement, and so is this.");

            // Assert
            Assert.AreEqual(2, result["this"]);
            Assert.AreEqual(2, result["is"]);
            Assert.AreEqual(1, result["a"]);
            Assert.AreEqual(1, result["statement"]);
            Assert.AreEqual(1, result["and"]);
            Assert.AreEqual(1, result["so"]);
        }

        [Test]
        public void RegressionTest1()
        {
            // Arrange
            WordsCounter counter = new WordsCounter();
            var result = counter.CountWords(
            @"In short, extremist football club supporters ('hooligans', 'ultras') who are unhappy with how the Croatian Football Federation (FF) is run and the (supposed) corruption within. They don't like the leadership with whom they are at war for years now. What happened today is their attempt at trying to force their way, embarrass the Croatian FF officials and incite outrage in the football world. By doing so, they hoped to disqualify the Croatian national football team from the EURO competition. They think this (amongst other things) will put enough pressure on the people they want to step down to step down.
This is not the first time they've done something like this and they are adamant to continue until their requests are satisfied. You might remember Croatia being punished/fined/disqualified 15+ times in the recent years due to disturbances such as this one (riots, clashes with the police, racism, pitch invasions, etc). Especially prominent was the swastika mowed into the Split stadium field the night before the EURO 2016 qualifier match against Italy.
Again, it is important to understand that these are not random acts of boredom or drunkenness; they are planned and precisely orchestrated to further an agenda.");

            // Act
            Assert.AreEqual(4, result["football"]);
            Assert.AreEqual(2, result["step"]);
            Assert.AreEqual(3, result["croatian"]);
            Assert.AreEqual(1, result["unhappy"]);
            Assert.AreEqual(140, result.Count);
            // Assert
            
        }
    }
}
