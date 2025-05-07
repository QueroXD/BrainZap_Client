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
        private int tiempoRestante = 30;
        private Timer timer;

        public FrmPregunta(ClJugador jugador, ClSocketClient socket)
        {
            InitializeComponent();
            this.jugador = jugador;
            this.socket = socket;

            InicializarTimer();
            socket.mensajeRecibido += onMensajeRecibido;

            // En caso de que la pregunta ya esté recibida al iniciar
            socket.solicitarPregunta();
        }

        private void InicializarTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tiempoRestante--;
            pbTiempo.Value = Math.Max(0, tiempoRestante * 100 / 15);

            if (tiempoRestante <= 0)
            {
                timer.Stop();
                bloquearRespuestas();
                enviarRespuesta(-1); // No respondió
            }
        }

        private void onMensajeRecibido(string mensaje)
        {
            if (mensaje.StartsWith("PREGUNTA"))
            {
                Invoke(new Action(() =>
                {
                    mostrarPregunta(mensaje);
                }));
            }
        }

        private void mostrarPregunta(string mensaje)
        {
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
                tiempoRestante = 30;
                pbTiempo.Value = 100;
                timer.Start();
            }
        }

        private void bloquearRespuestas()
        {
            btnResp1.Enabled = btnResp2.Enabled = btnResp3.Enabled = btnResp4.Enabled = false;
        }

        private void enviarRespuesta(int indice)
        {
            socket.enviarMensaje($"RESPUESTA|{indice}");
            // Cambiar a formulario de resultado
            //FrmResultado frmResultado = new FrmResultado(jugador, socket);
            //frmResultado.FormClosed += (s, e) => this.Close();
            //this.Hide();
            //frmResultado.Show();
        }

        private void btnResp1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            bloquearRespuestas();

            Button boton = sender as Button;
            int respSeleccionada = -1;

            if (boton == btnResp1) respSeleccionada = 0;
            else if (boton == btnResp2) respSeleccionada = 1;
            else if (boton == btnResp3) respSeleccionada = 2;
            else if (boton == btnResp4) respSeleccionada = 3;

            enviarRespuesta(respSeleccionada);
        }
    }
}

