using NpgsqlTypes;

namespace Modelo
{
    public static class AtletaAnexoEntidade
    {
        #region CAMPOS

        public static decimal codigo { get; set; }
        public static decimal codigo_atleta { get; set; }
        public static string descricao { get; set; }
        public static byte[] arquivo { get; set; }
        public static string tipoarquivo { get; set; }
        public static string status { get; set; }

        #endregion

        #region CONSULTAS

        #endregion
    }
}
