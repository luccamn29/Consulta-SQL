using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromFile2
{
    public class Fluxo
    {
        public void ImportacaoDeClientes(List<Entidade.Cliente> listaClientes)
        {
            var sql = new Conexoes.Sql();
            foreach(Entidade.Cliente cliente in listaClientes)
            {
                sql.inserir_BaseMarketing(cliente);
            }

        }
    }
}
