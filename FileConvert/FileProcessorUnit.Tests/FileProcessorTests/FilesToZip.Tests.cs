﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.Text;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using FileConvert.Services;

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

            var file1Dto = new FileDto()
            {
                FileName = file1Name,
                FileExtension = file1Extension,
                Content = file1AsArrayOfBytes
            };

            List<FileDto> fileList = new List<FileDto>() { file1Dto };
            string fullFileSavePath = $"{savePath}\\{zipName}.zip";

            // execute external test methods
            FileDto filesListToZip = FileConvertors.FilesToZip(fileList, zipName);

            List<FileDto> filesToSave = new List<FileDto>()
            {
                filesListToZip
            };

            FileConvertors.SaveFiles(filesToSave, savePath, false);


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

            var file1Dto = new FileDto()
            {
                FileName = file1Name,
                FileExtension = file1Extension,
                Content = file1AsArrayOfBytes
            };

            List<FileDto> fileList = new List<FileDto>() { file1Dto };
            string fullFileSavePath = $"{savePath}\\{zipName}.zip";

            // execute external test methods
            FileDto filesListToZip = FileConvertors.FilesToZip(fileList, zipName);

            List<FileDto> filesToSave = new List<FileDto>()
            {
                filesListToZip
            };

            FileConvertors.SaveFiles(filesToSave, savePath, false);
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
