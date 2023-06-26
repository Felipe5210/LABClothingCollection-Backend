using LabClothingCollection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.Dto
{
    public class ColecaoUpdateDto
    {
        public string NomeDaColecao { get; set; }
        public int idResponsavel { get; set; }
        public string Marca { get; set; }
        public decimal Orcamento { get; set; }
        public DateTime AnoDeLancamento { get; set; }
        public string estacao { get; set; }
        public string Status { get; set; }
    }
}
