namespace Capa_Entities
{
    public class clsDepartamento
    {
        #region atributos
        private int idDepartamento;
        private string nombre;
        #endregion

        #region constructores
        public clsDepartamento()
        {

            idDepartamento = 0;
            nombre = "";
        }
        public clsDepartamento(int idDepartamento, string nombre)
        {

            this.idDepartamento = idDepartamento;
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        #endregion
    }
}