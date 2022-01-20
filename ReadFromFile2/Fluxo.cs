using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromFile2
{
    public class Fluxo
    {
        public void ExportarListaParaDB(List<Entidade.Cliente> listaClientes)
        {
            var sql = new Conexoes.Sql();
            foreach(var cliente in listaClientes)
            {
                if (sql.VerificarSeHaRegistro(cliente.cpf))
                {
                    sql.AlterarClienteNaDB(cliente);
                }
                else
                {
                    sql.ExportarClienteParaDB(cliente);
                }
            }

        }

        public List<Entidade.Cliente> LerArquivo()
        {

            var listaClientes = new List<Entidade.Cliente>();

            string cpf, nome, sexo, idade, nacionalidade;
            var reader = new System.IO.StreamReader(@"C:\Users\lucca\Dropbox\Curso Rumo Exercícios\Exercicios\Importacao Questionarios\Clientes.txt");

            while (!reader.EndOfStream)
            {
                string linha = reader.ReadLine();
                cpf = linha.Substring(0, 11);
                nome = linha.Substring(11, 80);
                sexo = linha.Substring(91, 1);
                idade = linha.Substring(92, 3);
                nacionalidade = linha.Substring(95, 20);

                var cliente = new Entidade.Cliente();
                cliente.cpf = cpf;
                cliente.nome = nome.TrimStart();
                cliente.sexo = sexo;
                cliente.idade = Convert.ToInt32(idade);
                cliente.nacionalidade = nacionalidade.TrimStart();
                listaClientes.Add(cliente);
            }
            return listaClientes;
        }
    }
}
