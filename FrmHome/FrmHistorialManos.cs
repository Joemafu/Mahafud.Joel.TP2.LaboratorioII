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
    public partial class FrmHistorialManos : FrmHistorialBase
    {
        public FrmHistorialManos()
        {
            InitializeComponent();
        }

        private void FrmHistorialManos_Load(object sender, EventArgs e)
        {
            List<Mano> historialManosDeNaipes = new List<Mano>();
            StringBuilder sb = new StringBuilder();

            historialManosDeNaipes = Serializador<List<Mano>>.DeserializarXML(historialManosDeNaipes, "Historial_de_manos");

            foreach (Mano item in historialManosDeNaipes)
            {
                sb.Append(item.ToString());
            }

            this.richTxtBxHistorial.Text = sb.ToString();
        }
    }
}
