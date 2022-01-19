using System;

namespace ReadFromFile2
{
    public class Program
    {
        static void Main(string[] args)
        {

            var ferramentas = new Ferramentas();
            var fluxo = new Fluxo();
            fluxo.ImportacaoDeClientes(ferramentas.LerArquivo());
        }
    }
}
