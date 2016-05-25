using System;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public abstract class Rule<T>
    {
        public virtual string Name { get; protected set; }

        public virtual string InvalidMessage { get; set; }

        public abstract bool Validate(Func<T> source);

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? base.ToString() : Name;
        }
    }
}
