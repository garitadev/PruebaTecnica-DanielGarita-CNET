using PruebaTecnica_DanielGarita_CNET.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica_DanielGarita_CNET.Models
{
    public class TratamientoModel
    {
        public List<SelectListItem> ConsultarTratmientosCombo()
        {
            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var datos = (from x in context.Tratamientos
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idTratamiento.ToString(),
                            Text = item.nombreTratamiento,

                        });
                    }

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    context.Dispose();
                    throw ex;
                }
            }
        }
    }
}