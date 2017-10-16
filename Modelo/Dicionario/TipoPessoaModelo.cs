using System.Data;
using Npgsql;
using System;
using APB.Framework.Encryption;

namespace Modelo
{
    [Serializable]
    public class TipoPessoaModelo
    {
        public static DataSet TipoPessoaLista()
        {
            DataSet lTableSet = new DataSet();
            
            Conexao.sql = @" SELECT * FROM TIPOPESSOA WHERE STATUS = 'A' ORDER BY CODIGO ASC ";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
           
            lTableSet = Conexao.ExecutaDataSet(Conexao.cmd);
            
            return lTableSet;
        }

        public static string Include()
        {            
            Conexao.sql = " INSERT INTO TIPOPESSOA(DESCRICAO, STATUS, DATAREGISTRO) ";
            Conexao.sql += " VALUES(@DESCRICAO, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DESCRICAO", TipoPessoaEntidade.descricao));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
