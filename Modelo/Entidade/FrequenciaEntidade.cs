using NpgsqlTypes;

namespace Modelo
{
    public static class FrequenciaEntidade
    {
        #region CAMPOS

        public static decimal codigo { get; set; }
        public static NpgsqlDateTime dia { get; set; }
        public static int tipo { get; set; }
        public static int peso { get; set; }
        public static string observacao { get; set; }
        public static string status { get; set; }

        #endregion

        #region CONSULTAS

        #endregion
    }
}
