using MissingNumbers.Filters;
using Model;
using Model.BussinesLogic;
using System;
using System.Web.Mvc;

namespace MissingNumbers.Controllers
{
    [Autenticado]
    public class HistorialController : Controller
    {
        private Historial historial = new Historial();
        private LogicaHistorial conLogicaHistorial = new LogicaHistorial();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CargarHistorial(DateTime? fechaInicial, DateTime? fechaFinal)
        {
            return View(conLogicaHistorial.Listar(fechaInicial, fechaFinal));
        }

        public ActionResult Ver(int id)
        {
            return PartialView(conLogicaHistorial.Obtener(id));
        }

        public ActionResult Eliminar(int id)
        {
            historial.Id = id;
            conLogicaHistorial.Eliminar(historial);
            return Redirect("~/Historial/CargarHistorial");
        }
    }
}