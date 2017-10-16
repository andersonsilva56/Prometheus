using System;
using System.Data;
using Npgsql;

namespace Modelo
{
    public static class Conexao
    {
        public static NpgsqlConnection conn;
        static string conexao = "Server=127.0.0.1; Port=5432; Database=Prometheus; User Id=postgres; Password=!@#Pr0metheus*@!;";
        public static NpgsqlCommand cmd;
        public static NpgsqlCommand QOperacao;
        public static NpgsqlDataReader dr;
        public static string sql;
        public static string excecao;

        public static string conectar()
        {
            try
            {
                conn = new NpgsqlConnection(conexao);
                conn.Open();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static void desconectar()
        {
            conn.Close();
            conn = null;
        }


        public static string ExecutaComando(NpgsqlCommand Comando)
        {
            conectar();
            Comando.Connection = conn;

            try
            {
                Comando.ExecuteNonQuery();
                desconectar();
                return "";
            }
            catch (Exception e)
            {
                desconectar();
                excecao = e.Message.ToString();
                return e.Message;
            }
        }

        public static DataSet ExecutaDataSet(NpgsqlCommand Comando)
        {
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da;

            conectar();
            Comando.Connection = conn;

            try
            {
                da = new NpgsqlDataAdapter("", conn);
                da.SelectCommand = Comando;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds, "consulta");
                desconectar();
                return ds;
            }
            catch (Exception e)
            {
                desconectar();
                excecao = e.Message.ToString();
                return ds;
            }
        }
    }
}
