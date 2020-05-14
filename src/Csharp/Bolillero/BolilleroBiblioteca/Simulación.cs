using System.Collections.Generic;
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
                tareas[i].Wait();
            }

            return tareas.Sum(x => x.Result);
        }
        
    }
}