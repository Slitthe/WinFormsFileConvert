using FileConvert;
using FileConvert.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections;
using System.Text;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class TextFilesToJsonConvert
    {
        [TestMethod]
        public void WithExpectedValues()
        {

            string file1Extension = "txt";
            string file1Name = "unitTestExample1";
            string file1AsString = "I am a string and nothing more";
            byte[] file1AsArrayOfBytes = Encoding.Default.GetBytes(file1AsString);

            var file1Dto = new FileDTO()
            {
                FileName = file1Name,
                FileExtension = file1Extension,
                Content = file1AsArrayOfBytes
            };

            // whole object converted to json
            var file1AsJson = FileProcessor.TextFileToJson(file1Dto);

            // json result only
            var file1JsonText = Encoding.Default.GetString(file1AsJson.Content);
            
            var jsonResult = JsonConvert.DeserializeObject<FileDTO>(file1JsonText);


            bool sameFileName = file1Dto.FileName == jsonResult.FileName;
            bool sameContent = StructuralComparisons.StructuralEqualityComparer.Equals(file1Dto.Content, jsonResult.Content);
            bool sameFileExtension = file1Dto.FileExtension == jsonResult.FileExtension;


            Assert.AreEqual(
                sameFileExtension && sameFileName && sameContent, 
                true);


        }

        //[TestMethod]
        //public void WithNonTextFile()
        //{
        //    string outputDirectory = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles";

        //    string file1Extension = "html";
        //    string file1Name = "unitTestExample1";
        //    string file1AsString = "I am a string and nothing more";
        //    byte[] file1AsArrayOfBytes = Encoding.Default.GetBytes(file1AsString);

        //    var file1Dto = new FileDTO()
        //    {
        //        FileName = file1Name,
        //        FileExtension = file1Extension,
        //        Content = file1AsArrayOfBytes
        //    };

        //    var file1AsJson = FileProcessor.TextFileToJson(file1Dto);

        //    var file1JsonText = Encoding.Default.GetString(file1AsJson.Content);


        //}



    }
}
