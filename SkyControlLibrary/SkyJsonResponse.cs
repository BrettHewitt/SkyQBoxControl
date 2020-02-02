using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SkyControlLibrary
{
    public class SkyJsonResponse
    {
        [JsonProperty("ASVersion")]
        public string AsVersion { get; set; }

        [JsonProperty("DRMActivationStatus")]
        public bool DrmActivationStatus { get; set; }

        [JsonProperty("IPAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("MACAddress")]
        public string MacAddress { get; set; }

        [JsonProperty("activeStandby")]
        public bool ActiveStandby { get; set; }

        [JsonProperty("airplayID")]
        public string AirplayId { get; set; }

        [JsonProperty("btID")]
        public string BtId { get; set; }

        [JsonProperty("cable")]
        public bool Cable { get; set; }

        [JsonProperty("deviceID")]
        public string DeviceId { get; set; }

        [JsonProperty("estVersion")]
        public string EstVersion { get; set; }

        [JsonProperty("gateway")]
        public bool Gateway { get; set; }

        [JsonProperty("gatewayIPAddress")]
        public string GatewayIpAddress { get; set; }

        [JsonProperty("hardwareName")]
        public string HardwareName { get; set; }

        [JsonProperty("hdrCapable")]
        public bool HdrCapable { get; set; }

        [JsonProperty("householdToken")]
        public string HouseholdToken { get; set; }

        [JsonProperty("localIRDatabase")]
        public bool LocalIrDatabase { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("meshEnabled")]
        public bool MeshEnabled { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("networkVersion")]
        public string NetworkVersion { get; set; }

        [JsonProperty("numDTTTuners")]
        public long NumDttTuners { get; set; }

        [JsonProperty("pipCapable")]
        public bool PipCapable { get; set; }

        [JsonProperty("purchasebalance")]
        public string Purchasebalance { get; set; }

        [JsonProperty("purchaselimit")]
        public string Purchaselimit { get; set; }

        [JsonProperty("receiverID")]
        public string ReceiverId { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("systemUptime")]
        public long SystemUptime { get; set; }

        [JsonProperty("uhdCapable")]
        public bool UhdCapable { get; set; }

        [JsonProperty("versionNumber")]
        public string VersionNumber { get; set; }

        [JsonProperty("vespaID")]
        public string VespaId { get; set; }

        [JsonProperty("viewingCardNumber")]
        public string ViewingCardNumber { get; set; }

        [JsonProperty("wakeReason")]
        public string WakeReason { get; set; }
    }
}
