using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_PhoneWithFileIO_Rüscher
{
    public class Phonebook
    {
        //--fields--//
        Dictionary<string, Contact> contactList;
        FileIO file = new FileIO();
        List<string> favourites = new List<string>();

        //--properties--//
        public List<string> Favourites
        {
            get
            {
                return favourites;
            }
        }

        public Dictionary<string, Contact>.KeyCollection Names
        {
            get
            {
                contactList = file.ReadFile();
                return contactList.Keys;
            }
        }

        //--methods--//
        public Phonebook()
        {
            contactList = new Dictionary<string, Contact>();
        }
        
        public bool AddContact(string name, string phoneNumber)
        {
            Contact c = new Contact(name, phoneNumber);
            if (contactList.ContainsKey(name) == true)
            {
                return false;
            }
            else
            {
                contactList.Add(name, c);
                file.SaveContactToFile(c);
                return true;
            }
        }

        public bool Call(string name, double minutes)
        {
            if (contactList.ContainsKey(name))
            {
                Contact c = GetContact(name);
                c.Call(minutes);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteContact(string name)
        {
            if(name == "")
            {
                throw new ArgumentException("Select a Name!");
            }
            else
            {
                contactList.Remove(name);

                List<Contact> contacts = new List<Contact>();
                foreach(KeyValuePair<string, Contact> c in contactList)
                {
                    Contact con = GetContact(c.Key);
                    contacts.Add(con);
                }
                file.RewriteAllContactsToFile(contacts);

            }
        }

        public Contact GetContact(string name)
        {
            if (contactList.ContainsKey(name))
            {
                Contact c = contactList[name];
                return c;
            }
            else
            {
                return null;
            }
        }

        public void SetFavourit(string name, bool isFavourit)
        {
            try
            {
                Contact c = GetContact(name);
                c.IsFavorit = isFavourit;
                favourites.Add(name);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
