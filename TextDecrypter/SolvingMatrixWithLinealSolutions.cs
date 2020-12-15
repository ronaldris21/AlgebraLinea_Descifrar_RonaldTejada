using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDecrypter
{
    public class SolvingMatrixWithLinealSolutions
    {

        //SolvingMatrixWithLinealSolutions MatrixSolver = new SolvingMatrixWithLinealSolutions();
        //MatrixSolver.Find_Key_Matrix();

        public void Find_Key_Matrix()
        {
            int repetidas = 0;
            //Pruebas de resolución de matrices usando la forma
            //Ab = C
            //Donde solo conozco la matriz C y la matriz A
            //En este caso tengo C y estoy usando valores random de A que seria la clave usada para encryptar


            List<Matrix<Double>> matricesEmpleadas = new List<Matrix<Double>>();
            while (true)
            {

                //var ClaveMatrix = Matrix<Double>.Build.DenseOfArray(new Double[,] {
                //    { 6, 4, -2 },
                //    { 4, -4, 8 },
                //    { -2, 1, -2 }
                //});
                var watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 100000; i++)
                {
                    Matrix<Double> randomMatrix = Matrix<Double>.Build.Random(3, 3).PointwiseFloor();
                    //Resuelvo la matrix
                    try
                    {
                        if (!matricesEmpleadas.Contains(randomMatrix))
                        {
                            //Agrego la matriz
                            matricesEmpleadas.Add(randomMatrix.PointwiseFloor());
                            var resultProvidedMatrix = Vector<Double>.Build.Dense(new double[] { 25, 4, 15 });
                            var originalTextMatrix = randomMatrix.Solve(resultProvidedMatrix);
                            //Imprimo la solución
                            Console.WriteLine(randomMatrix);
                            System.Console.WriteLine(originalTextMatrix);
                            Console.WriteLine("\n\n");
                        }
                        else
                        {
                            repetidas++;
                        }
                    }
                    catch (Exception)
                    { //Insoluble}

                    }
                }
                watch.Stop();
                Console.WriteLine("\n\nRepetidas " + repetidas);
                Console.WriteLine("Tiempo {0} seconds", watch.Elapsed.TotalSeconds);


            }

        }
    }
}
