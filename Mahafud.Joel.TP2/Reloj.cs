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

        static Reloj()
        {
            Reloj.tasaDeRefresco = 1000;
            Reloj.hiloSecundario = new Task(Reloj.ActualizarReloj);
            Reloj.hiloSecundario.Start();
        }

        public static void ActualizarReloj()
        {
            bool a = true;
            do
            {
                TasaDeRefrescoSuperada.Invoke();
                Thread.Sleep(Reloj.tasaDeRefresco);
            } while (a);
            a = false;
        }
    }
}
