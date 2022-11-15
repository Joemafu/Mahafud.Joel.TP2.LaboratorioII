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
    public partial class FrmHistorialFlores : FrmHistorialBase
    {
        public FrmHistorialFlores()
        {
            InitializeComponent();
        }

        private void FrmHistorialFlores_Load(object sender, EventArgs e)
        {
            List<Mano> listaFlores = null;
            StringBuilder sb = new StringBuilder();
            listaFlores = Serializador<Mano>.DeserializarJson(listaFlores, "Historial_De_Flores.json");

            if (listaFlores is not null)
            {
                foreach (Mano item in listaFlores)
                {
                    sb.AppendLine(item.ToString());
                }
                this.richTxtBxHistorial.Text = sb.ToString();
            }            
        }
    }
}
