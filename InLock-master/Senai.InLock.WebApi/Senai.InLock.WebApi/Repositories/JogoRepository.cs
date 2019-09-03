using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Include(x => x.IdEstudioNavigation).ToList();
            }
        }
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos jogos = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(jogos);
                ctx.SaveChanges();
            }

        }
        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }
        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.IdJogo == id);   
            }
        }
        public void Atualizar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                    Jogos jogobuscado = ctx.Jogos.FirstOrDefault(x => x.IdJogo == jogo.IdJogo);
                    jogobuscado.NomeJogo = jogo.NomeJogo;
                    ctx.Jogos.Update(jogobuscado);
                    ctx.SaveChanges();    
            }
        }
    }
}
