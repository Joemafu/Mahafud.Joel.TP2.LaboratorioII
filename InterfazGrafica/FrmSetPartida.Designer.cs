
namespace TrucoArgentino
{
    partial class FrmSetPartida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblJugador1 = new System.Windows.Forms.Label();
            this.lblJugador2 = new System.Windows.Forms.Label();
            this.txtJugador1 = new System.Windows.Forms.TextBox();
            this.txtJugador2 = new System.Windows.Forms.TextBox();
            this.btnJugar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblJugador1
            // 
            this.lblJugador1.AutoSize = true;
            this.lblJugador1.Location = new System.Drawing.Point(12, 27);
            this.lblJugador1.Name = "lblJugador1";
            this.lblJugador1.Size = new System.Drawing.Size(125, 15);
            this.lblJugador1.TabIndex = 0;
            this.lblJugador1.Text = "Nombre Jugador Nº 1:";
            // 
            // lblJugador2
            // 
            this.lblJugador2.AutoSize = true;
            this.lblJugador2.Location = new System.Drawing.Point(12, 56);
            this.lblJugador2.Name = "lblJugador2";
            this.lblJugador2.Size = new System.Drawing.Size(125, 15);
            this.lblJugador2.TabIndex = 1;
            this.lblJugador2.Text = "Nombre Jugador Nº 2:";
            // 
            // txtJugador1
            // 
            this.txtJugador1.Location = new System.Drawing.Point(143, 24);
            this.txtJugador1.MaxLength = 20;
            this.txtJugador1.Name = "txtJugador1";
            this.txtJugador1.PlaceholderText = "Jugador 1";
            this.txtJugador1.Size = new System.Drawing.Size(100, 23);
            this.txtJugador1.TabIndex = 2;
            // 
            // txtJugador2
            // 
            this.txtJugador2.Location = new System.Drawing.Point(143, 53);
            this.txtJugador2.MaxLength = 20;
            this.txtJugador2.Name = "txtJugador2";
            this.txtJugador2.PlaceholderText = "Jugador 2";
            this.txtJugador2.Size = new System.Drawing.Size(100, 23);
            this.txtJugador2.TabIndex = 3;
            // 
            // btnJugar
            // 
            this.btnJugar.Location = new System.Drawing.Point(76, 102);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(103, 30);
            this.btnJugar.TabIndex = 0;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // FrmSetPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 149);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.txtJugador2);
            this.Controls.Add(this.txtJugador1);
            this.Controls.Add(this.lblJugador2);
            this.Controls.Add(this.lblJugador1);
            this.Name = "FrmSetPartida";
            this.Text = "Ingrese datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJugador1;
        private System.Windows.Forms.Label lblJugador2;
        private System.Windows.Forms.TextBox txtJugador1;
        private System.Windows.Forms.TextBox txtJugador2;
        private System.Windows.Forms.Button btnJugar;
    }
}