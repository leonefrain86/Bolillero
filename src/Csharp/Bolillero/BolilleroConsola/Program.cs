using System;
using BolilleroBiblioteca;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BolilleroConsola
{
    class Program
    {
        // static async Task Main(string[] args)
        static void Main(string[] args)
        {
            DateTime FH;
            
            Bolillero unBolillero = new Bolillero(10);
            List<int> bolillas = new List<int> { 0, 1, 4};
            Simulación sml = new Simulación();

            //No devuelve el resultado esperado
            Console.WriteLine(sml.SimularConHilosAsync(unBolillero, bolillas, 10000000, 3));

            // Hago uso de await pero se bloquea el resto de los procesos
            // Console.WriteLine(await sml.SimularConHilosAsync(unBolillero, bolillas, 10000000, 3));  

            FH = DateTime.Now;
            Console.WriteLine(sml.simularSinHilos(unBolillero, bolillas, 10000000));
            Console.WriteLine($"Duración sin hilos: {DateTime.Now - FH}");

            FH = DateTime.Now;
            Console.WriteLine(sml.simularConHilos(unBolillero, bolillas, 10000000, 3));
            Console.WriteLine($"Duración con hilos: {DateTime.Now - FH}");

            // Una idea que tuve pero no funcionó ya que eran diferentes tipos de metodos
            // await Task.WhenAll(simulacion.simularConHilos(), simulacion.SimularConHilosAsync(), simulacion.simularSinHilos())
            
            // // CASO DE UNA SOLA JUGADA
            // Console.WriteLine($"Gano: {unBolillero.unaJugada(bolillas)}");

            // // CASO DE MAS DE UNA JUGADA
            // Console.WriteLine($"Usted gano: {unBolillero.jugarNVeces(bolillas,10000000)} veces");
        }
        static void informeBolillero(Bolillero bolillero)
        {
            foreach (int bolilla in bolillero.bolillas)
            {
                Console.WriteLine($"bolilla: {bolilla}");
            }
        }
    }
}
