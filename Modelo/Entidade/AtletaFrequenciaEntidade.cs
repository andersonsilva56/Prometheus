using NpgsqlTypes;

namespace Modelo
{
    public static class AtletaFrequenciaEntidade
    {
        #region CAMPOS

        public static decimal codigo { get; set; }
        public static decimal codigo_atleta { get; set; }
        public static decimal codigo_frequencia { get; set; }
        public static int tipo { get; set; }
        public static string observacao { get; set; }
        public static string status { get; set; }

        #endregion

        #region CONSULTAS

        #endregion
    }
}
