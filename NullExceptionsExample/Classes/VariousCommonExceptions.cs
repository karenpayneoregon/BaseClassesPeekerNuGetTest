using System;
using System.Collections.Generic;
using System.Linq;
using BaseConnectionLibrary;

namespace NullExceptionsExample.Classes
{
    public class VariousCommonExceptions : BaseExceptionProperties
    {
        public void InvalidCastException()
        {
            mHasException = false;

            try
            {
                object o = "10";
                int x = (int)o;
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
        }

        public void InvalidOperationException()
        {
            mHasException = false;

            try
            {
                var numbers = new List<int> { 1, 3, 5 };
                var firstGreaterThanFive = numbers.Where(x => x > 5).First();
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
        }
        /// <summary>
        /// Correction to InvalidOperationException()
        /// </summary>
        public void ValidOperationDoneRight()
        {
            mHasException = false;

            try
            {
                var numbers = new List<int> { 1, 3, 5 };
                var firstGreaterThanFive = numbers.FirstOrDefault(x => x > 5);
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
        }
    }
}
