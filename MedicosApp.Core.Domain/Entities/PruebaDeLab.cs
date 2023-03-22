using MedicoApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Domain.Entities
{
    public class PruebaDeLab : AuditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<ResultDeLab>? ResultDeLab { get; set; }
    }
}
