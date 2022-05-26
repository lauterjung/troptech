namespace A3
{
    public class Grades
    {
        public static double CalculateAverageGrade(double grade1, double grade2, double grade3)
        {
            double mean = (grade1 + grade2 + grade3) / 3;
            return (mean);
        }
        public static double CalculateAverageGrade(double grade1, double grade2, double grade3, bool round)
        {
            double mean = (grade1 + grade2 + grade3) / 3;
            mean = Math.Round(mean, 1);
            return (mean);
        }
    }
}

// round = Console.ReadLine();
// if(round.ToLower() == "s")
// {
//     
// }