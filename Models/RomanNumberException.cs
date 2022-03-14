using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l4_2.Models
{
    public class RomanNumberException : Exception
    {
        public RomanNumberException(string message)
        {
            Console.WriteLine(message);
        }

    }
}
