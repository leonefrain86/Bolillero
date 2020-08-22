using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace BolilleroBiblioteca
{
    public class Simulación
    {
        internal Bolillero bolillero {get; set;}
        internal List<int> bolillas {get; set;}
        internal int cntSimulaciones {get; set;}
        internal int cntHilos {get; set;}
        
        internal Stopwatch stopWatch;
        public TimeSpan Duracion;

        internal Simulación()
        {
            this.stopWatch = new Stopwatch();
            Duracion = new TimeSpan();
        }
        public int simularSinHilos() 
                    => this.bolillero.jugarNVeces(this.bolillas, this.cntSimulaciones);

        public int simularConHilos()
        {
            Task<int>[] tareas = new Task<int>[cntHilos];
            int restoSXH = cntSimulaciones % cntHilos;

            for (int i = 0; i < cntHilos; i++)
            {
                var clon = (Bolillero)bolillero.Clone();
                int simulacionesXH = (cntSimulaciones / cntHilos) + 1;
                if(i >= restoSXH)
                {
                    simulacionesXH = cntSimulaciones / cntHilos;
                }
                tareas[i] = Task.Run(() => clon.jugarNVeces(bolillas, simulacionesXH));
                
            }
            Task<int>.WaitAll(tareas);
            
            return tareas.Sum(x => x.Result);
        }
        
        public async Task<int> SimularConHilosAsync()
        {
            Task<int>[] tareas = new Task<int>[cntHilos];
            int restoSXH = cntSimulaciones % cntHilos;

            for (int i = 0; i < cntHilos; i++)
            {
                var clon = (Bolillero)bolillero.Clone();
                int simulacionesXH = (cntSimulaciones / cntHilos) + 1;
                if (i >= restoSXH)
                {
                    simulacionesXH = cntSimulaciones / cntHilos;
                }
                tareas[i] = Task.Run(() => clon.jugarNVeces(bolillas, simulacionesXH));
            }
            await Task<int>.WhenAll(tareas);

            return tareas.Sum(x => x.Result);  
        }

        public async Task<int> SimularParallelAsync ()
        {
            int[] tareasArrays = new int [cntSimulaciones];

            int restoSXH = cntSimulaciones % cntHilos;

            // Parallel.For
            await   Task.Run(() =>
                                Parallel.For(0, cntHilos, i =>
                                                {
                                                    var clon = (Bolillero)bolillero.Clone();
                                                    int simulacionesXH = (cntSimulaciones / cntHilos) + 1;
                                                    if (i >= restoSXH)
                                                    {
                                                        simulacionesXH--;
                                                    }        
                                                    tareasArrays[i] = clon.jugarNVeces(bolillas, simulacionesXH);
                                                }
                                            )
                            );

            return tareasArrays.Sum();

        }        

        public void IniciarCronometro()
        {
            stopWatch.Start();
        }

        public void DetenerCronometro()
        {
            stopWatch.Stop();
            this.Duracion = stopWatch.Elapsed;
        }
        public void ReiniciarCronometro()
        {
            stopWatch.Restart();
        }     
    }
}