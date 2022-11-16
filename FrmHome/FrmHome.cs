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
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instancia una nuevasala de Truco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevaPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetPartida set = new FrmSetPartida();

            set.MdiParent = this;            

            set.Show();
        }

        /// <summary>
        /// Muestra un form con el historial de manos repartidas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historialDeManosRepartidasXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialManos frmHistorialManos = new FrmHistorialManos();

            frmHistorialManos.ShowDialog();
        }

        /// <summary>
        /// Muestra un form con el historial de partidas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historialDeResultadosSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialPartidas frmHistorialPartidas = new FrmHistorialPartidas();

            frmHistorialPartidas.ShowDialog();
        }

        /// <summary>
        /// Muestra un form con el historial de pardas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historialDePardasTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialDePardas frmHistorialDePardas = new FrmHistorialDePardas();

            frmHistorialDePardas.Show();
        }

        /// <summary>
        /// Muestra un form con el historial de flores cantadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historialDeFloresJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialFlores frmHistorialFlores = new FrmHistorialFlores();

            frmHistorialFlores.ShowDialog();
        }
    }
}
