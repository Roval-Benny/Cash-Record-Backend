using System;

namespace Cash_Record_Backend.Data.Exceptions
{
    public class InvalidYearException:ApplicationException
    {
        public InvalidYearException()
        {

        }
        public InvalidYearException(string message):base(message)
        {

        }
    }
}
