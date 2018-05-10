using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class PessoaModelo
    {
        public static DataTable Foto()
        {
            DataTable lTableSet = new DataTable();
            
            Conexao.sql = @" SELECT FOTO FROM PESSOA WHERE CODIGO = @CODIGO AND STATUS = 'A' ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", PessoaEntidade.codigo));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);
            
            return lTableSet;
        }

        public static DataTable CarregaDadosPessoaAtleta()
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT PES.CODIGO, PES.NOME
                            ,(SELECT POS.DESCRICAO FROM POSICAO POS 
                            WHERE ATL.CODIGO_POSICAO = POS.CODIGO AND POS.STATUS = 'A')POSICAO
                            ,(SELECT ATS.DESCRICAO FROM ATLETASTATUS ATS 
                            WHERE ATL.CODIGO_ATLETASTATUS = ATS.CODIGO AND ATS.STATUS = 'A')STATUS
                            FROM PESSOA PES LEFT OUTER JOIN ATLETA ATL
                            ON (PES.CODIGO = ATL.CODIGO_PESSOA)
                            WHERE PES.STATUS = 'A'
                            AND PES.CODIGO_TIPOPESSOA = 2
                            ORDER BY NOME, POSICAO, STATUS ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static DataTable CarregaDadosPessoaAtleta(string pQuery)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT PES.CODIGO, PES.NOME, ATL.CODIGO ATLETACODIGO
                            ,(SELECT POS.DESCRICAO FROM POSICAO POS 
                            WHERE ATL.CODIGO_POSICAO = POS.CODIGO AND POS.STATUS = 'A')POSICAO
                            ,(SELECT ATS.DESCRICAO FROM ATLETASTATUS ATS 
                            WHERE ATL.CODIGO_ATLETASTATUS = ATS.CODIGO AND ATS.STATUS = 'A')STATUS
                            FROM PESSOA PES LEFT OUTER JOIN ATLETA ATL
                            ON (PES.CODIGO = ATL.CODIGO_PESSOA)
                            WHERE PES.STATUS = 'A'
                            AND PES.CODIGO_TIPOPESSOA = 2 ";
            Conexao.sql += pQuery;
            Conexao.sql += "ORDER BY NOME, POSICAO, STATUS";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        public static DataTable CarregaDadosPessoaAtleta(decimal pCodigo)
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT PES.*, ATL.CODIGO CODIGO_ATLETA
                            ,(SELECT POS.CODIGO FROM POSICAO POS 
                            WHERE ATL.CODIGO_POSICAO = POS.CODIGO AND POS.STATUS = 'A')POSICAO
                            ,(SELECT ATS.CODIGO FROM ATLETASTATUS ATS 
                            WHERE ATL.CODIGO_ATLETASTATUS = ATS.CODIGO AND ATS.STATUS = 'A')ATLETASTATUS
                            FROM PESSOA PES LEFT OUTER JOIN ATLETA ATL
                            ON (PES.CODIGO = ATL.CODIGO_PESSOA)
                            WHERE PES.STATUS = 'A'
                            AND PES.CODIGO_TIPOPESSOA = 2
                            AND PES.CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", pCodigo));

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return lTableSet;
        }

        private static decimal SelectMaxId()
        {
            DataTable lTableSet = new DataTable();

            Conexao.sql = @" SELECT MAX(CODIGO) CODIGO FROM PESSOA";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);

            lTableSet = Conexao.ExecutaDataTable(Conexao.cmd);

            return decimal.Parse(lTableSet.Rows[0]["CODIGO"].ToString());
        }

        public static decimal Include()
        {            
            Conexao.sql = @" INSERT INTO PESSOA(CODIGO_TIPOPESSOA, NOME, NASCIMENTO, FOTO, EMAIL, CPF, RG, PROFISSAO
                            , ESCOLARIDADE, PLANOSAUDE, CONTATO, TELEFONE, CELULAR, STATUS, DATAREGISTRO) ";
            Conexao.sql += @" VALUES(@CODIGO_TIPOPESSOA, @NOME, @NASCIMENTO, @FOTO, @EMAIL, @CPF, @RG, @PROFISSAO, @ESCOLARIDADE
                            , @PLANOSAUDE, @CONTATO, @TELEFONE, @CELULAR, 'A', CURRENT_TIMESTAMP); ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_TIPOPESSOA", PessoaEntidade.codigo_tipopessoa));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@NOME", PessoaEntidade.nome));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@NASCIMENTO", PessoaEntidade.nacimento));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@FOTO", PessoaEntidade.foto));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@EMAIL", PessoaEntidade.email));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CPF", PessoaEntidade.cpf));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@RG", PessoaEntidade.rg));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@PROFISSAO", PessoaEntidade.profissao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@ESCOLARIDADE", PessoaEntidade.escolaridade));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@PLANOSAUDE", PessoaEntidade.planosaude));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CONTATO", PessoaEntidade.contato));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@TELEFONE", PessoaEntidade.telefone));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CELULAR", PessoaEntidade.celular));
            
            string pRetorno = Conexao.ExecutaComando(Conexao.cmd);

            if (pRetorno == "")
                return SelectMaxId();
            else
                return 0;
        }

        public static string Update()
        {
            Conexao.sql = @" UPDATE PESSOA SET CODIGO_TIPOPESSOA = @CODIGO_TIPOPESSOA, NOME = @NOME, NASCIMENTO = @NASCIMENTO
                            , FOTO = @FOTO, EMAIL = @EMAIL, CPF = @CPF, RG = @RG, PROFISSAO = @PROFISSAO, ESCOLARIDADE = @ESCOLARIDADE
                            , PLANOSAUDE = @PLANOSAUDE, CONTATO = @CONTATO, TELEFONE = @TELEFONE, CELULAR = @CELULAR, DATAATUALIZACAO = CURRENT_TIMESTAMP 
                            WHERE CODIGO = @CODIGO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO", PessoaEntidade.codigo));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CODIGO_TIPOPESSOA", PessoaEntidade.codigo_tipopessoa));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@NOME", PessoaEntidade.nome));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@NASCIMENTO", PessoaEntidade.nacimento));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@FOTO", PessoaEntidade.foto));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@EMAIL", PessoaEntidade.email));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CPF", PessoaEntidade.cpf));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@RG", PessoaEntidade.rg));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@PROFISSAO", PessoaEntidade.profissao));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@ESCOLARIDADE", PessoaEntidade.escolaridade));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@PLANOSAUDE", PessoaEntidade.planosaude));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CONTATO", PessoaEntidade.contato));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@TELEFONE", PessoaEntidade.telefone));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CELULAR", PessoaEntidade.celular));

            return Conexao.ExecutaComando(Conexao.cmd);            
        }
    }
}
