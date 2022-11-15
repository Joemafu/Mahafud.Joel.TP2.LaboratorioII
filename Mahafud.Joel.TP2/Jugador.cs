using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador
    {
        private Mano mano;
        private int puntajeGeneral;
        private string nombre;
        private bool esMano;
        private bool esSuTurno;
        private bool tieneElQuiero;

        public Jugador(string nombre, bool esMano)
        {
            this.nombre = nombre;
            this.esMano = esMano;
            this.esSuTurno = esMano;
        }

        public int PuntajeGeneral
        {
            get
            {
                return this.puntajeGeneral;
            }
            set
            {
                this.puntajeGeneral = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public bool EsSuTurno
        {
            get
            {
                return this.esSuTurno;
            }
            set
            {
                this.esSuTurno = value;
            }
        }

        public bool EsMano
        {
            get
            {
                return this.esMano;
            }
            set
            {
                this.esMano = value;
            }
        }

        public bool TieneElQuiero
        {
            get
            {
                return this.tieneElQuiero;
            }
            set
            {
                this.tieneElQuiero = value;
            }
        }

        public Mano Mano
        {
            get
            {
                return this.mano;
            }
            set
            {
                this.mano = value;
            }
        }

        public override string ToString()
        {
            return $"{this.nombre} con {this.puntajeGeneral} pts.";
        }
    }
}
