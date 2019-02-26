using Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Model.BussinesLogic
{
    public partial class LogicaUsuario
    {
        public ResponseModel Acceder(string nombreUsuario, string contrasena)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new MissingContext())
                {
                    contrasena = HashHelper.MD5(contrasena);

                    var usuario = ctx.Usuarios.Where(x => x.NombreUsuario == nombreUsuario)
                                              .Where(x => x.Contrasena == contrasena)
                                              .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.Id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Correo o contraseña Incorrecta.");
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return rm;
        }

        public Usuario Obtener(int id)
        {
            var usuario = new Usuario();

            try
            {
                using (var ctx = new MissingContext())
                {
                    usuario = ctx.Usuarios.Where(x => x.Id == id)
                                         .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return usuario;
        }

        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var ctx = new MissingContext())
                {
                    usuarios = ctx.Usuarios.Include("TipoDocumento")
                                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return usuarios;
        }

        public ResponseModel Guardar(Usuario model)
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
