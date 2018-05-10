using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class FrequenciaModelo
    {
        public static DataTable FrequenciaLista()
        {
            DataTable lTableSet = new DataTable();
            
            Conexao.sql = @" SELECT * FROM FREQUENCIA WHERE STATUS = 'A' ORDER BY CODIGO ASC ";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
           
            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);
            
            return lTableSet;
        }

        public static DataTable FrequenciaLista(string pId)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT * FROM FREQUENCIA WHERE STATUS = 'A' AND CODIGO = @CODIGO ORDER BY CODIGO ASC ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", pId));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static DataTable FrequenciaLista(DateTime pData)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT * FROM FREQUENCIA WHERE STATUS = 'A' AND DIA = @DIA ORDER BY CODIGO ASC ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DIA", pData));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static DataTable FrequenciaDataJustificativa(string pQuery)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT CODIGO, TO_CHAR(DIA, 'DD/MM/YYYY') DIA FROM FREQUENCIA ";
            Conexao.sql += pQuery;
            Conexao.sql += "ORDER BY DIA";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static DataTable FrequenciaListaParametro(string pQuery)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT CODIGO,TO_CHAR(DIA, 'DD/MM/YYYY') DIA, CASE TIPO WHEN 1 THEN 'TREINO NORMAL' WHEN 2 THEN 'DAY CAMP' 
                            END TIPO, TIPO TIPOPARAM,PESO, OBSERVACAO FROM FREQUENCIA WHERE STATUS = 'A' ";
            Conexao.sql += pQuery;
            Conexao.sql += "ORDER BY DIA";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static DataTable FrequenciaListaRelatorio()
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT PES.CODIGO, PES.NOME, ATL.CODIGO ATLETACODIGO
                            ,(SELECT POS.DESCRICAO FROM POSICAO POS 
                            WHERE ATL.CODIGO_POSICAO = POS.CODIGO AND POS.STATUS = 'A')POSICAO
                            ,(SELECT ATS.DESCRICAO FROM ATLETASTATUS ATS 
                            WHERE ATL.CODIGO_ATLETASTATUS = ATS.CODIGO AND ATS.STATUS = 'A')STATUS
                            ,(SELECT OBSERVACAO FROM ATLETAFREQUENCIA ATLF 
                            WHERE ATLF.CODIGO_ATLETA = ATL.CODIGO AND ATLF.STATUS='A' 
                            AND ATLF.CODIGO_FREQUENCIA = @CODIGO)
                            FROM PESSOA PES LEFT OUTER JOIN ATLETA ATL
                            ON (PES.CODIGO = ATL.CODIGO_PESSOA)
                            WHERE PES.STATUS = 'A'
                            AND PES.CODIGO_TIPOPESSOA = 2
                            ORDER BY NOME, POSICAO, STATUS ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", FrequenciaEntidade.codigo));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static string Include()
        {            
            Conexao.sql = " INSERT INTO FREQUENCIA(DIA, TIPO, PESO, OBSERVACAO, STATUS, DATAREGISTRO) ";
            Conexao.sql += " VALUES(@DIA, @TIPO, @PESO, @OBSERVACAO, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DIA", FrequenciaEntidade.dia));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@TIPO", FrequenciaEntidade.tipo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@PESO", FrequenciaEntidade.peso));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@OBSERVACAO", FrequenciaEntidade.observacao));

            return Conexao.ExecutaComando(Conexao.cmd);
        }

        public static string Update()
        {
            Conexao.sql = @" UPDATE FREQUENCIA SET DIA = @DIA, TIPO = @TIPO, PESO = @PESO, OBSERVACAO = @OBSERVACAO, DATAATUALIZACAO = CURRENT_TIMESTAMP WHERE CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", FrequenciaEntidade.codigo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DIA", FrequenciaEntidade.dia));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@TIPO", FrequenciaEntidade.tipo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@PESO", FrequenciaEntidade.peso));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@OBSERVACAO", FrequenciaEntidade.observacao));

            return Conexao.ExecutaComando(Conexao.cmd);
        }

        public static string Delete()
        {
            Conexao.sql = @" UPDATE FREQUENCIA SET STATUS = 'I' WHERE CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", FrequenciaEntidade.codigo));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
