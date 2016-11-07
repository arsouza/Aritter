using System;

namespace Aritter.Infra.Crosscutting
{
    public sealed class DescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            DescriptionAttribute other = obj as DescriptionAttribute;

            return (other != null) && other.Description == Description;
        }

        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }
    }
}
