namespace Biblioteca
{
    
        public class clsPersona
        {
            private int id;
            private string nombre;
            private string apellido;
            private string direccion;
            private string telefono;
            private string foto;
            private DateTime fechaNacimiento;
            private int idDepartamento;

            public clsPersona()
            {
            }

            public clsPersona(int id, string nombre, string apellido, string direccion, string telefono, string foto, DateTime fechaNacimiento, int idDepartamento)
            {
                this.id = id;
                this.nombre = nombre;
                this.apellido = apellido;
                this.direccion = direccion;
                this.telefono = telefono;
                this.foto = foto;
                this.fechaNacimiento = fechaNacimiento;
                this.idDepartamento = idDepartamento;
            }

            public int Id { get => id; set => id = value; }
            public string Nombre { get => nombre; set => nombre = value.Trim(); }
            public string Apellido { get => apellido; set => apellido = value.Trim(); }
            public string Direccion { get => direccion; set => direccion = value.Trim(); }

            public string Telefono
            {
                get => telefono; set
                {

                    {
                        telefono = value;
                    }

                }
            }

            public string Foto { get => foto; set => foto = value.Trim(); }
            public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

            public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        }
    }
