namespace BrainZap_Client.FORMULARIOS
{
    partial class FrmFinal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblGanador;
        private System.Windows.Forms.Panel panelRanking;
        private System.Windows.Forms.Label lblTop1;
        private System.Windows.Forms.Label lblTop2;
        private System.Windows.Forms.Label lblTop3;
        private System.Windows.Forms.Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblGanador = new System.Windows.Forms.Label();
            this.panelRanking = new System.Windows.Forms.Panel();
            this.lblTop1 = new System.Windows.Forms.Label();
            this.lblTop2 = new System.Windows.Forms.Label();
            this.lblTop3 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelRanking.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitulo.Location = new System.Drawing.Point(0, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(800, 50);
            this.lblTitulo.Text = "¡Partida finalizada!";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGanador
            this.lblGanador.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular);
            this.lblGanador.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblGanador.Location = new System.Drawing.Point(0, 80);
            this.lblGanador.Name = "lblGanador";
            this.lblGanador.Size = new System.Drawing.Size(800, 40);
            this.lblGanador.Text = "Ganador: Juan";
            this.lblGanador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRanking
            this.panelRanking.Controls.Add(this.lblTop1);
            this.panelRanking.Controls.Add(this.lblTop2);
            this.panelRanking.Controls.Add(this.lblTop3);
            this.panelRanking.Location = new System.Drawing.Point(150, 140);
            this.panelRanking.Size = new System.Drawing.Size(500, 150);
            this.panelRanking.Name = "panelRanking";
            // 
            // lblTop1
            this.lblTop1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTop1.ForeColor = System.Drawing.Color.Gold;
            this.lblTop1.Location = new System.Drawing.Point(0, 0);
            this.lblTop1.Size = new System.Drawing.Size(500, 40);
            this.lblTop1.Text = "🥇 Juan - 4500 pts";
            this.lblTop1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTop2
            this.lblTop2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTop2.ForeColor = System.Drawing.Color.Silver;
            this.lblTop2.Location = new System.Drawing.Point(0, 50);
            this.lblTop2.Size = new System.Drawing.Size(500, 30);
            this.lblTop2.Text = "🥈 Laura - 4000 pts";
            this.lblTop2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTop3
            this.lblTop3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTop3.ForeColor = System.Drawing.Color.Peru;
            this.lblTop3.Location = new System.Drawing.Point(0, 90);
            this.lblTop3.Size = new System.Drawing.Size(500, 30);
            this.lblTop3.Text = "🥉 Pedro - 3900 pts";
            this.lblTop3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCerrar.Location = new System.Drawing.Point(320, 320);
            this.btnCerrar.Size = new System.Drawing.Size(160, 40);
            this.btnCerrar.Text = "Salir";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmFinal
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panelRanking);
            this.Controls.Add(this.lblGanador);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmFinal";
            this.Text = "Ranking Final";
            this.panelRanking.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
