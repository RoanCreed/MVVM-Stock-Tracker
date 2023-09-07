using MVVMSettings.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernDesign.Exceptions
{
    public class InputValidationException : Exception
    {
        
        public InputValidationException()
        {
            MessageBox.Show("All fields must have the correct type and not be 0!");
        }

        public InputValidationException(string message) : base(message)
        {
            
        }

        public InputValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
