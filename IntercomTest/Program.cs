using IntercomTest.Services;


namespace IntercomTest
{
   public class Program
    {
        static void Main(string[] args)
        {
            var fileService = new FileService();
            var filePath = fileService.GetFilePath(@"Files\customers.txt");
            fileService.ReadFile(filePath);           
        }
    }
}
