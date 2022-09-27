namespace GradeBook
{
    public class Statistics
    {
        public Statistics(List<double> grades)
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Average = 0.0;
            Grades = grades;
        }

        public void GenerateStatistics()
        {
            CalculateStatistics();
            AssignAverageLetterGrade();
           
        }

        private void CalculateStatistics()
        {
            foreach (double grade in Grades)
            {
                Low = Math.Min(grade, Low);
                High = Math.Max(grade, High);
                Average += grade;
            }
            Average /= Grades.Count;
        }

        private void AssignAverageLetterGrade()
        {
            switch (Average)
            {
                case var d when d >= 90.0:
                    Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    Letter = 'D';
                    break;
                default:
                    Letter = 'F';
                    break;

            }
        }

        public double Average;

        public List<double> Grades { get; }
        public double High;
        public double Low;
        public char Letter;

    }
}