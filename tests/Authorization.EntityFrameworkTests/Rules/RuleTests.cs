using System;
using System.Linq;
using System.Linq.Expressions;
using Authorization.EntityFramework;
using Authorization.Tests.Profiles;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Authorization.Tests.Rules
{
    public class RuleTests
    {
        [Test]
        public void ApplyQueryableRuleTest()
        {
            using var dbContext = GetDbContext();
            var ruleExpression = new TariffAuthRuleExpression();

            var userId = Guid.NewGuid();
            
            var context = new AuthContext
            {
                UserId = userId
            };

            Expression<Func<Tariff, bool>> expression = tariff =>
                (context.CompanyId.HasValue && tariff.CompanyId == context.CompanyId) ||
                tariff.UserId == context.UserId;

            var qs1 = dbContext.Tariffs!.Where(ruleExpression.Apply(context)).ToQueryString();
            var qs2 = dbContext.Tariffs!.Where(expression).ToQueryString();

            qs1.Should().Be(qs2);
        }

        [Test]
        public void ApplyMemoryRuleTest()
        {
            var userId = Guid.NewGuid();
            
            var ruleExpression = new TariffAuthRuleExpression();
            var context = new AuthContext
            {
                UserId = userId
            };

            var tariff = new Tariff
            {
                UserId = userId
            };

            var result = ruleExpression.Apply(context).Compile()(tariff);

            result.Should().BeTrue();
        }

        private static AppDbContext GetDbContext()
        {
            var contextOptions = new DbContextOptionsBuilder().UseNpgsql("Server=localhost;Port=5432;Database=empty;User Id=tos;Password=empty").Options;

            var dbContext = new AppDbContext(contextOptions);
            return dbContext;
        }
    }
}