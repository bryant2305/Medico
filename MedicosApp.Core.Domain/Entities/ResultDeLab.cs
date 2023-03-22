using MedicoApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Domain.Entities
{
    public class ResultDeLab : AuditableBaseEntity
    {
        public string Name { get; set; }

        public string Apellido { get; set; }

        
        public Pacientes? Pacientes { get; set; }

        public PruebaDeLab? PruebaDeLab { get; set; }
        public int PacienteId { get; set; }
        public int PruebaDeLabId { get; set; }
    }
}
