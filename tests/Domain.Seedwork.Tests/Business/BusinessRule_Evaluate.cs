using System;
using FluentAssertions;
using Ritter.Domain.Business;
using Ritter.Infra.Crosscutting.Specifications;
using Xunit;

namespace Domain.Seedwork.Tests.Business
{
    public class BusinessRule_Evaluate
    {
        [Fact]
        public void EvaluateThrowExceptionForNullEntity()
        {
            Action func = () =>
            {
                var rule = new TestBusinessRule(new TrueSpecification<TestEntity>(), (testEntity) => { });
                rule.Evaluate(null);
            };

            func.Should().Throw<ArgumentNullException>()
                .WithMessage($"Cannot evaulate a business rule against a null reference. (Parameter 'entity')")
                .And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void EvaluateRuleWhenSpecificationIsSatisfied()
        {
            var entity = new TestEntity();
            var rule = new TestBusinessRule(new TrueSpecification<TestEntity>(), e => { e.Evaluated = true; });

            entity.Evaluated.Should().BeFalse();

            rule.Evaluate(entity);

            entity.Should().NotBeNull();
            entity.Evaluated.Should().BeTrue();
        }

        [Fact]
        public void DontEvaluateRuleWhenSpecificationIsNotSatisfied()
        {
            var entity = new TestEntity();
            var rule = new TestBusinessRule(!(new TrueSpecification<TestEntity>()), e => { e.Evaluated = true; });

            entity.Evaluated.Should().BeFalse();

            rule.Evaluate(entity);

            entity.Should().NotBeNull();
            entity.Evaluated.Should().BeFalse();
        }

        internal class TestEntity
        {
            public bool Evaluated { get; internal set; }
        }

        internal class TestBusinessRule : BusinessRule<TestEntity>
        {
            public TestBusinessRule(ISpecification<TestEntity> rule, Action<TestEntity> action) : base(rule, action)
            {
            }
        }
    }
}
