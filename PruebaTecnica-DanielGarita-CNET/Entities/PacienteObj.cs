using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnica_DanielGarita_CNET.Entities
{
    public class PacienteObj
    {
        public int idPaciente { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        public string apellido { get; set; }
        public string nombreCompleto { get; set; }
        [Required(ErrorMessage = "El numero personal es requerido")]
        public string numeroPersonal { get; set; }
        [Required(ErrorMessage = "El contacto de emergencia es requerido")]
        public string numeroEmergencia { get; set; }
    }
}