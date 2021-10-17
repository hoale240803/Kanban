using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class IntegrationEventLog
    {
        public Guid EventId { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public string EventTypeName { get; set; }
        public int State { get; set; }
        public int TimesSent { get; set; }
        public string TransactionId { get; set; }
    }
}
