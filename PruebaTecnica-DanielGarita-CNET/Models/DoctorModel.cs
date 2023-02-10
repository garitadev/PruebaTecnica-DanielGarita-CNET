using Newtonsoft.Json;
using PruebaTecnica_DanielGarita_CNET.Database;
using PruebaTecnica_DanielGarita_CNET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica_DanielGarita_CNET.Models
{
    public class DoctorModel
    {

        public string RegistrarDoctor(DoctorObj doctor)
        {
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    Doctores obj = new Doctores();
                    obj.nombreDoctor = doctor.nombre;
                    obj.apellidoDoctor = doctor.apellido;
                    obj.especialidad = doctor.especialidad;
                    context.Doctores.Add(obj);
                    context.SaveChanges();
                    context.Dispose();
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    context.Dispose();
                    return "Ha ocurrido un error";
                    throw ex;
                }
            }
        }
        public List<DoctorObj> ConsultarDoctores()
        {
            List<DoctorObj> resultado = new List<DoctorObj>();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var datos = (from x in context.Doctores
                                 select x).ToList();
                    foreach (var item in datos)
                    {
                        resultado.Add(new DoctorObj
                        {
                            idDoctor = item.idDoctor,
                            nombre = item.nombreDoctor,
                            apellido = item.apellidoDoctor,
                            especialidad = item.especialidad,
                            nombreCompleto = item.nombreDoctor +" "+ item.apellidoDoctor

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

        public DoctorObj ConsultarDoctorEspecifico(int idDoctor)
        {
            DoctorObj resultado = new DoctorObj();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var datos = (from x in context.Doctores
                                 where x.idDoctor == idDoctor
                                 select x).FirstOrDefault();

                    resultado.idDoctor = datos.idDoctor;
                    resultado.nombre = datos.nombreDoctor;
                    resultado.apellido = datos.apellidoDoctor.ToString();
                    resultado.especialidad = datos.especialidad;
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
        public DoctorObj ActualizarDoctor(DoctorObj doctor)
        {

            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var resultado = (from x in context.Doctores
                                     where x.idDoctor == doctor.idDoctor
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        resultado.idDoctor = doctor.idDoctor;
                        resultado.nombreDoctor = doctor.nombre;
                        resultado.apellidoDoctor = doctor.apellido;
                        resultado.especialidad = doctor.especialidad;

                        context.SaveChanges();
                        context.Dispose();
                        return doctor;
                    }
                    return null;

                }
                catch (Exception)
                {
                    context.Dispose();
                    return null;
                    throw;
                }
            }
        }

        public List<SelectListItem> ConsultarDoctoresCombo()
        {
            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var datos = (from x in context.Doctores
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        var nombreCompleto = item.nombreDoctor + " " + item.apellidoDoctor;
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idDoctor.ToString(),
                            Text = nombreCompleto,

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