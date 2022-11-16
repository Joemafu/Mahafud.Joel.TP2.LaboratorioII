using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public static class Reloj
    {
        private static int tasaDeRefresco;
        private static Task hiloSecundario;

        public static event Delegado.DelegadoReloj TasaDeRefrescoSuperada;

        /// <summary>
        /// Setea la tasa de refresco del reloj en 1 segundo, genera un nuevo hilo asociado al método Reloj.AtualizarReloj y lo corre.
        /// </summary>
        static Reloj()
        {
            Reloj.tasaDeRefresco = 1000;
            Reloj.hiloSecundario = new Task(Reloj.ActualizarReloj);
            Reloj.hiloSecundario.Start();
        }

        /// <summary>
        /// Invoca a Reloj.TasaDeRefrescoSuperada indefinidamente cada vez que se cumple la tasa de refresco.
        /// </summary>
        public static void ActualizarReloj()
        {
            do
            {
                Reloj.TasaDeRefrescoSuperada.Invoke();
                Thread.Sleep(Reloj.tasaDeRefresco);
            } while (true);
        }
    }
}
