using DAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.ManejadorasBL
{
    public class BorrarBL
    {
        ///<summary>
        /// Función que borra una persona con reglas de negocio
        /// Precondiciones: No hay
        /// Postcondiciones: Se borra una persona
        ///</summary>
        ///<param name="id"></param>
        ///<returns>Devuelve el número de filas afectadas</returns>
        public static int borraPersona(int id)
        {
            
            DateTime fechaActual = DateTime.Now;

            int numFilasAfectadas = 0;

            //Si es miércoles no se puede borrar
            if (fechaActual.DayOfWeek == DayOfWeek.Wednesday)
            {
                numFilasAfectadas = -1;
            }
            //Si no es miércoles se puede borrar
            else
            {
                numFilasAfectadas = DAL.Manejadoras.BorrarDAL.borrarPersona(id);
            }

            return numFilasAfectadas;
        }
    }
}
