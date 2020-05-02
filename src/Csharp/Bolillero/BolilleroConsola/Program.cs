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

            // USANDO 5 BOLILLAS PARA JUGAR
            List<int> bolillas = new List<int> { 0, 1, 5, 6, 2 };

            Simulación s = new Simulación();

            Console.WriteLine(s.simularSinHilos(unBolillero, bolillas, 10000000));
            Console.WriteLine(s.simularConHilos(unBolillero, bolillas, 10000000, 10));

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
