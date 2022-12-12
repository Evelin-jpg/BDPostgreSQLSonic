using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BDServerSonic
{
    class ConexionPostgreSQL
    {
        public static NpgsqlConnection conexion = new NpgsqlConnection();

        static string servidor = "localhost";
        static string bd = "Sonic2";
        static string ususario = "postgres";
        static string password = "Sonic";
        static string puerto = "5432";


        static String cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id =" + ususario + ";" + "password=" + password + ";" + "database=" + bd + ";";

        private static void conectar()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                //MessageBox.Show("Se conecto correctamente la base de datos");
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("No se puede conectar a la base de datos de PostgreSQL, error:" + e.ToString());
            }


        }

        public static DataTable EjecutaConsultaSelect(string consulta)
        {
            conectar();
            NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public static void EjecutaConsulta(string consulta)
        {
            conectar();
            NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
