using PruebaTecnica_DanielGarita_CNET.Entities;
using PruebaTecnica_DanielGarita_CNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica_DanielGarita_CNET.Controllers
{
    public class PacienteController : Controller
    {
        PacienteModel modelPaciente = new PacienteModel();
        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConsultarPacientes()
        {
            try
            {
                var listaPacientes = modelPaciente.ConsultarPacientes();

                if (listaPacientes.Count > 0)
                {
                    return View("ConsultarPacientes", listaPacientes);
                }
                else
                {
                    return View("ConsultarPacientes", new List<PacienteObj>());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public ActionResult CrearPacienteFrm()
        {
            var paciente = new PacienteObj();
            return View(paciente);
        }

        [HttpPost]
        public ActionResult CrearPaciente(PacienteObj paciente)
        {
            try
            {
                var respuesta = modelPaciente.RegistrarPaciente(paciente);
                if (respuesta == string.Empty)
                {
                    return RedirectToAction("ConsultarPacientes", "Paciente");
                }
                else
                {
                    ViewBag.MsjValidacion = respuesta;
                    return View(paciente);
                }
            }
            catch (Exception)
            {

                return View("../Shared/Error");
            }
        }


       
        [HttpPost]
        public ActionResult ActualizarPacienteFrm(int idPaciente)
        {
            try
            {
                var respuesta = modelPaciente.ConsultarPacienteEspecifico(idPaciente);



                if (respuesta != null)
                {
                    return View("ActualizarPaciente", respuesta);
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
        public ActionResult ActualizarPaciente(PacienteObj paciente)
        {
            try
            {
                
                var respuesta = modelPaciente.ActualizarPaciente(paciente);
                //verifica la respuesta
                if (respuesta != null)
                {
                    return RedirectToAction("ConsultarPacientes", "Paciente");
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