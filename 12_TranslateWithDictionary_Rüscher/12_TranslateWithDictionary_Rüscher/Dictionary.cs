using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_TranslateWithDictionary_Rüscher
{
    public class Dictionary
    {
        //fields
        WordTranslation wordTranslation;
        Dictionary<string, WordTranslation> words;

        //methods
        public Dictionary()
        {
            words = new Dictionary<string, WordTranslation>();
        }
        public void MakeEntry(string word1, string word2)
        {
            WordTranslation wdt = new WordTranslation(word1, word2);

            if (words.ContainsKey(word1))
            {
                wdt.Add(word2);  
            }
            else
            {
                words.Add(word1, wordTranslation);
            }
        }

        public List<string> Translate(string word)
        {
            List<string> Translate = new List<string>();

            foreach(WordTranslation wdt in words.Values)
            {
                if(wdt.Word == word)
                {
                    Translate = wdt.Translations;
                }
            }
            return Translate;
        }
    }
}
