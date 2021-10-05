using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class UserToken
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public string Token { get; set; }
        public DateTime? Expire { get; set; }
        public bool? IsExpired { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? RevokeAt { get; set; }
        public bool? IsActive { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
