using Model;
using Model.BussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MissingNumbers.Controllers
{
    public class ListasController : Controller
    {
        private LogicaListas conLogicaListas = new LogicaListas();
        // GET: Listas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultarListas(string txtCantidadNumerosInicial, string txtNumerosInicial, string txtCantidadNumerosSecundaria, string txtNumerosSecundaria)
        {
            List<string> listaOriginal = txtNumerosInicial.Split(' ').ToList();
            List<string> listaSecundaria = txtNumerosSecundaria.Split(' ').ToList();
            foreach (string item in listaSecundaria)
            {
                listaOriginal.Remove(item);
            }
            listaOriginal = listaOriginal.OrderBy(x => x).Distinct().ToList();
            Historial objHistorial = new Historial();
            objHistorial.Fecha = DateTime.Now;
            objHistorial.UsuarioId = 1;
            objHistorial.ListaOriginal = txtNumerosInicial;
            objHistorial.ListaResultado = txtNumerosSecundaria;
            objHistorial.listaPerdidos = string.Join(" ", listaOriginal);

            var rm = conLogicaListas.Guardar(objHistorial);

            return Json(new { success = true, result = objHistorial.listaPerdidos, message = "- Estos fueron los numeros que se perdieron." }, JsonRequestBehavior.AllowGet);
        }
    }
}