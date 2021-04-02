using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using IntercomTest;
using IntercomTest.Tests.Helper;
using IntercomTest.Services;
using IntercomTest.Classes;
using Newtonsoft.Json;

namespace IntercomTest.Tests
{
    [TestClass]
    public class FileServiceTests
    {
        [TestMethod]
        public void GetFilePath_FilePathIncluded_ShouldReturnCorrectDirectory()
        {
            var fileName = @"Files\test.txt";
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var path = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
            var filePath = path + fileName;

            Assert.IsNotNull(filePath);
            Assert.AreEqual(@"C:\Users\aisli\source\repos\IntercomTest\IntercomTest.Tests\Files\test.txt", filePath);

        }

        [TestMethod]
        public void GetFilePath_FilePathNotIncluded_ShouldFail()
        {
            var filePath = string.Empty;
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var path = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));
            var file = path + filePath;

            var fileService = new FileService();
            TestHelper.ExpectException<ArgumentNullException>(() => fileService.GetFilePath(null));
        }

        [TestMethod]
        public void ReadFile_DeserializeJson_ShouldMapToUserObject()
        {
            var json = @"{'latitude': '52.833502', 'user_id': 1, 'name': 'Aisling McGettigan', 'longitude': '-8.522366'}";
               
            var deserializedMessage = JsonConvert.DeserializeObject<User>(json);

            Assert.AreEqual(deserializedMessage.Name, "Aisling McGettigan");
            Assert.AreEqual(deserializedMessage.User_Id, 1);
            Assert.AreEqual(deserializedMessage.Latitude, 52.833502);
            Assert.AreEqual(deserializedMessage.Longitude, -8.522366);
        }

        [TestMethod]
        public void IsWithin100KM_IfDistanceMoreThan100KM_ShouldReturnFalse()
        {
            var dist = LocationService.Distance(52.833502, -8.522366, 54.080556, -6.361944);

            var isWithin100Km = dist < 100.00;
            Assert.IsFalse(isWithin100Km);
        }
    }
}
