namespace BrainZap_Client.FORMULARIOS
{
    partial class FrmPregunta
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lbPregunta;
        private System.Windows.Forms.Button btnResp1;
        private System.Windows.Forms.Button btnResp2;
        private System.Windows.Forms.Button btnResp3;
        private System.Windows.Forms.Button btnResp4;
        private System.Windows.Forms.ProgressBar pbTiempo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lbPregunta = new System.Windows.Forms.Label();
            this.btnResp1 = new System.Windows.Forms.Button();
            this.btnResp2 = new System.Windows.Forms.Button();
            this.btnResp3 = new System.Windows.Forms.Button();
            this.btnResp4 = new System.Windows.Forms.Button();
            this.pbTiempo = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lbPregunta
            // 
            this.lbPregunta.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lbPregunta.Location = new System.Drawing.Point(50, 20);
            this.lbPregunta.Name = "lbPregunta";
            this.lbPregunta.Size = new System.Drawing.Size(700, 80);
            this.lbPregunta.TabIndex = 0;
            this.lbPregunta.Text = "Aquí aparecerá la pregunta";
            this.lbPregunta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnResp1
            // 
            this.btnResp1.BackColor = System.Drawing.Color.Red;
            this.btnResp1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnResp1.ForeColor = System.Drawing.Color.White;
            this.btnResp1.Location = new System.Drawing.Point(50, 120);
            this.btnResp1.Name = "btnResp1";
            this.btnResp1.Size = new System.Drawing.Size(320, 100);
            this.btnResp1.TabIndex = 1;
            this.btnResp1.Text = "Respuesta 1";
            this.btnResp1.UseVisualStyleBackColor = false;
            this.btnResp1.Click += new System.EventHandler(this.btnResp1_Click);
            // 
            // btnResp2
            // 
            this.btnResp2.BackColor = System.Drawing.Color.Blue;
            this.btnResp2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnResp2.ForeColor = System.Drawing.Color.White;
            this.btnResp2.Location = new System.Drawing.Point(430, 120);
            this.btnResp2.Name = "btnResp2";
            this.btnResp2.Size = new System.Drawing.Size(320, 100);
            this.btnResp2.TabIndex = 2;
            this.btnResp2.Text = "Respuesta 2";
            this.btnResp2.UseVisualStyleBackColor = false;
            this.btnResp2.Click += new System.EventHandler(this.btnResp1_Click);
            // 
            // btnResp3
            // 
            this.btnResp3.BackColor = System.Drawing.Color.Gold;
            this.btnResp3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnResp3.ForeColor = System.Drawing.Color.Black;
            this.btnResp3.Location = new System.Drawing.Point(50, 250);
            this.btnResp3.Name = "btnResp3";
            this.btnResp3.Size = new System.Drawing.Size(320, 100);
            this.btnResp3.TabIndex = 3;
            this.btnResp3.Text = "Respuesta 3";
            this.btnResp3.UseVisualStyleBackColor = false;
            this.btnResp3.Click += new System.EventHandler(this.btnResp1_Click);
            // 
            // btnResp4
            // 
            this.btnResp4.BackColor = System.Drawing.Color.Green;
            this.btnResp4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnResp4.ForeColor = System.Drawing.Color.White;
            this.btnResp4.Location = new System.Drawing.Point(430, 250);
            this.btnResp4.Name = "btnResp4";
            this.btnResp4.Size = new System.Drawing.Size(320, 100);
            this.btnResp4.TabIndex = 4;
            this.btnResp4.Text = "Respuesta 4";
            this.btnResp4.UseVisualStyleBackColor = false;
            this.btnResp4.Click += new System.EventHandler(this.btnResp1_Click);
            // 
            // pbTiempo
            // 
            this.pbTiempo.Location = new System.Drawing.Point(50, 380);
            this.pbTiempo.Name = "pbTiempo";
            this.pbTiempo.Size = new System.Drawing.Size(700, 23);
            this.pbTiempo.TabIndex = 5;
            // 
            // FrmPregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbTiempo);
            this.Controls.Add(this.btnResp4);
            this.Controls.Add(this.btnResp3);
            this.Controls.Add(this.btnResp2);
            this.Controls.Add(this.btnResp1);
            this.Controls.Add(this.lbPregunta);
            this.Name = "FrmPregunta";
            this.Text = "Pregunta";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
