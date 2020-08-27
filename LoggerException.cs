using System;
using System.Runtime.Serialization;

namespace StringCalculatorBlank
{
    [Serializable]
    public class LoggerException : ApplicationException
    {
        public LoggerException(string message): base(message)
        {

        }
    }
}