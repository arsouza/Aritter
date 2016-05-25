using Aritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Seedwork.Validation
{
    public class DomainEntityValidator : IEntityValidator
    {
        #region Private Members

        private string ApplyRule<TEntity>(TEntity item, Rule<TEntity> rule)
            where TEntity : class, IValidatableEntity
        {
            if (!rule.Validate(() => item))
            {
                return rule.InvalidMessage;
            }

            return null;
        }

        private IEnumerable<string> Validate<TEntity>(TEntity item)
            where TEntity : class, IValidatableEntity
        {
            var result = new List<string>();

            foreach (var feature in item.Features.Values)
            {
                result.AddRange(Validate(item, feature.Rules));
            }

            return result;
        }

        private IEnumerable<string> Validate<TEntity>(TEntity item, IEnumerable<Rule<TEntity>> rules)
            where TEntity : class, IValidatableEntity
        {
            foreach (Rule<TEntity> rule in rules)
            {
                yield return ApplyRule(item, rule);
            }
        }

        #endregion

        #region IEntityValidator Members

        public bool IsValid<TEntity>(TEntity item)
            where TEntity : class, IValidatableEntity
        {
            return IsValid(item, null);
        }

        public bool IsValid<TEntity>(TEntity item, Feature<TEntity> feature)
            where TEntity : class, IValidatableEntity
        {
            var validationResult = GetValidationResult(item, feature);
            return validationResult.Any();
        }

        public IEnumerable<string> GetValidationResult<TEntity>(TEntity item)
            where TEntity : class, IValidatableEntity
        {
            return GetValidationResult(item, null);
        }

        public IEnumerable<string> GetValidationResult<TEntity>(TEntity item, Feature<TEntity> feature)
            where TEntity : class, IValidatableEntity
        {
            if (item == null)
            {
                return Array.Empty<string>();
            }

            item.ConfigureFeatures();

            if (feature != null)
            {
                return Validate(item, feature.Rules);
            }

            return Validate(item, null);
        }

        #endregion
    }
}
