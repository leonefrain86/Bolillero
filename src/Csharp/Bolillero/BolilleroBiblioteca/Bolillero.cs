using System;
using System.Collections.Generic;
using System.Linq;

namespace BolilleroBiblioteca
{
    public class Bolillero: ICloneable
    {
        public List<int> bolillas {get; set;}
        public List<int> bolillasClon {get; set;}

        public Bolillero()
        {
            bolillas = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bolillasClon = new List<int>(bolillas);
        }

        public int sacarBolilla()
        {
            int bolilla =  this.bolillas[new Random().Next(bolillas.Count())];
            bolillas.Remove(bolilla);
            return bolilla;
        }

        public void devolverBolillas() => bolillas = new List<int>(bolillasClon);

        public bool unaJugada (List<int> bolillas)
        {
            foreach (int bolilla  in  bolillas )
            {
                if(this.sacarBolilla() != bolilla)
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
        
        public object Clone() => new Bolillero();
                
    }
}
