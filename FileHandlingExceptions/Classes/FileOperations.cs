using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BaseConnectionLibrary;

namespace FileHandlingExceptions.Classes
{
    public class FileOperations : BaseExceptionProperties
    {
        public List<string> ReadFileWithBaseExceptionProperties(string fileName)
        {
            var lines = new List<string>();

            try
            {
                lines = File.ReadAllLines(fileName).ToList();
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
            return lines;
        }
        public List<string> ReadFileWithOutBaseExceptionProperties(string fileName) => 
            File.ReadAllLines(fileName).ToList();
    }
}
