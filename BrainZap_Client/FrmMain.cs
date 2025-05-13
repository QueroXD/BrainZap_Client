using BrainZap_Client.CLASSES;
using BrainZap_Client.FORMULARIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainZap_Client
{
    public partial class FrmMain : Form
    {
        public ClSocketClient socket;
        public ClJugador jugador;
        private FrmPregunta frmPregunta;

        public FrmMain()
        {
            InitializeComponent();

            socket = new ClSocketClient();
            socket.iniciarEscucha();
            socket.PreguntaRecibida += onPreguntaRecibida;
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            string ip = tbIp.Text.Trim();
            string puertoStr = tbPuerto.Text.Trim();
            string nickname = tbNickname.Text.Trim();

            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(puertoStr) || string.IsNullOrEmpty(nickname))
            {
                MessageBox.Show("Completa todos los campos.");
            }

            if (!int.TryParse(puertoStr, out int puerto))
            {
                MessageBox.Show("El puerto debe ser un número válido.");
            }

            jugador = new ClJugador(nickname);

            bool conectado = socket.conectar(nickname, ip, puerto);

            if (conectado)
            {
                lbEstado.Text = "Conectado correctamente.";
            }
            else
            {
                lbEstado.Text = "No se pudo conectar al servidor.";
            }
        }

        private void onPreguntaRecibida(string mensaje)
        {
            this.Invoke(new Action(() =>
            {
                if (frmPregunta == null || frmPregunta.IsDisposed)
                {
                    this.Hide();
                    frmPregunta = new FrmPregunta(jugador, socket, mensaje); // Pasamos la pregunta que ya llegó
                    frmPregunta.FormClosed += (s, args) => this.Close();
                    frmPregunta.Show();
                }
            }));
        }

        private void responsiveForm()
        {
            int formCenterX = this.ClientSize.Width / 2;

            // Posicionar el título
            lbTitulo.Location = new Point(formCenterX - lbTitulo.Width / 2, 40);

            // Posiciones relativas centradas
            int centerInputsX = formCenterX - tbNickname.Width / 2;

            lbNickname.Location = new Point(centerInputsX, 130);
            tbNickname.Location = new Point(centerInputsX, 155);

            lbIp.Location = new Point(centerInputsX, 195);
            tbIp.Location = new Point(centerInputsX, 220);

            lbPuerto.Location = new Point(centerInputsX, 260);
            tbPuerto.Location = new Point(centerInputsX, 285);

            lbEstado.Location = new Point(centerInputsX + tbPuerto.Width + 10, 290);

            btConectar.Location = new Point(formCenterX - btConectar.Width / 2, 340);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            responsiveForm();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            responsiveForm();
        }
    }
}
