using System;
using System.Data.Entity;

namespace Model.BussinesLogic
{
    public class LogicaListas
    {
        public ResponseModel Guardar(Historial model)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new MissingContext())
                {
                    if (model.Id > 0)
                    {
                        ctx.Entry(model).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(model).State = EntityState.Added;
                    }
                    rm.SetResponse(true);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return rm;
        }
    }
}
