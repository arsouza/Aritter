using System;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class CustomRule<TEntity> : ValidationRule<TEntity>
        where TEntity : class
    {
        private readonly Func<TEntity, bool> validateFunc;

        public CustomRule(Func<TEntity, bool> validateFunc)
            : this(validateFunc, null)
        {
        }

        public CustomRule(Func<TEntity, bool> validateFunc, string message)
           : base(message)
        {
            this.validateFunc = validateFunc ?? throw new ArgumentNullException(nameof(validateFunc)); ;
        }

        public override bool Validate(TEntity entity)
        {
            return validateFunc(entity);
        }
    }
}
