using System.Configuration;

namespace FitnessTracker.SecurityContext
{
    public class SecurityConfigurationSection : ConfigurationSection
    {
        private const string SectionName = "securityConfiguration";
        private const string ConstantSaltKey = "constantSalt";
        private const string GeneratedPasswordLengthKey = "generatedPasswordLength";
        private const string AllowedPasswordCharactersKey = "allowedPasswordCharacters";
        private const string ConstantInitializationVectorKey = "constantInitializationVector";
        private const string ConstantSaltLength = "constantSaltLength";
        public static SecurityConfigurationSection Instance;

        static SecurityConfigurationSection()
        {
            Instance = ConfigurationManager.GetSection(SectionName) as SecurityConfigurationSection;
        }

        [ConfigurationProperty(ConstantSaltLength, IsRequired = true, DefaultValue = 512)]
        public int SaltLength
        {
            get
            {
                return (int)this[ConstantSaltLength];
            }
        }

        [ConfigurationProperty(ConstantSaltKey, IsRequired = true)]
        public string ConstantSalt
        {
            get
            {
                return (string)this[ConstantSaltKey];
            }
        }

        [ConfigurationProperty(ConstantInitializationVectorKey, IsRequired = true)]
        public string ConstantInitializationVector
        {
            get
            {
                return (string)this[ConstantInitializationVectorKey];
            }
        }

        [ConfigurationProperty(GeneratedPasswordLengthKey, IsRequired = true, DefaultValue = 8)]
        public int GeneratedPasswordLength
        {
            get { return (int)this[GeneratedPasswordLengthKey]; }
        }

        [ConfigurationProperty(AllowedPasswordCharactersKey, IsRequired = true)]
        public string AllowedPasswordCharacters
        {
            get { return (string)this[AllowedPasswordCharactersKey]; }
        }
    }
}
