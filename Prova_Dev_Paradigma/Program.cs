using System;
using System.Collections.Generic;
using System.Linq;

namespace Prova_Dev_Paradigma
{
    class Program
    {
        static void Main(string[] args)
        {
            Tarefa_1();
            Tarefa_2();
        }

        public static void Tarefa_1()
        {
            var arrayOriginal = new int[] { 7, 5, 3, 9, 6, 4, 1 };
            var arrayModificada = new List<int>();

            foreach(var numero in arrayOriginal)
            {
                if(numero == 9)
                {
                    arrayModificada.Add(5);
                    continue;
                }

                if(numero == 4)
                {
                    continue;
                }

                arrayModificada.Add(numero);
            }

            var stringArrayOriginal = obterArrayConcatenada<int>(arrayOriginal);
            var stringArrayModificada = obterArrayConcatenada<int>(arrayModificada.ToArray());
            var somaArrayModificada = arrayModificada.Sum();

            Console.WriteLine("Array Original: [{0}]", stringArrayOriginal);
            Console.WriteLine("Array Modificada: [{0}]", stringArrayModificada);
            Console.WriteLine("Soma valores array modificada: {0}", somaArrayModificada);
        }

        public static void Tarefa_2()
        {
            var strArrayEntrada = string.Empty;
            var strSomaEntrada = string.Empty;
            int somaEntrada = 0;

            Console.WriteLine("Digite a lista de numeros (separados por virgula (,)): ");
            strArrayEntrada = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite a soma da entrada: ");
            strSomaEntrada = Console.ReadLine();

            int.TryParse(strSomaEntrada, out somaEntrada);
            var arrayEntrada = strArrayEntrada.Split(',');
            var intArrayEntrada = new int[arrayEntrada.Length];

            for(int indice = 0, quantidade = arrayEntrada.Length; indice < quantidade; ++indice)
            {
                var strNumero = arrayEntrada[indice];

                int numero;
                int.TryParse(strNumero, out numero);

                intArrayEntrada[indice] = numero;
            }

            for (int indiceA = 0, quantidade = arrayEntrada.Length; indiceA < quantidade; ++indiceA)
            {
                if(intArrayEntrada[indiceA] >= somaEntrada)
                {
                    continue;
                }

                for (int indiceB = indiceA + 1; indiceB < quantidade; ++indiceB)
                {
                    if (intArrayEntrada[indiceB] >= somaEntrada)
                    {
                        continue;
                    }

                    if(intArrayEntrada[indiceA] + intArrayEntrada[indiceB] == somaEntrada)
                    {
                        Console.WriteLine();
                        Console.WriteLine("{0} + {1} = {2} ===> {0} + {1} são os números encontrados no array de entrada ", intArrayEntrada[indiceA], intArrayEntrada[indiceB], somaEntrada);
                        Console.WriteLine("Indice {0} e Indice {1} são os indices dos números encontrados no array de entrada ", indiceA, indiceB);
                        return;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("X + Y = {0} ===> \nNenhuma combinação de números encontrados no array de entrada ", somaEntrada);
        }

        private static string obterArrayConcatenada<T>(T[] array)
        {
            var stringConcatenada = string.Empty;

            if(array.Count() > 0)
            {
                stringConcatenada = string.Join(", ", array);
            }

            return stringConcatenada;
        }
    }
}
