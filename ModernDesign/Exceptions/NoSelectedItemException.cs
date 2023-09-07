using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernDesign.Exceptions
{
    public class NoSelectedItemException : Exception
    {
        public NoSelectedItemException()
        {
            MessageBox.Show("Must select a stock");
        }

        public NoSelectedItemException(string message) : base(message)
        {
        }

        public NoSelectedItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSelectedItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
