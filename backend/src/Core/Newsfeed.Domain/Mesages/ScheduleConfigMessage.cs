namespace Newsfeed.Domain.Message;
public class ScheduleConfigMessage
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    public string Day {  get; set; }

    public string Month { get; set; }   

    public string Year { get; set; }

    public string Hour { get; set; }

    public string Minute { get; set; }

    public string CronExpression { get; set; }

    public string GenerateCronExpression()
    {
        // Các phần của cron expression
        string minute = string.IsNullOrEmpty(Minute) ? "*" : Minute;
        string hour = string.IsNullOrEmpty(Hour) ? "*" : Hour;
        string dayOfMonth = string.IsNullOrEmpty(Day) ? "*" : Day;
        string month = string.IsNullOrEmpty(Month) ? "*" : Month;
        string dayOfWeek = "?";
        string year = string.IsNullOrEmpty(Year) ? "*" : Year;

        // Tạo cron expression
        return $"0 {minute} {hour} {dayOfMonth} {month} {dayOfWeek} {year}";
    }
}
