using System.Data;
using Npgsql;
using System;
using APB.Framework.Encryption;

namespace Modelo
{
    [Serializable]
    public class UsuarioModelo
    {
        public static DataTable Acesso()
        {
            DataTable lTableSet = new DataTable();
            
            Conexao.sql = @" SELECT * FROM USUARIO WHERE EMAIL = @EMAIL AND SENHA = @SENHA AND STATUS = 'A' ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@EMAIL", UsuarioEntidade.email));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@SENHA", Crypto.Encode(UsuarioEntidade.senha)));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);
            
            return lTableSet;
        }

        public static string Include()
        {            
            Conexao.sql = " INSERT INTO USUARIO(EMAIL, SENHA, NOME, STATUS, DATAREGISTRO) ";
            Conexao.sql += " VALUES(@EMAIL, @SENHA, @NOME, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@EMAIL", UsuarioEntidade.email));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@SENHA", Crypto.Encode(UsuarioEntidade.senha)));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@NOME", UsuarioEntidade.nome));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
