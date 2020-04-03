using System;

namespace BolilleroBiblioteca
{
    public class Bolilla
    {
        public string color {get; set;}
        public int num {get; set;}

        public Bolilla()
        {
            
        }

        public Bolilla(string color, int num)
        {
            this.color = color;
            this.num = num;
        }
    }
}