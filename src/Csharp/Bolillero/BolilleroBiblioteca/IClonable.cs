using System.Collections.Generic;

namespace BolilleroBiblioteca
{
    public interface IClonable
    {
        void sacarBolilla();
        void devolverBolillas();
        bool unaJugada(List<int> bolillas);
        int jugarNVeces(List<int> bolillas, int num);
        Bolillero clonarBolillero();
    }
}