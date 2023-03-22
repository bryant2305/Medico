using MedicoApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Domain.Entities
{
    public class Medicos : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Apellido { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string? ImageUrl { get; set; }

        public double? Cedula { get; set; }
        public ICollection<Citas>? Citas { get; set; }

        public int CitasId { get; set; }


    }
}

