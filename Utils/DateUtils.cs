using System.Globalization;

namespace Restaurant.Utils;

public static class DateUtils
{
    public static int GetCurrentYear(DateTime date)
    {
        return date.Year;
    }

    public static string FormatFullDate(DateTime date)
    {
        return date.ToString("dd/MM/yyyy HH:mm");
    }

    public static string FormatSimpleDate(DateTime date)
    {
        return date.ToString("dd/MM/yyyy");
    }

    public static DateTime FormatStringToFullDate(string strDate)
    {
        return DateTime.Parse(strDate);
    }

    public static int CalculateDifferenceDays(DateTime date1, DateTime date2)
    {
        int days = 0;

        if (date1.CompareTo(date2) > 0)
        {
            TimeSpan duration = date1 - date2;
            days = duration.Days;

        } else if (date1.CompareTo(date2) < 0) 
        {
            TimeSpan duration = date2 - date1;
            days = duration.Days;

        } else
        {
            days = 0;
        }

        return days;
    }

    public static int CalculateDifferenceYears(DateTime date1, DateTime date2)
    {
        var yearDate1 = date1.Year;
        var yearDate2 = date2.Year;

        int years = 0;

        if (yearDate1.CompareTo(yearDate2) > 0)
        {
            int duration = yearDate1 - yearDate2;
            years = duration;

        }
        else if (yearDate1.CompareTo(yearDate2) < 0)
        {
            int duration = yearDate2 - yearDate1;
            years = duration;

        }
        else
        {
            years = 0;
        }

        return years;
    }

    public static DateTime DateFormatExternalAPI(string stringFecha)
    {
        string[] formatosAPIExterna = ["yyyyMMdd", "ddMMyyyy"];
        bool ok = DateTime.TryParseExact(stringFecha, formatosAPIExterna, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha);
        if (!ok) throw new FormatException();
        return fecha;
    }

}