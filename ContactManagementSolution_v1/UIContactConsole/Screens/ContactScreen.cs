using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIContactConsole.Screens
{

    public class ContactScreen : AbstractCrud<Contact>
    {

        public void Show()
        {
            while (true)
            {

                string choice = ShowMenu();

                switch (choice)
                {
                    case "0":
                        return;

                    case "1":
                        GetAll();
                        break;

                    case "2":

                        Add(() =>
                        {
                            Console.Write("  First Name : ");
                            string firstName = Console.ReadLine() ?? string.Empty;

                            Console.Write("  Last Name  : ");
                            string lastName = Console.ReadLine() ?? string.Empty;

                            Console.Write("  Email      : ");
                            string email = Console.ReadLine() ?? string.Empty;

                            Console.Write("  Phone      : ");
                            string phone = Console.ReadLine() ?? string.Empty;

                            Console.Write("  Address    : ");
                            string address = Console.ReadLine() ?? string.Empty;

                            int countryId = ReadCountryId();

                            BusinessLogicLayer.Contact _Contact = new Contact();

                            _Contact.FirstName = firstName;
                            _Contact.LastName = lastName;
                            _Contact.Email = email;
                            _Contact.Phone = phone;
                            _Contact.Address = address;
                            _Contact.CountryID = countryId;

                            int newContactId = (_Contact.Save()) ? _Contact.ContactID : -1;

                            return newContactId;

                        });

                        break;

                    case "3":
                       
                        Update(() =>
                        {
                            // Get Contact ID
                            int contactId = ReadInt("  Contact ID : ");

                            Console.WriteLine();

                            // Read contact information
                            Console.Write("  First Name : ");
                            string firstName = Console.ReadLine() ?? string.Empty;

                            Console.Write("  Last Name  : ");
                            string lastName = Console.ReadLine() ?? string.Empty;

                            Console.Write("  Email      : ");
                            string email = Console.ReadLine() ?? string.Empty;

                            Console.Write("  Phone      : ");
                            string phone = Console.ReadLine() ?? string.Empty;

                            Console.Write("  Address    : ");
                            string address = Console.ReadLine() ?? string.Empty;

                            // Select country
                            int countryId = ReadCountryId();

                            BusinessLogicLayer.Contact _Contact = Contact.GetContactByID(contactId);

                            // Create DTO

                            _Contact.FirstName = firstName;
                            _Contact.LastName = lastName;
                            _Contact.Email = email;
                            _Contact.Phone = phone;
                            _Contact.Address = address;
                            _Contact.CountryID = countryId;
                            _Contact.Mode = Contact.enMode.Update;

                            // Update contact
                            bool result = _Contact.Save();

                            if (result) return contactId;
                            else return -1;

                        });

                        break;

                    case "4":
                        Delete(contactID =>
                        {
                            return Contact.Delete(contactID);
                        });
                        break;

                    case "5":

                        FindEntityByID(() =>
                        {
                            // Read Contact ID
                            int contactID = ReadInt("  ➤ Contact ID: ");

                            // Find Entity
                            Contact contact = GetEntity(contactID);

                            Console.WriteLine();

                            if (contact == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine("  ✗ Contact not found.");
                                Console.WriteLine($"    No contact exists with ID {contactID}.");

                                Console.ResetColor();

                                return null;
                            }

                            return contact;

                        },
                        (contact) =>
                        {
                            ShowEntityInfo(contact);
                        });

                        break;

                    case "6":

                        IsExist(ContactID =>
                        {
                            return Contact.IsContactExist(ContactID);
                        });

                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private BusinessLogicLayer.Contact GetContactById(int contactId)
        {

            BusinessLogicLayer.Contact contact = Contact.GetContactByID(contactId);

            if (contact == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"\n  ✗ Contact with ID {contactId} was not found.");
                Console.ResetColor();

                return null;
            }

            return contact;
        }

        public override void GetAll()
        {
            var contacts = BusinessLogicLayer.Contact.GetAll();

            Console.Clear();

            Console.WriteLine("CONTACTS");
            Console.WriteLine(new string('-', 100));

            Console.WriteLine(
                "ID".PadRight(8) +
                "First Name".PadRight(20) +
                "Last Name".PadRight(20) +
                "Email".PadRight(35) +
                "Phone".PadRight(20));

            Console.WriteLine(new string('-', 100));

            foreach (var contact in contacts)
            {
                Console.WriteLine(
                    contact.ContactID.ToString().PadRight(8) +
                    contact.FirstName.PadRight(20) +
                    contact.LastName.PadRight(20) +
                    contact.Email.PadRight(35) +
                    contact.Phone.PadRight(20));
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private int ReadCountryId()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  Select Country:");
            Console.ResetColor();

            foreach (var country in BusinessLogicLayer.Country.GetAll())
            {
                Console.WriteLine($"  [{country.CountryID}] {country.CountryName}");
            }

            while (true)
            {
                Console.Write("\n  ➤ Choose Country: ");

                if (int.TryParse(Console.ReadLine(), out int countryId) && Country.IsCountryExist(countryId))
                {
                    return countryId;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ✗ Please enter a valid Country ID.");
                Console.ResetColor();
            }
        }

        protected override void ShowEntityInfo(Contact contact)
        {

            if (contact is null) return;

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║             CONTACT DETAILS             ║");
            Console.WriteLine("╠═════════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine($"║  ID        : {contact.ContactID,-27}║");
            Console.WriteLine($"║  FirstName : {contact.FirstName,-27}║");
            Console.WriteLine($"║  LastName  : {contact.LastName,-27}║");
            Console.WriteLine($"║  Email     : {contact.Email,-27}║");
            Console.WriteLine($"║  Phone     : {contact.Phone,-27}║");
            Console.WriteLine($"║  Address   : {contact.Address,-27}║");
            Console.WriteLine($"║  Country   : {contact.CountryID,-27}║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════════════════════════╝");

            Console.ResetColor();
        }

        public override Contact GetEntity(int id)
        {
            return Contact.GetContactByID(id);
        }

        public override Contact GetEntity(string name)
        {
            throw new NotImplementedException();
        }
    }

}
