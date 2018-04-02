using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class AtletaAnexoModelo
    {
        public static DataSet AtletaAnexoLista()
        {
            DataSet lTableSet = new DataSet();
            
            Conexao.sql = @" SELECT * FROM ATLETAANEXO WHERE STATUS = 'A' ORDER BY CODIGO ASC ";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
           
            lTableSet = Conexao.ExecutaDataSet(Conexao.cmd);
            
            return lTableSet;
        }

        public static string Include()
        {            
            Conexao.sql = " INSERT INTO ATLETAANEXO(CODIGO_ATLETA, DESCRICAO, ARQUIVO, TIPOARQUIVO, STATUS, DATAREGISTRO) ";
            Conexao.sql += " VALUES(@CODIGO_ATLETA, @DESCRICAO, @ARQUIVO, @TIPOARQUIVO, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_ATLETA", AtletaAnexoEntidade.codigo_atleta));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DESCRICAO", AtletaAnexoEntidade.descricao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@ARQUIVO", AtletaAnexoEntidade.arquivo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@TIPOARQUIVO", AtletaAnexoEntidade.tipoarquivo));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
