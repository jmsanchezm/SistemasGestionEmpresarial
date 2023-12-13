using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entities
{
    public class clsPersona
    {
        #region atributos
        private int id;
        private string nombre;
        private string apellido;
        private int idDepartamento;
        private DateTime fNac;
        private string foto;
        private string tlf;
        private string direccion;
        #endregion

        #region constructores
        public clsPersona()
        {
            id = 0;
            nombre = "";
            apellido = "";
            idDepartamento = 0;
            fNac = DateTime.Now;
            foto = "";
            tlf = "";
            direccion = "";
        }

        public clsPersona(string nombre, string apellido, int idDepartamento, int id, DateTime fNac, String foto, String tlf, String direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.idDepartamento = idDepartamento;
            this.fNac = fNac;
            this.foto = foto;
            this.tlf = tlf;
            this.direccion = direccion;
        }
        #endregion

        #region propiedades

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Tlf
        {
            get { return tlf; }
            set { tlf = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }

        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FNac
        {
            get { return fNac; }
            set { fNac = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public string NombreCompleto
        {
            get { return $"{nombre} {apellido}"; }
        }

        #endregion
    }
}
