using System.Linq.Expressions;
using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aritter.Infra.Crosscutting.Tests.Mock;
using System;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
{
    [TestClass]
    public class ExpressionTest
    {
        [TestMethod]
        public void GetPropertyNameMustReturnNull()
        {
            Expression expression = null;

            string propertyName = expression.PropertyName();
            Assert.IsNull(propertyName);
        }

        [TestMethod]
        public void GetMemberExpressionPropertyNameSuccessfully()
        {
            TestComplexObject1 object1 = new TestComplexObject1
            {
                Id = 1,
                TestComplexObject2Id = 1,
                TestComplexObject2 = new TestComplexObject2
                {
                    Id = 1
                }
            };

            ParameterExpression param = Expression.Parameter(typeof(TestComplexObject1), string.Empty); // I don't care about some naming

            MemberExpression property = Expression.PropertyOrField(param, "Id");
            Assert.IsNotNull(property);

            string propertyName = property.PropertyName();

            Assert.IsNotNull(propertyName);
            Assert.AreEqual("Id", propertyName);
        }

        [TestMethod]
        public void GetMemberExpressionPropertyMustThrowsException()
        {
            TestComplexObject1 object1 = new TestComplexObject1
            {
                Id = 1,
                TestComplexObject2Id = 1,
                TestComplexObject2 = new TestComplexObject2
                {
                    Id = 1
                }
            };

            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                ParameterExpression param = Expression.Parameter(typeof(TestComplexObject1), string.Empty); // I don't care about some naming
                MemberExpression property = Expression.PropertyOrField(param, "Name");
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual("propertyOrFieldName", exception.ParamName);
            Assert.IsTrue(exception.Message.Contains($"'Name' is not a member of type '{typeof(TestComplexObject1).FullName}'"));
        }

        [TestMethod]
        public void GetLambdaExpressionPropertyNameSuccessfully()
        {
            TestComplexObject1 object1 = new TestComplexObject1
            {
                Id = 1,
                TestComplexObject2Id = 1,
                TestComplexObject2 = new TestComplexObject2
                {
                    Id = 1
                }
            };

            ParameterExpression param = Expression.Parameter(typeof(TestComplexObject1), string.Empty); // I don't care about some naming

            MemberExpression property = Expression.PropertyOrField(param, "Id");
            Assert.IsNotNull(property);

            LambdaExpression lambda = Expression.Lambda(property, param);
            Assert.IsNotNull(lambda);

            string propertyName = lambda.PropertyName();

            Assert.IsNotNull(propertyName);
            Assert.AreEqual("Id", propertyName);
        }
    }
}