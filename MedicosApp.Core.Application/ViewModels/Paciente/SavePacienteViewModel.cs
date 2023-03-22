using MedicoApp.Core.Application.ViewModels.Citas;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.Paciente
{
    public class SavePacienteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el Nombre ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar el Apellido ")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe colocar el Telefono ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Debe colocar la Direccion ")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Debe colocar la Cedula")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Debe colocar si eres fumador")]
        public string Fumador { get; set; }
        [Required(ErrorMessage = "Debe colocar si tienes Alergias ")]
        public string Alergias { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
        public string? ImageUrl { get; set; }


        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
    }
}

