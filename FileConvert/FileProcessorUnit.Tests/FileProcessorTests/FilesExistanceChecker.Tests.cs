using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.Collections.Generic;
using FileConvert.Services;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class FilesExistanceChecker
    {
        [TestMethod]
        public void WithSingleCorrectValues()
        {
            string fullFilePath1 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileThree.txt.json";

            var filePathsList = new List<string>() { fullFilePath1 };
            

            bool result = FileNameHelpers.FilesExistenceChecker(filePathsList);

            bool expectedResult = true;

            

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WithMultipleCorrectValues()
        {
            string fullFilePath1 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";
            string fullFilePath2 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileOne.txt";
            string fullFilePath3 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileThree.txt.json";

            var filePathsList = new List<string>() { fullFilePath1, fullFilePath2, fullFilePath3 };


            bool result = FileNameHelpers.FilesExistenceChecker(filePathsList);

            bool expectedResult = true;



            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WithOneValuesBeingWrong()
        {
            string fullFilePath1 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";
            string fullFilePath2 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileOne.txt";
            string fullFilePath3 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\doesNotExist.really";

            var filePathsList = new List<string>() { fullFilePath1, fullFilePath2, fullFilePath3 };


            bool result = FileNameHelpers.FilesExistenceChecker(filePathsList);

            bool expectedResult = false;



            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WithEmptyList()
        {


            var filePathsList = new List<string>();


            bool result = FileNameHelpers.FilesExistenceChecker(filePathsList);

            bool expectedResult = false;



            Assert.AreEqual(expectedResult, result);
        }


    }
}
