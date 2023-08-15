using Business.Entidades;
using Business.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonaRepository: IRepository<Persona>
    {
        public PagedList<Persona> ConsultarPersonas(PersonaParameters parameters);
    }
}
