using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainZap_Client.CLASSES
{
    public class ClJugador
    {
        //Representa al jugador local: nickname, puntuación.

        public string username { get; private set; }
        public int puntos { get; private set; }

        public ClJugador(string nickname)
        {
            username = nickname;
            puntos = 0;
        }

        public void sumarPuntos(int cont)
        {
            puntos += cont;
        }

        /*public void reiniciarPuntos()
        {
            puntos = 0;
        }

        public override string ToString()
        {
            return $"{username} - {puntos} pts";
        }*/
    }
}
