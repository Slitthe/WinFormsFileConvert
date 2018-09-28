using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class CheckFileExistance
    {
        [TestMethod]
        public void WithCorrectFile()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";


            bool result =  FileConvertors.filesExistanceChecker(fullFilePath);

            bool expectedResult = true;

            

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void WithAFileWhichDoesNotExist()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\thisDoesNotExist.html";


            bool result = FileConvertors.filesExistanceChecker(fullFilePath);

            bool expectedResult = false;



            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WithWrongPath()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\asdsadsa\sadas.txt";


            bool result = FileConvertors.filesExistanceChecker(fullFilePath);

            bool expectedResult = false;



            Assert.AreEqual(expectedResult, result);
        }

    }
}
