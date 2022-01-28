using System;
using System.IO;

namespace Detector_de_nome_de_arquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomeArquivo;
            bool validade;
            do
            {
                Console.Write("Digite o nome do arquivo: ");
                nomeArquivo = Console.ReadLine();

                validade = !(Detector(nomeArquivo));

                if (validade)
                    Console.WriteLine("Nome invalido para arquivo!\n");

            } while(validade);

            var path = Path.Combine(Environment.CurrentDirectory, $"{nomeArquivo}.txt");
            CriarArquivo(path);

            Console.WriteLine("Arquivo criado no atual diretório!");
        }
        static void CriarArquivo(string path)
        {
            using var sw = File.CreateText(path);
            sw.WriteLine("Este arquivo foi criado pelo programa.");
        }
        static bool Detector(string nomeArquivo)
        {
            for (int i = 0; i < nomeArquivo.Length; i++)
            {
                foreach (char invalido in Path.GetInvalidFileNameChars())
                {
                    if (nomeArquivo[i] == invalido)
                        return false;
                }
            }
            return true;
        }
    }
}
