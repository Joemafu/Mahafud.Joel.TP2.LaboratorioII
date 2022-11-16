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

        /// <summary>
        /// Carga el DataGridView con el contenido de la base de datos SQL o Activa un MessageBox en caso de Excepción. 
        /// Luego cierra la conexión tal como lo requiere el método SQL.Leer(). 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
