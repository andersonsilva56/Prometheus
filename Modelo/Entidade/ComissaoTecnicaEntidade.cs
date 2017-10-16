using NpgsqlTypes;

namespace Modelo
{
    public static class ComissaoTecnicaEntidade
    {
        #region CAMPOS

        public static decimal codigo { get; set; }
        public static decimal codigo_pessoa { get; set; }
        public static string descricao { get; set; }
        public static string status { get; set; }

        #endregion

        #region CONSULTAS

        #endregion
    }
}
