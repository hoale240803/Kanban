using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class KanbanDomainException : Exception
    {
        public KanbanDomainException()
        { }

        public KanbanDomainException(string message)
            : base(message)
        { }

        public KanbanDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
