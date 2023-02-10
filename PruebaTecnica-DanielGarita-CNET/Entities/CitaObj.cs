using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnica_DanielGarita_CNET.Entities
{
    public class CitaObj
    {
        public int idCita { get; set; }
        [Required(ErrorMessage = "El paciente es requerido")]
        public int idPaciente { get; set; }
        public string nombrePaciente { get; set; }

        [Required(ErrorMessage = "El doctor es requerido")]
        public int idDoctor { get; set; }
        public string nombreDoctor { get; set; }

        [Required(ErrorMessage = "El tratamiento es requerido")]
        public int idTratamiento { get; set; }
        public string nombreTratamiento { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime fecha { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string descripcion { get; set; }
        [Required(ErrorMessage = "El monto es requirido")]
        public decimal monto { get; set; }
        public decimal montoTotalCitas { get; set; }
    }
}