using MissingNumbers.Filters;
using Model;
using Model.BussinesLogic;
using System.Web.Mvc;

namespace MissingNumbers.Controllers
{
    [NoLogin]
    public class HistorialController : Controller
    {
        private LogicaHistorial conLogicaHistorial = new LogicaHistorial();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CargarHistorial(AnexGRID grid)
        {
            return Json(conLogicaHistorial.Listar(grid));
        }

        public ActionResult Ver(int id)
        {
            return View(conLogicaHistorial.Obtener(id));
        }
    }
}