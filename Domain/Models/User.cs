using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            CardLists = new HashSet<CardList>();
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
        public string HashedPassword { get; set; }

        public virtual ICollection<CardList> CardLists { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
    }
}
