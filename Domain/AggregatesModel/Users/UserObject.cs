using Domain.SeedWork;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.AggregatesModel.Users
{
    public class UserObject : IdentityUser, IAggregateRoot
    {
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}