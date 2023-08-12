using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlubApp.Entities
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Plate { get; set; } = string.Empty;
        public int AircraftType { get; set; }
        public bool IsFlying { get; set; }
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;
    }
}
