using System;

namespace ITAssetManagement.BusinessLogic
{
    public class Router : Asset
    {
        public bool   HasDefaultCredentials { get; set; }
        public bool   HasFirewallEnabled    { get; set; }
        public string FirmwareVersion       { get; set; }

        public Router(string makeModel, string osVersion, string ipAddress,
                      string macAddress, bool hasDefaultCredentials,
                      bool hasFirewallEnabled, string firmwareVersion)
            : base(makeModel, osVersion, ipAddress, macAddress)
        {
            AssetType             = "Router";
            HasDefaultCredentials = hasDefaultCredentials;
            HasFirewallEnabled    = hasFirewallEnabled;
            FirmwareVersion       = string.IsNullOrWhiteSpace(firmwareVersion) ? "Unknown" : firmwareVersion;
        }

        public override string CalculateSecurityStatus()
        {
            if (HasDefaultCredentials && !HasFirewallEnabled)
                return "[CRITICAL] Default credentials AND firewall disabled. Network completely exposed!";

            if (HasDefaultCredentials)
                return "[HIGH] Default credentials still set. Change admin password immediately!";

            if (!HasFirewallEnabled)
                return "[MEDIUM] Firewall is disabled. Network perimeter at risk.";

            if (FirmwareVersion == "Unknown")
                return "[LOW] Firmware version untracked. Schedule a firmware audit.";

            return "[SECURE] No default creds, firewall active, firmware tracked. No issues.";
        }
    }
}
