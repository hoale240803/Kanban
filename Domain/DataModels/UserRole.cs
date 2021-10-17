using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class UserRole
    {
        public string IdUser { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
