using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TaxiAppsWebAPICore.Helper
{
    [Serializable]
    public class DataValidationException : Exception
    {
        public string ErrorCode { get; set; }

        protected DataValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DataValidationException(string message) : base(message) { }

        public DataValidationException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
