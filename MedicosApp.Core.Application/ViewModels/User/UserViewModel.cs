using MedicoApp.Core.Application.ViewModels.Citas;
using MedicoApp.Core.Application.ViewModels.Medico;
using MedicoApp.Core.Application.ViewModels.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.User
{

    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Apellido { get; set; }

        public bool Admin { get; set; }
        public ICollection<MedicoViewModel> Medicos { get; set; }
        public ICollection<PacienteViewModel> Pacientes { get; set; }
        public ICollection<SaveCitasViewModel> Citas { get; set; }
    }
}

