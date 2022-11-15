using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace Entidades
{
    public static class Serializador<T> where T : class
    {
        static Serializador()
        {
            if (!File.Exists("Historial_De_Flores.json"))
            {
                StreamWriter sw = File.CreateText("Historial_De_Flores.json");
                sw.Close();
                sw.Dispose();
            }
        }

        public static void SerializarXML (T objeto, string nombreDeArchivo)
        {
            string path = Environment.CurrentDirectory + "\\" + nombreDeArchivo + ".XML";

            using (StreamWriter sw = new StreamWriter(path))
            {
                XmlSerializer serializador = new XmlSerializer(objeto.GetType());
                serializador.Serialize(sw, objeto);
            }         
        }

        public static T DeserializarXML(T objeto, string nombreDeArchivo)
        {
            T ret = objeto;

            string path = Environment.CurrentDirectory + "\\" + nombreDeArchivo + ".XML";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    XmlSerializer serializador = new XmlSerializer(objeto.GetType());
                    ret = serializador.Deserialize(sr) as T;
                }
            }
            catch (Exception)
            {

            }

            return ret;
        }

        public static void SerializarJson (T objeto, string nombreDeArchivo)
        {
            StreamWriter sw = null;

            List<T> listaDeObjetos = new List<T>();

            listaDeObjetos = Serializador<T>.DeserializarJson(listaDeObjetos, "Historial_De_Flores.json");

            listaDeObjetos.Add(objeto);

            JsonSerializerOptions opciones = new JsonSerializerOptions();

            opciones.WriteIndented = true;

            string objetoEnJson = JsonSerializer.Serialize(listaDeObjetos, opciones);

            try
            {   
                sw = new StreamWriter (nombreDeArchivo, true, UTF8Encoding.UTF8);

                sw.WriteLine(objetoEnJson);
            }
            catch (Exception)
            {

            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }
        }

        public static List<T> DeserializarJson(List<T> objeto, string nombreDeArchivo)
        {
            StreamReader sr = null;
            List<T> ret = objeto;
            string jsonEnCadena;

            try
            {
                sr = File.OpenText(nombreDeArchivo);
                jsonEnCadena = sr.ReadToEnd();
                
                if (!String.IsNullOrWhiteSpace(jsonEnCadena))
                {
                    ret = JsonSerializer.Deserialize<List<T>>(jsonEnCadena);
                }                
            }
            catch(Exception)
            {

            }
            finally
            {
                sr.Close();
                sr.Dispose();
            }
            
            return ret;
        }
    }
}
