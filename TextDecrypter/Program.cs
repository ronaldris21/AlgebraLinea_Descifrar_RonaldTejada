using System;
using System.Collections.Generic;
using System.Linq;

namespace TextDecrypter
{
    public class Parrafos
    {
        public int length { get; set; }
        public string text { get; set; }
        public string originalText { get; set; }
        public string[] filasText { get; set; }
        public int[,] MatrizVertical { get; set; }
        public int[,] MatrizHorizontal { get; set; } //Ya que si contiene letras que desconozco, ES IMPOSIBLE USAR ESAS COLUMNAS!!!   
    }

    public static class Program
    {

        public const string textoCodificadoMatriz = "CTWKÑHOSQAHGFLXKZBQNBBÑFDBOEWECWKÑFPOEÑYRSKUZLIYHVBHUOADFYWWBHTLZFZBOAAUVVPQRRXBOIYDUBQVIRSTQTJGJGBTHSOJLÑPEAFFYOXDJUJGERVCQRDGGAUASJLTÑDQTRVHBGÑHRYQÑMTLJIOZVFPCIGOZHXLOXZAZPVXLRJLXTNCCCEEUUXDQQVCCQEUCIPELKQWPHZHYUKFCQEUCIPEVAAZMXUÑNKDQÑQÑDVÑBHBMUQFHAYTDBVCNDFTJELKUHPPJYTZGQACDUWKHPMPCTJHCILUÑUAJJJUTBGKQPYXPLMPQTJGGDBUTBRKAWHTWLEÑXZZXUHMÑNSUYÑZJDGHBYMPLQYLTNAKÑQHDRQESEQASOÑAURIYRAVYIOTJUESXBFCFEBYUFQIRFMKÑKBYCPTDGHBYEHQKDRUCWGUÑULKEASAADCLPXONTJSMAÑSVBMJSWRMTUETFTLPBULZLFLRHXWNCSIJVJPXUSZCGNJJBSUUDEVJHWUZLGVMHWCAXVXÑFGXCWABWYJWPYNKSIAXIJFOZTYURHRSINJAAPSPXKZBDAZBMUQJRBGFEBYVÑVPCQXBHDHACFYÑXELELIXJDNLÑKLIZABSMVBWHEMQÑNOISZEGDKJTPHZOEOTKLZVFPYMFQOWRRHCDWHJQUGJDCIYFWOAIDHBSOFSYKXQTMFYWWFPCNWREFTOEUWELKIELVHBRAKLCYQAUPVZMTPJZKFSLPEDKINYPRUEOOPNASWYVDGMFEAÑDRCDDAUREDFMEWGIHKEUOTEUJGSCNCBOQHYXMCRUGQNEUÑLLJL";
        public const string foderDirection = @"C:\Users\ronal\Documents\Drive Docs\UCAM\Algebra Lineal\Resultados\";
        public static Dictionary<int, int> Coprimos27 { get; set; }

        //Classes Ayudantes
        public static StringMatrizFormatterHelper stringMatrizFormatter = new StringMatrizFormatterHelper();




        public static void txtCreator(string Content, string fileName)
        {
			System.IO.File.WriteAllText(foderDirection + fileName + ".txt", Content);
		}


