using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanAPI.Dtos.User
{
    public class GetUserProfileResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
