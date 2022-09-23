namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(95);
                    break;
                case 'B':
                    AddGrade(85);
                    break;
                case 'C':
                    AddGrade(75);
                    break;
                case 'D':
                    AddGrade(65);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStats()
        {
            var results = new Statistics();

            results.High = double.MinValue;
            results.Low = double.MaxValue;

            foreach (double grade in grades)
            {
                results.Low = Math.Min(grade, results.Low);
                results.High = Math.Max(grade, results.High);
                results.Average += grade;
            }
            results.Average /= grades.Count;

            switch (results.Average)
            {
                case var d when d >= 90.0:
                    results.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    results.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    results.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    results.Letter = 'D';
                    break;
                default:
                    results.Letter = 'F';
                    break;

            }

            return results;
        }

        private List<double> grades;

    }
}
