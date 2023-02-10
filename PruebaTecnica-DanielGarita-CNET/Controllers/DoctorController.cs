using PruebaTecnica_DanielGarita_CNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica_DanielGarita_CNET.Entities
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        DoctorModel modeloDoc = new DoctorModel();
        [HttpGet]
        public ActionResult ConsultarDoctores()
        {
            try
            {
                var listaDoctores = modeloDoc.ConsultarDoctores();

                if (listaDoctores.Count > 0)
                {
                    return View("ConsultarDoctores", listaDoctores);
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
        public ActionResult CrearDoctor()
        {
            var doctor = new DoctorObj();
            return View(doctor);
        }

        [HttpPost]
        public ActionResult CrearDoctor(DoctorObj doctor)
        {
            try
            {
                var respuesta = modeloDoc.RegistrarDoctor(doctor);
                if (respuesta == string.Empty)
                {
                    return RedirectToAction("ConsultarDoctores", "Doctor");
                }
                else
                {
                    ViewBag.MsjValidacion = respuesta;
                    return View(doctor);
                }
            }
            catch (Exception)
            {

                return View("../Shared/Error");
            }
        }



        [HttpPost]
        public ActionResult ActualizarDoctorFrm(int idDoctor)
        {
            try
            {
                var respuesta = modeloDoc.ConsultarDoctorEspecifico(idDoctor);



                if (respuesta != null)
                {
                    return View("ActualizarDoctor", respuesta);
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
        public ActionResult ActualizarDoctor(DoctorObj doctor)
        {
            try
            {

                var respuesta = modeloDoc.ActualizarDoctor(doctor);
                //verifica la respuesta
                if (respuesta != null)
                {
                    return RedirectToAction("ConsultarDoctores", "Doctor");
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