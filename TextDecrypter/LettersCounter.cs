using System;
using System.Collections.Generic;
using System.Linq;

namespace TextDecrypter
{
    public class LettersCounter
    {
        string textoNomenclator = "ARNEOWAREORÑÑRTZNZÑMWRÑEZORORKWHXRNAWTXÑKWÑRKQZÑXTZHXNZAAWNARSCROORXÑRÑEZOMÑRQZOZORZLXAZATZNERNRWÑVXOTRÑNWWÑÑRDZORXÑARTXÑXWÑBRXÑKZJZLHZNAWÑWLWÑDWOBROARÑDOZAWÑRLOWÑEOWJZIZAWDWORLÑWLSCRNWWÑKZCÑRERTWORÑEZORXÑRNRLRLXÑRWMMZQZJORXÑTCROEWQROTZNWÑLWSCRQZKRTWÑRNLZBXAZEXRNRÑCRKWRNLZRERONXAZAKCZNAWLZTCROERWÑLLZTRTXOZALZZLZKZOZDORHCNEZOZSCXRNKORRXÑSCRÑWXÑORÑDWNARORXÑÑWMCNZOZHWNRÑMRÑHOXTXORLZRÑDZAZTXRNEOZÑTZNERNHZCNÑWDLWARZLXRNEWZQWOZKZOHZAMLCKQZADWOLZHLWOXZARZOZHWNDWOÑZNFWOHRERFZAZOXWÑOWNZLARONRÑEW";
        
        public string ContarPalabrasLetras(int NumLetras)
        {
            Dictionary<string, int> LetrasRepetidas = new Dictionary<string, int>();

            for (int i = NumLetras-1; i < textoNomenclator.Length; i++)
            {
                string N_Letras = textoNomenclator.Substring(i - (NumLetras-1), NumLetras);

                if (!LetrasRepetidas.ContainsKey(N_Letras))
                {
                    LetrasRepetidas.Add(N_Letras, 1);
                }
                else
                {
                    int cant = LetrasRepetidas[N_Letras] + 1;
                    LetrasRepetidas.Remove(N_Letras);
                    LetrasRepetidas.Add(N_Letras, cant);
                }
            }

            var letrasOrdenadas = LetrasRepetidas.OrderByDescending(f => f.Value).ToDictionary(l => l.Key);
            string Resultado = $"Frecuencia palabras de {NumLetras} letras seguidas\n";
            foreach (var item in letrasOrdenadas)
            {
                Console.WriteLine();
                Resultado += $"{item.Key} - {item.Value} veces\n";
            }
            return Resultado;
        }


        public string CambiarLetrasYaConocidas()
        {
            string resultado = "";
            foreach (char letraCodificadasNomenclator in textoNomenclator)
            {
                if (Dictionaries.LetrasCodificadasALetrasNormales.ContainsKey(letraCodificadasNomenclator))
                {
                    resultado += Dictionaries.LetrasCodificadasALetrasNormales[letraCodificadasNomenclator];
                }
                else
                {
                    resultado += "_";
                }
            }
            return resultado;
        }


        public void LetrasCuyoValorDesconozco()
        {
            char[] Abecedario = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            List<char> LetrasDesconocidas = new List<char>();
            foreach (var item in Abecedario)
            {
                if (!Dictionaries.LetrasCodificadasALetrasNormales.ContainsKey(item))
                {
                    LetrasDesconocidas.Add(item);
                    Console.WriteLine(item);
                }
            }

        }
    }
}
