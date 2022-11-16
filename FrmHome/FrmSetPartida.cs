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
    public partial class FrmSetPartida : Form
    {
        public FrmSetPartida()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setea una nueva partida si se cargaron nombres válidos (diferentes entre si y no vacíos).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (this.txtJugador1.Text == "" || this.txtJugador2.Text == "")
            {
                MessageBox.Show("Ingrese un nombre para cada jugador.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.txtJugador1.Text == this.txtJugador2.Text)
            {
                MessageBox.Show("Jugador 1 y Jugador 2 no pueden llamarse igual.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Jugador j1 = new Jugador(this.txtJugador1.Text,true);
                Jugador j2 = new Jugador(this.txtJugador2.Text,false);

                FrmMesa mesa = new FrmMesa(j1, j2);

                mesa.MdiParent = this.MdiParent;

                mesa.Show();

                this.Hide();
            }
        }
    }
}
