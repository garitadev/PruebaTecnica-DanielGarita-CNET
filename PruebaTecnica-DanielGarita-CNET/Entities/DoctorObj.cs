﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnica_DanielGarita_CNET.Entities
{
    public class DoctorObj
    {
        public int idDoctor { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string apellido { get; set; }


        [Required(ErrorMessage = "La especialidad es requerida")]
        public string especialidad { get; set; }

        public string nombreCompleto { get; set; }
    }
}