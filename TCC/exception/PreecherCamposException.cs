using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.exception
{
    public class PreecherCamposException : Exception
    {
        public PreecherCamposException() { }
        public PreecherCamposException(string message) : base(message) { }
    }
}
