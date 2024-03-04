
namespace Asynchronous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(directoryPath);
             
            string path1 = directoryPath + "\\Test1.txt";
            string path2 = directoryPath + "\\Test2.txt";

            var result = Task.Run(() => ConcateFiles(path1, path2)).Result;
                
            foreach (var line in result) 
            {
                Console.WriteLine(line);
            }            
 
        }
        static async Task<List<string>>   ReadHello(string fileName)
        { 
            var lines = await File.ReadAllLinesAsync(fileName);
           
            return lines.ToList();
        }


        static async Task<List<string>> ReadWorld(string fileName)
        {
            var lines = await File.ReadAllLinesAsync(fileName);           
            return lines.ToList();
        }

        static async Task<List<string>>   ConcateFiles (string file1 , string file2)
        {
            var t1 =   Task.Run(() => ReadHello (file1));           
            var t2 =  Task.Run(() => ReadWorld (file2));            
           
            var result1 = await t1;
            var result2 = await t2;

            result1.AddRange(result2);

            return result1; 
        }
    }
}
