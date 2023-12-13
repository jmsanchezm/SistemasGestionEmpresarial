using Capa_DAL;
using Capa_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL
{
    public class clsListaDepartamentosBL
    {
        public static ObservableCollection<clsDepartamento> ListadoCompletoDepartamentos()
        {
            return clsListaDepartamentosDAL.ListadoCompletoDepartamentos();
        }

        public static clsDepartamento DepartamentoPorId(int id)
        {
            return clsListaDepartamentosDAL.DepartamentoPorId(id);
        }
    }
}
