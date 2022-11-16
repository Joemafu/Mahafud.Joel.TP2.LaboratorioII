
namespace TrucoArgentino
{
    partial class FrmHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.nuevaPartidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeManosRepartidasXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeResultadosSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeFloresTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeFloresJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPartidaToolStripMenuItem,
            this.historialToolStripMenuItem});
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(800, 24);
            this.menuStripPrincipal.TabIndex = 1;
            this.menuStripPrincipal.Text = "menuStrip1";
            // 
            // nuevaPartidaToolStripMenuItem
            // 
            this.nuevaPartidaToolStripMenuItem.Name = "nuevaPartidaToolStripMenuItem";
            this.nuevaPartidaToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.nuevaPartidaToolStripMenuItem.Text = "Nueva Partida";
            this.nuevaPartidaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPartidaToolStripMenuItem_Click);
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialDeManosRepartidasXMLToolStripMenuItem,
            this.historialDeResultadosSQLToolStripMenuItem,
            this.historialDeFloresTXTToolStripMenuItem,
            this.historialDeFloresJSONToolStripMenuItem});
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.historialToolStripMenuItem.Text = "Historial";
            // 
            // historialDeManosRepartidasXMLToolStripMenuItem
            // 
            this.historialDeManosRepartidasXMLToolStripMenuItem.Name = "historialDeManosRepartidasXMLToolStripMenuItem";
            this.historialDeManosRepartidasXMLToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.historialDeManosRepartidasXMLToolStripMenuItem.Text = "Historial de manos repartidas (XML)";
            this.historialDeManosRepartidasXMLToolStripMenuItem.Click += new System.EventHandler(this.historialDeManosRepartidasXMLToolStripMenuItem_Click);
            // 
            // historialDeResultadosSQLToolStripMenuItem
            // 
            this.historialDeResultadosSQLToolStripMenuItem.Name = "historialDeResultadosSQLToolStripMenuItem";
            this.historialDeResultadosSQLToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.historialDeResultadosSQLToolStripMenuItem.Text = "Historial de resultados (SQL)";
            this.historialDeResultadosSQLToolStripMenuItem.Click += new System.EventHandler(this.historialDeResultadosSQLToolStripMenuItem_Click);
            // 
            // historialDeFloresTXTToolStripMenuItem
            // 
            this.historialDeFloresTXTToolStripMenuItem.Name = "historialDeFloresTXTToolStripMenuItem";
            this.historialDeFloresTXTToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.historialDeFloresTXTToolStripMenuItem.Text = "Historial de Pardas (TXT)";
            this.historialDeFloresTXTToolStripMenuItem.Click += new System.EventHandler(this.historialDePardasTXTToolStripMenuItem_Click);
            // 
            // historialDeFloresJSONToolStripMenuItem
            // 
            this.historialDeFloresJSONToolStripMenuItem.Name = "historialDeFloresJSONToolStripMenuItem";
            this.historialDeFloresJSONToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.historialDeFloresJSONToolStripMenuItem.Text = "Historial de Flores (JSON)";
            this.historialDeFloresJSONToolStripMenuItem.Click += new System.EventHandler(this.historialDeFloresJSONToolStripMenuItem_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStripPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripPrincipal;
            this.Name = "FrmHome";
            this.Text = "Truco Argentino";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem nuevaPartidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeManosRepartidasXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeResultadosSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeFloresTXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeFloresJSONToolStripMenuItem;
    }
}

