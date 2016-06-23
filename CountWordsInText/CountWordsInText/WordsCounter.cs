using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWordsInText
{
    public class WordsCounter
    {
        public Dictionary<string, int> CountWords(string text)
        {
            return CountWords(new StringReader(text));

        }

        public Dictionary<string, int> CountWords(TextReader textReader)
        {
            int current;
            StringBuilder currentWord = new StringBuilder();
            Dictionary<string, int> result = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
           
            do
            {
                current = textReader.Read();
                char currentChar = (char)current;

              
                if (currentChar == '&' && currentWord.Length != 0)
                {
                    currentWord.Append(currentChar);
                }              
                else if ( Char.IsPunctuation(currentChar) ||
                    Char.IsSeparator(currentChar) ||
                    Char.IsControl(currentChar) || 
                    current == -1)
                {                    

                    var word = currentWord.ToString();

                    if (!string.IsNullOrEmpty(word))
                    {
                        int counter;
                        if (result.TryGetValue(word, out counter))
                            result[word] = ++counter;
                        else
                            result[word] = 1;
                    }
                    currentWord = new StringBuilder();
                }
                else
                    currentWord.Append(currentChar);
                                    
            }
            while (current != -1);

            return result;
        }


    }
}
