using Biblioteca;
using Capa_BL;

namespace Capa_UI.Models.ViewModels
{
    public class PersonaConListadoDepartamento : clsPersona
    {

        #region atributos
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores
        public PersonaConListadoDepartamento(clsPersona persona)
        {

            listaDepartamentos = ListadoDepartamentosBL.listadoCompletoDepartamentos();

            this.Nombre = persona.Nombre;
            this.Apellido = persona.Apellido;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.Id = persona.Id;
            this.IdDepartamento = persona.IdDepartamento;
            this.Foto = persona.Foto;
        }

        public PersonaConListadoDepartamento()
        {

            listaDepartamentos = ListadoDepartamentosBL.listadoCompletoDepartamentos();

        }
        #endregion

        #region propiedades

        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
        }
        #endregion

    }
}
