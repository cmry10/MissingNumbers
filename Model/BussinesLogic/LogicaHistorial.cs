using System;
using System.Linq;

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

        public AnexGRIDResponde Listar(AnexGRID grid)
        {
            try
            {
                using (var ctx = new MissingContext())
                {
                    grid.Inicializar();

                    var query = ctx.Historials.Where(x => x.Id > 0);

                    // Ordenamiento
                    if (grid.columna == "Id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Id)
                                                             : query.OrderBy(x => x.Id);
                    }

                    if (grid.columna == "Fecha")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Fecha)
                                                             : query.OrderBy(x => x.Fecha);
                    }

                    var historial = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from h in historial
                        select new
                        {
                            h.Id,
                            h.Fecha,
                            h.ListaOriginal,
                            h.listaPerdidos,
                            h.ListaResultado
                        },
                        total
                    );
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return grid.responde();
        }
    }
}
