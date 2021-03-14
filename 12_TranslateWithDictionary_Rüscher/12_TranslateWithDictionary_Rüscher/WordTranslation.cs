using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_TranslateWithDictionary_Rüscher
{
    public class WordTranslation
    {
        //fields
        List<string> translations = new List<string>();
        string word;

        //properties
        public List<string> Translations
        {
            get
            {
                return translations;
            }
        }
        public string Word
        {
            get
            {
                return word;
            }
        }

        //methods
        public override bool Equals(object obj)
        {
            if (obj is WordTranslation)
            {
                WordTranslation otherWord = (WordTranslation)obj;
                if(otherWord.Word == this.Word)
                {
                    return true;
                }
            }
            return false;
        }

        public WordTranslation(string word)
        {
            this.word = word;
        }

        public WordTranslation(string word, string translation)
        {
            this.word = word;
            translations.Add(translation);
        }
        public bool Add(string newTranslation)
        {
            if (translations.Contains(newTranslation))
            {
                return false;
            }
            else
            {
                translations.Add(newTranslation);
                return true;
            }
        }
    }
}
