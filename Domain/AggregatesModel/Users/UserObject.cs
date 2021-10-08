using Domain.SeedWork;
using System.Collections.Generic;

namespace Domain.Users
{
    public class UserObject : Entity, IAggregateRoot
    {
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}