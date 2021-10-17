using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.DataModels
{
    public partial class Request
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Time { get; set; }
    }
}
