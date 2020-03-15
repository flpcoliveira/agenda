using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Exceptions
{
    public class EntitynotfoundException : Exception
    {
        public EntitynotfoundException(string message) : base(message)
        {
        }
    }
}
