using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domain.DataModels
{

    public partial class Request
    {
        [Key]
        public Guid? Id { get; set; }

        public string Name { get; set; }
        public DateTime? Time { get; set; }
    }
}