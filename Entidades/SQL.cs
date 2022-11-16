using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class SQL
    {
        private static SqlConnection conexion;
        private static SqlCommand comandoTexto;
        private static SqlDataReader dataReader;

        /// <summary>
        /// Constructor estático, setea datos de conexión.
        /// </summary>
        static SQL()
        {
            SQL.conexion = new SqlConnection("Server=localhost;Database=Truco_db;Trusted_Connection=True;");
            SQL.comandoTexto = new SqlCommand();
            SQL.comandoTexto.CommandType = System.Data.CommandType.Text;
            SQL.comandoTexto.Connection = conexion;
        }

        public static SqlConnection Conexion
        {
            get
            {
                return SQL.conexion;
            }
        }

        /// <summary>
        /// Cierra una conexión en caso de estar abierta.
        /// </summary>
        public static void Cerrar()
        {
            if (SQL.conexion.State == System.Data.ConnectionState.Open)
            {
                SQL.conexion.Close();
            }
        }

        /// <summary>
        /// Lee todo de la tabla TablaPartidas y lo trae en un SqlDataReader. Posteriormente se debe cerrar la conexión a través del método estático SQL.Cerrar().
        /// </summary>
        /// <returns>Un SqlDataReader con la data leída</returns>
        public static SqlDataReader Leer ()
        {
            // El bloque finally con su correspondiente Close está en la llamada
            // ya que si lo cerraba antes, el DataReader que devolvía llegaba trunco. 

            try
            {
                SQL.comandoTexto.CommandText = "SELECT * FROM TablaPartidas";
                SQL.conexion.Open();
                SQL.dataReader = comandoTexto.ExecuteReader();
            }
            catch (Exception)
            {
                throw new ExcepcionBaseDeDatos();
            }
            return SQL.dataReader;
        }

        /// <summary>
        /// GUarda los datos relevantes de una partida en una base de datos.
        /// </summary>
        /// <param name="partida">Partida a gardar.</param>
        public static void Guardar(Partida partida)
        {
            Jugador ganador = partida.CalcularGanador();
            SQL.comandoTexto.CommandText = "INSERT INTO TablaPartidas VALUES (@Jugador1, @PuntosJugador1, @Jugador2, @PuntosJugador2, @Ganador)";
            SQL.comandoTexto.Parameters.AddWithValue("@Jugador1", partida.Jugador1.Nombre);
            SQL.comandoTexto.Parameters.AddWithValue("@PuntosJugador1", partida.Jugador1.PuntajeGeneral);
            SQL.comandoTexto.Parameters.AddWithValue("@Jugador2", partida.Jugador2.Nombre);
            SQL.comandoTexto.Parameters.AddWithValue("@PuntosJugador2", partida.Jugador2.PuntajeGeneral);

            if (ganador is null)
            {
                SQL.comandoTexto.Parameters.AddWithValue("@Ganador", "Empate");
            }
            else
            {
                SQL.comandoTexto.Parameters.AddWithValue("@Ganador", ganador.Nombre);
            }            

            try
            {
                SQL.conexion.Open();
                SQL.comandoTexto.ExecuteNonQuery();
                SQL.comandoTexto.Parameters.Clear();
            }
            catch(Exception)
            {
                throw new ExcepcionBaseDeDatos ();
            }
            finally
            {
                SQL.Cerrar();
            }
        }
    }
}
