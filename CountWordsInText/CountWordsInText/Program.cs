using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWordsInText
{
    class Program
    {
        static void Main(string[] args)
        {
            WordsCounter wordCounater = new WordsCounter();
            var results =  wordCounater.CountWords(Console.ReadLine());

            foreach (var kvp in results)
                Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
