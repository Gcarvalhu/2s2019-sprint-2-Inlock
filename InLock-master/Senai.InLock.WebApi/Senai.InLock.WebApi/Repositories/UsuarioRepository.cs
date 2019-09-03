using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarEmailSenha(LoginViewModel login)
        {
            using(InLockContext ctx = new InLockContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                return usuario;
            }

        }
    }
}
