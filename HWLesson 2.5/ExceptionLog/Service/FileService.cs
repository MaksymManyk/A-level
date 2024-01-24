using Service.Abstraction;

namespace Service
{
    static class FileService
    {
       public static void SaveLog(string message)
        {
            string logFileName = $"logs\\{DateTime.Now.ToString("MMddyyyy hh.mm.ss")}.txt";
            File.WriteAllText(logFileName, message);
        }

       public static void DeleteLog(int countFiles, string path) 
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                int filesCount = files.Length;

                while (filesCount > countFiles)
                {
                    var file = GetOldestFile(Directory.GetFiles(path));
                    File.Delete($"{path}\\{file}");
                    filesCount--;
                }
            }
            else
            {
                Console.WriteLine($"Path {path} apsent.");
            }
        }

       private static string GetOldestFile(string[]  files)
        {
            FileInfo oldestFile = new FileInfo(files[0]);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                oldestFile = fileInfo.CreationTime < oldestFile.CreationTime ? fileInfo : oldestFile;
            }

            return oldestFile.Name;
        }
    }
}
