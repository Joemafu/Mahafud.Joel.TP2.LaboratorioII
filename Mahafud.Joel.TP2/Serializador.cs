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

        /// <summary>
        /// Serializa un objeto en XML
        /// </summary>
        /// <param name="objeto">Objeto genérico</param>
        /// <param name="nombreDeArchivo">Nombre que llevará el archivo XML</param>
        public static void SerializarXML (T objeto, string nombreDeArchivo)
        {
            string path = Environment.CurrentDirectory + "\\" + nombreDeArchivo + ".XML";

            using (StreamWriter sw = new StreamWriter(path))
            {
                XmlSerializer serializador = new XmlSerializer(objeto.GetType());
                serializador.Serialize(sw, objeto);
            }         
        }

        /// <summary>
        /// Deserializa un objeto de un archivo XML y lo retorna.
        /// </summary>
        /// <param name="objeto">Objeto de tipo genérico a deserializar.</param>
        /// <param name="nombreDeArchivo">Nombre del archivo a deserializar.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Serializa en Json
        /// </summary>
        /// <param name="objeto">Objeto de tipo genérico</param>
        /// <param name="nombreDeArchivo">Nombre del archivo Json</param>
        public static void SerializarJson (T objeto, string nombreDeArchivo)
        {
            StreamWriter sw = null;

            List<T> listaDeObjetos = new List<T>();

            listaDeObjetos = Serializador<T>.DeserializarJson(listaDeObjetos, nombreDeArchivo);

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

        /// <summary>
        /// Deserealiza Json
        /// </summary>
        /// <param name="objeto">Objeto de tipo genérico</param>
        /// <param name="nombreDeArchivo">Nombre del archivo Json</param>
        /// <returns></returns>
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
