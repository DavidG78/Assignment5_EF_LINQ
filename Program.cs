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
                        ContactManager.ListContacts();
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
                        ContactManager.UpdateContact();
                        break;

                    case Command.Delete:
                        ContactManager.DeleteContact();
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
