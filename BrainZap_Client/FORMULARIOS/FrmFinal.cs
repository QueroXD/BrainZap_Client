using System;
using System.Drawing;
using System.Windows.Forms;
using BrainZap_Client.CLASSES;

namespace BrainZap_Client.FORMULARIOS
{
    public partial class FrmFinal : Form
    {
        private ClSocketClient socket;
        private string[] top3;

        public FrmFinal(ClSocketClient socket, string[] top3)
        {
            InitializeComponent();
            this.socket = socket;
            this.top3 = top3;

            mostrarRanking();
        }

        private void mostrarRanking()
        {
            if (top3.Length > 0)
            {
                string ganador = obtenerNombre(top3[0]);
                lblGanador.Text = $"Ganador: {ganador}";
            }

            if (top3.Length > 0) lblTop1.Text = $"🥇 {formatearJugador(top3[0])}";
            if (top3.Length > 1) lblTop2.Text = $"🥈 {formatearJugador(top3[1])}";
            if (top3.Length > 2) lblTop3.Text = $"🥉 {formatearJugador(top3[2])}";
        }

        private string formatearJugador(string entrada)
        {
            // Entrada esperada: "Juan:4500"
            if (entrada.Contains(":"))
            {
                var partes = entrada.Split(':');
                return $"{partes[0]} - {partes[1]} pts";
            }
            return entrada;
        }

        private string obtenerNombre(string entrada)
        {
            return entrada.Contains(":") ? entrada.Split(':')[0] : entrada;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            socket?.desconectar();
            Application.Exit();
        }
    }
}
