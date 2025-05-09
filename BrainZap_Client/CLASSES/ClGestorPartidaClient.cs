using System;
using System.Windows.Forms;
using BrainZap_Client.CLASSES;
using BrainZap_Client.FORMULARIOS;

namespace BrainZap_Client.GESTORES
{
    public class ClGestorPartidaClient
    {
        private ClSocketClient socket;
        private ClJugador jugador;

        private FrmPregunta frmPregunta;
        private FrmResultado frmResultado;
        private FrmFinal frmFinal;

        public ClGestorPartidaClient(ClSocketClient socket, ClJugador jugador)
        {
            this.socket = socket;
            this.jugador = jugador;

            // Suscripción al evento de mensajes entrantes
            socket.mensajeRecibido += onMensajeRecibido;
        }

        public void iniciar()
        {
            frmPregunta = new FrmPregunta(jugador, socket);
            frmPregunta.FormClosed += (s, e) => Application.Exit(); // Cierra todo al cerrar ventana de juego
            frmPregunta.Show();
        }

        private void onMensajeRecibido(string mensaje)
        {
            if (mensaje.StartsWith("PREGUNTA|"))
            {
                // La FrmPregunta ya se encarga de mostrarla, no hace falta intervenir aquí.
            }
            else if (mensaje.StartsWith("RESULTADO|"))
            {
                mostrarResultado(mensaje);
            }
            else if (mensaje.StartsWith("FINPARTIDA|"))
            {
                mostrarPantallaFinal(mensaje);
            }
        }

        private void mostrarResultado(string mensaje)
        {
            // Formato: RESULTADO|1|500|Juan:1500,Laura:1200,Pedro:1000
            string[] partes = mensaje.Split('|');
            if (partes.Length >= 4)
            {
                bool acertada = partes[1] == "1";
                int puntos = int.TryParse(partes[2], out int p) ? p : 0;
                string[] top3 = partes[3].Split(',');

                jugador.sumarPuntos(puntos);

                frmPregunta?.Invoke(new Action(() =>
                {
                    frmPregunta.Hide();
                    frmResultado = new FrmResultado(jugador, socket, acertada, puntos, top3);
                    frmResultado.FormClosed += (s, e) => frmPregunta.Close();
                    frmResultado.Show();
                }));
            }
        }

        private void mostrarPantallaFinal(string mensaje)
        {
            // Formato: FINPARTIDA|Juan:1500,Laura:1200,Pedro:1000
            string[] top3 = mensaje.Replace("FINPARTIDA|", "").Split(',');

            frmResultado?.Invoke(new Action(() =>
            {
                frmResultado.Hide();
                frmFinal = new FrmFinal(socket, top3);
                frmFinal.FormClosed += (s, e) => Application.Exit();
                frmFinal.Show();
            }));
        }
    }
}
