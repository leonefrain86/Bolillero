using System;
using System.Collections.Generic;
using System.Linq;

namespace BolilleroBiblioteca
{
    public class Bolillero
    {
        public List<Bolilla> bolillas {get; set;}

        public Bolillero()
        {
            this.bolillas = new List<Bolilla>{
                new Bolilla("rojo", 0),
                new Bolilla("azul", 1),
                new Bolilla("verde", 2),
                new Bolilla("negro", 3),
                new Bolilla("naranja", 4),
                new Bolilla("violeta", 5),
                new Bolilla("amarillo", 6),
                new Bolilla("marón", 7),
                new Bolilla("griz", 8),
                new Bolilla("rosado", 9)
            };
        }

        public Bolilla sacarBolilla()
        {
            Bolilla bolilla =  this.bolillas[new Random().Next(bolillas.Count())];
            bolillas.Remove(bolilla);
            return bolilla;
        }

        public void devolverBolillas(List<Bolilla> bolillas)
        {
            foreach (var bolilla in bolillas)
            {
                this.bolillas.Add(bolilla);
            }
        }

        public bool unaJugada (List<Bolilla> bolillas)
        {
            int comprobador = 0;
            List<Bolilla> bolillasSacadas = new List<Bolilla>(); //Cree una lista ya que es mas logico que se devuelvan todas las bolillas al terminar un juego.
            foreach (var bolilla in bolillas)
            {
                bolillasSacadas.Add(sacarBolilla());
                if(bolillasSacadas.Last().num == bolilla.num)
                {
                    comprobador++;
                }
            }
            devolverBolillas(bolillasSacadas);
            return comprobador == bolillas.Count();
        }

        public int jugarNVeces (List<Bolilla> bolillas, int num)
        {
            int contador = 0;
            for (int i = 0; i < num; i++)
            {
                if (unaJugada(bolillas))
                {
                    contador++;
                }
            }
            return contador;
        }
    }
}
