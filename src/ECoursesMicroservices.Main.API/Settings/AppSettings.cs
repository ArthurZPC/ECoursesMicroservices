namespace ECoursesMicroservices.Main.API.Settings;

public class AppSettings
{
    public const string DefaultConnection = "DefaultConnection";

    public string CurrentConnectionString { get; set; } = string.Empty;
}
