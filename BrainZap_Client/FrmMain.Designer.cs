namespace BrainZap_Client
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbNickname = new System.Windows.Forms.Label();
            this.lbIp = new System.Windows.Forms.Label();
            this.tbNickname = new System.Windows.Forms.TextBox();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.btConectar = new System.Windows.Forms.Button();
            this.lbPuerto = new System.Windows.Forms.Label();
            this.tbPuerto = new System.Windows.Forms.TextBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(281, 88);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(221, 54);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "BrainZap";
            // 
            // lbNickname
            // 
            this.lbNickname.AutoSize = true;
            this.lbNickname.Location = new System.Drawing.Point(287, 161);
            this.lbNickname.Name = "lbNickname";
            this.lbNickname.Size = new System.Drawing.Size(68, 16);
            this.lbNickname.TabIndex = 1;
            this.lbNickname.Text = "Nickname";
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Location = new System.Drawing.Point(287, 195);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(19, 16);
            this.lbIp.TabIndex = 2;
            this.lbIp.Text = "IP";
            // 
            // tbNickname
            // 
            this.tbNickname.Location = new System.Drawing.Point(361, 158);
            this.tbNickname.Name = "tbNickname";
            this.tbNickname.Size = new System.Drawing.Size(141, 22);
            this.tbNickname.TabIndex = 3;
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(312, 189);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(190, 22);
            this.tbIp.TabIndex = 4;
            // 
            // btConectar
            // 
            this.btConectar.Location = new System.Drawing.Point(339, 248);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(111, 40);
            this.btConectar.TabIndex = 5;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(287, 223);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(46, 16);
            this.lbPuerto.TabIndex = 6;
            this.lbPuerto.Text = "Puerto";
            // 
            // tbPuerto
            // 
            this.tbPuerto.Location = new System.Drawing.Point(339, 220);
            this.tbPuerto.Name = "tbPuerto";
            this.tbPuerto.Size = new System.Drawing.Size(71, 22);
            this.tbPuerto.TabIndex = 7;
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(416, 223);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(0, 16);
            this.lbEstado.TabIndex = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.tbPuerto);
            this.Controls.Add(this.lbPuerto);
            this.Controls.Add(this.btConectar);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.tbNickname);
            this.Controls.Add(this.lbIp);
            this.Controls.Add(this.lbNickname);
            this.Controls.Add(this.lbTitulo);
            this.Name = "FrmMain";
            this.Text = "BrainZap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbNickname;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.TextBox tbNickname;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.Label lbPuerto;
        private System.Windows.Forms.TextBox tbPuerto;
        private System.Windows.Forms.Label lbEstado;
    }
}

