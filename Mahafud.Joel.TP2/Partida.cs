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

        public Jugador Jugador1 { get { return this.jugador1; } }

        public Jugador Jugador2 { get { return this.jugador2; } }

        public int NumeroDeMano { get { return this.numeroDeMano; } }

        public Ronda Ronda { get { return this.ronda; } }

        public bool PartidaTerminada 
        {
            get 
            {
                return this.numeroDeMano == 4 || this.jugador1.PuntajeGeneral >= 15 || this.jugador2.PuntajeGeneral >= 15; 
            } 
        }

        public Partida (Jugador j1, Jugador j2)
        {
            this.jugador1 = j1;
            this.jugador2 = j2;
            this.numeroDeMano = 1;
            this.ronda = new Ronda();
            Ronda.Repartir(this.Jugador1, this.Jugador2);
            this.jugador1.TieneElQuiero = true;
            this.jugador2.TieneElQuiero = true;
        }     

        public void AvanzarRonda()
        {
            this.numeroDeMano++;
            this.ronda = new Ronda();
            Ronda.Repartir(this.Jugador1, this.Jugador2);
            this.jugador1.TieneElQuiero = true;
            this.jugador2.TieneElQuiero = true;
        }

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
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Ganador {CalcularGanador()}");

            return sb.ToString();
        }
    }
}
