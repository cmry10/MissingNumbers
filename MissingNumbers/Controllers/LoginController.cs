using Helper;
using MissingNumbers.Filters;
using Model;
using Model.BussinesLogic;
using System.Web.Mvc;

namespace MissingNumbers.Controllers
{
    
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();
        private LogicaUsuario conLogicaUsuario = new LogicaUsuario();
        private LogicaTipoDocumento conLogicaTipoDocumento = new LogicaTipoDocumento();

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string NombreUsuario, string Contrasena)
        {
            var rm = conLogicaUsuario.Acceder(NombreUsuario, Contrasena);

            if (rm.response)
            {
                rm.href = Url.Content("~/historial/CargarHistorial");
            }

            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/login");
        }

    }
}