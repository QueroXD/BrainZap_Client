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

        public FrmMain()
        {
            InitializeComponent();
            socket = new ClSocketClient();
            socket.iniciarEscucha();
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
                socket.PreguntaRecibida += onPreguntaRecibida;
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
                this.Hide();
                FrmPregunta frmPregunta = new FrmPregunta(jugador, socket);
                frmPregunta.FormClosed += (s, args) => this.Close();
                frmPregunta.Show();
            }));
        }
    }
}
