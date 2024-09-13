using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatching
{
    public class MyFileWatcher : IMyFileWatcher
    {
        private string _directoryName = Path.Join(Environment.CurrentDirectory, "files");//change this to whatever you want
        private string _logFilePath = Path.Join(Environment.CurrentDirectory, "files", "log_file.txt");

        private string _fileFilter = string.Empty; //"*.*";
        FileSystemWatcher _fileSystemWatcher;
        ILogger<MyFileWatcher> _logger;
        IServiceProvider _serviceProvider;

        public MyFileWatcher(ILogger<MyFileWatcher> logger,
                                IServiceProvider serviceProvider)
        {
            _logger = logger;
            if (!Directory.Exists(_directoryName))
                Directory.CreateDirectory(_directoryName);
            _fileSystemWatcher = new FileSystemWatcher(_directoryName, _fileFilter);
            _serviceProvider = serviceProvider;
        }

        public void Start()
        {
            _fileSystemWatcher.NotifyFilter =
                                     NotifyFilters.Attributes
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.FileName
                                    | NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Security
                                    | NotifyFilters.Size;

            _fileSystemWatcher.Changed += _fileSystemWatcher_Changed;
            _fileSystemWatcher.Created += _fileSystemWatcher_Created;
            _fileSystemWatcher.Deleted += _fileSystemWatcher_Deleted;
            _fileSystemWatcher.Renamed += _fileSystemWatcher_Renamed;
            _fileSystemWatcher.Error += _fileSystemWatcher_Error;


            _fileSystemWatcher.EnableRaisingEvents = true;
            _fileSystemWatcher.IncludeSubdirectories = true;

            _logger.LogInformation($"File Watching has started for directory { _directoryName}");
        }

        private void _fileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            string message = e.GetException().Message;
            _logger.LogInformation($"File error event {message}");

            //try
            //{
            //    using (StreamWriter writer = new StreamWriter(_logFilePath))
            //    {
            //        writer.Write(message);
            //        writer.Flush();
            //    }
            //}
            //catch (Exception exp)
            //{
            //    Console.Write(exp.Message);
            //}
        }

        private void _fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            string message = $"File rename event for file {e.FullPath}";
            _logger.LogInformation(message);

            //try
            //{
            //    using (StreamWriter writer = new StreamWriter(_logFilePath))
            //    {
            //        writer.Write(message);
            //        writer.Flush();
            //    }
            //}
            //catch (Exception exp)
            //{
            //    Console.Write(exp.Message);
            //}
        }

        private void _fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string message = $"File deleted event for file {e.FullPath}";
            _logger.LogInformation(message);

            //try
            //{
            //    using (StreamWriter writer = new StreamWriter(_logFilePath))
            //    {
            //        writer.Write(message);
            //        writer.Flush();
            //    }
            //}
            //catch (Exception exp)
            //{
            //    Console.Write(exp.Message);
            //}
        }

        private void _fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string message = $"File changed event for file {e.FullPath}";
            _logger.LogInformation(message);

            //try
            //{
            //    using (StreamWriter writer = new StreamWriter(_logFilePath))
            //    {
            //        writer.Write(message);
            //        writer.Flush();
            //    }
            //}
            //catch (Exception exp)
            //{
            //    Console.Write(exp.Message);
            //}
        }

        private void _fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string message = $"File created event for file {e.FullPath}";
            _logger.LogInformation(message);

            //try
            //{
            //    using (StreamWriter writer = new StreamWriter(_logFilePath))
            //    {
            //        writer.Write(message);
            //        writer.Flush();
            //    }
            //}
            //catch (Exception exp)
            //{
            //    Console.Write(exp.Message);
            //}

            //using (var scope = _serviceProvider.CreateScope())
            //{
            //    var consumerService = scope.ServiceProvider.GetRequiredService
            //                                            <IFileConsumerService>();
            //    Task.Run(() => consumerService.ConsumeFile(e.FullPath));
            //}
        }
    }
    
}