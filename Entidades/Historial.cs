using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Historial
    {
        private static List<Mano> historialManosRepartidas;

        static Historial()
        {
            historialManosRepartidas = new List<Mano>();
            Historial.historialManosRepartidas = Serializador<List<Mano>>.DeserializarXML(historialManosRepartidas, "Historial_de_manos");
        }

        public static List<Mano> HistorialManosRepartidas
        {
            get
            {
                return Historial.historialManosRepartidas;
            }
            set
            {
                Historial.historialManosRepartidas = value;
            }
        }

        public static void Guardar()
        {
            Serializador<List<Mano>>.SerializarXML(Historial.historialManosRepartidas,"Historial_de_manos");
            {

            }
        }
    }
}
