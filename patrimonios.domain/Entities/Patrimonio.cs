using System;
using System.Collections.Generic;
using System.Text;

namespace patrimonios.domain.Entities
{
    public class Patrimonio
    {
        public int PatrimonioId { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public string Descricao { get; set; }
        public int NumeroTombo { get; set; }
    }
}
