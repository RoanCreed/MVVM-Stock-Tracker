using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.Exceptions
{
    internal class StockDoesNotExsistException : Exception
    {
        public StockDoesNotExsistException()
        {
        }

        public StockDoesNotExsistException(string message) : base(message)
        {
        }

        public StockDoesNotExsistException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
