using System.IO;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void EscritaBinaria()
        {
            using (var fs = new FileStream("arquivoBinario.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(0707);
                escritor.Write(112233);
                escritor.Write(1050.05);
                escritor.Write("Douglas");
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("arquivoBinario.txt", FileMode.Open))
            using (var escritor = new BinaryReader(fs))
            {
                var agencia = escritor.ReadInt32();
                var numero = escritor.ReadInt32();
                var saldo = escritor.ReadDouble();
                var titular = escritor.ReadString();

                System.Console.WriteLine($"Af.:{agencia}, nº:{numero}, saldo:{saldo}, titular:{titular}");
            }
        }
    }
}