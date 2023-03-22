using MedicoApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Domain.Entities
{
    public class Citas : AuditableBaseEntity
    {
        public string Name { get; set; }


        public string HoraDeLaCita { get; set; }

        public string FechaDeLaCita { get; set; }

        public int PacientesId { get; set; }
        public int MedicosId { get; set; }
        public Medicos? Medicos { get; set; }
        public Pacientes? Pacientes { get; set; }




    }
}
