using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.Collections.Generic;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class CheckMultipleFilesExistance
    {
        [TestMethod]
        public void WithCorrectValues()
        {
            string fullFilePath1 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";
            string fullFilePath2 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileOne.txt";
            string fullFilePath3 = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileThree.txt.json";

            var filePathsList = new List<string>() { fullFilePath1, fullFilePath2, fullFilePath3 };
            

            bool result =  FileConvertors.filesExistanceChecker(filePathsList);

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


            bool result = FileConvertors.filesExistanceChecker(filePathsList);

            bool expectedResult = false;



            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WithEmptyList()
        {


            var filePathsList = new List<string>();


            bool result = FileConvertors.filesExistanceChecker(filePathsList);

            bool expectedResult = false;



            Assert.AreEqual(expectedResult, result);
        }


    }
}
