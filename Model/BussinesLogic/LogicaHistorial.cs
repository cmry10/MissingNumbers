using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Routing;

namespace Model.BussinesLogic
{
    public class LogicaHistorial
    {

        public Historial Obtener(int id)
        {
            var historial = new Historial();

            try
            {
                using (var ctx = new MissingContext())
                {
                    historial = ctx.Historials.Where(x => x.Id == id)
                                         .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return historial;
        }

        public IndexViewModel Listar(DateTime? fechaInicial, DateTime? fechaFinal)
        {
            try
            {
                int pagina = 1;
                var cantidadRegistrosPorPagina = 10; // parámetro
                var listaHistorial = new List<Historial>();
                int totalDeRegistros = 0;
                using (var ctx = new MissingContext())
                {
                    if (fechaInicial != null && fechaFinal != null)
                    {
                        listaHistorial = ctx.Historials
                            .Where(x => x.Fecha >= fechaInicial && x.Fecha <= fechaFinal)
                            .OrderBy(x => x.Fecha)
                            .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                            .Take(cantidadRegistrosPorPagina).ToList();
                        totalDeRegistros = ctx.Historials.Where(x => x.Fecha >= fechaInicial && x.Fecha <= fechaFinal).Count();
                    }
                    else
                    {
                        listaHistorial = ctx.Historials.OrderBy(x => x.Fecha)
                        .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                        .Take(cantidadRegistrosPorPagina).ToList();
                        totalDeRegistros = ctx.Historials.Count();
                    }


                    var modelo = new IndexViewModel();
                    modelo.ListaHistorial = listaHistorial;
                    modelo.PaginaActual = pagina;
                    modelo.TotalDeRegistros = totalDeRegistros;
                    modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;
                    modelo.ValoresQueryString = new RouteValueDictionary();
                    //modelo.ValoresQueryString["edad"] = 5;

                    return modelo;
                }
            }
            catch (Exception E)
            {

                throw;
            }
        }

        public string Eliminar(Historial historial)
        {
            try
            {
                using (var ctx = new MissingContext())
                {
                    ctx.Entry(historial).State = EntityState.Deleted;
                    ctx.SaveChanges();
                    return "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
