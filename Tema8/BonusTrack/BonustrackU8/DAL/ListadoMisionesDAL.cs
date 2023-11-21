using Biblioteca;

namespace BonustrackU8.DAL
{
    public static class ListadoMisionesDAL
    {
        /// <summary>
        /// Método que devolverá un listado de misiones para Mando
        /// Se crea una lista de objetos de tipo clsMision
        /// Precondiciones: no tiene
        /// Postcondiciones: no tiene
        /// </summary>
        /// <returns></returns>
        public static List<clsMision> ListadoMisionesCompleto()
        {
            List<clsMision> ListadoMisiones = new List<clsMision>
            {
                new clsMision(1,"Rescate de Baby Yoda", "Debes hacerte con Grogu y llevárselo a Luke SkyWalker para su entrenamiento.",5000),
                new clsMision(2,"Recuperar armadura Beskar", "Tu armadura de Beskar ha sido robada. Debes encontrarla.",2000),
                new clsMision(3,"Planeta Sorgon", "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.",500),
                new clsMision(4,"Renacuajos", "Debes llevar a una Dama Rana y sus huevos de " +
                            "Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.",500)
            };

            return ListadoMisiones;
        }
    }
}
