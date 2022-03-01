using System;

namespace Cash_Record_Backend.Data.Exceptions
{
    public class InvalidMonthException:ApplicationException
    {
        public InvalidMonthException()
        {
        }

        public InvalidMonthException(string message):base(message)
        {

        }
    }
}
