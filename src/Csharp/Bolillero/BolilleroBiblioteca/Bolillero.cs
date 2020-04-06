using System;
using System.Collections.Generic;
using System.Linq;

namespace BolilleroBiblioteca
{
    public class Bolillero
    {
        public List<int> bolillas {get; set;}

        public Bolillero()
        {
            bolillas = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        public int sacarBolilla()
        {
            int bolilla =  this.bolillas[new Random().Next(bolillas.Count())];
            bolillas.Remove(bolilla);
            return bolilla;

        }

        public void devolverBolillas(List<int> bolillas) => this.bolillas.AddRange(bolillas);


        public bool unaJugada (List<int> bolillas)
        {
            List<int> bolillasSacadas = new List<int>();
            foreach (int bolilla  in  bolillas )
            {
                bolillasSacadas.Add(sacarBolilla());
                if(bolillasSacadas.Last() != bolilla)
                {
                    devolverBolillas(bolillasSacadas);
                    return false;
                }
            }
            devolverBolillas(bolillasSacadas);
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
