namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
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

        public override void AddGrade(double grade)
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

        public override event GradeAddedDelegate? GradeAdded;

        public override Statistics GetStatistics()
        {
            var results = new Statistics(grades);

            results.GenerateStatistics();
            return results;
        }

        private List<double> grades;

    }
}
