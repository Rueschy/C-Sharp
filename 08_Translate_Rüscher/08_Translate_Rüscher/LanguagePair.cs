using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Translate_Rüscher
{
    public class LanguagePair
    {
        string word1;
        string word2;

        public string Word1
        {
            set
            {
                this.word1 = value;
            }
            get
            {
                return word1;
            }
        }
        public string Word2
        {
            set
            {
                this.word2 = value;
            }
            get
            {
                return word2;
            }
        }

        public LanguagePair(string word1, string word2)
        {
            this.word1 = word1;
            this.word2 = word2;
        }

        public override string ToString()
        {
            return word1 + " - " + word2;
        }

        public override bool Equals(object obj)
        {
            if(obj is LanguagePair)
            {
                LanguagePair otherWord = (LanguagePair)obj;
                if(otherWord.Word1 == this.Word1 && otherWord.Word2 == this.Word2)
                {
                    return true;
                }
            }
            return false;
        }

        public string Translate(string searchWord)
        {
            if(word1 == searchWord)
            {
                return word2;
            }
            else if(word2 == searchWord)
            {
                return word1;
            }
            else
            {
                return null;
            }
        }
    }
}
