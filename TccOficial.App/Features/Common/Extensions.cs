namespace TccOficial.App.Features.Common
{
    public static class Extensions
    {
        public static DateTime Next(this DateTime from, DayOfWeek dayOfTheWeek)
        {
            var date = from.Date.AddDays(1);
            var days = ((int)dayOfTheWeek - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(days);
        }
    }
}
