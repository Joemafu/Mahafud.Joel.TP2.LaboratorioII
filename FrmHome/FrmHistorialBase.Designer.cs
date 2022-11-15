
namespace TrucoArgentino
{
    partial class FrmHistorialBase
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
            this.richTxtBxHistorial = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTxtBxHistorial
            // 
            this.richTxtBxHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtBxHistorial.Location = new System.Drawing.Point(12, 12);
            this.richTxtBxHistorial.Name = "richTxtBxHistorial";
            this.richTxtBxHistorial.Size = new System.Drawing.Size(370, 426);
            this.richTxtBxHistorial.TabIndex = 0;
            this.richTxtBxHistorial.Text = "";
            // 
            // FrmHistorialBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 450);
            this.Controls.Add(this.richTxtBxHistorial);
            this.Name = "FrmHistorialBase";
            this.Text = "Historial Base";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTxtBxHistorial;
    }
}