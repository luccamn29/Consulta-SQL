using System;

namespace ReadFromFile2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fluxo = new Fluxo();
            fluxo.ExportarParaDB(fluxo.LerArquivo());
        }
    }
}
