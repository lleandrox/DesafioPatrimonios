using System;
using System.Collections.Generic;
using System.Text;

namespace patrimonios.domain.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nome { get; set; }

        public Marca()
        {

        }
        public Marca(string nome)
        {
            Nome = nome;
        }
    }
    
}
