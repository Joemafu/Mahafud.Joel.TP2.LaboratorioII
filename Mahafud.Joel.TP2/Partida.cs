using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Partida
    {
        private Jugador jugador1;
        private Jugador jugador2;
        private Ronda ronda;
        private int numeroDeMano; //Se juegan 4 manos

        /// <summary>
        /// Constructor, recibe 2 jugadores y los ubica en una nueva partida.
        /// </summary>
        /// <param name="j1">Jugador 1</param>
        /// <param name="j2">Jugador 2</param>
        public Partida(Jugador j1, Jugador j2)
        {
            this.jugador1 = j1;
            this.jugador2 = j2;
            this.numeroDeMano = 1;
            this.ronda = new Ronda();
            Ronda.Repartir(this.Jugador1, this.Jugador2);
            this.jugador1.TieneElQuiero = true;
            this.jugador2.TieneElQuiero = true;
        }

        public Jugador Jugador1 { get { return this.jugador1; } }

        public Jugador Jugador2 { get { return this.jugador2; } }

        public int NumeroDeMano { get { return this.numeroDeMano; } }

        public Ronda Ronda { get { return this.ronda; } }

        /// <summary>
        /// Retorna true si la partida alcanzó un parámetro que determina su finalización.
        /// </summary>
        public bool PartidaTerminada 
        {
            get 
            {
                return this.numeroDeMano >= 4 || this.jugador1.PuntajeGeneral >= 15 || this.jugador2.PuntajeGeneral >= 15; 
            } 
        }

        /// <summary>
        /// Genera una nueva ronda y reparte nuevas manos. Resetea valores correspondientes e incrementa valor del numero de mano.
        /// </summary>
        public void AvanzarRonda()
        {
            this.numeroDeMano++;
            this.ronda = new Ronda();
            Ronda.Repartir(this.Jugador1, this.Jugador2);
            this.jugador1.TieneElQuiero = true;
            this.jugador2.TieneElQuiero = true;
        }

        /// <summary>
        /// Calcula quién ganó la partida que lo invoca.
        /// </summary>
        /// <returns>Devuelve Jugador ganador</returns>
        public Jugador CalcularGanador()
        {
            Jugador ret = null;
            if (this.jugador1.PuntajeGeneral > this.jugador2.PuntajeGeneral)
            {
                ret = this.jugador1;
            }else if (this.jugador1.PuntajeGeneral < this.jugador2.PuntajeGeneral)
            {
                ret = this.jugador2;
            }
            return ret;
        }

        public override string ToString()
        {
            Jugador ganador = CalcularGanador();
            StringBuilder sb = new StringBuilder();

            if (ganador is null)
            {
                sb.AppendLine($"Empate!");
            }
            else
            {
                sb.AppendLine($"Ganador {ganador}");
            }

            return sb.ToString();
        }
    }
}
