using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class ComissaoTecnicaModelo
    {        
        private static decimal SelectMaxId()
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT MAX(CODIGO) CODIGO FROM COMISSAOTECNICA";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return decimal.Parse(lTableSet.Rows[0]["CODIGO"].ToString());
        }

        public static DataTable CarregaDadosComissao()
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT PES.CODIGO, PES.NOME, CT.CODIGO CODIGOCT, CT.DESCRICAO
                            FROM PESSOA PES LEFT JOIN COMISSAOTECNICA CT
                            ON (PES.CODIGO = CT.CODIGO_PESSOA AND PES.STATUS = 'A' 
                            AND CT.STATUS = 'A' AND PES.CODIGO_TIPOPESSOA = 3)
                            ORDER BY NOME ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static DataTable CarregaDadosComissao(decimal pCodigo)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT PES.CODIGO, PES.NOME, CT.CODIGO CODIGOCT, CT.DESCRICAO
                            FROM PESSOA PES LEFT JOIN COMISSAOTECNICA CT
                            ON (PES.CODIGO = CT.CODIGO_PESSOA AND PES.STATUS = 'A' 
                            AND CT.STATUS = 'A' AND PES.CODIGO_TIPOPESSOA = 3)
                            WHERE PES.CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", pCodigo));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static decimal Include()
        {            
            Conexao.sql = @" INSERT INTO COMISSAOTECNICA(CODIGO_PESSOA, DESCRICAO, STATUS, DATAREGISTRO) ";
            Conexao.sql += @" VALUES(@CODIGO_PESSOA, @DESCRICAO, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_PESSOA", ComissaoTecnicaEntidade.codigo_pessoa));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DESCRICAO", ComissaoTecnicaEntidade.descricao));
            
            string pRetorno = Conexao.ExecutaComando(Conexao.cmd);

            if (pRetorno == "")
                return SelectMaxId();
            else
                return 0;
        }

        public static string Update()
        {
            Conexao.sql = @" UPDATE COMISSAOTECNICA SET DESCRICAO = @DESCRICAO, DATAATUALIZACAO = CURRENT_TIMESTAMP
                            WHERE CODIGO = @CODIGO";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", ComissaoTecnicaEntidade.codigo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@DESCRICAO", ComissaoTecnicaEntidade.descricao));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
