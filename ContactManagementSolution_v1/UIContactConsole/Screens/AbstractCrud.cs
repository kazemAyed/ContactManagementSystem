using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIContactConsole.Screens.Interfaces;
using UIContactConsole.Screens.Delegates;

namespace UIContactConsole.Screens
{
    public abstract class AbstractCrud<T> : ICrud<T>
    {

        public void IsExist(Func<int, bool> IsExistEntity)
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║            CHECK ABOUT ENTITY          ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            // Get Contact ID
            int EntityID = ReadInt("  Contact ID : ");

            Console.WriteLine();

            //Check
            //bool result = Contact.IsContactExist(EntityID);
            bool result = IsExistEntity(EntityID);

            Console.WriteLine();

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"  ✓ Entity with ID {EntityID} Existed In DataBase!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"  ✗ Entity with ID {EntityID} was not found.");
            }

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        protected abstract void ShowEntityInfo(T Entity);

        protected int ReadId(string message)
        {
            int id;

            do
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                    return id;

                Console.WriteLine("Please enter a valid ID.");
            }
            while (true);
        }

        protected string ShowMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("║           MANAGEMENT SECREEN            ║");
            Console.WriteLine("║                                         ║");
            Console.WriteLine("╠═════════════════════════════════════════╣");
            Console.WriteLine("║                                         ║");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("║     [0]    Exit                         ║");
            Console.WriteLine("║     [1]    List Of Entities             ║");
            Console.WriteLine("║     [2]    Add New                      ║");
            Console.WriteLine("║     [3]    Update Entity                ║");
            Console.WriteLine("║     [4]    Delete Entity                ║");
            Console.WriteLine("║     [5]    Find Entity                  ║");
            Console.WriteLine("║     [6]    Is Exist?                    ║");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("║                                         ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n  ➤ Choose an option: ");

            Console.ForegroundColor = ConsoleColor.White;

            string choice = Console.ReadLine() ?? string.Empty;

            Console.ResetColor();

            return choice;
        }

        protected int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int value) &&
                    value > 0)
                {
                    return value;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ✗ Please enter a valid number.");
                Console.ResetColor();
            }
        }

        public void Add(AddDel addEntity)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║             ADD NEW ENTITY             ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            int newEntityId = addEntity.Invoke();

            Console.WriteLine();

            if (newEntityId > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  ✓ Entity added successfully with ID {newEntityId}!");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ✗ Failed to add Entity.");
            }

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        public void Update(UpdateDel updateDel)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║            UPDATE Entiry               ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            int EntityUpdatedId = updateDel.Invoke();

            // Update contact
            bool result = EntityUpdatedId > 0;

            Console.WriteLine();

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"  ✓ Entity with ID {EntityUpdatedId} updated successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"  ✗ Failed to update Entity with ID {EntityUpdatedId}.");
            }

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        public void Delete(Func<int, bool> FuncDeletionEntityType)
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║            DELETE Entity               ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            // Get Contact ID
            int EntityID = ReadInt("  Contact ID : ");

            Console.WriteLine();

            // Confirm deletion
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"  ⚠ Are you sure you want to delete contact {EntityID}? (Y/N): ");
            Console.ResetColor();

            string confirmation = Console.ReadLine() ?? string.Empty;

            if (!confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n  → Delete operation cancelled.");
                Console.ResetColor();

                Console.WriteLine("\n  Press any key to continue...");
                Console.ReadKey();

                return;
            }

            // Delete 
            bool result = FuncDeletionEntityType.Invoke(EntityID);

            Console.WriteLine();

            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"  ✓ Contact with ID {EntityID} deleted successfully!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"  ✗ Contact with ID {EntityID} was not found.");
            }

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        public void FindEntityByID(Func<T> GetEntity, Action<T> ShowContactInfo)
        {
            Console.Clear();

            // Header
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║          FIND ENTITY BY ID            ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();

            T Entity = GetEntity();

            // Contact found
            if (Entity != null) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  ✓ Entity found!");
                Console.ResetColor();

                Console.WriteLine();

                ShowContactInfo.Invoke(Entity);
            }

            Console.WriteLine();
            Console.WriteLine("  Press any key to continue...");
            Console.ReadKey();
        }

        public abstract void GetAll();

        public abstract T GetEntity(int id);

        public abstract T GetEntity(string name);

    }

}
