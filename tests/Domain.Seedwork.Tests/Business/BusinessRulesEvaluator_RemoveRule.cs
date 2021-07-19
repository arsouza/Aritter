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
    public class BusinessRulesEvaluator_RemoveRule
    {
        public static IEnumerable<object[]> ThrowsArgumentNullExceptionTestData()
        {
            yield return new object[] { "", "ruleName", "Expected a non empty and non-null rule name. (Parameter 'ruleName')" };
            yield return new object[] { null, "ruleName", "Expected a non empty and non-null rule name. (Parameter 'ruleName')" };
        }

        [Theory]
        [MemberData(nameof(ThrowsArgumentNullExceptionTestData))]
        public void ThrowsArgumentNullException(string ruleName, string paramName, string expected)
        {
            Action func = () =>
            {
                var evaluator = new TestRuleEvaluator();
                evaluator.RemoveRule(ruleName);
            };

            func.Should().Throw<ArgumentException>()
                .WithMessage(expected)
                .And.ParamName.Should().Be(paramName);
        }

        [Fact]
        public void RemoveRuleSuccessfully()
        {
            Func<TestRuleEvaluator> func = () => new TestRuleEvaluator();

            func.Should().NotThrow();

            TestRuleEvaluator evaluator = func.Invoke();
            evaluator.Should().NotBeNull();
            evaluator.RuleNames.Should().HaveCount(1).And.Contain("DefaultRule");

            evaluator.RemoveRule("DefaultRule");
            evaluator.RuleNames.Should().HaveCount(0);
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
                AddRule("DefaultRule", new TestBusinessRule());
            }

            public new void RemoveRule(string name) => base.RemoveRule(name);
        }
    }
}
