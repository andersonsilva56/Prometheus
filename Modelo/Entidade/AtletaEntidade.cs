using NpgsqlTypes;

namespace Modelo
{
    public static class AtletaEntidade
    {
        #region CAMPOS

        public static decimal codigo { get; set; }
        public static decimal codigo_pessoa { get; set; }
        public static decimal codigo_posicao { get; set; }
        public static decimal codigo_atletastatus { get; set; }
        public static string altura { get; set; }
        public static string peso { get; set; }
        public static int numeracao { get; set; }
        public static string apelido { get; set; }
        public static string tamanhouniforme { get; set; }
        public static string status { get; set; }

        #endregion

        #region CONSULTAS

        #endregion
    }
}
