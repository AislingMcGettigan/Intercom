using IntercomTest.Classes;
using Newtonsoft.Json;
using System;
using System.IO;

namespace IntercomTest.Services
{
    public class FileService
    {

        public string GetFilePath(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var basePath = Path.GetFullPath(Path.Combine(_BaseDirectory, @"..\..\..\"));
            var file = basePath + filePath;
            return file;
         
        }

        public void ReadFile(string file)
        {
            foreach (string line in File.ReadLines(file))
            {
                var user = JsonConvert.DeserializeObject<User>(line);
                var withinDistance = IsWithin100Km(user);
                if (withinDistance)
                {
                    WriteUsersToFile(user);
                }
            }
        }

        public bool IsWithin100Km(User user)
        {
            var distance = LocationService.Distance(53.339428, -6.257664, user.Latitude, user.Longitude);
            if (distance < 100.00)
            {
                return true;
            }
            return false;
        }


        public void WriteUsersToFile(User user)
        {
            using (var writer = new StreamWriter(GetFilePath(@"Files\output.txt")))
            {
                writer.WriteLine(user.User_Id + " " + user.Name);
            }
        }      
    }
}
