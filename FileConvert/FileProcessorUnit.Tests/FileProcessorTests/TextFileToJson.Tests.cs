using FileConvert;
using FileConvert.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections;
using System.Text;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class TextFileToJson
    {
        [TestMethod]
        public void WithExpectedValues()
        {
            // create file object
            string file1Extension = "txt";
            string file1Name = "unitTestExample1";
            string file1AsString = "I am a string and nothing more";
            byte[] file1AsArrayOfBytes = Encoding.Default.GetBytes(file1AsString);

            FileDTO file1Dto = new FileDTO()
            {
                FileName = file1Name,
                FileExtension = file1Extension,
                Content = file1AsArrayOfBytes
            };


            // convert object to json
            FileDTO file1AsJson = FileProcessor.TextFileToJson(file1Dto);
     
            // convert file content as string
            string file1AsJsonToString = Encoding.Default.GetString(file1AsJson.Content);

            // Expected (manually convert)

            TextFileAsJsonDTO fileAsJsonDTo = new TextFileAsJsonDTO()
            {
                FileName = file1Dto.FileName,
                FileExtension = file1Dto.FileExtension,
                Content = Encoding.Default.GetString(file1Dto.Content)
            };

            string fileAsJsonDToConverted = JsonConvert.SerializeObject(fileAsJsonDTo);







            Assert.AreEqual(
                file1AsJsonToString == fileAsJsonDToConverted,
                true);


        }

        [TestMethod]
        public void WithNonTextFileExtension()
        {
            // create file object
            string file1Extension = "json";
            string file1Name = "unitTestExample1";
            string file1AsString = "I am a string and nothing more";
            byte[] file1AsArrayOfBytes = Encoding.Default.GetBytes(file1AsString);

            FileDTO file1Dto = new FileDTO()
            {
                FileName = file1Name,
                FileExtension = file1Extension,
                Content = file1AsArrayOfBytes
            };


            // convert object to json
            FileDTO file1AsJson = FileProcessor.TextFileToJson(file1Dto);




            // Assert
            Assert.AreEqual(
                file1AsJson.FileExtension == file1Dto.FileExtension &&
                file1AsJson.FileName == file1Dto.FileName &&
                StructuralComparisons.StructuralEqualityComparer.Equals(file1Dto.Content, file1AsJson.Content)
                , true);


        }



    }
}
