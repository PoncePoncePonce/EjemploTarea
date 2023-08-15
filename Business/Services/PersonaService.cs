
using Business.Entidades;
using Business.Interfaces;
using Business.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PersonaService: IPersonaService
    {
        private readonly IPersonaRepository _repo;
        public PersonaService(IPersonaRepository repo) 
        {
            _repo = repo;
        }
        public Persona AgregarPersona(string nombre, string apellido, int edad)
        {
            Persona persona = new Persona()
            {
                Nombre= nombre,
                Apellido= apellido,
                Edad= edad
            };
            _repo.Agregar(persona);
            _repo.GuardarCambios();
            return persona;
        }
        public PagedList<Persona> ConsultarPersonas(PersonaParameters parameters) 
        {
            PagedList<Persona> lista = _repo.ConsultarPersonas(parameters);

            return lista;
        }
        public List<Persona> ConsultarPersona()
        {
            List<Persona> lista = _repo.Consultar();
            return lista;
        }
        public Persona ConsultarPersonaPorId(string id)
        {
            var persona = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();
            return persona;
        }
        public Persona ActualizarPersona(string id, string nombre, string apellido, int edad)
        {
            var persona = _repo.ConsultarPorId(id) ?? throw new ValidationException("No existe");
            persona.Nombre = nombre ?? persona.Nombre;
            persona.Apellido = apellido ?? persona.Apellido;
            if(edad != null)
            {
                persona.Edad = edad;
            }
            _repo.Actualizar(persona);
            _repo.GuardarCambios();
            return persona;
        }
        public Persona EliminarPersona(string id)
        {
            Persona persona = _repo.ConsultarPorId(id);
            if (persona == null)
            {
                throw new ValidationException("Cliente no encontrado");
            }
            _repo.Eliminar(persona);
            return persona;
        }
    }
}


       