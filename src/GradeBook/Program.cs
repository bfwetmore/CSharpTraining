namespace GradeBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who's Book Are we editing today?");

            var bookName = Console.ReadLine();
            bookName ??= "Unkown";
            var book = new Book(bookName);

            book.GradeAdded += OnGradeAdded;
            

            Console.WriteLine($"Please Add Grades to {book.Name}'s gradebook, enter q when finished.");
            string? input;
            do 
            {
                input = Console.ReadLine();
                if (input != "q")
                {
                    try
                    {
                        if (input == null)
                        {
                            throw new Exception();
                        }
                        double grade = double.Parse(input);
                        book.AddGrade(grade);
                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
            }
            while (input != "q");      

            var stats = book.GetStats();

            Console.WriteLine($"The average grade is {stats.Average}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
       

    }

}