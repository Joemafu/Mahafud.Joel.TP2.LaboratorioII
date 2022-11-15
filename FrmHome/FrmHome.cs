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

        private void nuevaPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetPartida set = new FrmSetPartida();

            set.MdiParent = this;            

            set.Show();
        }

        private void historialDeManosRepartidasXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialManos frmHistorialManos = new FrmHistorialManos();

            frmHistorialManos.ShowDialog();
        }

        private void historialDeResultadosSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialPartidas frmHistorialPartidas = new FrmHistorialPartidas();

            frmHistorialPartidas.ShowDialog();
        }

        private void historialDePardasTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialDePardas frmHistorialDePardas = new FrmHistorialDePardas();

            frmHistorialDePardas.Show();
        }

        private void historialDeFloresJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialFlores frmHistorialFlores = new FrmHistorialFlores();

            frmHistorialFlores.ShowDialog();
        }
    }
}
