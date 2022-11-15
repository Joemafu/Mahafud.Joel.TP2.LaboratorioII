using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ronda : IAccionesRonda
    {
        private int valorDelTrucoActual;
        private int valorDelTrucoSiSeAcepta;
        private int valorDelTantoActual;
        private int valorDelTantoSiSeAcepta;
        private bool trucoCantado;
        private bool tantoCantado;
        private EEstadoEnvido estadoEnvido;
        private Naipe naipeJugador1;
        private Naipe naipeJugador2;
        private int numeroDeTurno;
        private int manosGanadasJugador1;
        private int manosGanadasJugador2;
        private Jugador ganadorEnvido;
        private Jugador ganadorTruco;
        private Jugador ganaPrimera;
        private Jugador canto;
        private bool tantoJugado;

        public Ronda()
        {
            this.valorDelTrucoActual = 1;
            this.valorDelTrucoSiSeAcepta = 1;
            this.valorDelTantoActual = 0;
            this.valorDelTantoSiSeAcepta = 0;
            this.trucoCantado = false;
            this.tantoCantado = false;
            this.estadoEnvido = 0;
            this.naipeJugador1 = null;
            this.naipeJugador2 = null;            
            this.numeroDeTurno = 1;
            this.manosGanadasJugador1 = 0;
            this.manosGanadasJugador2 = 0;
            this.ganadorEnvido = null;
            this.ganadorTruco = null;
            this.GanaPrimera = null;
            this.canto = null;
            this.tantoJugado = false;
        }

        public bool TrucoCantado 
        {
            get
            {
                return this.trucoCantado; 
            }
            set
            {
                this.trucoCantado = value;
            }
        }

        public bool TantoCantado 
        {
            get
            {
                return this.tantoCantado; 
            }
            set
            {
                this.tantoCantado = value;
            }
        }

        public bool TantoJugado
        {
            get
            {
                return this.tantoJugado;
            }
            set
            {
                this.tantoJugado = value;
            }
        }

        public int ValorDelTrucoActual 
        {
            get
            {
                return this.valorDelTrucoActual;
            }
            set
            {
                this.valorDelTrucoActual = value;
            }
        }

        public int ValorDelTrucoSiSeAcepta
        {
            get
            {
                return this.valorDelTrucoSiSeAcepta;
            }
            set
            {
                this.valorDelTrucoSiSeAcepta = value;
            }
        }

        public int ValorDelTantoActual
        {
            get
            {
                return this.valorDelTantoActual;
            }
            set
            {
                this.valorDelTantoActual = value;
            }
        }

        public int ValorDelTantoSiSeAcepta
        {
            get
            {
                return this.valorDelTantoSiSeAcepta;
            }
            set
            {
                this.valorDelTantoSiSeAcepta = value;
            }
        }

        public int EstadoEnvido 
        {
            get
            {
                return (int)this.estadoEnvido; 
            }
            set
            {
                this.estadoEnvido = (EEstadoEnvido)value;
            }
        }

        public int ManosGanadasJugador1 
        { 
            get 
            {
                return this.manosGanadasJugador1; 
            }
            set
            {
                this.manosGanadasJugador1 = value;
            }
        }

        public int ManosGanadasJugador2 
        { 
            get 
            { 
                return this.manosGanadasJugador2; 
            }
            set
            {
                this.manosGanadasJugador2 = value;
            }
        }

        public Jugador GanadorEnvido
        {
            get
            {
                return this.ganadorEnvido;
            }
            set
            {
                this.ganadorEnvido = value;
            }
        }

        public Jugador GanadorTruco
        {
            get
            {
                return this.ganadorTruco;
            }
            set
            {
                this.ganadorTruco = value;
            }
        }

        public Jugador GanaPrimera
        {
            get
            {
                return this.ganaPrimera;
            }
            set
            {
                this.ganaPrimera = value;
            }
        }

        public Jugador Canto
        {
            get
            {
                return this.canto;
            }
            set
            {
                this.canto = value;
            }
        }

        public Naipe NaipeJugador1 
        {
            get
            {
                return this.naipeJugador1;
            }
            set
            {
                this.naipeJugador1 = value;
            }
        }

        public Naipe NaipeJugador2
        {
            get
            {
                return this.naipeJugador2;
            }
            set
            {
                this.naipeJugador2 = value;
            }
        }

        public int NumeroDeTurno
        { 
            get 
            {
                return (int)this.numeroDeTurno; 
            }
            set
            {
                this.numeroDeTurno = value;
            }
        }

        public void Aceptar(Jugador jugadorQueAcepta, Jugador jugadorPasivo)
        {
            if (this.trucoCantado)
            {
                this.AceptarTruco(jugadorQueAcepta, jugadorPasivo);
            }
            else if (this.tantoCantado)
            {
                this.AceptarEnvido(jugadorQueAcepta, jugadorPasivo);
            }
        }

        public void Declinar(Jugador jugadorPasivo)
        {
            if (this.tantoCantado)
            {
                this.DeclinarEnvido(jugadorPasivo);
            }
            else
            {
                this.ganadorTruco = jugadorPasivo;
            }            
        }

        public void CederElQuiero(Jugador jugadorQueCede, Jugador JugadorQueRecibe)
        {
            jugadorQueCede.TieneElQuiero = false;
            JugadorQueRecibe.TieneElQuiero = true;
        }

        public void Retrucar(Jugador jugadorQueRetruca, Jugador jugadorPasivo)
        {
            if (this.trucoCantado)
            {
                AceptarTruco(jugadorPasivo, jugadorQueRetruca);
            }
            this.trucoCantado = true;
            this.valorDelTrucoSiSeAcepta++;
        }

        public void AceptarTruco(Jugador jugadorQueAcepta, Jugador jugadorPasivo)
        {
            this.valorDelTrucoActual = this.valorDelTrucoSiSeAcepta;
            this.trucoCantado = false;
            this.CederElQuiero(jugadorPasivo, jugadorQueAcepta);
        }

        /// <summary>
        /// Reavivar envido o real envido.
        /// </summary>
        /// <param name="valorEstadoDelEnvido">Estado de la reavivada según enumerado EEstadoEnvido</param>
        /// <param name="valorDeLaReavivada">2 para envido, 3 para real envido</param>
        public void ReavivarEnvido(int valorEstadoDelEnvido, int valorDeLaReavivada)
        {
            this.TantoCantado = true;
            this.EstadoEnvido = valorEstadoDelEnvido;
            this.valorDelTantoSiSeAcepta += valorDeLaReavivada;
            this.valorDelTantoActual += 1;
        }

        /// <summary>
        /// Sobrecarga para falta envido.
        /// </summary>
        /// <param name="partida">Instancia de la partida</param>
        public void ReavivarEnvido(Partida partida)
        {
            this.valorDelTantoSiSeAcepta = 0;
            this.ReavivarEnvido(2, CalcularValorFaltaEnvido(partida));
        }

        public void AceptarEnvido(Jugador jugadorQueAcepta, Jugador jugadorPasivo)
        {
            this.valorDelTantoActual = this.valorDelTantoSiSeAcepta;
            this.tantoCantado = false;
            this.tantoJugado = true;
            if (jugadorQueAcepta.Mano.Tanto > jugadorPasivo.Mano.Tanto || jugadorQueAcepta.EsMano && jugadorQueAcepta.Mano.Tanto == jugadorPasivo.Mano.Tanto)
            {
                this.ganadorEnvido = jugadorQueAcepta;
            }else
            {
                this.ganadorEnvido = jugadorPasivo;
            }
        }

        public void DeclinarEnvido(Jugador jugadorPasivo)
        {
            this.ganadorEnvido = jugadorPasivo;
            this.tantoJugado = true;
            this.tantoCantado = false;
        }

        public static void Repartir(Jugador j1, Jugador j2)
        {
            j1.Mano = new Mano(true);

            do
            {
                j2.Mano = new Mano(true);
            } while (j1.Mano == j2.Mano);

            Historial.HistorialManosRepartidas.Add(j1.Mano);
            Historial.HistorialManosRepartidas.Add(j2.Mano);
            Historial.Guardar();
        }

        public int CalcularValorFaltaEnvido(Partida partida)
        {
            int ret;
            if (partida.CalcularGanador() is null)
            {
                ret = 15 - partida.Jugador1.PuntajeGeneral;
            }else
            {
                ret = 15 - partida.CalcularGanador().PuntajeGeneral;
            }
            return ret;
        }

        public void TerminarRonda()
        {
            if (this.ganadorEnvido is not null)
            {
                this.ganadorEnvido.PuntajeGeneral += this.valorDelTantoActual;
            }            
            this.ganadorTruco.PuntajeGeneral += this.valorDelTrucoActual;
        }

        /// <summary>
        /// Trae el jugador y supuntaje en formato de string.
        /// </summary>
        /// <param name="partida">Partida a la cual referimos</param>
        /// <param name="puesto">Posición del jugador a mostrar (1 0 2)</param>
        /// <returns></returns>
        public string MostrarPosicion(Partida partida, int puesto)
        {
            string puesto1 = $"{partida.Jugador1.Nombre} -> {partida.Jugador1.PuntajeGeneral} pts.";
            string puesto2 = $"{partida.Jugador2.Nombre} -> {partida.Jugador2.PuntajeGeneral} pts.";
            string ret;
            if (partida.Jugador1.PuntajeGeneral < partida.Jugador2.PuntajeGeneral)
            {
                puesto2 = $"{partida.Jugador1.Nombre} -> {partida.Jugador1.PuntajeGeneral} pts.";
                puesto1 = $"{partida.Jugador2.Nombre} -> {partida.Jugador2.PuntajeGeneral} pts.";
            }

            ret = puesto1;

            if(puesto==2)
            {
                ret = puesto2;
            }

            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.ganadorTruco.Nombre} se lleva {this.valorDelTrucoActual} pts. de la partida.");
            if (this.ganadorEnvido is not null)
            {
                sb.AppendLine($"{this.ganadorEnvido.Nombre} se lleva {this.valorDelTantoActual} pts. del tanto.");
            }
            else
            {
                sb.AppendLine($"No se cantó el tanto");
            }            

            return sb.ToString();
        }
    }
}
