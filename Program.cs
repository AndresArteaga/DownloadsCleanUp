internal class DownloadsCleanUp (ILogger logger)
{
    private const string deleteFolder = "Delete";
    private readonly ILogger log = logger;

    private void DeleteFiles(string[] filesToDelete)
    {
        if (filesToDelete.Length == 0)
            return;
        foreach (string file in filesToDelete)
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception ex)
            {
                log.Log($"Error deleting file: {file} - {ex.Message}\n{ex.StackTrace}");
            }
        }
    }

    private void DeleteDirectories(string[] directoriesToDelete)
    {
        if (directoriesToDelete.Length == 0)
            return;
        foreach (string directory in directoriesToDelete)
        {
            try
            {
                Directory.Delete(directory, true);
            }
            catch (Exception ex)
            {
                log.Log($"Error deleting directory: {directory} - {ex.Message}\n{ex.StackTrace}");
            }
        }
    }

    private void CleanUp()
    {
        string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        string deleteFolderPath = Path.Combine(downloadsPath, deleteFolder);
        if (Directory.Exists(deleteFolderPath))
        {
            string[] files = Directory.GetFiles(deleteFolderPath);
            string[] subDirectories = Directory.GetDirectories(deleteFolderPath);
            DeleteFiles(files);
            DeleteDirectories(subDirectories);
        }    
        else
        {
            Directory.CreateDirectory(deleteFolderPath);
            log.Log($"Delete Directory created at {deleteFolderPath}");
        }
    }

    public static void Main()
    {
        ILogger logger = new Logger();
        DownloadsCleanUp cleanUp = new DownloadsCleanUp(logger);
        cleanUp.CleanUp();
    }
}