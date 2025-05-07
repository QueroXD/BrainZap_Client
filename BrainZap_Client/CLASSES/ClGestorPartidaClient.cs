using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainZap_Client.CLASSES
{
    internal class ClGestorPartidaClient
    {
        //Controla el juego desde el lado del cliente.

        private ClSocketClient socket;
        private ClJugador jugador;

        public ClGestorPartidaClient(ClSocketClient socket, ClJugador jugador)
        {
            this.socket = socket;
            this.jugador = jugador;
        }

        public void iniciarPartida()
        {
            Console.WriteLine("Esperando preguntas del servidor...");

            while (true)
            {
                string mensaje = socket.recibir();

                if (mensaje == null)
                    break;

                if (mensaje.StartsWith("PREGUNTA:"))
                {
                    mostrarYResponderPregunta(mensaje);
                }
                else if (mensaje.StartsWith("FIN"))
                {
                    Console.WriteLine("Partida finalizada.");
                    break;
                }
                else
                {
                    Console.WriteLine("Mensaje: " + mensaje);
                }
            }
        }

        private void mostrarYResponderPregunta(string mensaje)
        {
            Console.WriteLine("\n" + mensaje.Replace("PREGUNTA:", ""));
            Console.Write("Tu respuesta: ");
            string respuesta = Console.ReadLine();
            socket.enviar(respuesta);
        }
    }
}
