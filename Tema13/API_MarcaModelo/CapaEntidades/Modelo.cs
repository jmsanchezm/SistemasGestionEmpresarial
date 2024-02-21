using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Modelo
    {

        private int id;
        private int idMarca;
        private string nombre;
        private float precio;   

        public Modelo(int id, int idMarca, string nombre, float precio)
        {
            this.id = id;
            this.idMarca = idMarca;
            this.nombre = nombre;
            this.precio = precio;
        }

        public int Id
        {
            get { return id; }
        }   

        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

    }
}
