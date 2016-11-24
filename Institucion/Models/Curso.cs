using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institucion.Models
{
    public struct CursoStruct
    {
        const string NombreAsignado = "NO ASIGNADO";
        private string curso;
        public string Curso
        {
            get { return curso; }
            set { curso = value; }
        }
        public readonly short max_capacidad;
        public CursoStruct(short max)
        {
            max_capacidad = max;
            curso = NombreAsignado;
        }
    }
}
