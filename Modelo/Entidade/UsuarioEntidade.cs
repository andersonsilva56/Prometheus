using NpgsqlTypes;

namespace Modelo
{
    public static class UsuarioEntidade
    {
        #region CAMPOS

        public static decimal codigo { get; set; }
        public static string email { get; set; }
        public static string senha { get; set; }
        public static string nome { get; set; }
        public static string status { get; set; }
        public static NpgsqlDateTime dataregistro { get; set; }
        public static NpgsqlDateTime dataatualizacao { get; set; }

        #endregion

        #region CONSULTAS

        #endregion
    }
}
