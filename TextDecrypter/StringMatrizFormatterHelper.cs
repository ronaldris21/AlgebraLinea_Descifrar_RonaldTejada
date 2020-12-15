using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TextDecrypter
{

    public class StringMatrizFormatterHelper
    {
        
        public string[] GetStringInFiles(string text)
        {
            int ExtraX = (4 - text.Length % 4) % 4;
            for (int i = 0; i < ExtraX; i++)
            {
                text += "X";
            }
            string[] filas = new string[4] { "","","",""};
            int pos = 0;
            foreach (var item in text)
            {
                filas[pos++] += item;
                pos %= 4;
            }
            return filas;
        }

        public void PrintLines(string[] lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }



        public string ConvertTextToMatlabMatriz(string texto)
        {
            string[] filas = GetStringInFiles(texto);
            string MatrizTexto1 = "[";
            for (int i = 0; i < filas.Length; i++)
            {
                for (int j = 0; j < filas[i].Length; j++)
                {
                    try
                    {
                        char LetraNormal = Dictionaries.LetrasCodificadasALetrasNormales[filas[i][j]];
                        MatrizTexto1 += Dictionaries.LetrasNormalesANumerosClave[LetraNormal];
                    }
                    catch (Exception e)
                    {
                        MatrizTexto1 += "_";
                        Debug.WriteLine(e);
                        Debug.WriteLine(e.InnerException);
                    }
                    if (j!= filas[i].Length-1  )
                    {
                        MatrizTexto1 += ",";
                    }
                }
                if (i!=filas.Length-1)
                {
                    MatrizTexto1 += ";";
                }
            }
            MatrizTexto1 += "]";
             return MatrizTexto1;
        }

        public string ConvertTextToMatlabMatrizWithNormalAlphabet(string texto)
        {
            string[] filas = GetStringInFiles(texto);
            string MatrizTexto1 = "[";
            for (int i = 0; i < filas.Length; i++)
            {
                for (int j = 0; j < filas[i].Length; j++)
                {
                        MatrizTexto1 += Dictionaries.AbecedarioNormal[filas[i][j]];
                    if (j != filas[i].Length - 1)
                    {
                        MatrizTexto1 += ",";
                    }
                }
                if (i != filas.Length - 1)
                {
                    MatrizTexto1 += ";";
                }
            }
            MatrizTexto1 += "]";
            return MatrizTexto1;
        }


        public string ConvertMatrizNumbersToText(string text, System.Collections.Generic.Dictionary<char, int> Diccionario)
        {
            Dictionary<int, char> TempDictionary = new Dictionary<int, char>();
            string TextoCorregido = "";
            int NumPruebas;

            foreach (var item in Diccionario)
            {
                TempDictionary.Add(item.Value, item.Key);
            }

            text = text.Replace("\n", " ");
            string[] numeros = text.Split(' ');
            for (int i = 0; i < numeros.Length; i++)
            {
                if (int.TryParse(numeros[i],out NumPruebas))
                {
                    if (TempDictionary.ContainsKey(NumPruebas))
                    {
                        TextoCorregido += TempDictionary[NumPruebas];
                    }
                    else //En caso que me aparezca una letra que no ten[ia contemplada en las variables conocidas
                    {
                        TextoCorregido += numeros[i]; //Lo agrego normal
                    }
                }
            }
            string textoFinal = "";
            int tamanoFila = TextoCorregido.Length / 4;
            for (int i = 0; i < tamanoFila; i++)
            {
                textoFinal += TextoCorregido.Substring(i + tamanoFila * 0, 1);
                textoFinal += TextoCorregido.Substring(i + tamanoFila * 1, 1);
                textoFinal += TextoCorregido.Substring(i + tamanoFila * 2, 1);
                textoFinal += TextoCorregido.Substring(i + tamanoFila * 3, 1);
            }

            return textoFinal;
        }





        public string CleanOriginalTextToFormat(string texto)
        {
            string FormattedText = "";
            texto = texto.ToUpper();
            texto = texto.Replace('Á', 'A');
            texto = texto.Replace('É', 'E');
            texto = texto.Replace('Í', 'I');
            texto = texto.Replace('Ó', 'O');
            texto = texto.Replace('Ú', 'U');

            int letter = 0;
            foreach (var item in texto)
            {
                letter = (int)item;

                if((letter>=65 && letter<=90) || item == 'Ñ')
                {
                    FormattedText += item;
                }
            }

            return FormattedText;

        }
    }
}
