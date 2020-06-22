using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriandoArquivo()
        {
            var caminhoArquivoCriado = "ContaCriada.csv";

            using (var fluxoArquivo = new FileStream(caminhoArquivoCriado, FileMode.Create))
            {
                var contaString = "0707,39789,1050.45,Douglas Souto";
                var encouding = Encoding.UTF8;

                var bytes = encouding.GetBytes(contaString);

                fluxoArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriandoArquivoComStramWriter()
        {
            var caminhoArquivoCriado = "ContaCriada.csv";

            using (var fluxoArquivo = new FileStream(caminhoArquivoCriado, FileMode.Create))
            using (var escritorArquivo = new StreamWriter(fluxoArquivo))
            {
                var contaString = "0707,39789,1050.45,Douglas Bufão";

                escritorArquivo.Write(contaString);
            }
        }

        static void TestandoEscrita()
        {
            var caminhoArquivoCriado = "ArquivoTeste.csv";

            using (var fluxoArquivo = new FileStream(caminhoArquivoCriado, FileMode.Create))
            using (var escritorArquivo = new StreamWriter(fluxoArquivo))
            {
                int i = 1;

                do
                {

                    escritorArquivo.WriteLine($"linha {i}");
                    Console.WriteLine($"linha {i} escrita");
                    escritorArquivo.Flush();//Descarregado no HD

                    i++;
                } while (Console.ReadKey().Key != ConsoleKey.Escape);

            }
        }
    }

}

