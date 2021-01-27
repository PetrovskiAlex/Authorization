using System;

namespace Authorization.EntityFramework
{
    public class Tariff
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}