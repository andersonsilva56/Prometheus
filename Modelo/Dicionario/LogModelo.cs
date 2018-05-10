using System.Data;
using Npgsql;
using System;
using APB.Framework.Encryption;

namespace Modelo
{
    [Serializable]
    public class LogModelo
    {
        public static DataTable Acesso()
        {
            DataTable lTableSet = new DataTable();
            
            Conexao.sql = @" SELECT * FROM LOG WHERE CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", LogEntidade.codigo));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);
            
            return lTableSet;
        }

        public static string Include()
        {            
            Conexao.sql = " INSERT INTO LOG(DESCRICAO) ";
            Conexao.sql += " VALUES(@DESCRICAO); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DESCRICAO", LogEntidade.descricao));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
