using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlubApp.Entities.DTOs
{
    public class NewAircraftDTO
    {
        [Required(ErrorMessage = "El campo Matrícula es requerido.")]
        [MinLength(6, ErrorMessage = "La matrícula debe tener 6 caracteres.")]
        [MaxLength(6, ErrorMessage = "La matrícula debe tener 6 caracteres.")]
        public string Plate { get; set; } = string.Empty;

        [Required(ErrorMessage = "No se ha seleccionado un tipo de aeronave.")]
        public int AircraftType { get; set; }
        public int isFlying { get; set; } = 0;
    }
}
