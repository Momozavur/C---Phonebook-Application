using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

class Phonebook_Application
{
    static void Main()
    {
        Phonebook phonebook = new Phonebook();

        while (true)
        {
            Menu();

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    if (phonebook.SearchContact(name) != null)
                    {
                        Console.WriteLine("Name already taken!");
                        break;
                    }

                    Console.Write("Phone number: ");
                    string phoneNumber = Console.ReadLine();

                    if (!int.TryParse(phoneNumber, out int phoneNumberChecked))
                    {
                        Console.WriteLine("Enter a valid number!");
                        break;
                    }

                    phonebook.AddContact(name, phoneNumber);
                    Console.WriteLine("New contact registered");
                    break;

                case "2":
                    Console.Write("Contact to search: ");
                    string searchName = Console.ReadLine();

                    string findContact = phonebook.SearchContact(searchName);
                    if (findContact != null)
                        Console.WriteLine("Contact found: " + findContact);
                    else
                        Console.WriteLine("Contact not found!");
                    break;

                case "3":
                    Console.Write("Contact name to delete: ");
                    string deleteName = Console.ReadLine();
                    phonebook.DeleteContact(deleteName);
                    Console.WriteLine("Contact deleted.");
                    break;

                default:
                    Console.WriteLine("ERROR#404");
                    break;
            }
        }
         void Menu() 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nContacts List:");
            phonebook.DisplayAllContacts();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. Search For a Contact");
            Console.WriteLine("3. Delete Existing Contact");
            Console.Write("Enter your choice: ");

            Console.ResetColor();
        }
    }
}


public class Phonebook
{
    private Dictionary <string, string> contacts;

    public Phonebook(){
        contacts = new Dictionary<string, string>();
    }

    public void AddContact(string name, string number){
        contacts[name] = number;
    }

    public string SearchContact(string name){
        if (contacts.ContainsKey(name))
            return contacts[name];
        else
            return null;
    }

    public void DeleteContact(string name){
        if (contacts.ContainsKey(name))
            contacts.Remove(name);
    }

    public void DisplayAllContacts(){
        foreach (var contact in contacts.Keys)
        {
            Console.WriteLine(contact + ": " + contacts[contact]);
        }
    }
}