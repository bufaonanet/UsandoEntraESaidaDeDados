using ByteBankImportacaoExportacao.Modelos;
using System;
using System.IO;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsarStramReader()
        {
            var endercoArquivo = "contas.txt";

            using (var fs = new FileStream(endercoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fs))
            {
                while (!leitor.EndOfStream)
                {
                    var linhaLida = leitor.ReadLine();

                    var cc = ConverteStringParaContaCorrente(linhaLida);
                    var msg = $"Ag.: {cc.Agencia}, Nº: {cc.Numero}, Saldo: {cc.Saldo}, Titular: {cc.Titular.Nome}";

                    Console.WriteLine(msg);
                }
            }
        }

        static ContaCorrente ConverteStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace(".", ","));
            var nomeTitular = campos[3];

            var contaCorrente = new ContaCorrente(agencia, numero);
            contaCorrente.Depositar(saldo);
            contaCorrente.Titular = new Cliente { Nome = nomeTitular };

            return contaCorrente;
        }

    }
}