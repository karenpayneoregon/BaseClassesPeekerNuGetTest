using System;
using System.Collections.Generic;
using System.Linq;
using BaseConnectionLibrary;

namespace NullExceptionsExample.Classes
{
    public class CollectionExamples : BaseExceptionProperties
    {
        public void CollectionIsNull()
        {
            try
            {
                var people = new List<Person>();
                people.Add(null);
                var names = from p in people select p.Name;
                var firstName = names.First();
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
        }


    }
}
