using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class AtletaFrequenciaModelo
    {
        public static DataTable AtletaFrequenciaLista()
        {
            DataTable lTableSet = new DataTable();
            
            Conexao.sql = @" SELECT * FROM ATLETAFREQUENCIA WHERE STATUS = 'A' ORDER BY CODIGO ASC ";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
           
            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);
            
            return lTableSet;
        }

        public static DataTable AtletaFrequenciaPresenca(string pQuery)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT PES.CODIGO, PES.NOME, ATL.CODIGO ATLETACODIGO
                            ,(SELECT POS.DESCRICAO FROM POSICAO POS 
                            WHERE ATL.CODIGO_POSICAO = POS.CODIGO AND POS.STATUS = 'A')POSICAO
                            ,(SELECT ATS.DESCRICAO FROM ATLETASTATUS ATS 
                            WHERE ATL.CODIGO_ATLETASTATUS = ATS.CODIGO AND ATS.STATUS = 'A')STATUS
                            FROM PESSOA PES JOIN ATLETA ATL
                            ON (PES.CODIGO = ATL.CODIGO_PESSOA)
                            WHERE PES.STATUS = 'A'
                            AND PES.CODIGO_TIPOPESSOA = 2
                            AND ATL.CODIGO NOT IN (SELECT CODIGO_ATLETA 
                            FROM ATLETAFREQUENCIA WHERE CODIGO_FREQUENCIA=@CODIGO AND STATUS = 'A') ";
            Conexao.sql += pQuery;
            Conexao.sql += "ORDER BY NOME, POSICAO, STATUS";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", AtletaFrequenciaEntidade.codigo));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }        

        public static string Include()
        {            
            Conexao.sql = " INSERT INTO ATLETAFREQUENCIA(CODIGO_ATLETA, CODIGO_FREQUENCIA, TIPO, OBSERVACAO, STATUS, DATAREGISTRO) ";
            Conexao.sql += " VALUES(@CODIGO_ATLETA, @CODIGO_FREQUENCIA, @TIPO, @OBSERVACAO, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_ATLETA", AtletaFrequenciaEntidade.codigo_atleta));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_FREQUENCIA", AtletaFrequenciaEntidade.codigo_frequencia));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@TIPO", AtletaFrequenciaEntidade.tipo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@OBSERVACAO", AtletaFrequenciaEntidade.observacao));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
