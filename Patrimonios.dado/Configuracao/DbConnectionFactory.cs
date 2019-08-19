using System;
using System.Collections.Generic;
using System.Text;

namespace Patrimonios.dado.Configuracao
{
    internal static class DbConnectionFactory
    {
        //todo: MUDAR STRING DE CONEXÃO
        public static string SQLConnectionString => "Data Source=WKSJUN000147\\SQLEXPRESS;Initial Catalog = PROJETO_PATRIMONIO; Integrated Security = True";
        //"Integrated Security = SSPI; Persist Security Info=False;Initial Catalog =PROJETO_PATRIMONIO; Data Source = WKSJUN000147\\LOCAL";
        //"Data Source=.;Initial Catalog=PROJETO_PATRIMONIO;Integrated Security=True";
    }
}
