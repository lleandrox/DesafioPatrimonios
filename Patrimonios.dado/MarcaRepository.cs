using Dapper;
using patrimonios.domain.Dtos;
using patrimonios.domain.Entities;
using Patrimonios.dado.Configuracao;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Patrimonios.dado
{
    public class MarcaRepository 
    {
        public IEnumerable<Marca> Selecionar()
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var lista = connection.Query<Marca>($"SELECT * FROM [MARCA]");

                return lista;
            }
        }

        public Marca SelecionarPorId(int id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.QueryFirstOrDefault<Marca>($"SELECT * FROM [MARCA] WHERE MARCAID = {id}");

                return obj;
            }
        }

        public IEnumerable<MarcaDto> SelecionarPatrimonioPorMarcaId(int Id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                var obj = connection.Query<MarcaDto>($"SELECT P.NOME, P.DESCRICAO, P.NUMEROTOMBO FROM [MARCA] M JOIN [PATRIMONIO] P ON P.MARCAID = M.MARCAID  WHERE P.MARCAID = {Id}");

                return obj;
            }
        }

        public int Inserir(Marca obj)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                return connection.QuerySingle<int>($"DECLARE @ID INT;" +
                                                   $"INSERT INTO [MARCA]" +
                                                   $"(NOME)" +
                                                   $"VALUES('{obj.Nome}')" +
                                                   $"SET @ID = SCOPE_IDENTITY();" +
                                                   $"SELECT @ID");
            }
        }

        public void Alterar(Marca obj)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                connection.Execute($"UPDATE [MARCA]" +
                                   $"SET NOME = '{obj.Nome}'" +
                                   $"WHERE MARCAID = '{obj.MarcaId}'");
            }
        }

        public void Deletar(int id)
        {
            using (var connection = new SqlConnection(DbConnectionFactory.SQLConnectionString))
            {
                connection.Execute($"DELETE FROM [MARCA] WHERE MARCAID = {id}");
            }
        }
    }
}
