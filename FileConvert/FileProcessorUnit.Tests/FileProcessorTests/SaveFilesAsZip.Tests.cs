using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.Text;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class SaveFilesToAsZip
    {
        [TestMethod]
        public void JustCheckingExistance()
        {
            string outputDirectory = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\ZipTests";
            string zipName = "zipName";

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

            string file2Extension = "txt";
            string file2Name = "unitTestExample2";
            string file2AsString = "I am a another string and nothing more";
            byte[] file2AsArrayOfBytes = Encoding.Default.GetBytes(file2AsString);

            var file2Dto = new FileDTO()
            {
                FileName = file2Name,
                FileExtension = file2Extension,
                Content = file2AsArrayOfBytes
            };

            List<FileDTO> dummyFilesList = new List<FileDTO>() { file1Dto, file2Dto };

            FileProcessor.SaveFilesAsZip(dummyFilesList, outputDirectory, zipName);


            var openSavedFile = File.Open(outputDirectory + "\\" + zipName + ".zip", FileMode.Open);
            ZipArchive zipArch = new ZipArchive(openSavedFile, ZipArchiveMode.Read);

            var entries = zipArch.Entries;

            openSavedFile.Dispose();
            zipArch.Dispose();

            try
            {
                Assert.AreEqual(
                    entries[0].FullName == $"{file1Name}.{file1Extension}"
                    &&
                    entries[1].FullName == $"{file2Name}.{file2Extension}",
                    true
                );
            }
            finally
            {
                File.Delete(outputDirectory + "\\" + zipName + ".zip");
            }
            
        }
    }
}
