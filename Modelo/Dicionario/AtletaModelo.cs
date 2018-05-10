using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class AtletaModelo
    {        
        private static decimal SelectMaxId()
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT MAX(CODIGO) CODIGO FROM ATLETA";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return decimal.Parse(lTableSet.Rows[0]["CODIGO"].ToString());
        }

        public static DataTable CarregaDadosAtleta(decimal pCodigo)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT ATL.*
                            ,(SELECT POS.CODIGO FROM POSICAO POS 
                            WHERE ATL.CODIGO_POSICAO = POS.CODIGO AND POS.STATUS = 'A')POSICAO
                            ,(SELECT ATS.CODIGO FROM ATLETASTATUS ATS 
                            WHERE ATL.CODIGO_ATLETASTATUS = ATS.CODIGO AND ATS.STATUS = 'A')ATLETASTATUS
                            ,(SELECT NUM.NUMERO FROM NUMERACAO NUM 
                            WHERE ATL.NUMERACAO = NUM.NUMERO)NUMERO
                            ,(SELECT NUM.CONTADOR FROM NUMERACAO NUM 
                            WHERE ATL.NUMERACAO = NUM.NUMERO)CONTADOR
                            FROM ATLETA ATL
                            WHERE ATL.STATUS = 'A'
                            AND ATL.CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", pCodigo));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static decimal Include()
        {            
            Conexao.sql = @" INSERT INTO ATLETA(CODIGO_PESSOA, CODIGO_POSICAO, CODIGO_ATLETASTATUS, ALTURA, PESO, NUMERACAO, TAMANHOUNIFORME, APELIDO
                            , STATUS, DATAREGISTRO) ";
            Conexao.sql += @" VALUES(@CODIGO_PESSOA, @CODIGO_POSICAO, @CODIGO_ATLETASTATUS, @ALTURA, @PESO, @NUMERACAO, @TAMANHOUNIFORME, @APELIDO
                            , 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_PESSOA", AtletaEntidade.codigo_pessoa));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_POSICAO", AtletaEntidade.codigo_posicao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_ATLETASTATUS", AtletaEntidade.codigo_atletastatus));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@ALTURA", AtletaEntidade.altura));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@PESO", AtletaEntidade.peso));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@NUMERACAO", AtletaEntidade.numeracao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@TAMANHOUNIFORME", AtletaEntidade.tamanhouniforme));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@APELIDO", AtletaEntidade.apelido));

            string pRetorno = Conexao.ExecutaComando(Conexao.cmd);

            if (pRetorno == "")
                return SelectMaxId();
            else
                return 0;
        }

        public static string Update()
        {
            Conexao.sql = @" UPDATE ATLETA SET CODIGO_POSICAO = @CODIGO_POSICAO, CODIGO_ATLETASTATUS = @CODIGO_ATLETASTATUS
                            , ALTURA = @ALTURA, PESO = @PESO, NUMERACAO = @NUMERACAO, TAMANHOUNIFORME = @TAMANHOUNIFORME, APELIDO = @APELIDO
                            ,DATAATUALIZACAO = CURRENT_TIMESTAMP
                            WHERE CODIGO = @CODIGO";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", AtletaEntidade.codigo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_POSICAO", AtletaEntidade.codigo_posicao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_ATLETASTATUS", AtletaEntidade.codigo_atletastatus));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@ALTURA", AtletaEntidade.altura));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@PESO", AtletaEntidade.peso));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@NUMERACAO", AtletaEntidade.numeracao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@TAMANHOUNIFORME", AtletaEntidade.tamanhouniforme));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@APELIDO", AtletaEntidade.apelido));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
