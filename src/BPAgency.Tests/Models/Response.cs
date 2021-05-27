using System.Text.Json.Serialization;

namespace BPAgency.Tests.Models
{
    public class Response
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("serviceStartTime")]
        public string ServiceStartTime { get; set; }

        [JsonPropertyName("serviceEndTime")]
        public string ServiceEndTime { get; set; }

        [JsonPropertyName("selfServiceStartTime")]
        public string SelfServiceStartTime { get; set; }

        [JsonPropertyName("selfServiceEndTime")]
        public string SelfServiceEndTime { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("phone2")]
        public string Phone2 { get; set; }

        [JsonPropertyName("phone3")]
        public string Phone3 { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("isStation")]
        public bool IsStation { get; set; }

        [JsonPropertyName("isCapital")]
        public bool IsCapital { get; set; }

        [JsonPropertyName("isOpen")]
        public bool IsOpen { get; set; }

        [JsonPropertyName("distanceInKm")]
        public double DistanceInKm { get; set; }
    }
}