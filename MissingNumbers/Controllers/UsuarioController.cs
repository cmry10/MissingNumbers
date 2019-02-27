using Helper;
using MissingNumbers.Filters;
using Model;
using Model.BussinesLogic;
using System.Web.Mvc;

namespace MissingNumbers.Controllers
{
    [NoLogin]
    public class UsuarioController : Controller
    {
        private LogicaUsuario conLogicaUsuario = new LogicaUsuario();
        private LogicaTipoDocumento conLogicaTipoDocumento = new LogicaTipoDocumento();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crud(int id = 0)
        {
            ViewBag.TipoDocumento = conLogicaTipoDocumento.Listar();

            return View(
                id == 0 ? new Usuario()
                        : conLogicaUsuario.Obtener(id)
            );
        }

        public JsonResult Guardar(Usuario model)
        {
            var rm = new ResponseModel();
            model.Contrasena = HashHelper.MD5(model.Contrasena);

            if (ModelState.IsValid)
            {
                rm = conLogicaUsuario.Guardar(model);
                if (rm.response)
                {
                    rm.href = Url.Content("~/login");
                }
            }

            return Json(rm);
        }
    }
}