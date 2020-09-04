using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.DAL.SQLClient.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException()
        {

        }

        public DatabaseException(string message) : base(message)
        {

        }
    }
}
