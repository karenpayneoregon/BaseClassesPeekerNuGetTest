using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseConnectionLibrary;

namespace NullExceptionsExample.Classes
{
    public class ArrayExamples : BaseExceptionProperties
    {
        public void SetValueWithNullArray()
        {

            try
            {
                int[] numbers = null;
                int n = numbers[0];
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
        }
    }
}
