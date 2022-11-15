
namespace TrucoArgentino
{
    partial class FrmHistorialPartidas
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
            this.dgvHistorialPartidas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialPartidas
            // 
            this.dgvHistorialPartidas.AllowUserToAddRows = false;
            this.dgvHistorialPartidas.AllowUserToDeleteRows = false;
            this.dgvHistorialPartidas.AllowUserToResizeRows = false;
            this.dgvHistorialPartidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialPartidas.Location = new System.Drawing.Point(12, 12);
            this.dgvHistorialPartidas.Name = "dgvHistorialPartidas";
            this.dgvHistorialPartidas.ReadOnly = true;
            this.dgvHistorialPartidas.RowHeadersVisible = false;
            this.dgvHistorialPartidas.RowTemplate.Height = 25;
            this.dgvHistorialPartidas.ShowEditingIcon = false;
            this.dgvHistorialPartidas.ShowRowErrors = false;
            this.dgvHistorialPartidas.Size = new System.Drawing.Size(776, 426);
            this.dgvHistorialPartidas.TabIndex = 0;
            // 
            // FrmHistorialPartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvHistorialPartidas);
            this.Name = "FrmHistorialPartidas";
            this.Text = "Historial de partidas terminadas";
            this.Load += new System.EventHandler(this.FrmHistorialPartidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPartidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialPartidas;
    }
}