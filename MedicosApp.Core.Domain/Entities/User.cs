using MedicoApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Username { get; set; }
        public string Name { get; set; }

        public string Apellido { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool Admin { get; set; }
        

    }
}
