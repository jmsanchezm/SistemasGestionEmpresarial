namespace CapaEntidades
{
    public class Marca
    {
        private int id; 
        private string nombre;

        public Marca(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        
        public int Id
        {
            get { return id; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
