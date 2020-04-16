using System;
using System.Collections.Generic;
using System.Linq;

namespace BolilleroBiblioteca
{
    public class Bolillero
    {
        public List<int> bolillas {get; set;}
        public List<int> bolillasSacadas {get; set;}

        public Bolillero()
        {
            bolillas = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bolillasSacadas = new List<int>();
        }

        public void sacarBolilla()
        {
            int bolilla =  this.bolillas[new Random().Next(bolillas.Count())];
            bolillasSacadas.Add(bolilla);
            bolillas.Remove(bolilla);
        }

        public void devolverBolillas() 
        {
            this.bolillas.AddRange(bolillasSacadas);
            this.bolillasSacadas.Clear();
        }


        public bool unaJugada (List<int> bolillas)
        {
            foreach (int bolilla  in  bolillas )
            {
                this.sacarBolilla();
                if(bolillasSacadas.Last() != bolilla)
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
    }
}
