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
        private FrmResultado frmResultadoActual;


        public FrmPregunta(ClJugador jugador, ClSocketClient socket, string mensajeInicial = null)
        {
            InitializeComponent();
            this.jugador = jugador;
            this.socket = socket;

            inicializarTimer();
            socket.PreguntaRecibida += onMensajeRecibido;
            socket.ResultadoRecibido += onResultadoRecibido;

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
                    // Cerramos el FrmResultado si está abierto
                    if (frmResultadoActual != null && !frmResultadoActual.IsDisposed)
                    {
                        frmResultadoActual.Close();
                        frmResultadoActual = null;
                    }

                    mostrarPregunta(mensaje); // Mostrar nueva pregunta
                }));
            }
        }

        private void mostrarPregunta(string mensaje)
        {
            desbloquearRespuestas();
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
            btnResp1.Enabled = btnResp2.Enabled = btnResp3.Enabled = btnResp4.Enabled = false;

            if (respSeleccionada == 0)
            {
                btnResp1.ForeColor = Color.White;
                btnResp2.BackColor = btnResp3.BackColor = btnResp4.BackColor = Color.Gray;
            } else if (respSeleccionada == 1)
            {
                btnResp2.ForeColor = Color.White;
                btnResp1.BackColor = btnResp3.BackColor = btnResp4.BackColor = Color.Gray;
            } else if( respSeleccionada == 2)
            {
                btnResp3.ForeColor = Color.White;
                btnResp1.BackColor = btnResp2.BackColor = btnResp4.BackColor = Color.Gray;
            } else if (respSeleccionada == 3)
            {
                btnResp4.ForeColor = Color.White;
                btnResp1.BackColor = btnResp2.BackColor = btnResp3.BackColor = Color.Gray;
            }
            else
            {
                btnResp1.Enabled = btnResp2.Enabled = btnResp3.Enabled = btnResp4.Enabled = false;
                btnResp1.BackColor = btnResp2.BackColor = btnResp3.BackColor = btnResp4.BackColor = Color.Gray;
            }
        }

        private void desbloquearRespuestas()
        {
            btnResp1.Enabled = btnResp2.Enabled = btnResp3.Enabled = btnResp4.Enabled = true;
            btnResp1.BackColor = Color.Red;
            btnResp2.BackColor = Color.Blue;
            btnResp3.BackColor = Color.Yellow;
            btnResp4.BackColor = Color.Green;
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

        private void onResultadoRecibido(string mensaje)
        {
            this.Invoke(new Action(() =>
            {
                // Formato: RESULTADO|nick|CORRECTO|puntosGanados|nick1:puntos1,nick2:puntos2,nick3:puntos3
                string[] partes = mensaje.Split('|');
                if (partes.Length >= 5)
                {
                    string estado = partes[2]; // CORRECTO o INCORRECTO
                    bool acierto = estado == "CORRECTO";
                    int puntosGanados = int.TryParse(partes[3], out int puntos) ? puntos : 0;
                    string[] top3 = partes[4].Split(',');

                    frmResultadoActual = new FrmResultado(jugador, socket, acierto, puntosGanados, top3);
                    frmResultadoActual.FormClosed += (s, args) =>
                    {
                        this.Show(); // Volver a mostrar FrmPregunta al cerrarse el resultado
                        frmResultadoActual = null; // Liberamos referencia
                    };

                    this.Hide(); // Ocultamos FrmPregunta mientras se ve el resultado
                    frmResultadoActual.Show();

                }
            }));
        }

    }
}

