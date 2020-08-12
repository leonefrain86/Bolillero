using System;
using System.Diagnostics;
using BolilleroBiblioteca;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolilleroConsola
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            Bolillero unBolillero = new Bolillero(10);
            List<int> bolillas = new List<int> { 1, 5, 3};
            Simulación sml = new Simulación();

            stopWatch.Start();
            Console.WriteLine(sml.simularSinHilos(unBolillero, bolillas, 10000000));
            stopWatch.Stop();
            Console.WriteLine($"Duración sin hilos: {stopWatch.Elapsed}");

            stopWatch.Restart();
            Console.WriteLine(sml.simularConHilos(unBolillero, bolillas, 10000000, 3));
            stopWatch.Stop();
            Console.WriteLine($"Duración con hilos: {stopWatch.Elapsed}");

            stopWatch.Restart();
            Console.WriteLine(await sml.SimularConHilosAsync(unBolillero, bolillas, 10000000, 3));
            stopWatch.Stop();
            Console.WriteLine($"Duración con hilos y Async: {stopWatch.Elapsed}");

            stopWatch.Restart();
            Console.WriteLine(await sml.SimularParallelAsync(unBolillero, bolillas, 10000000, 3));
            stopWatch.Stop();
            Console.WriteLine($"Duración con Parallel y Async: {stopWatch.Elapsed}");
            
            // // CASO DE UNA SOLA JUGADA
            // Console.WriteLine($"Gano: {unBolillero.unaJugada(bolillas)}");

            // // CASO DE MAS DE UNA JUGADA
            // Console.WriteLine($"Usted gano: {unBolillero.jugarNVeces(bolillas,10000000)} veces");

            // Console.WriteLine(50 / 4);
        }
        // static void informeBolillero(Bolillero bolillero)
        // {
        //     foreach (int bolilla in bolillero.bolillas)
        //     {
        //         Console.WriteLine($"bolilla: {bolilla}");
        //     }
        // }
    }
}
