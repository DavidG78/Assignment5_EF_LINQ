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
                ent.Contacts.Add(contact);
                CatchErrors(ent);
            }

        }

        public static void UpdateContact()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine().Trim());

            var ent = new contactsEntities();
            using (ent)
            {
                Contact contact = (from c in ent.Contacts.Where
                                (a => a.ID == id)
                                   select c).FirstOrDefault();

                Console.Write("First: ");
                contact.FirstName = Console.ReadLine().Trim();
                Console.Write("Last: ");
                contact.LastName = Console.ReadLine().Trim();
                Console.Write("DOB: ");
                contact.DOB = Convert.ToDateTime(Console.ReadLine().Trim());
                CatchErrors(ent);
            }
        }

        public static void DeleteContact()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine().Trim());

            var ent = new contactsEntities();

            using (ent)
            {
                Contact contact = (from c in ent.Contacts.Where
                                   (a => a.ID == id)
                                   select c).FirstOrDefault();
                ent.Contacts.Remove(contact);
                CatchErrors(ent);
            }

        }

        private static void CatchErrors(contactsEntities ent)
        {
            try
            {
                ent.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }
        }
    }
}
