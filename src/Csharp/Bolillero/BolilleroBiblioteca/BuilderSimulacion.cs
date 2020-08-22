using System;
using System.Collections.Generic;
using System.Text;

namespace BolilleroBiblioteca
{
    public class BuilderSimulacion
    {
        public Simulación sml;
        public BuilderSimulacion()
        {
            sml = new Simulación();
        }

        public BuilderSimulacion SetBolillero(Bolillero bolillero) 
        {
            this.sml.bolillero = bolillero;
            return this;
        }   

        public BuilderSimulacion SetBolillas(List<int> bolillas)
        {
            this.sml.bolillas = bolillas;
            return this;
        }

        public BuilderSimulacion SetSimulaciones(int cantSimulaciones)
        {
            this.sml.cntSimulaciones = cantSimulaciones;
            return this;
        }

        public BuilderSimulacion SetHilos(int cantHilos)
        {
            this.sml.cntHilos = cantHilos;
            return this;
        }

        public Simulación CrearSimulacion()
        {
            return this.sml;
        }
    }
}
