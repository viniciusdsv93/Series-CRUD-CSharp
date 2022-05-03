using System;

namespace _21seriesCRUD
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ReturnById();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        userOption = "X";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }
        }

        private static string GetUserOption()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Welcome to the Series Manager");
            System.Console.WriteLine("Please, inser your option:");
            System.Console.WriteLine("1 - List Series;");
            System.Console.WriteLine("2 - Insert new Serie;");
            System.Console.WriteLine("3 - Update Serie;");
            System.Console.WriteLine("4 - Delete Serie;");
            System.Console.WriteLine("5 - View Serie;");
            System.Console.WriteLine("C - Clear screen;");
            System.Console.WriteLine("X - Exit;");
            System.Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return userOption;
        }

        private static void ListSeries()
        {
            System.Console.WriteLine("List Series:");
            var list = repository.ReturnList();

            if (list.Count == 0)
            {
                System.Console.WriteLine("There are no Series registered.");
                return;
            }

            foreach (var serie in list)
            {
                System.Console.WriteLine($"#ID {serie.getId()}: - {serie.getTitle()} - Deleted: {(serie.isDeleted() ? "Yes" : "No")}");
            }
        }

        private static void InsertSerie()
        {
            System.Console.WriteLine("Insert new Serie.");

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Gender), i)}");
            }
            System.Console.WriteLine("Insert one of the Gender options above:");
            int inputGender = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the Serie's title:");
            string inputTitle = Console.ReadLine();

            System.Console.WriteLine("Enter the year it started:");
            int inputYear = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the Serie's description:");
            string inputDescription = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                        gender: (Gender)inputGender,
                                        title: inputTitle,
                                        year: inputYear,
                                        description: inputDescription);

            repository.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            System.Console.WriteLine("Insert the Serie's Id:");
            int indexSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Gender), i)}");
            }

            System.Console.WriteLine("Insert one of the Gender options above:");
            int inputGender = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the Serie's title:");
            string inputTitle = Console.ReadLine();

            System.Console.WriteLine("Enter the year it started:");
            int inputYear = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter the Serie's description:");
            string inputDescription = Console.ReadLine();

            Serie updatedSerie = new Serie(id: repository.NextId(),
                                        gender: (Gender)inputGender,
                                        title: inputTitle,
                                        year: inputYear,
                                        description: inputDescription);

            repository.Update(indexSerie, updatedSerie);
        }

        private static void DeleteSerie()
        {
            System.Console.WriteLine("Insert the Serie's Id:");
            int indexSerie = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Are you sure you want to delete this Serie? Y for yes and N for no:");
            string userDeleteOption = Console.ReadLine().ToUpper();

            if (userDeleteOption == "Y")
            {
                repository.Delete(indexSerie);
            }
            else
            {
                return;
            }
        }

        private static void ReturnById()
        {
            System.Console.WriteLine("Insert the Serie's Id:");
            int indexSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(indexSerie);

            System.Console.WriteLine(serie);
        }
    }
}