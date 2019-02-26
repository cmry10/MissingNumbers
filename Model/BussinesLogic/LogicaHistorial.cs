using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BussinesLogic
{
    public class LogicaHistorial
    {
        public List<Historial> Listar()
        {
            var historial = new List<Historial>();
            try
            {
                using (var ctx = new MissingContext())
                {
                    historial = ctx.Historials.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return historial;
        }

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
    }
}
