using Business.Entidades;
using Business.Interfaces;
using Business.Modelos;
using Infraestructura.Context;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class PersonaRepository : Repository<Persona>, IPersonaRepository
    {
        public PersonaRepository(SQLServerContext context) : base(context) 
        { 

        }
        public PagedList<Persona> ConsultarPersonas(PersonaParameters parameters)
        {
            if(parameters.Name.IsNullOrEmpty() == false)
            {
                return PagedList<Persona>.ToPagedList(FindAll().Where(x => x.Edad > parameters.MinAge && x.Edad < parameters.MaxAge && x.Nombre.Contains(parameters.Name)), parameters.PageNumber, parameters.PageSize);
            }
            else
            {
                return PagedList<Persona>.ToPagedList(FindAll().Where(x => x.Edad > parameters.MinAge && x.Edad < parameters.MaxAge), parameters.PageNumber, parameters.PageSize);
            }
            
        }
        
    }
}
