# DownloadsCleanUp

A small C# console application to help keep the Downloads folder clean on Windows machines.

## Features

- Deletes files and directories within a specified folder (default is "Delete" folder inside Downloads).
- Logs actions and errors to a log file (`DownloadCleanup_Log.txt`).

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later

## Getting Started

### Building the Application

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/DownloadsCleanUp.git
    cd DownloadsCleanUp
    ```

2. Build the application:
    ```sh
    dotnet build
    ```

### Running the Application

1. Run the application:
    ```sh
    dotnet run
    ```

### Publishing the Application

1. Publish the application for Windows:
    ```sh
    dotnet publish -c Release -r win-x64 --self-contained
    ```

2. The published files will be located in the `bin\Release\net6.0\win-x64\publish` directory.

### Deploying the Application

1. Copy the contents of the `publish` directory to the desired location on your Windows machine (e.g., `C:\Program Files\DownloadsCleanUp`).

### Setting Up a Scheduled Task

1. Open Task Scheduler (`Win + R`, type `taskschd.msc`, and press Enter).
2. Create a new task:
    - **General Tab**:
        - Name: `DownloadsCleanUp`
        - Description: `Clean up the Downloads folder`
        - Run whether user is logged on or not
        - Run with highest privileges
    - **Triggers Tab**:
        - New trigger: Set the schedule (e.g., daily at 2:00 AM)
    - **Actions Tab**:
        - New action: Start a program
        - Program/script: `C:\Program Files\DownloadsCleanUp\DownloadsCleanUp.exe`
    - **Conditions and Settings Tabs**: Configure any additional conditions and settings as needed.

3. Test the scheduled task by right-clicking on it and selecting "Run".

## Logging

- The application logs actions and errors to `DownloadCleanup_Log.txt` in the application's directory.
- Each log entry includes a timestamp and a message.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a new Pull Request.

## License

This project is licensed under the Apache V2.0 License - see the [LICENSE](LICENSE) file for details.