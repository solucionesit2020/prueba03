using Modelo;
using Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class EstudianteController : Controller
    {
        private IEstudianteService _serviceEst;

        public EstudianteController(IEstudianteService serviceEst)
        {
            _serviceEst = serviceEst;
        }
        [HttpGet]
        // GET: Estudiante
        public ActionResult Index()
        {
            var estModel = _serviceEst.GeAllEstudiante();
            return View(estModel);
        }

        [HttpGet]
        public ActionResult Crud(int id = 0) {
            return View(id == 0 ? new EstudianteModelo() : _serviceEst.GetByIdEstudiante(id));
        }

        [HttpPost]
        public ActionResult Crud(int?id, EstudianteModelo estudiante)
        {
            bool result = false;
            string msg = string.Empty;

            if (ModelState.IsValid) {
                if (id == 0) id = null;
                bool isNew = !id.HasValue;
                _serviceEst.AddEdditEstudiante(isNew, estudiante);
                result = true;
                msg = "Ok";
            }
            else
            {
                result = false;
                msg = "Error";
            }
            return Json(new { Response = result, message = msg }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult DeleteEstudiante(int id) {
            EstudianteModelo modelo = new EstudianteModelo();
            modelo = _serviceEst.GetByIdEstudiante(id);
            modelo.NombreCompleto = $"{modelo.PrimerNombre} {modelo.PrimerApellido}";
            modelo.Id = id;

            return View(modelo);

        }

        [HttpPost]
        public ActionResult DeleteEstudiante(int id, FormCollection form) {
            _serviceEst.EliminarEstudiante(id);

            return Json(new { Response = true, message = "exito" }, JsonRequestBehavior.AllowGet);
        }



    }
}