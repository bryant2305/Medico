using MedicoApp.Core.Application.ViewModels.Medico;
using MedicoApp.Core.Application.ViewModels.Paciente;
using MedicoApp.Core.Application.ViewModels.PruebaDeLab;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.ResultDeLab
{
    public class SaveResultDeLabViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el Nombre ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar el Apellido ")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe colocar la cedula ")]
       

        public int PacienteId { get; set; }
        public int PruebaDeLabId { get; set; }


        public List<PacienteViewModel>? PacinetesList { get; set; }
        public List<PruebaDeLabViewModel>? PruebaDeLabList { get; set; }

    }
}
