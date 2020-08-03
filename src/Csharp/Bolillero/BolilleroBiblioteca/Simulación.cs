using System.Collections.Generic;
// using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;

namespace BolilleroBiblioteca
{
    public class Simulación
    {
        public int simularSinHilos(Bolillero unBolillero, List<int> unaJugada, int cntSimulaciones) 
                    => unBolillero.jugarNVeces(unaJugada,cntSimulaciones);

        public int simularConHilos(Bolillero unBolillero, List<int> unaJugada, int cntSimulaciones, int cntHilos)
        {
            Task<int>[] tareas = new Task<int>[cntHilos];
            int restoSXH = cntSimulaciones % cntHilos;

            for (int i = 0; i < cntHilos; i++)
            {
                var clon = (Bolillero)unBolillero.Clone();
                int simulacionesXH = cntSimulaciones / cntHilos + 1;
                if(i >= restoSXH)
                {
                    simulacionesXH = cntSimulaciones / cntHilos;
                }
                tareas[i] = Task.Run(() => clon.jugarNVeces(unaJugada, simulacionesXH));
                
            }
            Task<int>.WaitAll(tareas);
            
            return tareas.Sum(x => x.Result);
        }
        
        public async Task<int> SimularConHilosAsync(Bolillero unBolillero, List<int> unaJugada, int cntSimulaciones, int cntHilos)
        {
            Task<int>[] tareas = new Task<int>[cntHilos];
            int restoSXH = cntSimulaciones % cntHilos;

            for (int i = 0; i < cntHilos; i++)
            {
                var clon = (Bolillero)unBolillero.Clone();
                int simulacionesXH = cntSimulaciones / cntHilos + 1;
                if (i >= restoSXH)
                {
                    simulacionesXH = cntSimulaciones / cntHilos;
                }
                tareas[i] = Task.Run(() => clon.jugarNVeces(unaJugada, simulacionesXH));
            }
            await Task<int>.WhenAll(tareas);

            return tareas.Sum(x => x.Result);  
        }

        public async Task<int> SimularParallelAsync (Bolillero unBolillero, List<int> unaJugada,
                                                      int cntSimulaciones, int cntHilos)
        {
            Task<int>[] tareas = new Task<int>[cntHilos]; // Coleccion de task que cuando finaliza devuelve int
            // ConcurrentBag<int> tareas2 = new ConcurrentBag<int>[cntHilos]; // Coleccion segura para hilos
            List<int> tareasList = new List<int>();

            int restoSXH = cntSimulaciones % cntHilos;


            await Task.Run(() => Parallel.For(0, cntHilos, i => {
                var clon = (Bolillero)unBolillero.Clone();
                int simulacionesXH = cntSimulaciones / cntHilos + 1;
                if (i >= restoSXH)
                {
                    simulacionesXH = cntSimulaciones / cntHilos;
                }
                tareasList.Add(clon.jugarNVeces(unaJugada, simulacionesXH));
            }));

            // Parallel.ForEach(tareas, tarea => {
            //     var clon = (Bolillero)unBolillero.Clone();
                
            //     tarea = Task.Run(() => clon.jugarNVeces(unaJugada, cntSimulaciones/tareas.Count()));
                
            // });

            // Parallel.ForEach(tareas, x => x.Start());

            // Parallel.For(0, words.Length, i => results[i] = AddB(words[i]));

            // Parallel.For(inicio, fin, accion);
            // Parallel.ForEach(Lista, accion);

            // int restoSXH = cntSimulaciones % cntHilos;

            // for (int i = 0; i < cntHilos; i++)
            // {
            //     var clon = (Bolillero)unBolillero.Clone();
            //     int simulacionesXH = cntSimulaciones / cntHilos + 1;
            //     if (i >= restoSXH)
            //     {
            //         simulacionesXH = cntSimulaciones / cntHilos;
            //     }
            //     tareas[i] = Task.Run(() => clon.jugarNVeces(unaJugada, simulacionesXH));
            // }
            // Parallel.ForEach(tareas, x => x.Start());
            

            return tareasList.Sum();
        }
    }
}