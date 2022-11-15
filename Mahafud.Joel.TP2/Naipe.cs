using System;

namespace Entidades
{
    public class Naipe
    {
        private EPalos palo;
        private int numero;
        private int valorNaipe;
        private int valorTanto;

        
        public Naipe()
        {

        }

        public Naipe(bool rondomizar)
        {
            this.numero = Naipe.RandomizarNumero();
            this.palo = Naipe.RandomizarPalo();
            this.valorNaipe = CalcularValorNaipe(this.numero, this.palo);
            this.valorTanto = CalcularValorTanto(this.numero);
        }

        public EPalos Palo 
        { 
            get 
            {
                return this.palo; 
            }
            set
            {
                this.palo = value;
            }
        }

        public int Numero 
        { 
            get 
            { 
                return this.numero; 
            } 
            set
            {
                this.numero = value;
            }
        }

        public int ValorTanto 
        { 
            get 
            { 
                return this.valorTanto; 
            }
            set
            {
                this.valorTanto = value;
            }
        }

        public int ValorNaipe 
        { 
            get 
            { 
                return this.valorNaipe; 
            }
            set
            {
                this.valorNaipe = value;
            }
        }

        private int CalcularValorNaipe(int numero, EPalos palo)
        {
            int ret=numero;

            if (numero < 4)
            {
                ret += 12;
            }

            switch (palo)
            {
                case EPalos.Oro:
                    {
                        if (numero == 7)
                        {
                            ret = 16;
                        }
                        break;
                    }
                case EPalos.Basto:
                    {
                        if (numero == 1)
                        {
                            ret = 18;
                        }
                        break;
                    }
                case EPalos.Espada:
                    {
                        if (numero == 1)
                        {
                            ret = 19;
                        }
                        else if (numero == 7)
                        {
                            ret = 17;
                        }
                        break;
                    }
            }
            return ret;
        }

        private int CalcularValorTanto(int numero)
        {
            int ret=0;

            if(numero<=7)
            {
                ret = numero;
            }

            return ret;
        }

        private static int RandomizarNumero()
        {
            int numero;
            Random random = new Random();

            do
            {
                numero = random.Next(1, 13);
            } while (numero == 8 || numero == 9);

            return numero;
        }

        private static EPalos RandomizarPalo()
        {
            EPalos palo;
            Random random = new Random();

            palo = (EPalos)random.Next(0, 4);

            return palo;
        }

        public static bool operator ==(Naipe n1, Naipe n2)
        {
            return n1.numero == n2.numero && n1.palo == n2.palo;
        }

        public static bool operator !=(Naipe n1, Naipe n2)
        {
            return !(n1 == n2);
        }

        public override bool Equals(object obj)
        {
            bool ret = false;

            if (this is null && obj is null)
            {
                ret = true;
            }
            else if (obj is not null && obj is Naipe && this is not null)
            {
                ret = this == (Naipe)obj;
            }

            return ret;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.numero} de {this.palo.ToString()}";
        }
    }
}
