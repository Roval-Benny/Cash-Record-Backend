using System;

namespace Cash_Record_Backend.Data.Exceptions
{
    public class EntryNotFoundException:ApplicationException
    {
        public EntryNotFoundException(){}
        public EntryNotFoundException(string message):base(message){}
    }
}
