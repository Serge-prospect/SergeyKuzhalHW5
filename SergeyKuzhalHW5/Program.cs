using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergeyKuzhalHW5
{
    // Count matching words and collect missing letters
    class WordComposition
    {
        static void Main(string[] args)
        {
            string parentWord = "Синхрофазатрон";
            parentWord = parentWord.ToLower();
            string[] wordsArray = { "троль", "фазан", "нарзан", "трон", "трасса", "трос" };
            int countWordsSuccess = 0;
            string alMissingLetters = "";

            for (int indexWordsArray = 0; indexWordsArray < wordsArray.Length; indexWordsArray++)
            {
                bool isWordSuccess = IsWordMatch(wordsArray[indexWordsArray], parentWord);

                if (isWordSuccess == true)
                {
                    countWordsSuccess++;
                }
                else
                {
                    alMissingLetters += WordMissingLetters(wordsArray[indexWordsArray], parentWord);
                }
            }

            Console.WriteLine($"{countWordsSuccess} words can be composed from \"{parentWord}\".");

            if (alMissingLetters != "")
            {
                Console.WriteLine($"\"{alMissingLetters}\" letters are not enough to compose {wordsArray.Length - countWordsSuccess} words from \"{parentWord}\".");
            }
        }


        // Compare letters in one litle word
        static bool IsWordMatch(string littleWord, string bigWord)
        {
            bool[] isBigWordLetterUsed = new bool[bigWord.Length];
            int countLetterMatch = 0;

            for (int index_littleWord = 0; index_littleWord < littleWord.Length; index_littleWord++)
            {
                for (int index_bigWord = 0; index_bigWord < bigWord.Length; index_bigWord++)
                {
                    if (littleWord[index_littleWord] == bigWord[index_bigWord] && isBigWordLetterUsed[index_bigWord] != true)
                    {
                        isBigWordLetterUsed[index_bigWord] = true;
                        countLetterMatch++;
                        break;
                    }
                }
            }

            if (countLetterMatch == littleWord.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Find missing letters in one little word
        static string WordMissingLetters(string littleWord, string bigWord)
        {
            bool[] isBigWordLetterUsed = new bool[bigWord.Length];
            int countLetterMatch = 0;
            bool isMissingLetter = false;
            string missingLetters = "";

            for (int index_littleWord = 0; index_littleWord < littleWord.Length; index_littleWord++)
            {
                for (int index_bigWord = 0; index_bigWord < bigWord.Length; index_bigWord++)
                {
                    if (littleWord[index_littleWord] == bigWord[index_bigWord] && isBigWordLetterUsed[index_bigWord] != true)
                    {
                        isBigWordLetterUsed[index_bigWord] = true;
                        countLetterMatch++;
                        isMissingLetter = false;
                        break;
                    } 
                    else
                    {
                        isMissingLetter = true;
                    }
                }

                if (isMissingLetter == true)
                {
                    missingLetters += littleWord[index_littleWord];
                }
            }
            return missingLetters;            
        }
    }
}