        // Main Method 
        public static void Main(String[] args)
		{
			//Se borró el archivo, por eso se perdió el demás código de está clase.
			//Al menos las demás siguen sin alterarse



            // Read the file and display it line by line
            string[] filesTxt = System.IO.File.ReadAllLines(foderDirection+ "MuretPosiblesTextos.txt");
            List<Parrafos> LineasDepuradas = new List<Parrafos>();
            foreach (var item in filesTxt)
            {
                string CleanTexto = stringMatrizFormatter.CleanOriginalTextToFormat(item);
                
                if (CleanTexto.Length >= textoCodificadoMatriz.Length-3  && CleanTexto.Length <= textoCodificadoMatriz.Length ) // Casos en los que haya rellenado con X, XX, o XXX, o que las letras estén completas
                {
                    //Console.WriteLine(CleanTexto.Length);
                    //Console.WriteLine(CleanTexto);
                    LineasDepuradas.Add(new Parrafos()
                    {
                        length = CleanTexto.Length,
                        originalText= item,
                        text = CleanTexto
                    });
                }
            }

            Console.WriteLine("Texto De la Matriz Codificada");
            Console.WriteLine(textoCodificadoMatriz.Length);
            Console.WriteLine(textoCodificadoMatriz);

            Console.WriteLine("Texto de Muret ordenados de mayor a menor por cantidad de letras");

            
            LineasDepuradas = LineasDepuradas.OrderBy(p => p.length).ToList(); //Ordeno por cantidad
            Console.WriteLine("Posibles textos\n\n\n");
            for (int i = 0; i < LineasDepuradas.Count; i++)
            {
                Console.WriteLine("Caso posible # {0}",i+1); ;
                Console.WriteLine(LineasDepuradas[i].length);
                Console.WriteLine(LineasDepuradas[i].originalText+"\n");
                Console.WriteLine(LineasDepuradas[i].text);
                Console.WriteLine("\n\n\n");
            }

            Coprimos27 = new Dictionary<int, int>();
            for (int i = 1; i < 27; i++)
            {
                if (i%3!=0) //Entonces es coprimo para el 27
                {
                    int valorCoprimo=1;
                    while(i*valorCoprimo % 27  != 1)
                    {
                        valorCoprimo++;
                    }
                    Console.WriteLine("{0}x{1} % 27 == 1",i,valorCoprimo);
                    Coprimos27.Add(i, valorCoprimo);
                }
            }







            //EjemploFuncional(); // del algoritmo implementado, acá se hicieron pruebas antes de probar con los datos finales
            Console.WriteLine();
            Console.ReadLine(); //Para que no sé cierre autómaticamente el programa
        }


