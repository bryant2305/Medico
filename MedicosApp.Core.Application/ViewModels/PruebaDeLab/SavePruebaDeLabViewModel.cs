using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.PruebaDeLab
{
    public class SavePruebaDeLabViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el Nombre ")]
        public string Name { get; set; }

    }
}
