using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace ReadFromFile2.Conexoes
{
   
    public class Sql
    {
        private readonly SqlConnection _conexao;
        public Sql()
        {
            string conexao = File.ReadAllText(@"C:\Users\lucca\Dropbox\Curso Rumo Exercícios\Acesso SQL.txt");
            this._conexao = new SqlConnection(conexao);
        }
        public void ExportarClienteParaDB(Entidade.Cliente cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Cliente
                                (Cpf, Nome, Idade, Genero, Nacionalidade)
                                VALUES
                                (@cpf, @nome, @idade, @genero, @nacionalidade);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("cpf", cliente.cpf);
                    cmd.Parameters.AddWithValue("nome", cliente.nome);
                    cmd.Parameters.AddWithValue("idade", cliente.idade);
                    cmd.Parameters.AddWithValue("genero", cliente.sexo);
                    cmd.Parameters.AddWithValue("nacionalidade", cliente.nacionalidade);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }
        }
        public void AlterarClienteNaDB(Entidade.Cliente cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE Cliente
                            SET Nome = @Nome
                            ,Genero = @Genero
                            ,Nacionalidade = @Nacionalidade
                            ,Idade = @Idade
                                WHERE Cpf = @Cpf ";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("cpf", cliente.cpf);
                    cmd.Parameters.AddWithValue("nome", cliente.nome);
                    cmd.Parameters.AddWithValue("idade", cliente.idade);
                    cmd.Parameters.AddWithValue("genero", cliente.sexo);
                    cmd.Parameters.AddWithValue("nacionalidade", cliente.nacionalidade);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public bool VerificarSeHaRegistro(string cpf)
        {
            try
            {
                _conexao.Open();

                string sql = @"select Count(Cpf) AS total from Cliente WHERE Cpf = @Cpf;";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("cpf", cpf);
                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}
