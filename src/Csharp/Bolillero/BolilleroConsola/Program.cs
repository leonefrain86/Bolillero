using System;
using BolilleroBiblioteca;
using System.Collections.Generic;
using System.Linq;

namespace BolilleroConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime FH;

            Bolillero unBolillero = new Bolillero(10);

            informeBolillero(unBolillero);

            List<int> bolillas = new List<int> { 0, 1, 4};

            Simulación s = new Simulación();

            FH = DateTime.Now;
            Console.WriteLine(s.simularSinHilos(unBolillero, bolillas, 10000000));
            Console.WriteLine($"Duración sin hilos: {DateTime.Now - FH}");

            FH = DateTime.Now;
            Console.WriteLine(s.simularConHilos(unBolillero, bolillas, 10000000, 3));
            Console.WriteLine($"Duración con hilos: {DateTime.Now - FH}");

            // // CASO DE UNA SOLA JUGADA
            // Console.WriteLine($"Gano: {unBolillero.unaJugada(bolillas)}");

            // // CASO DE MAS DE UNA JUGADA
            // Console.WriteLine($"Usted gano: {unBolillero.jugarNVeces(bolillas,10000000)} veces");
            informeBolillero(unBolillero);
        
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
