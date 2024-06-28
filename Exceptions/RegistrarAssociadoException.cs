using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAuto.Exceptions
{
    public class RegistrarAssociadoException : Exception
    {
        public RegistrarAssociadoException(String message) : base(message)
        {

        }
    }
}