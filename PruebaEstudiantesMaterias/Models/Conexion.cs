using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PruebaEstudiantesMaterias.Models
{
    public class Conexion
    {




        static string strConeccion = "Data Source=DESKTOP-GHUOM0P\\SQLEXPRESS;Database=prueba;User Id=sa;Password=1234;";

        public static DataTable SqlConsulta(String SQL)
        {
            SQL = "set dateformat dmy; " + SQL;
            SqlConnection conec = new SqlConnection(strConeccion);

            SqlCommand comando = new SqlCommand(SQL, conec);

            SqlDataAdapter datos = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable();

            try
            {
                conec.Open();
                datos.Fill(tabla);

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                conec.Close();
                comando.Dispose();
            }
            return tabla;
        }

        public static string SqlQueryGestion(string SQL)
        {

            SqlConnection conexion = new SqlConnection(strConeccion);
            SqlCommand comando = new SqlCommand(SQL);
            comando.Connection = conexion;
            string val = "no";

            try
            {
                conexion.Open();
                int fill_afec = comando.ExecuteNonQuery();

                if (fill_afec > 0)
                {
                    val = "yes";


                }

            }
            catch (System.Exception a)
            {
                return a.Message.ToString();
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return val;
        }

        public static bool existe(string comandoSQL)
        {
            comandoSQL = "set dateformat dmy; " + comandoSQL;
            SqlConnection conec = new SqlConnection(strConeccion);
            SqlCommand comando = new SqlCommand(comandoSQL, conec);
            try
            {
                conec.Open();
                var reader = comando.ExecuteReader();
                if (!reader.HasRows)
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conec.Close();
                comando.Dispose();
            }

            return true;
        }

        public static string SqlJson(string comandoSQL)
        {
            comandoSQL = "set dateformat dmy; " + comandoSQL;
            SqlConnection conec = new SqlConnection(strConeccion);
            SqlCommand comando = new SqlCommand(comandoSQL, conec);
            var jsonResult = new StringBuilder();
            try
            {
                conec.Open();
                var reader = comando.ExecuteReader();
                if (!reader.HasRows)
                {
                    jsonResult.Append("[]");
                }
                else
                {
                    while (reader.Read())
                    {
                        jsonResult.Append(reader.GetValue(0).ToString());
                    }
                }
            }
            catch (Exception e)
            {
                jsonResult.Append("[]");
            }
            finally
            {
                conec.Close();
                comando.Dispose();
            }

            return jsonResult.ToString();
        }
    }
}