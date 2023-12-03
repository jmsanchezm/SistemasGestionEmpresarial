using Biblioteca;
using DAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.ManejadorasBL
{
    public class InsertarBL
    {
        /// <summary>
        /// Función que inserta una persona con reglas de negocio
        /// Precondiciones: No hay
        /// Postcondiciones: Se inserta una persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static int createPersonaBL(clsPersona persona)
        {

            int numFilasAfectadas = 0;

            numFilasAfectadas = InsertarDAL.insertarPersona(persona);

            return numFilasAfectadas;

        }
    }
}
