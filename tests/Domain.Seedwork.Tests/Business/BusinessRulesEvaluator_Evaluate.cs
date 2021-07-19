using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FluentAssertions;
using Ritter.Domain.Business;
using Ritter.Infra.Crosscutting.Specifications;
using Xunit;

namespace Domain.Seedwork.Tests.Business
{
    public class BusinessRulesEvaluator_Evaluate
    {
        public static IEnumerable<object[]> ThrowsArgumentNullExceptionEvaluatingOneRulesTestData()
        {
            yield return new object[] { null, "DefaultRule", "entity", "Cannot evaluate a business rule set against a null reference. (Parameter 'entity')" };
            yield return new object[] { new TestEntity(), "", "ruleName", "Rule name is required. (Parameter 'ruleName')" };
            yield return new object[] { new TestEntity(), null, "ruleName", "Rule name is required. (Parameter 'ruleName')" };
        }

        public static IEnumerable<object[]> EvaluateARuleSuccessfullyTestData()
        {
            yield return new object[] { null, "DefaultRule", "entity", "Cannot evaluate a business rule set against a null reference. (Parameter 'entity')" };
            yield return new object[] { new TestEntity(), "", "ruleName", "Rule name is required. (Parameter 'ruleName')" };
            yield return new object[] { new TestEntity(), null, "ruleName", "Rule name is required. (Parameter 'ruleName')" };
        }

        [Fact]
        public void ThrowsArgumentNullExceptionEvaluatingAllRules()
        {
            Action func = () =>
            {
                var evaluator = new TestRuleEvaluator();
                evaluator.Evaluate(null);
            };

            func.Should().Throw<ArgumentException>()
                .WithMessage("Cannot evaluate rules against a null reference. Expected a valid non-null entity instance. (Parameter 'entity')")
                .And.ParamName.Should().Be("entity");
        }

        [Theory]
        [MemberData(nameof(ThrowsArgumentNullExceptionEvaluatingOneRulesTestData))]
        public void ThrowsArgumentNullExceptionEvaluatingOneRules(TestEntity entity, string ruleName, string paramName, string expected)
        {
            Action func = () =>
            {
                var evaluator = new TestRuleEvaluator();
                evaluator.Evaluate(entity, ruleName);
            };

            func.Should().Throw<ArgumentException>()
                .WithMessage(expected)
                .And.ParamName.Should().Be(paramName);
        }

        [Fact]
        public void EvaluateAllRulesSuccessfully()
        {
            var entity = new TestEntity();

            entity.DefaultRule.Should().BeFalse();
            entity.Rule1.Should().BeFalse();

            var evaluator = new TestRuleEvaluator();
            evaluator.AddRule("Rule", new TestBusinessRule(e => e.Rule1 = true));

            evaluator.Evaluate(entity);

            entity.Should().NotBeNull();
            entity.DefaultRule.Should().BeTrue();
            entity.Rule1.Should().BeTrue();
        }

        [Fact]
        public void EvaluateDefaultRuleSuccessfully()
        {
            var entity = new TestEntity();

            entity.DefaultRule.Should().BeFalse();
            entity.Rule1.Should().BeFalse();

            var evaluator = new TestRuleEvaluator();
            evaluator.AddRule("Rule", new TestBusinessRule(e => e.Rule1 = true));

            evaluator.Evaluate(entity, "DefaultRule");

            entity.Should().NotBeNull();
            entity.DefaultRule.Should().BeTrue();
            entity.Rule1.Should().BeFalse();
        }

        [Fact]
        public void EvaluateRuleSuccessfully()
        {
            var entity = new TestEntity();

            entity.DefaultRule.Should().BeFalse();
            entity.Rule1.Should().BeFalse();

            var evaluator = new TestRuleEvaluator();
            evaluator.AddRule("Rule", new TestBusinessRule(e => e.Rule1 = true));

            evaluator.Evaluate(entity, "Rule");

            entity.Should().NotBeNull();
            entity.DefaultRule.Should().BeFalse();
            entity.Rule1.Should().BeTrue();
        }

        public class TestEntity
        {
            public bool DefaultRule { get; internal set; }
            public bool Rule1 { get; internal set; }
        }

        public class TestBusinessRule : BusinessRule<TestEntity>
        {
            public TestBusinessRule(Action<TestEntity> action) : base(new TrueSpecification<TestEntity>(), action)
            {
            }
        }

        public class TestRuleEvaluator : BusinessRulesEvaluator<TestEntity>
        {
            public IEnumerable<string> RuleNames => rules.Keys.Select(k => k);

            public TestRuleEvaluator()
            {
                AddRule("DefaultRule", new TestBusinessRule(e => e.DefaultRule = true));
            }

            public new void AddRule(string name, IBusinessRule<TestEntity> rule) => base.AddRule(name, rule);
        }
    }
}
