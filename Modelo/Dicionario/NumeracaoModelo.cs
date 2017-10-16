using System.Data;
using Npgsql;
using System;

namespace Modelo
{
    [Serializable]
    public class NumeracaoModelo
    {
        public static DataSet NumeracaoLista()
        {
            DataSet lTableSet = new DataSet();
            
            Conexao.sql = @" SELECT NUMERO, NUMERO || '|' || CONTADOR NUMEROCONT FROM NUMERACAO WHERE CONTADOR <= 1 ORDER BY NUMERO ASC ";
            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
           
            lTableSet = Conexao.ExecutaDataSet(Conexao.cmd);
            
            return lTableSet;
        }

        public static string Update(int pContador, decimal pNumero)
        {
            Conexao.sql = " UPDATE NUMERACAO SET CONTADOR = @CONTADOR WHERE NUMERO = @NUMERO ";

            Conexao.cmd = new NpgsqlCommand(Conexao.sql, Conexao.conn);
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@CONTADOR", pContador));
            Conexao.cmd.Parameters.Add(new NpgsqlParameter("@NUMERO", pNumero));

            return Conexao.ExecutaComando(Conexao.cmd);
        }
    }
}
