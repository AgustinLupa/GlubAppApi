using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlubApp.Entities.DTOs
{
    public class AircraftDTO
    {
        [Required]
        [MinLength(6, ErrorMessage = "Plate has to be 6 characters long.")]
        [MaxLength(6, ErrorMessage = "Plate has to be 6 characters long.")]
        public string Plate { get; set; } =string.Empty;

        [Required]
        public int AircraftType { get; set; }
        public int IsFlying { get; set; }
    }
}
