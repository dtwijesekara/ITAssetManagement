using System;

namespace ITAssetManagement.BusinessLogic
{
    public class Laptop : Asset
    {
        public bool HasEncryptedDisk { get; set; }
        public bool IsCorpManaged    { get; set; }

        public Laptop(string makeModel, string osVersion, string ipAddress,
                      string macAddress, bool hasEncryptedDisk, bool isCorpManaged)
            : base(makeModel, osVersion, ipAddress, macAddress)
        {
            AssetType        = "Laptop";
            HasEncryptedDisk = hasEncryptedDisk;
            IsCorpManaged    = isCorpManaged;
        }

        public override string CalculateSecurityStatus()
        {
            string[] deprecatedOS = { "Windows 7", "Windows XP", "Windows 10 1507", "Windows Server 2008" };
            bool isDeprecated = Array.Exists(deprecatedOS,
                os => OS_Version.IndexOf(os, StringComparison.OrdinalIgnoreCase) >= 0);

            if (isDeprecated)
                return $"[CRITICAL] Deprecated OS '{OS_Version}' detected. Immediate replacement required!";

            if (!HasEncryptedDisk && !IsCorpManaged)
                return "[HIGH] Unencrypted disk AND not corp-managed. High-risk endpoint.";

            if (!HasEncryptedDisk)
                return "[MEDIUM] Disk not encrypted. Vulnerable to physical data theft.";

            if (!IsCorpManaged)
                return "[LOW] Not enrolled in MDM. Patch compliance unknown.";

            return "[SECURE] Encrypted + managed + current OS. No issues detected.";
        }
    }
}
