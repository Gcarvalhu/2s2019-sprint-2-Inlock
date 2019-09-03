using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.IdUsuarioNavigation).ToList();
            }
        }
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios estudios = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(estudios);
                ctx.SaveChanges();
            }
        }
        public void Cadastrar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }
        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.IdEstudio == id);
            }
        }
        public void Atualizar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios estudiobuscado = ctx.Estudios.FirstOrDefault(x => x.IdEstudio == estudio.IdEstudio);
                estudiobuscado.NomeEstudio = estudio.NomeEstudio;
                ctx.Estudios.Update(estudiobuscado);
                ctx.SaveChanges();
            }
        }
    }
}
