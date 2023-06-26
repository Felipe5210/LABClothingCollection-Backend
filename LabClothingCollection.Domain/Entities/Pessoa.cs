using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LabClothingCollection.Domain.Entities
{
    public class Pessoa
    {

        public int id { get; set; }

        public string? nomeCompleto { get; set; }

        public string? Genero { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string? CpfOuCnpj { get; set; }

        public string? Telefone { get; set; }
    }
}