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

        private bool ValidarNaipe(Naipe naipe)
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

        private int CalcularTanto()
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
            else if (this.TieneTanto())
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

        private bool CalcularSiTieneFlor()
        {
            bool ret = false;

            if (this.Naipes[0].Palo == this.Naipes[1].Palo && this.Naipes[0].Palo == this.Naipes[2].Palo)
            {
                ret = true;
            }

            return ret;
        }

        private bool TieneTanto()
        {
            bool ret = false;

            if (this.Naipes[0].Palo == this.Naipes[1].Palo || this.Naipes[0].Palo == this.Naipes[2].Palo || this.Naipes[1].Palo == this.Naipes[2].Palo)
            {
                ret = true;
            }

            return ret;
        }

        private int CalcularTantoDoble()
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
