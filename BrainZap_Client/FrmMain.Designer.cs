using System.Drawing;
using System.Windows.Forms;
using System;

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
            this.lbTitulo.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lbTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbTitulo.Location = new System.Drawing.Point(250, 40);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(287, 81);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "BrainZap";
            // 
            // lbNickname
            // 
            this.lbNickname.AutoSize = true;
            this.lbNickname.Location = new System.Drawing.Point(220, 140);
            this.lbNickname.Name = "lbNickname";
            this.lbNickname.Size = new System.Drawing.Size(86, 23);
            this.lbNickname.TabIndex = 1;
            this.lbNickname.Text = "Nickname";
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Location = new System.Drawing.Point(220, 180);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(25, 23);
            this.lbIp.TabIndex = 3;
            this.lbIp.Text = "IP";
            // 
            // tbNickname
            // 
            this.tbNickname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbNickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNickname.ForeColor = System.Drawing.Color.White;
            this.tbNickname.Location = new System.Drawing.Point(320, 135);
            this.tbNickname.Name = "tbNickname";
            this.tbNickname.Size = new System.Drawing.Size(250, 30);
            this.tbNickname.TabIndex = 2;
            this.tbNickname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIp
            // 
            this.tbIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIp.ForeColor = System.Drawing.Color.White;
            this.tbIp.Location = new System.Drawing.Point(320, 175);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(250, 30);
            this.tbIp.TabIndex = 4;
            this.tbIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btConectar
            // 
            this.btConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btConectar.FlatAppearance.BorderSize = 0;
            this.btConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConectar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btConectar.ForeColor = System.Drawing.Color.White;
            this.btConectar.Location = new System.Drawing.Point(320, 270);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(150, 45);
            this.btConectar.TabIndex = 8;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = false;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // lbPuerto
            // 
            this.lbPuerto.AutoSize = true;
            this.lbPuerto.Location = new System.Drawing.Point(220, 220);
            this.lbPuerto.Name = "lbPuerto";
            this.lbPuerto.Size = new System.Drawing.Size(61, 23);
            this.lbPuerto.TabIndex = 5;
            this.lbPuerto.Text = "Puerto";
            // 
            // tbPuerto
            // 
            this.tbPuerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbPuerto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPuerto.ForeColor = System.Drawing.Color.White;
            this.tbPuerto.Location = new System.Drawing.Point(320, 215);
            this.tbPuerto.Name = "tbPuerto";
            this.tbPuerto.Size = new System.Drawing.Size(100, 30);
            this.tbPuerto.TabIndex = 6;
            this.tbPuerto.Text = "5000";
            this.tbPuerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(430, 220);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(0, 23);
            this.lbEstado.TabIndex = 7;
            // 
            // FrmMain
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbNickname);
            this.Controls.Add(this.tbNickname);
            this.Controls.Add(this.lbIp);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.lbPuerto);
            this.Controls.Add(this.tbPuerto);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.btConectar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BrainZap";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
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

