using Biblioteca;
using Capa_BL;

namespace Capa_UI.Models.ViewModels
{
    public class PersonaConDepartamento: clsPersona
    {
        #region atributos
        clsDepartamento departamento;
        #endregion

        #region constructores
        public PersonaConDepartamento(clsPersona persona)
        {

            departamento = ListadoDepartamentosBL.departamentoSelect(persona.IdDepartamento);

            this.Nombre = persona.Nombre;
            this.Apellido = persona.Apellido;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.Id = persona.Id;
            this.IdDepartamento = persona.IdDepartamento;
            this.Foto = persona.Foto;


        }
        #endregion

        #region propiedades
        public clsDepartamento Departamento
        {

            get { return departamento; }

        }
        #endregion
    }
}
