using System;
using ContactsBook.Controllers;
using ContactsBook.Entity;


namespace ContactsBook
{
    public static class Program
    {
        private static void Main()
        {
            using (var db = new ContactContext())
            {
                var create = new Create();
                var delete = new Delete();
                var update = new Update();
                var read = new Read();

                var run = true;
                while (run)
                {
                    Console.WriteLine("|=====================|");
                    Console.WriteLine("|======MAIN MENU======|");
                    Console.WriteLine("|=====================|");
                    Console.WriteLine("| 1: Add New User     |");
                    Console.WriteLine("| 2: Delete User      |");
                    Console.WriteLine("| 3: Activate User    |");
                    Console.WriteLine("| 4: Deactivate User  |");
                    Console.WriteLine("| 5: List Users       |");
                    Console.WriteLine("| 6: Exit Program     |");
                    Console.WriteLine("|=====================|\n");
                    Console.Write("Please enter the value: ");
                    var checkNumberInput = InputValidators.CheckNumberInput();
                    switch (checkNumberInput)
                    {
                        case 1:
                            create.AddUser(db);
                            read.ListUsers(db);
                            break;
                        case 2:
                            read.ListUsers(db);
                            delete.DeleteUser(db);
                            read.ListUsers(db);
                            break;
                        case 3:
                            read.ListUsers(db);
                            update.ActivateUser(db);
                            read.ListUsers(db);
                            break;
                        case 4:
                            read.ListUsers(db);
                            update.DeactivateUser(db);
                            read.ListUsers(db);
                            break;
                        case 5:
                            read.ListUsers(db);
                            break;
                        case 6:
                            run = false;
                            break;
                        default:
                            Console.WriteLine("Wrong Input");
                            break;
                    }
                }
                Console.WriteLine("Please press Enter to exit the program...");
                Console.ReadKey();
            }
        }
    }
}
