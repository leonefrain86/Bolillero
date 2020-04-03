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
            List<Bolilla> bolillas = new List<Bolilla>{
                new Bolilla("rojo", 0),
                new Bolilla("azul", 1),
                new Bolilla("verde", 5),
                new Bolilla("negro", 3),
                new Bolilla("naranja", 7)
            };
            
            // CASO DE UNA SOLA JUGADA
            Console.WriteLine($"Gano: {unBolillero.unaJugada(bolillas)}");
            informeBolillero(unBolillero);

            // CASO DE MAS DE UNA JUGADA
            Console.WriteLine($"Usted gano: {unBolillero.jugarNVeces(bolillas,1000000)} veces");
            informeBolillero(unBolillero);
        }
        static void informeBolillero(Bolillero bolillero)
        {
            foreach (var bolilla in bolillero.bolillas)
            {
                Console.WriteLine($"color: {bolilla.color} num: {bolilla.num}");
            } 
        }
    }
}
