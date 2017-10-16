using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class AtletaStatusModelo
    {
        public static DataSet AtletaStatusLista()
        {
            DataSet lTableSet = new DataSet();
            
            Conexao.sql = @" SELECT * FROM ATLETASTATUS WHERE STATUS = 'A' ORDER BY CODIGO ASC ";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
           
            lTableSet = Conexao.ExecutaDataSet(Conexao.cmd);
            
            return lTableSet;
        }

        public static string Include()
        {            
            Conexao.sql = " INSERT INTO ATLETASTATUS(DESCRICAO, SIGLA, STATUS, DATAREGISTRO) ";
            Conexao.sql += " VALUES(@DESCRICAO, @SIGLA, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DESCRICAO", PosicaoEntidade.descricao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@SIGLA", PosicaoEntidade.sigla));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
