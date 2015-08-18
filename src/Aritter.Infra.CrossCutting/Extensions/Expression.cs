using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aritter.Infra.CrossCutting.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static string PropertyName(this Expression exp)
		{
			if (exp is MemberExpression)
				return ((MemberExpression)exp).Member.Name;
			if (exp is UnaryExpression)
				return ((UnaryExpression)exp).Operand.ToString().GetPropertyName();
			if (exp is ConstantExpression)
				return ((ConstantExpression)exp).Value.ToString();
			if (exp is MethodCallExpression)
				return ((MethodCallExpression)exp).Arguments[0].ToString().GetPropertyName();
			if (exp is LambdaExpression)
				return (exp as LambdaExpression).Body.PropertyName();
			throw new ArgumentException("Parameter 'exp' is not of the expected type.");
		}

		public static string[] PropertyNames(this Expression expression)
		{
			var result = new List<string>(3);

			if (expression is UnaryExpression)
				expression = ((UnaryExpression)expression).Operand;

			while (expression is MemberExpression)
			{
				var propExpression = (MemberExpression)expression;
				if (propExpression.NodeType == ExpressionType.MemberAccess)
					result.Add(propExpression.Member.Name);
				expression = propExpression.Expression;
			}

			result.Reverse();
			return result.ToArray();
		}

		private static string GetPropertyName(this string body)
		{
			return string.IsNullOrEmpty(body) ? string.Empty : body.Substring(body.IndexOf('.') + 1);
		}

		#endregion Methods
	}
}