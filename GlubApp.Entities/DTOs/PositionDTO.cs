using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlubApp.Entities.DTOs
{
    public class PositionDTO
    {
        [Required(ErrorMessage = "La matricula es requerida para actualizar la geolocalizacion.")]
        public string Plate { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
