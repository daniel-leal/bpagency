namespace BPAgency.Domain.Entities
{
    public class Agency : Entity
    {
        public Agency(string name,
                      string serviceStartTime,
                      string serviceEndTime,
                      string selfServiceStartTime,
                      string selfServiceEndTime,
                      decimal latitude,
                      decimal longitude,
                      string phone,
                      string phone2,
                      string phone3,
                      string address,
                      string cep,
                      string district,
                      string city,
                      bool isStation,
                      bool isCapital)
        {
            Name = name;
            ServiceStartTime = serviceStartTime;
            ServiceEndTime = serviceEndTime;
            SelfServiceStartTime = selfServiceStartTime;
            SelfServiceEndTime = selfServiceEndTime;
            Latitude = latitude;
            Longitude = longitude;
            Phone = phone;
            Phone2 = phone2;
            Phone3 = phone3;
            Address = address;
            Cep = cep;
            District = district;
            City = city;
            IsStation = isStation;
            IsCapital = isCapital;
        }

        public string Name { get; private set; }

        public string ServiceStartTime { get; private set; }

        public string ServiceEndTime { get; private set; }

        public string SelfServiceStartTime { get; private set; }

        public string SelfServiceEndTime { get; private set; }

        public decimal Latitude { get; private set; }

        public decimal Longitude { get; private set; }

        public string Phone { get; private set; }

        public string Phone2 { get; private set; }

        public string Phone3 { get; private set; }

        public string Address { get; private set; }

        public string Cep { get; private set; }

        public string District { get; private set; }

        public string City { get; private set; }

        public bool IsStation { get; private set; } // Posto de Atendimento?

        public bool IsCapital { get; private set; } // Agencia ou Posto da Capital?
    }
}