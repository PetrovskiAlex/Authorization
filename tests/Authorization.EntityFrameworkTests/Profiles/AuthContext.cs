using System;

namespace Authorization.Tests.Profiles
{
    public class AuthContext
    {
        public Guid UserId { get; set; }
        public Guid? CompanyId { get; set; }
    }
}