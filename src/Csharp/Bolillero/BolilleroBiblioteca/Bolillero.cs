using System;
using System.Collections.Generic;
using System.Linq;

namespace BolilleroBiblioteca
{
    public class Bolillero: ICloneable
    {
        public List<int> bolillas {get; set;}
        public List<int> bolillasAfuera {get; set;}
        public Random aleatorio {get; set;}

        public Bolillero()
        {
            bolillas = new List<int> ();
            bolillasAfuera = new List<int>();
            aleatorio = new Random();
        }

        public Bolillero( int cantBolillas) : this()
        {
            for (int i = 0; i < cantBolillas; i++)
            {
                this.bolillas.Add(i);
            }
        }

        public void sacarBolilla()
        {
            int bolilla =  this.bolillas[aleatorio.Next(bolillas.Count())];
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

        // public object Clone() => new Bolillero(this.bolillas, this.bolillasAfuera);
        public object Clone() => new Bolillero() { bolillasAfuera = new List<int>(this.bolillasAfuera),
                                                   bolillas = new List<int>(this.bolillas)};

    }
}
