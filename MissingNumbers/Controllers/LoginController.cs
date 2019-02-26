using Helper;
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

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string NombreUsuario, string Contrasena)
        {
            var rm = conLogicaUsuario.Acceder(NombreUsuario, Contrasena);

            if (rm.response)
            {
                rm.href = Url.Content("~/historial/index");
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