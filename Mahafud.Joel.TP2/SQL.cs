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

        static SQL()
        {
            SQL.conexion = new SqlConnection("Server=localhost;Database=Truco_db;User ID=sa;Password=truco;");
            SQL.comandoTexto = new SqlCommand();
            SQL.comandoTexto.CommandType = System.Data.CommandType.Text;
            SQL.comandoTexto.Connection = conexion;
        }

        public static void Cerrar()
        {
            if (SQL.conexion.State == System.Data.ConnectionState.Open)
            {
                SQL.conexion.Close();
            }
        }

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

        public static void Guardar(Partida partida)
        {
            SQL.comandoTexto.CommandText = "INSERT INTO TablaPartidas VALUES (@Jugador1, @PuntosJugador1, @Jugador2, @PuntosJugador2, @Ganador)";
            SQL.comandoTexto.Parameters.AddWithValue("@Jugador1", partida.Jugador1.Nombre);
            SQL.comandoTexto.Parameters.AddWithValue("@PuntosJugador1", partida.Jugador1.PuntajeGeneral);
            SQL.comandoTexto.Parameters.AddWithValue("@Jugador2", partida.Jugador2.Nombre);
            SQL.comandoTexto.Parameters.AddWithValue("@PuntosJugador2", partida.Jugador2.PuntajeGeneral);
            SQL.comandoTexto.Parameters.AddWithValue("@Ganador", partida.CalcularGanador().Nombre);

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
