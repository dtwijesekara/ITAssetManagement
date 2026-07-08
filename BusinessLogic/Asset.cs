using System;

namespace ITAssetManagement.BusinessLogic
{
    public abstract class Asset
    {
        private string _ipAddress;
        private string _macAddress;

        public int    AssetID    { get; set; }
        public string AssetType  { get; protected set; }
        public string MakeModel  { get; set; }
        public string OS_Version { get; set; }
        public int?   AssignedTo { get; set; }

        public string IPAddress
        {
            get { return _ipAddress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("IP Address cannot be null or empty.");
                _ipAddress = value.Trim();
            }
        }

        public string MACAddress
        {
            get { return _macAddress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("MAC Address cannot be null or empty.");
                _macAddress = value.Trim().ToUpperInvariant();
            }
        }

        protected Asset(string makeModel, string osVersion, string ipAddress, string macAddress)
        {
            MakeModel  = makeModel  ?? throw new ArgumentNullException(nameof(makeModel));
            OS_Version = osVersion  ?? throw new ArgumentNullException(nameof(osVersion));
            IPAddress  = ipAddress;
            MACAddress = macAddress;
        }

        public virtual string CalculateSecurityStatus()
        {
            return $"[BASE] Asset '{MakeModel}' running '{OS_Version}' — Perform manual audit.";
        }

        public override string ToString()
        {
            return $"[{AssetType}] {MakeModel} | OS: {OS_Version} | IP: {_ipAddress}";
        }
    }
}
