using MedicoApp.Core.Application.ViewModels.Citas;
using MedicoApp.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.ViewModels.Medico
{
    public class SaveMedicoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar el Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe colocar el Telefono")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Debe colocar el Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe colocar el Correo")]

        public double? Cedula { get; set; }


        public string? ImageUrl { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }

    }
}

