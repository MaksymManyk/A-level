using Config;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using Enums;

namespace  Services
{
    internal class LoggerService : ILoggerService
    {
        private readonly LoggerOption _loggerOption;
        private readonly SemaphoreSlim _semaphoreSlim;
        private readonly string _fullPathLog;
        private readonly string _fullPathBackup;

        public LoggerService(IOptions<LoggerOption> loggerOptions)
        {
            this._loggerOption = loggerOptions.Value;
            _fullPathLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _loggerOption.LogFilePath);
            _fullPathBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _loggerOption.BackUpFolder);
            this.CheckDirectory(_fullPathLog);
            this.CheckDirectory(_fullPathBackup);
            this._semaphoreSlim = new SemaphoreSlim(1);
        }

        public void CheckDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public async Task SaveLog(LogType logType, string message)
        {
            var log = $"{DateTime.UtcNow} {logType,-10} {message,-10}";
            await _semaphoreSlim.WaitAsync();
            try
            {
                var logFileName = CheckLogFile();
                using (StreamWriter writer = new StreamWriter (logFileName, append: true))
                {
                    await writer.WriteLineAsync(log);
                    await writer.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Register log failed: {ex.Message}");
            }
            finally { this._semaphoreSlim.Release(); }
        }

        public string CheckLogFile()
        {

            int countLogLine = 0;
            string fileName = Path.Combine(_fullPathLog, $"{DateTime.Now.ToString("yyyyMMdd HH_mm_ss")}.txt");
            string[] files = Directory.GetFiles(_fullPathLog);
            var fileInfo = files.Select(file => new FileInfo(file));

            var lastFile = fileInfo.OrderByDescending(file => file.CreationTime).FirstOrDefault();
            if (lastFile != null)
            {
                using (StreamReader reader = new StreamReader(lastFile.FullName))
                {
                    while (reader.ReadLine() != null)
                    {
                        countLogLine++;
                    }
                }

                if (countLogLine >= _loggerOption.NumbersOfEntries)
                {
                    lastFile.MoveTo(Path.Combine(_fullPathBackup, lastFile.Name));
                    Console.WriteLine($"File {lastFile.Name} was moved to {_fullPathBackup} directory");
                    return fileName;
                }
                else
                {
                    return lastFile.FullName;
                }
            }
            else
            {
                return fileName;
            }
        }

        public void PrintLoggerOptions()
        {
            Console.WriteLine($"Path = {_loggerOption.LogFilePath}, Number = {_loggerOption.NumbersOfEntries}, BackUp directory = {_loggerOption.BackUpFolder}");
        }

    }
}
