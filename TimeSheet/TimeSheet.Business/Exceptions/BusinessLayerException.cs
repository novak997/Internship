using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Business.Exceptions
{
    public class BusinessLayerException : Exception
    {
        public BusinessLayerException()
        {

        }

        public BusinessLayerException(string message) : base(message)
        {

        }
    }
}
