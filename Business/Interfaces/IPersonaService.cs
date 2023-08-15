using Business.Entidades;
using Business.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonaService
    {
        public Persona AgregarPersona(string nombre, string apellido, int edad);
        public PagedList<Persona> ConsultarPersonas(PersonaParameters parameters);
        public List<Persona> ConsultarPersona();
        public Persona ConsultarPersonaPorId(string id);
        public Persona ActualizarPersona(string id, string nombre, string apellido, int edad);
        public Persona EliminarPersona(string id);
    }
}
