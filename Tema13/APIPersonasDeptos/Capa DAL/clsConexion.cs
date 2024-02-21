namespace Capa_DAL
{
    public class clsConexion
    {
        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión abierta con la base de datos</returns>
        public static string connection()
        {

            return "server=juanma.database.windows.net;database=Personas;uid=prueba;pwd=fernandoG321;";

        }
    }
}
