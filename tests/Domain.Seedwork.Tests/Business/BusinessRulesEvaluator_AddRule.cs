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
    public class BusinessRulesEvaluator_AddRule
    {
        public static IEnumerable<object[]> ThrowsArgumentNullExceptionTestData()
        {
            yield return new object[] { "", new TestBusinessRule(), "ruleName", "Cannot add a rule with an empty or null rule name. (Parameter 'ruleName')" };
            yield return new object[] { null, new TestBusinessRule(), "ruleName", "Cannot add a rule with an empty or null rule name. (Parameter 'ruleName')" };
            yield return new object[] { "DefaultRule", new TestBusinessRule(), null, "Another rule with the same name already exists. Cannot add duplicate rules." };
            yield return new object[] { "Rule1", null, "rule", "Cannot add a null rule instance. Expected a non null reference. (Parameter 'rule')" };
        }

        [Theory]
        [MemberData(nameof(ThrowsArgumentNullExceptionTestData))]
        public void ThrowsArgumentNullException(string ruleName, IBusinessRule<TestEntity> rule, string paramName, string expected)
        {
            Action func = () =>
            {
                var evaluator = new TestRuleEvaluator();
                evaluator.AddRule("DefaultRule", new TestBusinessRule());
                evaluator.AddRule(ruleName, rule);
            };

            func.Should().Throw<ArgumentException>()
                .WithMessage(expected)
                .And.ParamName.Should().Be(paramName);
        }

        [Fact]
        public void AddRuleSuccessfully()
        {
            Func<TestRuleEvaluator> func = () =>
            {
                var evaluator = new TestRuleEvaluator();

                evaluator.AddRule("DefaultRule", new TestBusinessRule());
                evaluator.AddRule("Rule1", new TestBusinessRule());

                return evaluator;
            };

            func.Should().NotThrow();

            TestRuleEvaluator evaluator = func.Invoke();
            evaluator.Should().NotBeNull();
            evaluator.RuleNames
                .Should().HaveCount(2)
                .And.Contain("DefaultRule", "Rule1");
        }

        public class TestEntity
        {
            public bool Evaluated { get; internal set; }
        }

        public class TestBusinessRule : BusinessRule<TestEntity>
        {
            public TestBusinessRule() : base(new TrueSpecification<TestEntity>(), (e) => { })
            {
            }
        }

        public class TestRuleEvaluator : BusinessRulesEvaluator<TestEntity>
        {
            public IEnumerable<string> RuleNames => rules.Keys.Select(k => k);

            public TestRuleEvaluator()
            {
            }

            public new void AddRule(string name, IBusinessRule<TestEntity> rule) => base.AddRule(name, rule);
        }
    }
}
