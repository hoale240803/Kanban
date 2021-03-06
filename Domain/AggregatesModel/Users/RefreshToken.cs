using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public partial class RefreshToken
    {

        public int Id { get; set; }

        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }

        // condition DateTime.UtcNow >= Expires;
        public bool IsExpired { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }

        // condition Revoked == null && !IsExpired;
        public bool IsActive { get; set; }

        //public bool IsUsed { get; set; }
    }
}
