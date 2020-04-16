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

            // SOLO SE USAN 5 BOLILLAS PARA JUGAR
            List<int> bolillas = new List<int> { 2, 4, 6, 1, 3 };
            
            // CASO DE UNA SOLA JUGADA
            Console.WriteLine($"Gano: {unBolillero.unaJugada(bolillas)}");

            // CASO DE MAS DE UNA JUGADA
            Console.WriteLine($"Usted gano: {unBolillero.jugarNVeces(bolillas,1000000)} veces");
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
