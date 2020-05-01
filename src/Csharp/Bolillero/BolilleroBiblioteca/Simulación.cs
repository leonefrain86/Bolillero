using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BolilleroBiblioteca
{
    public class Simulación
    {
        public int simularSinHilos(Bolillero unBolillero, List<int> unaJugada, int cntSimulaciones) 
                    => unBolillero.jugarNVeces(unaJugada,cntSimulaciones);

        public int simularConHilos(Bolillero unBolillero, List<int> unaJugada, int cntSimulaciones, int cntHilos)
        {
            Task<int>[] tareas = new Task<int>[cntHilos];
            int simulacionesPorHilo = cntSimulaciones/cntHilos;

            for (int i = 0; i < cntHilos; i++)
            {
                var clon = (Bolillero)unBolillero.Clone();
                tareas[i] = new Task<int>(() => clon.jugarNVeces(unaJugada, simulacionesPorHilo));
            }

            foreach (var tarea in tareas)
            {
                tarea.Start();
            }

            Task<int>.WaitAll(tareas);

            return tareas.Sum(x => x.Result);
        }
        
    }
}