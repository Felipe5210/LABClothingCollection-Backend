using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabClothingCollection.Domain.Enums;

namespace LabClothingCollection.Domain.Entities
{
    public class Usuario : Pessoa
    {

        [Required(ErrorMessage = "O campo TipoDeUsuario � obrigat�rio")]
        public string? TipoDeUsuario { get; set; }

        [Required(ErrorMessage = "O campo Email � obrigat�rio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Status � obrigat�rio")]
        [EnumDataType(typeof(StatusEnum))]
        public string? Status { get; set; }

        public void update(string status)
        {
            Status = status;
        }
    }
}