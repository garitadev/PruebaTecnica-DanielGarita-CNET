using PruebaTecnica_DanielGarita_CNET.Database;
using PruebaTecnica_DanielGarita_CNET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica_DanielGarita_CNET.Models
{
    public class PacienteModel
    {

        public string RegistrarPaciente(PacienteObj paciente)
        {
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    Pacientes obj = new Pacientes();
                    obj.nombrePaciente = paciente.nombre;
                    obj.apellidoPaciente = paciente.apellido;
                    obj.numeroPesonal = paciente.numeroPersonal;
                    obj.numeroEmergencia = paciente.numeroEmergencia;
                    context.Pacientes.Add(obj);
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
        public List<PacienteObj> ConsultarPacientes()
        {
            List<PacienteObj> resultado = new List<PacienteObj>();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var datos = (from x in context.Pacientes
                                 select x).ToList();
                    foreach (var item in datos)
                    {
                        resultado.Add(new PacienteObj
                        {
                            idPaciente = item.idPaciente,
                            nombreCompleto = item.nombrePaciente +" "+ item.apellidoPaciente,
                            nombre = item.nombrePaciente,
                            apellido = item.apellidoPaciente,
                            numeroPersonal = item.numeroPesonal.ToString(),
                            numeroEmergencia = item.numeroEmergencia.ToString()

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


        //Consultar por un registro especifico
        public PacienteObj ConsultarPacienteEspecifico(int idPaciente)
        {
            PacienteObj resultado = new PacienteObj();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var datos = (from x in context.Pacientes
                                 where x.idPaciente == idPaciente
                                 select x).FirstOrDefault();

                    resultado.idPaciente = datos.idPaciente;
                    resultado.nombre = datos.nombrePaciente;
                    resultado.apellido = datos.apellidoPaciente.ToString();
                    resultado.numeroPersonal = datos.numeroPesonal;
                    resultado.numeroEmergencia = datos.numeroEmergencia;
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

        public PacienteObj ActualizarPaciente(PacienteObj paciente)
        {
          
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var resultado = (from x in context.Pacientes
                                     where x.idPaciente == paciente.idPaciente
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        resultado.idPaciente = paciente.idPaciente;
                        resultado.nombrePaciente = paciente.nombre;
                        resultado.apellidoPaciente = paciente.apellido;
                        resultado.numeroPesonal = paciente.numeroPersonal;
                        resultado.numeroEmergencia = paciente.numeroEmergencia;

                        context.SaveChanges();
                        context.Dispose();
                        return paciente;
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

        public List<SelectListItem> ConsultarPacientesCombo()
        {
            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var datos = (from x in context.Pacientes
                                 select x).ToList();

                    foreach (var item in datos)
                    {
                        var nombreCompleto = item.nombrePaciente + " " + item.apellidoPaciente;
                        resultado.Add(new SelectListItem
                        {
                            Value = item.idPaciente.ToString(),
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