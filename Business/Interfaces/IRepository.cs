using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void GuardarCambios();
        void Guardar(List<T> entidades);
        void Agregar(T entity);
        List<T> Consultar();
        IQueryable<T> FindAll();
        T ConsultarPorId(string Id);
        void Actualizar(T t);
        void Eliminar(T t);
    }
}
