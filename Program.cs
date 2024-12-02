internal class DownloadsCleanUp
{
    private const string deleteFolder = "Delete";

    private static void DeleteFiles(string[] filesToDelete)
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
                Logger.Log($"Error deleting file: {file} - {ex.Message}");
            }
        }
    }

    private static void DeleteDirectories(string[] directoriesToDelete)
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
                Logger.Log($"Error deleting directory: {directory} - {ex.Message}");
            }
        }
    }

    private static void Main()
    {
        string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        Console.WriteLine($"Downloads folder path: {downloadsPath}");

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
            Logger.Log($"Delete Directory created at {deleteFolderPath}");
        }
    }
}