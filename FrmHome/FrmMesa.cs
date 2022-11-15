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
    public partial class FrmMesa : Form , IAccionesRonda
    {
        private Partida partida;
        private Control[] controlesJugador1;
        private Control[] controlesJugador2;
        private RadioButton[] naipesManoJugador1;
        private RadioButton[] naipesManoJugador2;
        private Label[] naipesMesaJugador1;
        private Label[] naipesMesaJugador2;

        public FrmMesa(Jugador j1, Jugador j2)
        {
            InitializeComponent();
            this.partida = new Partida(j1, j2);
            this.controlesJugador1 = new Control[10] { this.btnJugarNaipe1, this.btnEnvido1, this.btnFlor1, this.btnRealEnvido1, this.btnTruco1, this.btnFaltaEnvido1, this.btnQuiero1, this.btnAlMazo1, this.chkBxOcultarMano1, this.lblCantoJugador1 };
            this.controlesJugador2 = new Control[10] { this.btnJugarNaipe2, this.btnEnvido2, this.btnFlor2, this.btnRealEnvido2, this.btnTruco2, this.btnFaltaEnvido2, this.btnQuiero2, this.btnAlMazo2, this.chkBxOcultarMano2, this.lblCantoJugador2 };
            this.naipesManoJugador1 = new RadioButton[3] { this.rBtn1, this.rBtn2, this.rBtn3 };
            this.naipesManoJugador2 = new RadioButton[3] { this.rBtn4, this.rBtn5, this.rBtn6 };
            this.naipesMesaJugador1 = new Label[3] { this.lblNaipe11, this.lblNaipe21, this.lblNaipe31 };
            this.naipesMesaJugador2 = new Label[3] { this.lblNaipe12, this.lblNaipe22, this.lblNaipe32 };
            Reloj.TasaDeRefrescoSuperada += this.RefrescarReloj;
        }

        private void FrmMesa_Load(object sender, EventArgs e)
        {
            //Seteo el nombre de los jugadores a cada lado de la mesa
            this.grpBxJugador1.Text = this.partida.Jugador1.Nombre;
            this.grpBxJugador2.Text = this.partida.Jugador2.Nombre;

            //Habilito todos los naipes
            foreach (RadioButton item in naipesManoJugador1)
            {
                item.Enabled = true;
            }
            foreach (RadioButton item in naipesManoJugador2)
            {
                item.Enabled = true;
            }

            //Actualizo los controles
            this.RefrescarControles();

            //Blanqueo etiquetas de nombre a los naipes en mesa
            this.lblNaipe11.Text = "";
            this.lblNaipe12.Text = "";
            this.lblNaipe21.Text = "";
            this.lblNaipe22.Text = "";
            this.lblNaipe31.Text = "";
            this.lblNaipe32.Text = "";

            //Blanqueo Valores de ronda de tanto
            this.lblTanto.Visible = false;
            this.lblTantoJugador1.Text = "";
            this.lblTantoJugador2.Text = "";

            //Blanqueo las cantadas de los jugadores
            this.lblCantoJugador1.Text = "";
            this.lblCantoJugador2.Text = "";
        }

        private void CambiarDeTurno()
        {
            //Si es el turno del jugador 1 cambio al jugador 2 y vice versa, seteando las opciones disponibles según corresponda
            if (this.partida.Jugador1.EsSuTurno)
            {
                this.partida.Jugador1.EsSuTurno = false;
                this.partida.Jugador2.EsSuTurno = true;
                this.RefrescarControles();
            }
            else
            {
                this.partida.Jugador1.EsSuTurno = true;
                this.partida.Jugador2.EsSuTurno = false;
                this.RefrescarControles();
            }
        }

        private void RefrescarControles()
        {
            this.lblValorDelTruco.Text = $"Valor del Truco: {this.partida.Ronda.ValorDelTrucoActual}";
            this.lblValorTanto.Text = $"Valor del Tanto: {this.partida.Ronda.ValorDelTantoActual}";

            if (this.partida.Jugador1.EsSuTurno)
            {
                this.DeshabilitarJugador(this.partida.Jugador1, this.controlesJugador1);
                this.DeshabilitarJugador(this.partida.Jugador2, this.controlesJugador2);
                this.HabilitarJugador(this.partida.Jugador1, this.controlesJugador1);
            }
            else
            {
                this.DeshabilitarJugador(this.partida.Jugador1, this.controlesJugador1);
                this.DeshabilitarJugador(this.partida.Jugador2, this.controlesJugador2);
                this.HabilitarJugador(this.partida.Jugador2, this.controlesJugador2);
            }
        }

        private void HabilitarJugador(Jugador jugador, Control[] controles)
        {
            //lógica de botones disponibles según la circunstancia de la partida 
            /*
             * 0 = Boton Jugar Carta
             * 1 = Boton Envido
             * 2 = Boton Flor
             * 3 = Boton Real Envido
             * 4 = Boton Truco
             * 5 = Boton Falta envido
             * 6 = Boton Quiero
             * 7 = Boton Me voy al mazo
             * 8 = CheckBox Ocultar Mano
             * 9 = Etiqueta de cantado
             * 
             * */

            this.lblPosicion1.Text = this.partida.Ronda.MostrarPosicion(this.partida, 1);
            this.lblPosicion2.Text = this.partida.Ronda.MostrarPosicion(this.partida, 2);

            controles[7].Text = "Me voy al mazo!";

            foreach (RadioButton item in this.naipesManoJugador1)
            {
                if (item.Enabled)
                {
                    item.Checked = true;
                    break;
                }
            }
            foreach (RadioButton item in this.naipesManoJugador2)
            {
                if (item.Enabled)
                {
                    item.Checked = true;
                    break;
                }
            }

            if (this.partida.Ronda.ValorDelTrucoSiSeAcepta < 4 && jugador.TieneElQuiero)
            {
                controles[4].Enabled = true;
                if (this.partida.Ronda.ValorDelTrucoSiSeAcepta == 3)
                {
                    controles[4].Text = "Vale Cuatro!";
                }
                else if (this.partida.Ronda.ValorDelTrucoSiSeAcepta == 2)
                {
                    controles[4].Text = "Retruco!";
                }
                else 
                {
                    controles[4].Text = "Truco!";
                }
            }

            if (this.partida.Ronda.TrucoCantado)
            {
                controles[6].Enabled = true;
            }
            else if (this.partida.Ronda.TantoCantado && !this.partida.Ronda.TantoJugado)
            {
                controles[7].Text = "No quiero!";

                if (this.partida.Jugador1.Mano.TieneFlor)
                {
                    controles[2].Enabled = true;
                }
                else
                {
                    controles[6].Enabled = true;

                    if (this.partida.Ronda.EstadoEnvido < 2)
                    {
                        controles[3].Enabled = true;
                        controles[5].Enabled = true;

                        if (this.partida.Ronda.EstadoEnvido < 1)
                        {
                            controles[1].Enabled = true;
                        }
                    }
                }
            }
            else
            {
                if (this.partida.Ronda.NumeroDeTurno == 1 && !this.partida.Ronda.TantoJugado)
                {
                    if (jugador.Mano.TieneFlor)
                    {
                        controles[2].Enabled = true;
                    }
                    else
                    {
                        controles[1].Enabled = true;
                        controles[3].Enabled = true;
                        controles[5].Enabled = true;
                    }
                }
                controles[0].Enabled = true;
            }
            controles[7].Enabled = true;
            controles[8].Enabled = true;
            controles[9].Text = "";
        }

        private void DeshabilitarJugador(Jugador jugador, Control[] controles)
        {
            foreach (Control item in controles)
            {
                item.Enabled = false;
            }
            ((CheckBox)controles[8]).Checked = true;
            controles[9].Enabled = true;
        }

        private void OcultarNaipes (GroupBox grpBx)
        {
            foreach (object item in grpBx.Controls)
            {
                if (item is RadioButton)
                {
                    ((RadioButton)item).Text = "";
                }
            }
        }

        private void MostrarNaipes(GroupBox grpBx, Jugador j)
        {
            int i = 0;
            foreach (object item in grpBx.Controls)
            {
                if (item is RadioButton)
                {
                    ((RadioButton)item).Text = j.Mano.Naipes[i].ToString();
                    i++;
                }
                
            }
        }

        private void chkBxOcultarMano1_CheckedChanged(object sender, EventArgs e)
        {
            AlternarMostrarOcultar(this.grpBxJugador1, this.partida.Jugador1);
        }

        private void chkBxOcultarMano2_CheckedChanged(object sender, EventArgs e)
        {
            AlternarMostrarOcultar(this.grpBxJugador2, this.partida.Jugador2);
        }

        private void AlternarMostrarOcultar(GroupBox grpBx, Jugador j)
        {
            foreach (object item in grpBx.Controls)
            {
                if (item is CheckBox)
                {
                    if (((CheckBox)item).Checked)
                    {
                        OcultarNaipes(grpBx); 
                    }
                    else
                    {
                        MostrarNaipes(grpBx, j);
                    }
                    break;
                }
            }
        }

        private void btnCancelarPartida_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Si se cancela la partida no se guardará en la base de datos. ¿Está seguro de cancelar?","Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnJugarNaipe1_Click(object sender, EventArgs e)
        {
            this.partida.Ronda.NaipeJugador1 = ValidarNaipe(this.partida.Jugador1, this.naipesManoJugador1, this.chkBxOcultarMano1);
            if (this.partida.Ronda.NaipeJugador1 is not null)
            {
                TerminarOCambiarTurno();
            }
        }

        private void btnJugarNaipe2_Click(object sender, EventArgs e)
        {
            this.partida.Ronda.NaipeJugador2 =  ValidarNaipe(this.partida.Jugador2,this.naipesManoJugador2, this.chkBxOcultarMano2);
            if (this.partida.Ronda.NaipeJugador2 is not null)
            {
                TerminarOCambiarTurno();
            }
        }

        private Naipe ValidarNaipe(Jugador jugador, RadioButton[] naipes, CheckBox checkBox)
        {
            Naipe ret = null;
            if (checkBox.Checked)
            {
                MessageBox.Show("No puede jugar sus cartas a ciegas.\nDestilde 'ocultar cartas' y seleccione una carta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;
                foreach (RadioButton item in naipes)
                {
                    if (item.Checked)
                    {
                        JugarNaipe(jugador.Mano.Naipes[i]);
                        item.Enabled = false;
                        break;
                    }
                    i++;
                }
                ret = jugador.Mano.Naipes[i];
            }
            return ret;
        }

        private void TerminarOCambiarTurno ()
        {
            if (this.partida.Ronda.NaipeJugador1 is not null && this.partida.Ronda.NaipeJugador2 is not null)
            {
                this.TerminarTurno();
            }
            else
            {
                this.CambiarDeTurno();
            }
        }

        private void JugarNaipe(Naipe naipe)
        { 
            switch (this.partida.Ronda.NumeroDeTurno)
            {
                case 1:
                    if(this.partida.Jugador1.EsSuTurno)
                    {
                        this.lblNaipe11.Text = naipe.ToString();
                    }else
                    {
                        this.lblNaipe12.Text = naipe.ToString();
                    }
                    break;
                case 2:
                    if (this.partida.Jugador1.EsSuTurno)
                    {
                        this.lblNaipe21.Text = naipe.ToString();
                    }
                    else
                    {
                        this.lblNaipe22.Text = naipe.ToString();
                    }
                    break;
                case 3:
                    if (this.partida.Jugador1.EsSuTurno)
                    {
                        this.lblNaipe31.Text = naipe.ToString();
                    }
                    else
                    {
                        this.lblNaipe32.Text = naipe.ToString();
                    }
                    break;
            }
        }

        void TerminarTurno()
        {
            if (this.partida.Ronda.NaipeJugador1.ValorNaipe > this.partida.Ronda.NaipeJugador2.ValorNaipe)
            {
                if(this.partida.Ronda.GanaPrimera == null)
                {
                    this.partida.Ronda.GanaPrimera = this.partida.Jugador1;
                }
                this.partida.Ronda.ManosGanadasJugador1++;
                this.ColorearNaipeGanador(1);
                this.partida.Jugador1.EsSuTurno = true;
                this.partida.Jugador2.EsSuTurno = false;
            }
            else if (this.partida.Ronda.NaipeJugador1.ValorNaipe < this.partida.Ronda.NaipeJugador2.ValorNaipe)
            {
                if (this.partida.Ronda.GanaPrimera == null)
                {
                    this.partida.Ronda.GanaPrimera = this.partida.Jugador2;
                }
                this.partida.Ronda.ManosGanadasJugador2++;
                this.ColorearNaipeGanador(2);
                this.partida.Jugador1.EsSuTurno = false;
                this.partida.Jugador2.EsSuTurno = true;
            }
            else
            {
                this.partida.Ronda.ManosGanadasJugador1++;
                this.partida.Ronda.ManosGanadasJugador2++;
                this.ColorearNaipeGanador(3);
                this.partida.Jugador1.EsSuTurno = this.partida.Jugador1.EsMano;
                this.partida.Jugador2.EsSuTurno = this.partida.Jugador2.EsMano;
                Txt.Guardar(this.partida, this.partida.Ronda.NaipeJugador1, this.partida.Ronda.NaipeJugador2);
            }

            this.partida.Ronda.NumeroDeTurno++;
            this.partida.Ronda.NaipeJugador1 = null;
            this.partida.Ronda.NaipeJugador2 = null;
            this.RefrescarControles();

            int ganadas1 = this.partida.Ronda.ManosGanadasJugador1;
            int ganadas2 = this.partida.Ronda.ManosGanadasJugador2;

            if (ganadas1 > ganadas2 && ganadas1 >= 2) 
            {
                this.partida.Ronda.GanadorTruco = this.partida.Jugador1;
                this.TerminarRonda();
            }
            else if (ganadas2 > ganadas1 && ganadas2 >= 2)
            {
                this.partida.Ronda.GanadorTruco = this.partida.Jugador2;
                this.TerminarRonda();
            }
            else if (ganadas1 == 2 && ganadas2 == 2)
            {
                if(this.partida.Ronda.GanaPrimera is not null)
                {
                    this.partida.Ronda.GanadorTruco = this.partida.Ronda.GanaPrimera;
                    this.TerminarRonda();
                }                
            }
            else if (ganadas1 == 3 && ganadas2 == 3)
            {
                if (this.partida.Jugador1.EsMano)
                {
                    this.partida.Ronda.GanadorTruco = this.partida.Jugador1;
                }
                else
                {
                    this.partida.Ronda.GanadorTruco = this.partida.Jugador2;
                }
                this.TerminarRonda();
            }
        }

        void ColorearNaipeGanador(int ganador)
        {
            int indiceAColorear = this.partida.Ronda.NumeroDeTurno - 1;

            if(ganador == 1 || ganador == 3)
            {
                this.naipesMesaJugador1[indiceAColorear].ForeColor = System.Drawing.Color.Green;
                this.naipesMesaJugador1[indiceAColorear].Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            }
            if (ganador == 2 || ganador == 3)
            {
                this.naipesMesaJugador2[indiceAColorear].ForeColor = System.Drawing.Color.Green;
                this.naipesMesaJugador2[indiceAColorear].Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            }
        }

        void CompletarTantos()
        {
            this.lblTanto.Visible = true;
            this.lblTantoJugador1.Text = this.partida.Jugador1.Mano.Tanto.ToString();
            this.lblTantoJugador2.Text = this.partida.Jugador2.Mano.Tanto.ToString();

            if (this.partida.Jugador1.Mano.Tanto > this.partida.Jugador2.Mano.Tanto || this.partida.Jugador1.EsMano && this.partida.Jugador1.Mano.Tanto == this.partida.Jugador2.Mano.Tanto)
            {
                this.lblTantoJugador1.ForeColor = System.Drawing.Color.Green;
                this.lblTantoJugador1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            }
            else
            {
                this.lblTantoJugador2.ForeColor = System.Drawing.Color.Green;
                this.lblTantoJugador2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            }
            this.RefrescarControles();
        }

        private void btnEnvido1_Click(object sender, EventArgs e)
        {
            this.RecordarQuienCanto(this.partida.Jugador1);
            this.partida.Ronda.ReavivarEnvido(0,2);
            this.lblCantoJugador1.Text = "Envido!";
            this.CambiarDeTurno();
        }

        private void btnEnvido2_Click(object sender, EventArgs e)
        {
            this.RecordarQuienCanto(this.partida.Jugador2);
            this.partida.Ronda.ReavivarEnvido(0,2);
            this.lblCantoJugador2.Text = "Envido!";
            this.CambiarDeTurno();
        }

        private void btnRealEnvido1_Click(object sender, EventArgs e)
        {
            this.RecordarQuienCanto(this.partida.Jugador1);
            this.partida.Ronda.ReavivarEnvido(1,3);
            this.lblCantoJugador1.Text = "Real Envido!";
            this.CambiarDeTurno();
        }

        private void btnRealEnvido2_Click(object sender, EventArgs e)
        {
            this.RecordarQuienCanto(this.partida.Jugador2);
            this.partida.Ronda.ReavivarEnvido(1,3);
            this.lblCantoJugador2.Text = "Real Envido!";
            this.CambiarDeTurno();
        }

        private void btnFaltaEnvido1_Click(object sender, EventArgs e)
        {
            this.RecordarQuienCanto(this.partida.Jugador1);
            this.partida.Ronda.ReavivarEnvido(this.partida);
            this.lblCantoJugador1.Text = "Falta Envido!";
            this.CambiarDeTurno();
        }

        private void btnFaltaEnvido2_Click(object sender, EventArgs e)
        {
            this.RecordarQuienCanto(this.partida.Jugador2);
            this.partida.Ronda.ReavivarEnvido(this.partida);
            this.lblCantoJugador2.Text = "Falta Envido!";
            this.CambiarDeTurno();
        }

        private void btnFlor1_Click(object sender, EventArgs e)
        {
            this.lblValorTanto.Text = $"{this.partida.Jugador1.Nombre} cantó Flor = 3";
            this.partida.Ronda.ValorDelTantoActual = 3;
            this.partida.Ronda.GanadorEnvido = this.partida.Jugador1;
            this.lblCantoJugador1.Text = "Flor!";
            this.btnFlor1.Enabled = false;
            this.partida.Ronda.TantoJugado = true;
            this.RefrescarControles();
            Serializador<Mano>.SerializarJson(this.partida.Jugador1.Mano, "Historial_De_Flores.json");
        }

        private void btnFlor2_Click(object sender, EventArgs e)
        {
            this.lblValorTanto.Text = $"{this.partida.Jugador2.Nombre} cantó Flor = 3";
            this.partida.Ronda.ValorDelTantoActual = 3;
            this.partida.Ronda.GanadorEnvido = this.partida.Jugador2;
            this.lblCantoJugador1.Text = "Flor!";
            this.btnFlor2.Enabled = false;
            this.partida.Ronda.TantoJugado = true;
            this.RefrescarControles();
            Serializador<Mano>.SerializarJson(this.partida.Jugador2.Mano, "Historial_De_Flores.json");
        }

        private void btnTruco1_Click(object sender, EventArgs e)
        {
            this.RecordarQuienCanto(this.partida.Jugador1);
            this.partida.Ronda.Retrucar(this.partida.Jugador1, this.partida.Jugador2);
            this.lblCantoJugador1.Text = this.btnTruco1.Text;
            this.CambiarDeTurno();
        }

        private void btnTruco2_Click(object sender, EventArgs e)
        {
            this.RecordarQuienCanto(this.partida.Jugador2);
            this.partida.Ronda.Retrucar(this.partida.Jugador2, this.partida.Jugador1);
            this.lblCantoJugador2.Text = this.btnTruco2.Text;
            this.CambiarDeTurno();
        }

        private void btnQuiero1_Click(object sender, EventArgs e)
        {
            this.Aceptar(this.partida.Jugador1, this.partida.Jugador2);
        }

        private void btnQuiero2_Click(object sender, EventArgs e)
        {
            this.Aceptar(this.partida.Jugador2, this.partida.Jugador1);
        }

        private void btnAlMazo1_Click(object sender, EventArgs e)
        {
            this.Declinar(this.partida.Jugador2);
        }

        private void btnAlMazo2_Click(object sender, EventArgs e)
        {
            this.Declinar(this.partida.Jugador1);
        }

        private void RecordarQuienCanto(Jugador jugadorQueCanto)
        {
            if (!this.partida.Ronda.TantoCantado && !this.partida.Ronda.TrucoCantado)
            {
                this.partida.Ronda.Canto = jugadorQueCanto;
            }
        }

        private void VolverAlTurnoDeQuienCanto()
        {
            while (!this.partida.Ronda.Canto.EsSuTurno)
            {
                this.CambiarDeTurno();
            }
            this.RefrescarControles();
        }

        public void Aceptar(Jugador jugador1, Jugador jugador2)
        {
            if (this.partida.Ronda.TantoCantado)
            {
                this.CompletarTantos();
            }
            this.partida.Ronda.Aceptar(jugador1, jugador2);
            this.VolverAlTurnoDeQuienCanto();
        }

        public void Declinar(Jugador jugador)
        {
            this.partida.Ronda.Declinar(jugador);
            if (!this.partida.Ronda.TantoCantado)
            {
                this.TerminarRonda();
            }
            else
            {
                this.CambiarDeTurno();
            }
            this.RefrescarControles();
        }

        private void MostrarResultadoRonda()
        {
            MessageBox.Show(this.partida.Ronda.ToString(), "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarResultadoPartida()
        {
            if(MessageBox.Show(this.partida.ToString(), "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)==DialogResult.OK)
            {
                try
                {
                    SQL.Guardar(this.partida);
                }
                catch (ExcepcionBaseDeDatos ex)
                {
                    MessageBox.Show(ex.Message, "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
                finally
                {
                    this.Close();
                }
            }
        }

        public void TerminarRonda() 
        {
            this.partida.Ronda.TerminarRonda();
            this.MostrarResultadoRonda();

            this.RefrescarControles();

            if (this.partida.PartidaTerminada)
            {
                this.MostrarResultadoPartida();                
            }
            else
            {
                this.partida.AvanzarRonda();
                this.FrmMesa_Load(this, new EventArgs());
            }
        }

        public void RefrescarReloj()
        {
            if (this.lblFechaYHora.InvokeRequired)
            {
                Action refrescarReloj = this.RefrescarReloj;
                lblFechaYHora.Invoke(refrescarReloj);
            }
            else
            {
                this.lblFechaYHora.Text = DateTime.Now.ToString("G");
            }            
        }
    }
}
