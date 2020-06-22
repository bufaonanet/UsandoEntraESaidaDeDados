using System;
using System.IO;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsandoStreamDeEntrada()
        {
            using (var fluxoEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("ArquivoDeEntradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                do
                {
                    var bytesLidos = fluxoEntrada.Read(buffer, 0, 1024);
                    fs.Write(buffer, 0, bytesLidos);
                    fs.Flush();
                    Console.WriteLine($"Númerode bytes lidos: {bytesLidos}");

                } while (Console.ReadKey().Key !=  ConsoleKey.Escape);

            }
        }
    }
}
