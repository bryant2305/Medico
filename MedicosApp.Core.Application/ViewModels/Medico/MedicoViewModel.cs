using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.Medico
{
    public class MedicoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public double? Cedula { get; set; }
    }
}
