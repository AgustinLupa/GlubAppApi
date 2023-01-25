using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlubApp.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Plate { get; set; } = string.Empty;
        public int AircraftType { get; set; }
        public bool IsFlying { get; set; }
    }
}
