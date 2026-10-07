using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIContactConsole.Screens.Delegates;
using UIContactConsole.Screens.Interfaces;

namespace UIContactConsole.Screens
{
    public class CountryScreen : AbstractCrud<Country>
    {
        protected string ReadCountryCode(string message)
        {
            while (true)
            {
                Console.Write(message);
                string code = Console.ReadLine()?.Trim().ToUpper() ?? "";

                if (code.Length == 3 && code.All(char.IsLetter))
                    return code;

                Console.WriteLine("Invalid country code. Please enter exactly 3 letters.");
            }
        }

        Func<string, string> ReadCuntryCode =
                           delegate (string message)
                           {
                               while (true)
                               {
                                   Console.Write(message);
                                   string code = Console.ReadLine()?.Trim().ToUpper() ?? "";

                                   if (code.Length == 3 && code.All(char.IsLetter))
                                       return code;

                                   Console.WriteLine("Invalid country code. Please enter exactly 3 letters.");
                               }
                           };

        Func<string, string> ReadPhoneCode =
            delegate (string message)
            {
                while (true)
                {
                    Console.Write(message);
                    string code = Console.ReadLine()?.Trim() ?? "";

                    if (code.Length == 3 && code.All(char.IsDigit))
                        return code;

                    Console.WriteLine("Invalid phone code. Please enter exactly 3 digits.");
                }
            };

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

                        Add
                        (
                            () =>
                            {

                                Console.Write("  Contry Name : ");
                                string CountryName = Console.ReadLine() ?? string.Empty;

                                string CountryCode = ReadCuntryCode("  Code : ");

                                string CountryPhoneCode = ReadPhoneCode("  Phone Code : ");


                                BusinessLogicLayer.Country _Country =
                                    new Country()
                                    {
                                        CountryName = CountryName,
                                        Code = CountryCode,
                                        PhoneCode = CountryPhoneCode
                                    };

                                return (_Country.Save()) ? _Country.CountryID : -1;

                            }
                        );
                        break;

                    case "3":

                        Update(()
                               =>
                               {
                                   // Get countrry ID
                                   int countryID = ReadInt("  Country ID : ");

                                   Console.WriteLine();

                                   // Read countrry information
                                   Console.Write("  Country Name : ");
                                   string CountryName = Console.ReadLine() ?? string.Empty;

                                   Console.WriteLine();

                                   string CountryCode = ReadCuntryCode("  Code : ");

                                   Console.WriteLine();

                                   string CountryPhoneCode = ReadPhoneCode("  Phone Code : ");

                                   BusinessLogicLayer.Country _Country = this.GetEntity(countryID);

                                   // Create DTO

                                   _Country.CountryName = CountryName;
                                   _Country.Mode = Contact.enMode.Update;
                                   _Country.Code = CountryCode;
                                   _Country.PhoneCode = CountryPhoneCode;

                                   return _Country.Save() ? _Country.CountryID : -1;

                               }
                            );

                        break;

                    case "4":

                        Delete(CountryID =>
                        {
                            return Country.Delete(CountryID);
                        });
                        break;

                    case "5":

                        FindEntityByID
                            (
                                () =>
                                {
                                    // Read country ID
                                    int countryID = ReadInt("  ➤ Contact ID: ");

                                    // Find Entity
                                    Country county = GetEntity(countryID);

                                    Console.WriteLine();

                                    if (county == null)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;

                                        Console.WriteLine("  ✗ Contact not found.");
                                        Console.WriteLine($"    No contact exists with ID {countryID}.");

                                        Console.ResetColor();

                                        return null;
                                    }

                                    return county;

                                },
                                country =>
                                {
                                    ShowEntityInfo(country);
                                }
                            );

                        break;

                    case "6":

                        IsExist(CountryID =>
                        {
                            return Country.IsCountryExist(CountryID);
                        });

                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public override void GetAll()
        {
            var countries = BusinessLogicLayer.Country.GetAll();

            Console.Clear();

            Console.WriteLine("  COUNTRIES");
            Console.WriteLine(new string('-', 70));

            Console.WriteLine(
                " ID".PadRight(8) +
                " Country Name".PadRight(20) +
                " Code".PadRight(20) +
                " Phone Code".PadRight(20) 
                );

            Console.WriteLine(new string('-', 70));

            foreach (var country in countries)
            {
                Console.WriteLine(" " +
                    country.CountryID.ToString().PadRight(8) +
                    country.CountryName.PadRight(20) + 
                    country.Code.PadRight(20) + 
                    country.PhoneCode.PadRight(20) 
                    );
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

      
        public override Country GetEntity(string name)
        {
            throw new NotImplementedException();
        }

        public override Country GetEntity(int id)
        {
            return Country.GetCuntryByID(id);
        }

        protected override void ShowEntityInfo(Country Entity)
        {

            if (Entity is null) return;

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║             COUNTRY DETAILS             ║");
            Console.WriteLine("╠═════════════════════════════════════════╣");
            Console.ResetColor();
            Console.WriteLine($"║  ID        : {Entity.CountryID,-27}║");
            Console.WriteLine($"║  FirstName : {Entity.CountryName,-27}║");
            Console.WriteLine($"║  FirstName : {Entity.Code,-27}║");
            Console.WriteLine($"║  FirstName : {Entity.PhoneCode,-27}║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════════════════════════╝");

            Console.ResetColor();
        }

    }
}
