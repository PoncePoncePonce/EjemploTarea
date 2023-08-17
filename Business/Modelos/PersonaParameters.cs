using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modelos
{
    public class PersonaParameters: QueryParameters
    {
        public int MinAge { get; set; } = 0;

        public int MaxAge { get; set; } = 100;
        public bool ValidAgeRange => MaxAge > MinAge;
        public string Name { get; set; } = String.Empty;
    }
}
