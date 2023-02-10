using PruebaTecnica_DanielGarita_CNET.Entities;
using PruebaTecnica_DanielGarita_CNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica_DanielGarita_CNET.Controllers
{
    public class CitaController : Controller
    {
        DoctorModel docModel = new DoctorModel();
        PacienteModel pacienteModel = new PacienteModel();
        TratamientoModel tratamientosModel = new TratamientoModel();    
        CitaModel citasModel = new CitaModel(); 


        // GET: Cita
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ConsultarCitas()
        {
            try
            {

                var listaCitas = citasModel.ConsultarCitas();

                if (listaCitas.Count > 0)
                {
                    ViewBag.montoTotalCitas = listaCitas.LastOrDefault().montoTotalCitas;
                    return View("ConsultarCitas", listaCitas);
                }
                else
                {
                    return View("ConsultarDoctores", new List<DoctorObj>());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult CrearCita()
        {
            var cita = new CitaObj();
            return View(cita);
        }

        [HttpPost]
        public ActionResult CrearCita(CitaObj cita)
        {
            try
            {
                var respuesta = citasModel.RegistrarCita(cita);
                if (respuesta == string.Empty)
                {
                    return RedirectToAction("ConsultarCitas", "Cita");
                }
                else
                {
                    ViewBag.MsjValidacion = respuesta;
                    return View(cita);
                }
            }
            catch (Exception)
            {

                return View("../Shared/Error");
            }
        }

        public ActionResult CrearCitaFrm()
        {
            ViewBag.listaDoctores = docModel.ConsultarDoctoresCombo();
            ViewBag.listaPacientes = pacienteModel.ConsultarPacientesCombo();
            ViewBag.listaTratamientos = tratamientosModel.ConsultarTratmientosCombo();

            return View("CrearCita");
        }

        [HttpPost]
        public ActionResult ActualizarCitaFrm(int idCita)
        {
            try
            {
                var respuesta = citasModel.ConsultarCitaEspecifica(idCita);
                



                if (respuesta != null)
                {
                    ViewBag.listaDoctores = docModel.ConsultarDoctoresCombo();
                    ViewBag.listaPacientes = pacienteModel.ConsultarPacientesCombo();
                    ViewBag.listaTratamientos = tratamientosModel.ConsultarTratmientosCombo();
                    return View("ActualizarCita", respuesta);
                }
                else
                {
                    return View("../Shared/Error");

                }
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }

        }

        [HttpPost]
        public ActionResult ActualizarCita(CitaObj cita)
        {
            try
            {

                var respuesta = citasModel.ActualizarCita(cita);
                //verifica la respuesta
                if (respuesta != null)
                {
                    return RedirectToAction("ConsultarCitas", "Cita");
                }
                else
                {
                    //ViewBag.MsjValidacion = respuesta;
                    //return View(producto);
                    return View("../Shared/Error");
                }
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }
        }


    }
}
