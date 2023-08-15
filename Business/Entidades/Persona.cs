using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entidades
{
    public class Persona: IEntity
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public Persona() 
        {
            Id ??= Guid.NewGuid().ToString();
        }
        public Persona(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }
    }

}
