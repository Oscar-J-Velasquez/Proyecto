using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
    }
}
