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
            Bolillero unBolillero = new Bolillero();

            List<int> bolillas = new List<int> { 0};

            Simulación s = new Simulación();

            Console.WriteLine(s.simularSinHilos(unBolillero, bolillas, 100));
            Console.WriteLine(s.simularConHilos(unBolillero, bolillas, 100, 3));
            
            // // CASO DE UNA SOLA JUGADA
            // Console.WriteLine($"Gano: {unBolillero.unaJugada(bolillas)}");

            // // CASO DE MAS DE UNA JUGADA
            // Console.WriteLine($"Usted gano: {unBolillero.jugarNVeces(bolillas,10000000)} veces");
            // informeBolillero(unBolillero);
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
