using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.Citas
{
    public class CitasViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MedicoId { get; set; }

        public string HoraDeLaCita { get; set; }


        public string FechaDeLaCita { get; set; }

        public string PacienteName { get; set; }

        public string MedicoName { get; set; }
        public int PacienteId { get; set; }


    }
}
