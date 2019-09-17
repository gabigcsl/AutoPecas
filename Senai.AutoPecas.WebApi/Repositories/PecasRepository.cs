using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository
    {
      public List<Pecas> Listar (int IdFornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.Where(x => x.Fornecedores.IdFornecedor == IdFornecedor).ToList();
            }

           
        }
    }
}
