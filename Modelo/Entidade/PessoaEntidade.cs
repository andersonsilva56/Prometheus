using NpgsqlTypes;

namespace Modelo
{
    public static class PessoaEntidade
    {
        #region CAMPOS

        public static decimal codigo { get; set; }
        public static decimal codigo_tipopessoa { get; set; }
        public static string nome { get; set; }
        public static NpgsqlDateTime nacimento { get; set; }
        public static byte[] foto { get; set; }
        public static string email { get; set; }
        public static string cpf { get; set; }
        public static string rg { get; set; }
        public static string profissao { get; set; }
        public static string escolaridade { get; set; }
        public static string planosaude { get; set; }
        public static string contato { get; set; }
        public static string telefone { get; set; }
        public static string celular { get; set; }
        public static string status { get; set; }

        #endregion

        #region CONSULTAS

        #endregion
    }
}
