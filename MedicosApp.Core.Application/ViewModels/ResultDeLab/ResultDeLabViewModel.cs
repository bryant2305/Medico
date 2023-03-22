using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.ResultDeLab
{
    public class ResultDeLabViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Apellido { get; set; }

        public string PacienteName { get; set; }
        public string PruebaDeLabName { get; set; }
        public int PacienteId { get; set; }
        public int PruebaDeLabId { get; set; }
    }
}
