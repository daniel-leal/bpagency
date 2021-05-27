using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BPAgency.Domain.Utils;
using NetTopologySuite.Geometries;

namespace BPAgency.Domain.Entities
{
    public class Agency : Entity
    {
        public Agency(string name,
                      string serviceStartTime,
                      string serviceEndTime,
                      string selfServiceStartTime,
                      string selfServiceEndTime,
                      Point location,
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
            Location = location;
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

        public string Code { get; private set; }

        public string ServiceStartTime { get; private set; }

        public string ServiceEndTime { get; private set; }

        public string SelfServiceStartTime { get; private set; }

        public string SelfServiceEndTime { get; private set; }

        [JsonIgnore]
        public Point Location { get; private set; }

        public double Latitude => Location.Coordinate.X;

        public double Longitude => Location.Coordinate.Y;

        public double DistanceInKm => CalcDistanceInKm(-1.4398515, -48.490871);

        public string Phone { get; private set; }

        public string Phone2 { get; private set; }

        public string Phone3 { get; private set; }

        public string Address { get; private set; }

        public string Cep { get; private set; }

        public string District { get; private set; }

        public string City { get; private set; }

        public bool IsStation { get; private set; } // Posto de Atendimento?

        public bool IsCapital { get; private set; } // Agencia ou Posto da Capital?

        /// <summary>This method calculates the distance in KM between you 
        /// and another geographic point (Agency).
        /// <example>For example:
        /// <code>
        ///    var senadorLemos = new Point(-122.333056, 47.609722) { SRID = 4326 };
        ///    
        ///    var yourDistanceFromSLemosInKm = CalcDisntaceInKm(
        ///         senadorLemos.CoordinateX,
        ///         senadorLemos.CoodinateY
        ///     );
        /// </code>
        /// results in <c>yourDistanceFromSeattleInKm</c>.
        /// </example>
        /// </summary>
        /// <param name="lat">the new x-coordinate (Latitude).</param>
        /// <param name="lon">the new y-coordinate (Longitude).</param>
        private double CalcDistanceInKm(double lat, double lon)
        {
            /* 
            * SRID 4326 refers to WGS 84, a pattern used in GPS and 
            * other grographic systems
            */
            var pt = new Point(lat, lon) { SRID = 4326 };

            /* 
            * In order to get the distance in meters, we need to project to an 
            * appropriate coordinate system. In this case, we're using SRID 2855 
            * since it covers the geographic area of our data 
            */
            var distanceInKm = Math.Round(
                Location
                .ProjectTo(2855)
                .Distance(pt.ProjectTo(2855)) / 1000.0,
                2);

            return distanceInKm;
        }
    }
}