using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernDesign.Exceptions
{
    internal class StockAlreadyExsistsException : Exception
    {
        public StockAlreadyExsistsException()
        {
            MessageBox.Show("Stock name already exsits. Please use the edit page to edit stocks.");
        }

        public StockAlreadyExsistsException(string message) : base(message)
        {
        }

        public StockAlreadyExsistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
