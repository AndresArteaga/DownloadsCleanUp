public static class Logger
{
    private const string LogFileName = "DownloadCleanup_Log.txt";

    public static void Log(string message)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(LogFileName, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error writing to log file: {ex.Message}");
        }
    }
}