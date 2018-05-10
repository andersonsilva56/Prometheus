using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class AtletaAnexoModelo
    {
        public static DataTable AtletaAnexoLista()
        {
            DataTable lTableSet = new DataTable();
            
            Conexao.sql = @" SELECT * FROM ATLETAANEXO WHERE STATUS = 'A' ORDER BY CODIGO ASC ";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
           
            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);
            
            return lTableSet;
        }

        public static DataTable AtletaAnexoLista(string pId)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT * FROM ATLETAANEXO WHERE STATUS = 'A' AND CODIGO_ATLETA = @CODIGO_ATLETA ORDER BY CODIGO ASC ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_ATLETA", pId));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static DataTable AtletaAnexoByte()
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT ARQUIVO FROM ATLETAANEXO WHERE STATUS = 'A' AND CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", AtletaAnexoEntidade.codigo));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

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

        public static string Update()
        {
            Conexao.sql = @" UPDATE ATLETAANEXO SET DESCRICAO = @DESCRICAO WHERE CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", AtletaAnexoEntidade.codigo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DESCRICAO", AtletaAnexoEntidade.descricao));

            return Conexao.ExecutaComando(Conexao.cmd);
        }

        public static string Delete()
        {
            Conexao.sql = @" UPDATE ATLETAANEXO SET STATUS = 'I' WHERE CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", AtletaAnexoEntidade.codigo));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
