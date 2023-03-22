using MedicoApp.Core.Application.ViewModels.Medico;
using MedicoApp.Core.Application.ViewModels.Paciente;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.Citas
{
    public class SaveCitasViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar la hora ")]
        public string HoraDeLaCita { get; set; }
        [Required(ErrorMessage = "Debe colocar la fecha ")]
        public string FechaDeLaCita { get; set; }
        public int MedicoId { get; set; }

        public int PacienteId { get; set; }
        public List<MedicoViewModel>? MedicosList { get; set; }
        public List<PacienteViewModel>? PacinetesList { get; set; }



    }
}
