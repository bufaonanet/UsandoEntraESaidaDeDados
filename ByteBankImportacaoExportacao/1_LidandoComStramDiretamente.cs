using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsarFileStramDiretamente()
        {
            var endercoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(endercoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024];// = 1kb

                var bytesLidos = -1;

                while (bytesLidos != 0)
                {
                    bytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

                    Console.WriteLine($" Bytes lidos:{bytesLidos}");
                    EscreverBuffer(buffer, bytesLidos);
                }
            }

        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var texto = Encoding.Default.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);
        }
    }


}