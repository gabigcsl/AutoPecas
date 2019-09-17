using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int IdPecas { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double? Peso { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal? PrecoVenda { get; set; }
        public int? IdFornecedor { get; set; }

        public Fornecedores IdFornecedorNavigation { get; set; }
    }
}
