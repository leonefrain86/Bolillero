using BolilleroBiblioteca;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolilleroConsola
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Bolillero unBolillero = new Bolillero(10);
            List<int> bolillas = new List<int> { 1, 5, 3};
            var bs = new BuilderSimulacion();

            /*pensar que tiene que devolver cualquiera de los metodos
              Set... para que la llamadas encadenadas sean validas.
              CrearSimulacion() es el unico método que devuelve un obj Simulacion*/
            var sml = bs.SetBollilero(unBolillero)
                        .SetBolillas(bolillas)
                        .SetSimulaciones(10000000)
                        .SetHilos(3)
                        .CrearSimulacion();

            sml.IniciarCronometro();
            Console.WriteLine(sml.simularSinHilos());
            sml.DetenerCronometro();
            Console.WriteLine($"Duración sin hilos: {sml.Duracion}");

            sml.ReiniciarCronometro();
            Console.WriteLine(sml.simularConHilos());
            sml.DetenerCronometro();
            Console.WriteLine($"Duración con hilos: {sml.Duracion}");

            sml.ReiniciarCronometro();
            Console.WriteLine(await sml.SimularConHilosAsync());
            sml.DetenerCronometro();
            Console.WriteLine($"Duración con hilos y Async: {sml.Duracion}");

            sml.ReiniciarCronometro();
            Console.WriteLine(await sml.SimularParallelAsync());
            sml.DetenerCronometro();
            Console.WriteLine($"Duración con Parallel y Async: {sml.Duracion}");
        }        
    }
}