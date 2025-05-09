using BrainZap_Client.CLASSES;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrainZap_Client.FORMULARIOS
{
    public partial class FrmResultado : Form
    {
        private ClJugador jugador;
        private ClSocketClient socket;
        private bool acierto;
        private int puntosGanados;
        private string[] top3;

        public FrmResultado(ClJugador jugador, ClSocketClient socket, bool acierto, int puntosGanados, string[] top3)
        {
            InitializeComponent();
            this.jugador = jugador;
            this.socket = socket;
            this.acierto = acierto;
            this.puntosGanados = puntosGanados;
            this.top3 = top3;

            mostrarResultado();
        }

        private void mostrarResultado()
        {
            // Cambiar color del panel según acierto
            if (acierto)
            {
                panelResultado.BackColor = Color.ForestGreen;
                lblTitulo.Text = "¡Correcto!";
            }
            else
            {
                panelResultado.BackColor = Color.Firebrick;
                lblTitulo.Text = "¡Incorrecto!";
            }

            // Mostrar puntos ganados
            lblPuntos.Text = $"+{puntosGanados} puntos";

            // Mostrar top 3 si disponible
            if (top3.Length >= 3)
            {
                lblTop1.Text = formatearJugador(top3[0]);
                lblTop2.Text = formatearJugador(top3[1]);
                lblTop3.Text = formatearJugador(top3[2]);
            }
        }

        private string formatearJugador(string entrada)
        {
            // Espera formato: "Juan:1500"
            if (entrada.Contains(":"))
            {
                var partes = entrada.Split(':');
                return $"{partes[0]} - {partes[1]} pts";
            }
            return entrada;
        }
    }
}
