using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Translate_Rüscher
{
    public class Dictionary
    {
        LanguagePair wordpair;

        List<LanguagePair> wordPairs = new List<LanguagePair>();

        public bool MakeEntry(string word1, string word2)
        {
            wordpair = new LanguagePair(word1, word2);
            if (wordPairs.Contains(wordpair))
            {
                return true;
            }
            else
            {
                wordPairs.Add(wordpair);
                return false;
            }
        }

        public List<LanguagePair> Search(string searchString)
        {
            List<LanguagePair> filtered = new List<LanguagePair>();

            foreach(LanguagePair search in wordPairs)
            {
                if(searchString == search.Word1 || searchString == search.Word2)
                {
                    filtered.Add(search);
                }
            }
            return filtered;
        }

        public List<string> Translate(string word)
        {
            List<string> translations = new List<string>();

            foreach(LanguagePair t in wordPairs)
            {
                if(t.Translate(word) != null)
                {
                    translations.Add(t.Translate(word));
                }
            }
            return translations;
        }
    }
}
