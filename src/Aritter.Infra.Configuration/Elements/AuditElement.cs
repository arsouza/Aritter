using System.Configuration;

namespace Aritter.Infra.Configuration
{
    public sealed class AuditElement : ConfigurationElement
    {
        #region Properties

        [ConfigurationProperty("enabled", DefaultValue = false, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }

        #endregion Properties
    }
}