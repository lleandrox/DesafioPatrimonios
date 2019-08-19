using Dapper;
using patrimonios.domain.Entities;
using Patrimonios.dado.Configuracao;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Patrimonios.dado
{
    public class PatrimonioRepository
    {
        public IEnumerable<Patrimonio> Selecionar()
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var lista = connection.Query<Patrimonio>($"SELECT * FROM [PATRIMONIO]");

                return lista;
            }
        }

        public Patrimonio SelecionarPorId(int id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<Patrimonio>($"SELECT * FROM [PATRIMONIO] WHERE PATRIMONIOID = {id}");

                return obj;
            }
        }
        public int Inserir(Patrimonio obj)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                return connection.QuerySingle<int>($"DECLARE @ID INT;" +
                                                   $" INSERT INTO [PATRIMONIO]" +
                                                   $" (NOME, MARCAID, DESCRICAO, NUMEROTOMBO)" +
                                                   $" VALUES('{obj.Nome}','{obj.MarcaId}','{obj.Descricao}','{obj.NumeroTombo}')" +
                                                   $" SET @ID = SCOPE_IDENTITY();" +
                                                   $" SELECT @ID");
            }
        }

        public void Alterar(Patrimonio obj)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                connection.Execute($"UPDATE [PATRIMONIO]" +
                                   $" SET NOME = '{obj.Nome}',DESCRICAO = '{obj.Descricao}',NUMEROTOMBO = '{obj.NumeroTombo}'" +
                                   $"WHERE PATRIMONIOID = '{obj.MarcaId}'");
            }
        }

        public void Deletar(int id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                connection.Execute($"DELETE FROM [PATRIMONIO] WHERE PATRIMONIOID = {id}");
            }
        }
    }
}
