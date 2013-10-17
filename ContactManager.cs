using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class ContactManager
    {
        public static void ListContacts()
        {
            var ent = new contactsEntities();
            using (ent)
            {
                var query = from c in ent.Contacts select c;
                foreach (var c in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", c.ID, c.FirstName, c.LastName, c.DOB);
                }
            }
        }

        public static void CreateContact(Contact contact)
        {
            var ent = new contactsEntities();
            using (ent)
            { 
                try
                {
                    ent.Contacts.Add(contact);
                    ent.SaveChanges();
                }
                catch (Exception ex)
                {

                    Console.Write(ex.ToString());
                }
            }

        }

        public static void UpdateContact(Contact contact)
        {
            

            var ent = new contactsEntities();
            using (ent)
            {
                try
                {
                    Contact contact2 = (from c in ent.Contacts.Where
                                    (a => a.ID == contact.ID)
                                       select c).FirstOrDefault();

                    contact2.FirstName = contact.FirstName;
                    contact2.LastName = contact.LastName;
                    contact2.DOB = contact.DOB;               
                    
                    ent.SaveChanges();
                }
                catch (Exception ex)
                {

                    Console.Write(ex.ToString());
                }

            }
        }

        public static void DeleteContact(Contact contact)
        {
            

            var ent = new contactsEntities();

            using (ent)
            {
                Contact contact2 = (from c in ent.Contacts.Where
                                   (a => a.ID == contact.ID)
                                   select c).FirstOrDefault();
                
                try
                {
                    ent.Contacts.Remove(contact2);
                    ent.SaveChanges();
                }
                catch (Exception ex)
                {

                    Console.Write(ex.ToString());
                }
            }

        }
    }
}
