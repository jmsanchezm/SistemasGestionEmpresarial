using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class clsModelo
    {

        private int id;
        private int idMarca;
        private string nombre;
        private float precio;

        public clsModelo()
        {
            this.id = 0;
            this.idMarca = 0;
            this.nombre = "";
            this.precio = 0;

        }

        public clsModelo(int id, int idMarca, string nombre, float precio) 
        { 
            this.id = id;
            this.idMarca = idMarca;
            this.nombre = nombre;
            this.precio = precio;

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
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
