namespace A3
{
    public class Converter
    {
        public static int DayToHours(int day)
        {
            return (day * 24);
        }
        public static int DayToMinutes(int day)
        {
            return (day * 24 * 60);
        }
        public static int DayToSeconds(int day)
        {
            return (day * 24 * 3600);
        }
    }
}