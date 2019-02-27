using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.BussinesLogic
{
    public class LogicaTipoDocumento
    {
        public List<TipoDocumento> Listar()
        {
            var datos = new List<TipoDocumento>();

            try
            {
                using (var ctx = new MissingContext())
                {
                    datos = ctx.TipoDocumentoes.OrderBy(x => x.Descripcion)
                                           .ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return datos;
        }
    }
}
