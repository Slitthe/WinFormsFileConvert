using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class GetFileName
    {
        [TestMethod]
        public void WithSimplePath()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";


            string result =  FileProcessor.GetFileName(fullFilePath);

            string expected = "fileTwo";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithFileNameContainingMoreThanOneDotCharacters()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.antoher.html";


            string result = FileProcessor.GetFileName(fullFilePath);

            string expected = "fileTwo.antoher";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithNoFileInPath()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\";


            string result = FileProcessor.GetFileName(fullFilePath);

            string expected = "";

            Assert.AreEqual(expected, result);
        }




    }
}
