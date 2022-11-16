using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TrucoArgentino
{
    public partial class FrmHistorialDePardas : FrmHistorialBase
    {
        public FrmHistorialDePardas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga el RichTextBox con el contenido del archivo Historial_De_Pardas.txt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmHistorialDePardas_Load(object sender, EventArgs e)
        {
            this.richTxtBxHistorial.Text = Txt.Leer();
        }
    }
}
