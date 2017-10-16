using NpgsqlTypes;

namespace Modelo
{
    public static class PosicaoEntidade
    {
        #region CAMPOS

        public static decimal codigo { get; set; }
        public static string descricao { get; set; }
        public static string sigla { get; set; }
        public static string status { get; set; }

        #endregion

        #region CONSULTAS

        #endregion
    }
}
