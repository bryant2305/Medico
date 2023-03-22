using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.Paciente
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Phone { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public string Fumador { get; set; }
        public string Alergias { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
