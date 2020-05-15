using System;
using System.Collections.Generic;
using System.Linq;

namespace BolilleroBiblioteca
{
    public class Bolillero: ICloneable
    {
        public List<int> bolillas {get; set;}
        public List<int> bolillasAfuera {get; set;}

        public Bolillero()
        {
            bolillas = new List<int> { 0, 1 };
            bolillasAfuera = new List<int> {3, 5, 6};
        }

        public Bolillero( List<int> bolillasC, List<int> bolillasAfueraC) 
        {
            this.bolillas = new List<int>(bolillasC);
            this.bolillasAfuera = new List<int>(bolillasAfueraC);
        }

        public void sacarBolilla()
        {
            int bolilla =  this.bolillas[new Random().Next(bolillas.Count())];
            bolillasAfuera.Add(bolilla);
            bolillas.Remove(bolilla);
        }

        public void devolverBolillas()
        {
            this.bolillas.AddRange(bolillasAfuera);
            this.bolillasAfuera.Clear();
        }

        public bool unaJugada (List<int> bolillas)
        {
            foreach (int bolilla  in  bolillas )
            {
                this.sacarBolilla();
                if(bolillasAfuera.Last() != bolilla)
                {
                    devolverBolillas();
                    return false;
                }
            }
            devolverBolillas();
            return true;
        }

        public int jugarNVeces (List<int> bolillas, int num)
        {
            int contador = 0;
            for (int i = 0; i < num; i++)
            {
                if (this.unaJugada(bolillas))
                {
                    contador++;
                }
            }
            return contador;
        }
        
        public object Clone() => new Bolillero(this.bolillas, this.bolillasAfuera);

    }
}
