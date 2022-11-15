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
using System.Data.SqlClient;

namespace TrucoArgentino
{
    public partial class FrmHistorialPartidas : Form
    {
        public FrmHistorialPartidas()
        {
            InitializeComponent();
        }

        private void FrmHistorialPartidas_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataSource = new DataTable();

                dataSource.Load(SQL.Leer());

                this.dgvHistorialPartidas.DataSource = dataSource;

            }
            catch (ExcepcionBaseDeDatos edb)
            {
                MessageBox.Show(edb.Message, "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQL.Cerrar();
            }
        }
    }
}
