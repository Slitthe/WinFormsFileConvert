using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.Text;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using FileConvert.Enums;
using FileConvert.Services;
using System.Collections;

namespace FileConvertorsUnit.Tests
{
    [TestClass]
    public class ConvertCheck
    {
        [TestMethod]
        public void CheckConvertExtensionOnly()
        {
            var filesToConvertDummyData = FilesObjGenerators.GetFilesToConvertList();

            var convertedFilesList = FileConvertors.ConvertFiles(filesToConvertDummyData);


            bool extensionTest = convertedFilesList[0].FileExtension == "json";
            extensionTest = extensionTest && convertedFilesList[1].FileExtension == "";
            extensionTest = extensionTest && convertedFilesList[2].FileExtension == "html";

            Assert.AreEqual(extensionTest, true);
        }

        [TestMethod]
        public void CheckConvertContent()
        {

            // convert files by method
            var filesToConvertDummyData = FilesObjGenerators.GetFilesToConvertList();
            
            
            // manually convert
            var convertedFilesList = FileConvertors.ConvertFiles(filesToConvertDummyData);
            var file1ActualJson = convertedFilesList[0];
            var file2ActualBinary = convertedFilesList[1];

            var file1ExpectedJson = FileProcessor.TextFileToJson(convertedFilesList[0]);
            var file2ExpectedBinary = FileProcessor.TextToBinary(convertedFilesList[1]);

            bool jsonComparison = StructuralComparisons.StructuralEqualityComparer.Equals(file1ExpectedJson.Content, file1ActualJson.Content);

            bool binaryComparison = StructuralComparisons.StructuralEqualityComparer.Equals(file2ActualBinary.Content, file2ExpectedBinary.Content);



            Assert.AreEqual(binaryComparison && jsonComparison, true);
        }

        [TestMethod]
        public void NullValuesCheck()
        {
            var nullFilesToConvert = new List<FileToConvertDTO>() { null, null };

            var convertedFilesList = FileConvertors.ConvertFiles(nullFilesToConvert);

            Assert.AreEqual(convertedFilesList.Count, 0);
        }

        [TestMethod]
        public void SameContentFilesNotConverted()
        {
            var filesToConvertDummyData = FilesObjGenerators.GetFilesToConvertList();

            var convertedFilesList = FileConvertors.ConvertFiles(filesToConvertDummyData);


            bool sameContent = StructuralComparisons.StructuralEqualityComparer.Equals(filesToConvertDummyData[2].FileObj.Content, convertedFilesList[2].Content);

            Assert.AreEqual(sameContent, true);
        }
    }
}
