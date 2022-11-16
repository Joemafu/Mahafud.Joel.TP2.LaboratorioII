using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mano
    {
        private List<Naipe> naipes;
        private double tanto;
        private bool tieneFlor;

        /// <summary>
        /// Constructor por defecto para la serialización.
        /// </summary>
        public Mano()
        {

        }

        /// <summary>
        /// Constructor real. Randomiza genera 3 naipes validando que no se repitan 
        /// ordena por valor descendente y calcula los puntos de tanto o si tiene flor.
        /// </summary>
        /// <param name="randomizar">Recibe un booleando para randomizar. True o false es indistinto.</param>
        public Mano (bool randomizar)
        {
            this.naipes = new List<Naipe>();
            Naipe aux;

            do
            {
                aux = new Naipe(true);

                if (ValidarNaipe(aux))
                {
                    this.naipes.Add(aux);
                }

            } while (this.naipes.Count < 3);

            this.naipes.Sort(OrdenamientoPorValor);

            this.tanto = this.CalcularTanto();
            this.tieneFlor = this.CalcularSiTieneFlor();

            if(this.tanto==0)
            {
                this.tanto = CalcularTantoSoloFiguras();
            }
        }

        public double Tanto
        { 
            get 
            { 
                return this.tanto; 
            } 
            set
            {
                this.tanto = value;
            }
        }

        public List<Naipe> Naipes 
        { 
            get 
            { 
                return this.naipes; 
            } 
            set
            {
                this.naipes = value;
            }
        }

        public bool TieneFlor 
        { 
            get 
            { 
                return this.tieneFlor; 
            }
            set
            {
                this.tieneFlor = value;
            }
        }

        public int OrdenamientoPorValor(Naipe n1, Naipe n2)
        {
            int ret = 1;

            if (n1.ValorNaipe == n2.ValorNaipe)
            {
                ret = 0;
            }
            else if (n1.ValorNaipe > n2.ValorNaipe)
            {
                ret = -1;
            }

            return ret;
        }

        public static bool operator ==(Mano m1, Mano m2)
        {
            bool ret = false;

            foreach (Naipe naipeM1 in m1.naipes)
            {
                foreach (Naipe naipeM2 in m2.naipes)
                {
                    if (naipeM1==naipeM2)
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }

        public static bool operator !=(Mano m1, Mano m2)
        {
            return !(m1 == m2);
        }

        public override bool Equals(object obj)
        {
            bool ret = false;

            if (this is null && obj is null)
            {
                ret = true;
            }
            else if (obj is not null && obj is Mano && this is not null)
            {
                ret = this == (Mano)obj;
            }

            return ret;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Valida que el naipe randomizado no esté repetido con otro de la mano.
        /// </summary>
        /// <param name="naipe">Naipe a validar.</param>
        /// <returns>True si es válido, false caso contrario.</returns>
        public bool ValidarNaipe(Naipe naipe)
        {
            bool ret = true;

            foreach (Naipe item in this.naipes)
            {
                if (item==naipe)
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// Calcula el tanto de la mano que lo invoca.
        /// </summary>
        /// <returns>Retorna valor del tanto.</returns>
        public int CalcularTanto()
        {
            int ret=0;

            if(this.CalcularSiTieneFlor())
            {
                ret += 20;
                foreach (Naipe item in this.Naipes)
                {
                    ret += item.ValorTanto;
                }
            }
            else if (this.CalcularSiTieneTanto())
            {
                ret = this.CalcularTantoDoble();
            }
            else
            {
                foreach (Naipe item in this.Naipes)
                {
                    if (item.ValorTanto> ret)
                    {
                        ret = item.ValorTanto;
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// Calcula si la Mano que lo invoca tiene flor.
        /// </summary>
        /// <returns>True si tiene flor. False caso contrario.</returns>
        public bool CalcularSiTieneFlor()
        {
            bool ret = false;

            if (this.Naipes[0].Palo == this.Naipes[1].Palo && this.Naipes[0].Palo == this.Naipes[2].Palo)
            {
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// Calcula los casos en que la mano contiene 2 cartas del mismo palo o más.
        /// </summary>
        /// <returns>True si tiene al menos 2 del mismo palo.</returns>
        public bool CalcularSiTieneTanto()
        {
            bool ret = false;

            if (this.Naipes[0].Palo == this.Naipes[1].Palo || this.Naipes[0].Palo == this.Naipes[2].Palo || this.Naipes[1].Palo == this.Naipes[2].Palo)
            {
                ret = true;
            }

            return ret;
        }

        /// <summary>
        /// Calcula el valor del tanto en caso que tenga 2 del mismo palo.
        /// </summary>
        /// <returns>retorna valor del tanto.</returns>
        public int CalcularTantoDoble()
        {
            int ret = 20;

            if (this.Naipes[0].Palo == this.Naipes[1].Palo)
            {
                ret += this.Naipes[0].ValorTanto + this.Naipes[1].ValorTanto;
            }
            else if (this.Naipes[0].Palo == this.Naipes[2].Palo)
            {
                ret += this.Naipes[0].ValorTanto + this.Naipes[2].ValorTanto;
            }
            else if (this.Naipes[1].Palo == this.Naipes[2].Palo)
            {
                ret += this.Naipes[1].ValorTanto + this.Naipes[2].ValorTanto;
            }

            return ret;
        }

        /// <summary>
        /// Calcula el valor del tanto en el caso de que tenga 2 del mismo palo pero estas sean figuras.
        /// </summary>
        /// <returns>Retorna un decimal que sirve para ver los diferentes valores de un tanto que vale 0</returns>
        private double CalcularTantoSoloFiguras()
        {
            double ret = 0.25;
            int aux = 0;

            foreach (Naipe item in this.Naipes)
            {
                if (item.ValorNaipe>aux)
                {
                    aux = item.ValorNaipe;
                }
            }

            if (aux == 12)
            {
                ret = 0.75;
            }
            else if (aux == 11)
            {
                ret = 0.5;
            }

            return ret;
        }

        /// <summary>
        /// Sobreescritura de método ToString.
        /// </summary>
        /// <returns>Devuelve un string con el número y palo de los 3 naipes de la mano y un separador para enlistar.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Naipe item in this.naipes)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("******///******");

            return sb.ToString();
        }
    }
}
