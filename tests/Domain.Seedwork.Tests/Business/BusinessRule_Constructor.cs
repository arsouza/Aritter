using System;
using FluentAssertions;
using Ritter.Domain.Business;
using Ritter.Infra.Crosscutting.Specifications;
using Xunit;

namespace Domain.Seedwork.Tests.Business
{
    public class BusinessRule_Constructor
    {
        [Fact]
        public void ConstructRuleSuccessfully()
        {
            Func<TestBusinessRule> func = () =>
            {
                return new TestBusinessRule(new TrueSpecification<TestEntity>(), (testEntity) => { });
            };

            func.Should().NotThrow();

            func.Invoke()
                .Should().NotBeNull()
                .And.BeOfType<TestBusinessRule>();
        }

        [Fact]
        public void ConstructRuleThrowExceptionForMissingRule()
        {
            Func<TestBusinessRule> func = () =>
            {
                return new TestBusinessRule(null, (testEntity) => { });
            };

            func.Should().Throw<ArgumentNullException>()
                .WithMessage($"Please provide a valid non null rule delegate instance. (Parameter 'rule')")
                .And.ParamName.Should().Be("rule");
        }

        [Fact]
        public void ConstructRuleThrowExceptionForMissingAction()
        {
            Func<TestBusinessRule> func = () =>
            {
                return new TestBusinessRule(new TrueSpecification<TestEntity>(), null);
            };

            func.Should().Throw<ArgumentNullException>()
                .WithMessage($"Please provide a valid non null action delegate instance. (Parameter 'action')")
                .And.ParamName.Should().Be("action");
        }

        internal class TestEntity
        {
        }

        internal class TestBusinessRule : BusinessRule<TestEntity>
        {
            public TestBusinessRule(ISpecification<TestEntity> rule, Action<TestEntity> action) : base(rule, action)
            {
            }
        }
    }
}