        //Función 100% funcional
        private static void EjemploFuncional()
        {


            //Pruebo los algoritmoss que tengo!!!!
            //Me basaré en los datos del archivo CifrandoTexto Ejemplo Con Abecedario Desde Cero.txt
            //Dictionaries.AbecedarioNormalFromZero como permutación clave



            //Lleno los datos que ya calcule previamente
            Parrafos pEntrada = new Parrafos() { originalText = "UNTRABAJOLABORIOSOYBONITO" };
            pEntrada.length = pEntrada.originalText.Length;
            pEntrada.text = stringMatrizFormatter.CleanOriginalTextToFormat(pEntrada.originalText);
            pEntrada.filasText = stringMatrizFormatter.GetStringInFiles(pEntrada.text);

            Parrafos pSalida = new Parrafos() { originalText = "TTOIGNJPNKHECYJNDAMHKJLRJXAM" };
            pSalida.length = pSalida.originalText.Length;
            pSalida.text = stringMatrizFormatter.CleanOriginalTextToFormat(pSalida.originalText);
            pSalida.filasText = stringMatrizFormatter.GetStringInFiles(pSalida.text);

            //AHora construyo la matriz numérica! -- Usaré listas, porque quiero hacerla dinámica, ya que no siempre podré disponer de todos las filas
            //Caso de las 4 letras que desconozco, así en esos casos eliminaré las columnas completas!!

            List<int[]> MatrizEntradaTrans = new List<int[]>();
            List<int[]> MatrizSalidaTrans = new List<int[]>();

            for (int c = 0; c < pEntrada.filasText[0].Length; c++)
            {
                bool ContainsInvalidad = false;
                for (int f = 0; f < 4; f++)
                {
                    if (
                        !Dictionaries.AbecedarioNormalFromZero.ContainsKey(pEntrada.filasText[f][c]) ||
                        !Dictionaries.AbecedarioNormalFromZero.ContainsKey(pSalida.filasText[f][c]))
                    {
                        ContainsInvalidad = true;
                    }
                }

                if (!ContainsInvalidad) /// Entonces todos los elementos de la columnas con validos! As[i que los agrego!!!
                {
                    int[] ColumnaDatos = new int[4];
                    for (int f = 0; f < 4; f++) //Columna Entrada
                    {
                        ColumnaDatos[f] = Dictionaries.AbecedarioNormalFromZero[pEntrada.filasText[f][c]];
                    }
                    MatrizEntradaTrans.Add(ColumnaDatos);
                    ColumnaDatos = new int[4];
                    for (int f = 0; f < 4; f++) //Columna de salida
                    {
                        ColumnaDatos[f] = Dictionaries.AbecedarioNormalFromZero[pSalida.filasText[f][c]];
                    }
                    MatrizSalidaTrans.Add(ColumnaDatos);
                }
            }



            Console.WriteLine("Matriz Entrada transpuesta");
            foreach (var item in MatrizEntradaTrans)
            {
                foreach (var dato in item)
                {
                    Console.Write("{0,3}", dato);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Matriz Salida transpuesta");
            foreach (var item in MatrizSalidaTrans)
            {
                foreach (var dato in item)
                {
                    Console.Write("{0,3}", dato);
                }
                Console.WriteLine();
            }





            //Creo la matriz que me interesa

            //MATRICES HORIZONTALES
            int CantColumnas = MatrizEntradaTrans.Count;
            int[,] MatrizEntradaF = new int[4, CantColumnas];
            int[,] MatrizSalidaF = new int[4, CantColumnas];

            //Matrices VERTICALES

            int[,] MatrizEntradaF_Vertical = new int[CantColumnas, 4];
            int[,] MatrizSalidaF_Vertical = new int[CantColumnas, 4];




            Console.WriteLine("\n");
            Console.WriteLine("Matriz Ampliada a analizar");
            for (int f = 0; f < 4; f++)
            {
                for (int c = 0; c < CantColumnas; c++)
                {
                    MatrizEntradaF_Vertical[c, f] = MatrizEntradaTrans[c][f] % 27;
                    MatrizEntradaF[f, c] = MatrizEntradaTrans[c][f] % 27;
                    Console.Write("{0,4}", MatrizEntradaF[f, c]);
                }
                Console.Write(" | ");
                for (int c = 0; c < CantColumnas; c++)
                {
                    MatrizSalidaF_Vertical[c, f] = MatrizSalidaTrans[c][f] % 27;
                    MatrizSalidaF[f, c] = MatrizSalidaTrans[c][f] % 27;
                    Console.Write("{0,4}", MatrizSalidaF[f, c]);
                }
                Console.WriteLine();
            }



            AnalisisMatricesAmpliadasVERTICAL(CantColumnas, MatrizEntradaF_Vertical, MatrizSalidaF_Vertical); //Acá sería cantidad de filas
            AnalisisMatricesAmpliadasHORIZONTAL(CantColumnas, MatrizEntradaF, MatrizSalidaF);


        }

        private static void AnalisisMatricesAmpliadasVERTICAL(int cantFilas, int[,] MatrizEntradaF, int[,] MatrizSalidaF)
        {
            Console.WriteLine("ANALISIS MATRIZ AMPLIADA EN VERTICAL");


            int Fila, Columna;
            do
            {
                Console.Write("\n\nCoprimos de 27: ");
                foreach (var item in Coprimos27)
                {
                    Console.Write($"{item.Value}, ");
                }
                Console.WriteLine();


                ImprimirMatrizAmpliada(cantFilas, 4, MatrizEntradaF, MatrizSalidaF);

                Console.Write("\nColumna: ");
                Columna = int.Parse(Console.ReadLine());
                Console.Write("Fila: ");
                Fila = int.Parse(Console.ReadLine());


                //Primero hago 1!!!
                int ValorSeleccionado = MatrizEntradaF[Fila, Columna];

                if (Coprimos27.ContainsKey(ValorSeleccionado))
                {
                    ValorSeleccionado = Coprimos27[ValorSeleccionado];//Saco el que lo hace 27n+1
                    for (int i = 0; i < 4; i++)
                    {
                        //Entrada
                        MatrizEntradaF[Fila, i] *= ValorSeleccionado; //A modo de hacerlo 1
                        MatrizEntradaF[Fila, i] = MatrizEntradaF[Fila, i] % 27;

                        //Salida
                        MatrizSalidaF[Fila, i] *= ValorSeleccionado; //A modo de hacerlo 1
                        MatrizSalidaF[Fila, i] = MatrizSalidaF[Fila, i] % 27;
                    }

                    ImprimirMatrizAmpliada(cantFilas, 4, MatrizEntradaF, MatrizSalidaF);

                    //Me interesa hacer CEROS en la COLUMNA SELECCIONADA!!!
                    //Ahora, tengo que hacer Ceros los demas
                    for (int f = 0; f < cantFilas; f++)
                    {
                        if (f != Fila)//Para no hacer cero a la fila seleccionada!!!
                        {
                            int ValorColumnaEnF = MatrizEntradaF[f, Columna];
                            for (int c = 0; c < 4; c++)
                            {
                                //Entrada
                                MatrizEntradaF[f, c] = (MatrizEntradaF[f, c] - MatrizEntradaF[Fila, c] * ValorColumnaEnF) % 27; //Fila queda fija

                                //Salida
                                MatrizSalidaF[f, c] = (MatrizSalidaF[f, c] - MatrizSalidaF[Fila, c] * ValorColumnaEnF) % 27; //Fila queda fija
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n\n***************************************\n{0} NO ES COPRIMO DE 27\n\n", ValorSeleccionado);
                }




            } while (!(Fila == 0 && Columna == 0));
        }

        private static void AnalisisMatricesAmpliadasHORIZONTAL(int CantColumnas,int[,] MatrizEntradaF, int[,] MatrizSalidaF)
        {
            Console.WriteLine("ANALISIS MATRIZ AMPLIADA EN VERTICAL");

            int Fila, Columna;
            do
            {
                Console.Write("\n\nCoprimos de 27: ");
                foreach (var item in Coprimos27)
                {
                    Console.Write($"{item.Value}, ");
                }
                Console.WriteLine();


                ImprimirMatrizAmpliada(4,CantColumnas, MatrizEntradaF, MatrizSalidaF);

                Console.Write("Columna: ");
                Columna = int.Parse(Console.ReadLine());
                Console.Write("\nFila: ");
                Fila = int.Parse(Console.ReadLine());
                

                //Primero hago 1!!!
                int ValorSeleccionado = MatrizEntradaF[Fila, Columna];

                if (Coprimos27.ContainsKey(ValorSeleccionado))
                {
                    ValorSeleccionado = Coprimos27[ValorSeleccionado];//Saco el que lo hace 27n+1
                    for (int i = 0; i < CantColumnas; i++)
                    {
                        //Entrada
                        MatrizEntradaF[Fila, i] *= ValorSeleccionado; //A modo de hacerlo 1
                        MatrizEntradaF[Fila, i] = MatrizEntradaF[Fila, i] % 27;

                        //Salida
                        MatrizSalidaF[Fila, i] *= ValorSeleccionado; //A modo de hacerlo 1
                        MatrizSalidaF[Fila, i] = MatrizSalidaF[Fila, i] % 27;
                    }

                    ImprimirMatrizAmpliada(4,CantColumnas, MatrizEntradaF, MatrizSalidaF);

                    //Me interesa hacer CEROS en la COLUMNA SELECCIONADA!!!
                    //Ahora, tengo que hacer Ceros los demas
                    for (int f = 0; f < 4; f++)
                    {
                        if (f != Fila)//Para no hacer cero a la fila seleccionada!!!
                        {
                            int ValorColumnaEnF = MatrizEntradaF[f, Columna];
                            for (int c = 0; c < CantColumnas; c++)
                            {
                                //Entrada
                                MatrizEntradaF[f, c] = (MatrizEntradaF[f, c] - MatrizEntradaF[Fila, c] * ValorColumnaEnF) % 27; //Fila queda fija

                                //Salida
                                MatrizSalidaF[f, c] = (MatrizSalidaF[f, c] - MatrizSalidaF[Fila, c] * ValorColumnaEnF) % 27; //Fila queda fija
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n\n***************************************\n{0} NO ES COPRIMO DE 27\n\n", ValorSeleccionado);
                }




            } while (!(Fila == 0 && Columna == 0));

        }


        private static void ImprimirMatrizAmpliada(int cantFilas, int CantColumnas, int[,] MatrizEntradaF, int[,] MatrizSalidaF)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Matriz Ampliada a analizar");

            for (int i = 0; i < CantColumnas; i++)
            {
                Console.Write("{0,4}", i);
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int f = 0; f < cantFilas; f++)
            {
                for (int c = 0; c < CantColumnas; c++)
                {
                    Console.Write("{0,4}", MatrizEntradaF[f, c]);
                    if (Coprimos27.ContainsKey(MatrizEntradaF[f, c]))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write(" | ");
                for (int c = 0; c < CantColumnas; c++)
                {
                    Console.Write("{0,4}", MatrizSalidaF[f, c]);
                }
                Console.WriteLine();
            }
        }
    }

}
