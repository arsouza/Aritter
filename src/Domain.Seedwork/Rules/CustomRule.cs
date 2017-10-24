using System;

namespace Ritter.Domain.Seedwork.Rules
{
    public class CustomRule<TEntity> : ValidationRule<TEntity>
        where TEntity : class
    {
        protected Func<TEntity, bool> validateFunc;

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
