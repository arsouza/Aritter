using System;

namespace Aritter.Infra.Crosscutting
{
    public sealed class AmbientValueAttribute : Attribute
    {

        private readonly object value;

        public AmbientValueAttribute(Type type, string value)
        {
            this.value = value;
        }
        public AmbientValueAttribute(char value)
        {
            this.value = value;
        }

        public AmbientValueAttribute(byte value)
        {
            this.value = value;
        }

        public AmbientValueAttribute(short value)
        {
            this.value = value;
        }

        public AmbientValueAttribute(int value)
        {
            this.value = value;
        }

        public AmbientValueAttribute(long value)
        {
            this.value = value;
        }

        public AmbientValueAttribute(float value)
        {
            this.value = value;
        }

        public AmbientValueAttribute(double value)
        {
            this.value = value;
        }

        public AmbientValueAttribute(bool value)
        {
            this.value = value;
        }
        public AmbientValueAttribute(string value)
        {
            this.value = value;
        }

        public AmbientValueAttribute(object value)
        {
            this.value = value;
        }

        public object Value
        {
            get
            {
                return value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            AmbientValueAttribute other = obj as AmbientValueAttribute;

            if (other != null)
            {
                if (value != null)
                {
                    return value.Equals(other.Value);
                }
                else
                {
                    return (other.Value == null);
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
