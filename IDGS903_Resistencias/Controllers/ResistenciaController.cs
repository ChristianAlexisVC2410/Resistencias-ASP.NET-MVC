using IDGS903_Resistencias.Models;
using IDGS903_Resistencias.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS903_Resistencias.Controllers
{
    public class ResistenciaController : Controller
    {
        // GET: Resistencia
        public ActionResult Resistencias()
        {
            var ope = new ServiceResistencia();
            var temp = ope.MostrarResistencias();
            return View("Resistencias",temp);
        }

        [HttpPost]
        public ActionResult Resistencias(Resistencia r)
        {
            var ope = new ServiceResistencia();
            ope.GuardarArchivoResistencia(r);
        

            ViewBag.b1 = r.Banda1;
            ViewBag.b2 = r.Banda2;
            ViewBag.b3 = r.Banda3;
            ViewBag.t = r.Tolerancia;
            return View();
        }

        public ActionResult _AlmacenResultados()
        {
            var ope = new ServiceResistencia();
            var temp=ope.MostrarResistencias();
            var result=ope.ValoresColores(temp);
            
            return View(result);
        }
    }
}