namespace Calculator
{
    public class GradingCalculator
    {
        public string GetGrade(int score, int attendancePercentage)
        {
            if (score > 90 && attendancePercentage > 70) return "A";
            else if (score > 80 && attendancePercentage > 60) return "B";
            else if (score > 60 && attendancePercentage > 60) return "C";
            else return "F";
        }
    }
}
