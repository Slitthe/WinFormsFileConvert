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
    public class FilesToZipTests
    {
        [TestMethod]
        public void CheckSaveOfZipFile()
        {
            // dummy date prepare
            string zipName = "packaged";

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

            List<FileDTO> fileList = new List<FileDTO>() { file1Dto };
            string fullFileSavePath = $"{savePath}\\{zipName}.zip";

            // execute external test methods
            FileDTO filesListToZip = FileProcessor.FilesToZip(fileList, zipName);

            List<FileDTO> filesToSave = new List<FileDTO>()
            {
                filesListToZip
            };

            FileProcessor.SaveFiles(filesToSave, savePath);


            // check for results
            FileInfo fileInfo = new FileInfo(fullFileSavePath);
            bool fileExists = fileInfo.Exists;
            bool correctFilename = fileInfo.Name == $"{zipName}.zip";

            // assert & cleanup
            try
            {
                Assert.AreEqual(fileExists && correctFilename, true);
            }
            finally
            {
                if(fileExists)
                {
                    File.Delete(fullFileSavePath);
                }
            }
        }


        [TestMethod]
        public void CheckZipFileContent()
        {
            // dummy date prepare
            string zipName = "packagedContentTest";

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

            List<FileDTO> fileList = new List<FileDTO>() { file1Dto };
            string fullFileSavePath = $"{savePath}\\{zipName}.zip";

            // execute external test methods
            FileDTO filesListToZip = FileProcessor.FilesToZip(fileList, zipName);

            List<FileDTO> filesToSave = new List<FileDTO>()
            {
                filesListToZip
            };

            FileProcessor.SaveFiles(filesToSave, savePath);
            bool correctEntriesNumber = false;
            bool correctEntryName = false;

            // check for results
            using ( Stream zipStream = File.OpenRead(fullFileSavePath) )
            using ( ZipArchive za = new ZipArchive(zipStream, ZipArchiveMode.Read) )
            {
                var entries = za.Entries;
                correctEntriesNumber = entries.Count == 1;
                correctEntryName = entries[0].FullName == $"{file1Dto.FileName}.{file1Dto.FileExtension}";
            }

            // assert conditions


            // assert execution and cleanup
            try
            {
                Assert.AreEqual(correctEntriesNumber && correctEntryName, true);
            }
            finally
            {
                File.Delete(fullFileSavePath);
            }


        }

        private string savePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\ZipTests";
    }
}
