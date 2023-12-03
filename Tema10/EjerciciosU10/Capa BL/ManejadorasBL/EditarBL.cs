using Biblioteca;
using DAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.ManejadorasBL
{
    public class EditarBL
    {

        /// <summary>
        /// Función que edita una persona con reglas de negocio
        /// Precondiciones: No hay
        /// Postcondiciones: Se edita una persona
        /// </summary>
        /// <param name="pers"></param>
        /// <returns></returns>
        public static int editPersonaBL(clsPersona pers)
        {
            int numFilasAfectadas = 0;

            numFilasAfectadas = EditarDAL.actualizarPersona(pers);

            return numFilasAfectadas;
        }
    }
}
