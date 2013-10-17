using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment5
{
    public enum Command
    {
        List,
        Insert,
        Update,
        Delete,
        Exit,
        None
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var command = GetCommand();
            while (command != Command.Exit)
            {
                switch (command)
                {
                    case Command.List:
                        var query = ContactManager.ListContacts();
                        foreach (var c in query)
                        {
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}", c.ID, c.FirstName, c.LastName, c.DOB);
                        }
                        break;

                    case Command.Insert:
                        var contact = new Contact();
                        Console.Write("First: ");
                        contact.FirstName = Console.ReadLine().Trim();
                        Console.Write("Last: ");
                        contact.LastName = Console.ReadLine().Trim();
                        Console.Write("DOB: ");
                        contact.DOB = Convert.ToDateTime(Console.ReadLine().Trim());
                        ContactManager.CreateContact(contact);
                        break;

                    case Command.Update:
                        var contact2 = new Contact();
                        Console.Write("ID: ");
                        contact2.ID = Convert.ToInt32(Console.ReadLine().Trim());
                        Console.Write("First: ");
                        contact2.FirstName = Console.ReadLine().Trim();
                        Console.Write("Last: ");
                        contact2.LastName = Console.ReadLine().Trim();
                        Console.Write("DOB: ");
                        contact2.DOB = Convert.ToDateTime(Console.ReadLine().Trim());
                        ContactManager.UpdateContact(contact2);
                        break;

                    case Command.Delete:
                        var contact3 = new Contact();
                        Console.Write("ID: ");
                        contact3.ID = Convert.ToInt32(Console.ReadLine().Trim());
                        ContactManager.DeleteContact(contact3);
                        break;
                }

                command = GetCommand();
            }
            
        }

        static Command GetCommand()
        {
            Command command = Command.None;

            while (command == Command.None)
            {
                Console.Write("Next Action (List, Insert, Update, Delete, Exit): ");

                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "l":
                    case "list":
                        command = Command.List;
                        break;

                    case "i":
                    case "insert":
                        command = Command.Insert;
                        break;

                    case "u":
                    case "update":
                        command = Command.Update;
                        break;

                    case "d":
                    case "delete":
                        command = Command.Delete;
                        break;

                    case "e":
                    case "exit":
                        command = Command.Exit;
                        break;

                    default:
                        command = Command.None;
                        break;
                }
            }

            return command;
        }
    }

    
}
