using PruebaTecnica_DanielGarita_CNET.Database;
using PruebaTecnica_DanielGarita_CNET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica_DanielGarita_CNET.Models
{
    public class CitaModel
    {
        public string RegistrarCita(CitaObj cita)
        {
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    Citas obj = new Citas();
                    obj.idPaciente = cita.idPaciente;
                    obj.idTratamiento = cita.idTratamiento;
                    obj.idDoctor = cita.idDoctor;
                    obj.descripcionCita = cita.descripcion;
                    obj.fecha = cita.fecha;
                    obj.monto = cita.monto;

                    context.Citas.Add(obj);
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

        public List<CitaObj> ConsultarCitas()
        {
            decimal sumaMont = 0;
            List<CitaObj> resultado = new List<CitaObj>();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var datos = (from x in context.Citas
                                 select x).ToList();
                    foreach (var item in datos)
                    {
                        var nombreDoctor = (from x in context.Doctores
                                            where x.idDoctor == item.idDoctor
                                            select new { x.nombreDoctor, x.apellidoDoctor }).FirstOrDefault();

                        var nombrePaciente = (from x in context.Pacientes
                                             where x.idPaciente == item.idPaciente
                                             select new { x.nombrePaciente, x.apellidoPaciente }).FirstOrDefault();

                        var tratamiento = (from x in context.Tratamientos
                                          where x.idTratamiento == item.idTratamiento
                                          select x.nombreTratamiento).FirstOrDefault();

                         sumaMont = sumaMont + (decimal)item.monto;




                        resultado.Add(new CitaObj
                        {

                            idCita = item.idCita,
                            idDoctor = (int)item.idDoctor,
                            nombreDoctor = nombreDoctor.nombreDoctor + " " + nombreDoctor.apellidoDoctor,


                            idPaciente = (int)item.idPaciente,
                            nombrePaciente = nombrePaciente.nombrePaciente + " " + nombrePaciente.apellidoPaciente,

                            idTratamiento = (int)item.idTratamiento,
                            nombreTratamiento = tratamiento.ToString(),

                            fecha = (DateTime)item.fecha,

                            descripcion = item.descripcionCita.ToString(),
                            monto = (decimal)item.monto,
                            montoTotalCitas = (decimal)sumaMont

                        }); ; ;
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



        public CitaObj  ConsultarCitaEspecifica(int idCita)
        {
            CitaObj resultado = new CitaObj();
            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    //Consultas para obtener los datos
                    var datos = (from x in context.Citas
                                 where x.idCita == idCita
                                 select x).FirstOrDefault();

                    var nombreDoctor = (from x in context.Doctores
                                     where x.idDoctor == datos.idDoctor
                                     select new { x.nombreDoctor, x.apellidoDoctor }).FirstOrDefault();

                    var nombrePaciente = (from x in context.Pacientes
                                          where x.idPaciente == datos.idPaciente
                                          select new { x.nombrePaciente, x.apellidoPaciente }).FirstOrDefault();

                    var tratamiento = (from x in context.Tratamientos
                                       where x.idTratamiento == datos.idTratamiento
                                       select x.nombreTratamiento).FirstOrDefault();

                    resultado.idCita = datos.idCita;
                    resultado.nombreDoctor = nombreDoctor.nombreDoctor + " " + nombreDoctor.apellidoDoctor;
                    resultado.nombrePaciente = nombrePaciente.nombrePaciente + " " + nombrePaciente.apellidoPaciente;
                    resultado.nombreTratamiento = tratamiento;
                    resultado.monto = (decimal)datos.monto;
                    resultado.descripcion = datos.descripcionCita;
                    resultado.fecha = (DateTime)datos.fecha;
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
        public CitaObj ActualizarCita(CitaObj cita)
        {

            using (var context = new DB_ExpedientesEntities())
            {
                try
                {
                    var resultado = (from x in context.Citas
                                     where x.idCita == cita.idCita
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        resultado.idCita = cita.idCita;
                        resultado.idPaciente = cita.idPaciente;
                        resultado.idDoctor = cita.idDoctor;
                        resultado.idTratamiento = cita.idTratamiento;
                        resultado.descripcionCita = cita.descripcion;
                        resultado.monto = cita.monto;
                        resultado.fecha = cita.fecha;

                        context.SaveChanges();
                        context.Dispose();
                        return cita;
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
    }
}