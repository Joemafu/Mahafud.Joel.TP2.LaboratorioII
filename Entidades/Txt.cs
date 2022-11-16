using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class Txt
    {
        private static StreamWriter sw;
        private static StreamReader sr;

        static Txt ()
        {
            
        }

        /// <summary>
        /// Lee el archivo Historial_De_Pardas.txt del directorio actual.
        /// </summary>
        /// <returns>Retorna un string con el contenido del archivo.</returns>
        public static string Leer()
        {
            string ret = "";

            if (!File.Exists("Historial_De_Pardas.txt"))
            {
                Txt.sw = File.CreateText("Historial_De_Pardas.txt");
                Txt.sw.Close();
                Txt.sw.Dispose();
            }

            Txt.sr = File.OpenText("Historial_De_Pardas.txt");

            ret = sr.ReadToEnd();

            sr.Close();

            return ret;
        }

        /// <summary>
        /// Guarda un string con información de una parda.
        /// </summary>
        /// <param name="partida">Partida de donde extraer los datos.</param>
        /// <param name="naipe1">Naipe empardado 1</param>
        /// <param name="naipe2">Naipe empardado 2</param>
        public static void Guardar(Partida partida, Naipe naipe1, Naipe naipe2)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"El {naipe1} de {partida.Jugador1.Nombre} empardó con el {naipe2} de {partida.Jugador2.Nombre} en la ronda {partida.Ronda.NumeroDeTurno} de la mano {partida.NumeroDeMano} el {DateTime.Now.ToShortDateString()} a las {DateTime.Now.ToShortTimeString()}");
            
            sb.AppendLine("******///******");

            try
            {
                Txt.sw = new StreamWriter("Historial_De_Pardas.txt", true, UTF8Encoding.UTF8);

                Txt.sw.WriteLine(sb.ToString());
            }
            catch
            {

            }
            finally
            {
                Txt.sw.Close();
                Txt.sw.Dispose();
            }
        }
    }
}
