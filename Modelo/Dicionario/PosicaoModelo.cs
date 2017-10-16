using System.Data;
using Npgsql;
using System;
using APB.Framework.Encryption;

namespace Modelo
{
    [Serializable]
    public class PosicaoModelo
    {
        public static DataSet PossicaoLista()
        {
            DataSet lTableSet = new DataSet();
            
            Conexao.sql = @" SELECT * FROM POSICAO WHERE STATUS = 'A' ORDER BY DESCRICAO ";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
           
            lTableSet = Conexao.ExecutaDataSet(Conexao.cmd);
            
            return lTableSet;
        }

        public static string Include()
        {            
            Conexao.sql = " INSERT INTO POSICAO(DESCRICAO, SIGLA, STATUS, DATAREGISTRO) ";
            Conexao.sql += " VALUES(@DESCRICAO, @SIGLA, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DESCRICAO", PosicaoEntidade.descricao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@SIGLA", PosicaoEntidade.sigla));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
