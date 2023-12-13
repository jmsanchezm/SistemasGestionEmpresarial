using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_DAL;
using Capa_Entities;

namespace Capa_BL
{
    public class HandlerPersonaBL
    {
    
        public static int deletePersona(int id)
        {
            DateTime fechaActual = DateTime.Now;
            int numFilasAfectadas = 0;

            if (fechaActual.DayOfWeek == DayOfWeek.Wednesday)
            {
                numFilasAfectadas = -1;
            }
            else
            {
                numFilasAfectadas = HandlerPersonaDAL.deletePersonaDAL(id);
            }

            return numFilasAfectadas;
        }

        public static int editPersonaBL(clsPersona persona)
        {
            int numFilasAfectadas = 0;

            numFilasAfectadas = HandlerPersonaDAL.editPersonaDAL(persona);

            return numFilasAfectadas;
        }

        public static int createPersonaBL(clsPersona persona)
        {

            int numFilasAfectadas = 0;

            numFilasAfectadas = HandlerPersonaDAL.createPersonaDAL(persona);

            return numFilasAfectadas;

        }

    }


}
