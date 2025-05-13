using BrainZap_Client.CLASSES;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrainZap_Client.FORMULARIOS
{
    public partial class FrmPregunta : Form
    {
        private ClJugador jugador;
        private ClSocketClient socket;
        private string[] respuestas = new string[4];
        private const int tiempoMaximo = 30;
        private int tiempoRestante = tiempoMaximo;
        private Timer timer;

        public FrmPregunta(ClJugador jugador, ClSocketClient socket, string mensajeInicial = null)
        {
            InitializeComponent();
            this.jugador = jugador;
            this.socket = socket;

            inicializarTimer();
            socket.PreguntaRecibida += onMensajeRecibido;

            if (!string.IsNullOrEmpty(mensajeInicial))
            {
                mostrarPregunta(mensajeInicial); // Muestra la pregunta que llegó antes de crear el formulario
            }
        }


        private void inicializarTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tiempoRestante--;
            pbTiempo.Value = Math.Max(0, tiempoRestante);

            if (tiempoRestante <= 0)
            {
                timer.Stop();
                bloquearRespuestas(-1);
                enviarRespuesta(-1); // No respondió
            }
        }

        private void onMensajeRecibido(string mensaje)
        {
            if (mensaje.StartsWith("PREGUNTA|"))
            {
                Invoke(new Action(() =>
                {
                    mostrarPregunta(mensaje);
                }));
            }
        }

        private void mostrarPregunta(string mensaje)
        {
            if (!this.Visible) { this.Show(); }

            string[] partes = mensaje.Split('|');
            if (partes.Length == 6)
            {
                lbPregunta.Text = partes[1];
                respuestas[0] = partes[2];
                respuestas[1] = partes[3];
                respuestas[2] = partes[4];
                respuestas[3] = partes[5];

                btnResp1.Text = respuestas[0];
                btnResp2.Text = respuestas[1];
                btnResp3.Text = respuestas[2];
                btnResp4.Text = respuestas[3];

                btnResp1.Enabled = btnResp2.Enabled = btnResp3.Enabled = btnResp4.Enabled = true;

                tiempoRestante = tiempoMaximo;
                pbTiempo.Minimum = 0;
                pbTiempo.Maximum = tiempoMaximo;
                pbTiempo.Value = tiempoMaximo;

                timer.Start();
            }
        }

        private void bloquearRespuestas(int respSeleccionada)
        {
            if (respSeleccionada == 1)
            {
                btnResp1.Enabled = false;
                btnResp2.BackColor = btnResp3.BackColor = btnResp4.BackColor = Color.Gray;
            } else if (respSeleccionada == 2)
            {
                btnResp2.Enabled = false;
                btnResp1.BackColor = btnResp3.BackColor = btnResp4.BackColor = Color.Gray;
            } else if( respSeleccionada == 3)
            {
                btnResp3.Enabled = false;
                btnResp1.BackColor = btnResp2.BackColor = btnResp4.BackColor = Color.Gray;
            } else if (respSeleccionada == 4)
            {
                btnResp4.Enabled = false;
                btnResp1.BackColor = btnResp2.BackColor = btnResp3.BackColor = Color.Gray;
            }
            else
            {
                btnResp1.Enabled = btnResp2.Enabled = btnResp3.Enabled = btnResp4.Enabled = false;
                btnResp1.BackColor = btnResp2.BackColor = btnResp3.BackColor = btnResp4.BackColor = Color.Gray;
            }
        }

        private void enviarRespuesta(int indice)
        {
            string respuesta = (indice >= 0 && indice < respuestas.Length) ? respuestas[indice] : "SINRESPUESTA";
            socket.enviarMensaje($"RESPUESTA|{jugador.username}|{lbPregunta.Text}|{respuesta}");
        }

        private void btnResp1_Click(object sender, EventArgs e)
        {
            timer.Stop();

            Button boton = sender as Button;
            int respSeleccionada = -1;

            if (boton == btnResp1) respSeleccionada = 0;
            else if (boton == btnResp2) respSeleccionada = 1;
            else if (boton == btnResp3) respSeleccionada = 2;
            else if (boton == btnResp4) respSeleccionada = 3;

            bloquearRespuestas(respSeleccionada);

            enviarRespuesta(respSeleccionada);
        }
    }
}

