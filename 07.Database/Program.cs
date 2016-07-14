namespace Database
{

    using Database.Model;
    using Database.Repository;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Linq;

    public class Program
    {

        private const string DATABASE_KEY = "DatabaseName";
        private static AgendaRepository repository = null;

        public static void Main(string[] args)
        {
            // Enable to app to read json setting files
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            // Get the connection string
            var databaseName = configuration.GetConnectionString(DATABASE_KEY);

            // Get the repository
            repository = new AgendaRepository(databaseName);

            // Execute the logic of the program
            Execute();

            Console.Clear();
            Console.WriteLine("Thanks for use the program... :-)");
            Console.ReadLine();
        }

        private static void Execute()
        {
            var action = String.Empty;

            while (action != "X")
            {
                Console.Clear();
                Console.WriteLine("X = Exit | N = New Friend | L = List Friends | E = Edit Friend (by Id) | D = Delete Friend (by Id)");
                action = Console.ReadLine();

                Console.Clear();

                if (action == "L")
                {
                    ListFriends();
                }

                if (action == "N")
                {
                    AddNewFriend();
                }

                if (action == "E")
                {
                    EditFriend();
                }

                if (action == "D")
                {
                    DeleteFriend();
                }
                
            }
        }

        private static void ListFriends()
        {
            var entities = repository.GetAll().ToList();

            if (entities.Count > 0)
            {
                Console.WriteLine("Id \t Name \t\t PhoneNumber \t CreatedAt \t\t ModifiedAt");

                foreach (var entity in entities)
                {
                    Console.WriteLine($"{entity.Id} \t {entity.Name} \t\t {entity.PhoneNumber} \t {entity.CreatedAt} \t {entity.ModifiedAt}");
                }
            }
            else
            {
                Console.WriteLine("You don't have friends! :-P");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void AddNewFriend()
        {
            var myFriend = new MyFriend();

            var data = String.Empty;
            while (String.IsNullOrEmpty(data))
            {
                Console.Clear();
                Console.WriteLine("Write the Name of your friend:");
                data = Console.ReadLine();
                myFriend.Name = data;
            }

            Console.WriteLine($"Write the Phone Number of {myFriend.Name}:");
            data = Console.ReadLine();
            myFriend.PhoneNumber = data;

            var response = repository.Create(myFriend);
            if (response)
            {
                Console.WriteLine("Your friend has been added to the list");
            }
            else
            {
                Console.WriteLine("An error ocurred while your friend was added to the list");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void EditFriend()
        {
            var myFriend = new MyFriend();

            var data = String.Empty;
            while (String.IsNullOrEmpty(data))
            {
                Console.Clear();
                Console.WriteLine("Write the Id of your friend:");
                data = Console.ReadLine();
                myFriend.Id = Convert.ToInt32(data);
            }

            myFriend = repository.GetBy(myFriend.Id);

            Console.WriteLine($"Write the new Phone Number of {myFriend.Name}:");
            data = Console.ReadLine();
            myFriend.PhoneNumber = data;

            myFriend.ModifiedAt = DateTime.UtcNow;
            var response = repository.Modify(myFriend);
            if (response)
            {
                Console.WriteLine("Your friend has been modified in the list");
            }
            else
            {
                Console.WriteLine("An error ocurred while your friend was modified in the list");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void DeleteFriend()
        {
            var id = 0;

            var data = String.Empty;
            while (String.IsNullOrEmpty(data))
            {
                Console.Clear();
                Console.WriteLine("Write the Id of your friend:");
                data = Console.ReadLine();
                id = Convert.ToInt32(data);
            }

            var response = repository.DeleteBy(id);

            if (response)
            {
                Console.WriteLine("Your friend has been deleted from the list");
            }
            else
            {
                Console.WriteLine("An error ocurred while your friend was deleting from the list");
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

    }

}