using System;

namespace Entidades
{
    public class Naipe
    {
        private EPalos palo;
        private int numero;
        private int valorNaipe;
        private int valorTanto;

        /// <summary>
        /// Constructor por defecto para la serialización.
        /// </summary>
        public Naipe()
        {

        }

        /// <summary>
        /// Constructor real. Randomiza los atributos del naipe y calcula su valor en juego.
        /// </summary>
        /// <param name="randomizar">True o false es indistinto. Indica que el naipe debe ser randomizado.</param>
        public Naipe(bool randomizar)
        {
            this.numero = Naipe.RandomizarNumero();
            this.palo = Naipe.RandomizarPalo();
            this.valorNaipe = CalcularValorNaipe(this.numero, this.palo);
            this.valorTanto = CalcularValorTanto();
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

        /// <summary>
        /// Calcula el valor del naipe en mesa.
        /// </summary>
        /// <param name="numero">Numero del naipe.</param>
        /// <param name="palo">Palo del naipe.</param>
        /// <returns>Valor representativo en la escala de las cartas según reglas del juego.</returns>
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

        /// <summary>
        /// Calcula el valor de tanto de un naipe individual (caso de tener 3 naipes de palo diferente).
        /// </summary>
        /// <param name="numero">Numero del naipe.</param>
        /// <returns>Valor del naipe en tanto.</returns>
        public int CalcularValorTanto()
        {
            int ret=0;

            if(this.Numero<=7)
            {
                ret = this.Numero;
            }

            return ret;
        }

        /// <summary>
        /// Randomiza el numero del naipe.
        /// </summary>
        /// <returns>Numero random del 1 al 12 sin 8 ni 9</returns>
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

        /// <summary>
        /// Randomiza el palo del naipe.
        /// </summary>
        /// <returns>Palo randomizado.</returns>
        public static EPalos RandomizarPalo()
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

        /// <summary>
        /// Sobreescritura de ToString
        /// </summary>
        /// <returns>Retorna un string con el numero y el palo del naipe</returns>
        public override string ToString()
        {
            return $"{this.numero} de {this.palo.ToString()}";
        }
    }
}
