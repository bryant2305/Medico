using MedicoApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Domain.Entities
{
    public class Pacientes : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Phone { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public string Fumador { get; set; }
        public string Alergias { get; set; }
        public DateTime FechaNacimiento { get; set; } 

        public string? ImageUrl { get; set; }
        public ICollection<Citas>? Citas { get; set; }
        public ICollection<ResultDeLab>? ResultDeLab { get; set; }
        public int CitasId { get; set; }


    }
}
