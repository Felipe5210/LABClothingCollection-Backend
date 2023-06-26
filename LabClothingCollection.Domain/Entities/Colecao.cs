using LabClothingCollection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.Entities
{
    public class Colecao
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo NomeDaColecao é obrigatório")]
        public string NomeDaColecao { get; set; }
        
        [Required(ErrorMessage = "O campo idResponsavel é obrigatório")]
        public int idResponsavel { get; set; }
        
        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }
        
        [Required(ErrorMessage = "O campo Orcamento é obrigatório")]
        public decimal Orcamento { get; set; }
        
        [Required(ErrorMessage = "O campo AnoDeLancamento é obrigatório")]
        public DateTime AnoDeLancamento { get; set; }
        
        [Required(ErrorMessage = "O campo estacao é obrigatório")]
        [EnumDataType(typeof(EstacaoEnum))]
        public string estacao { get; set; }
       
        [Required(ErrorMessage = "O campo Status é obrigatório")]
        [EnumDataType(typeof(StatusEnum))]
        public string Status { get; set; }


        public void update(string status)
        {
            Status = status;
        }

        public void updateAll(string nomeDaColecao, int IdResponsavel, string marca, decimal orcamento, DateTime anoLancamento, string Estacao, string status)
        {
            Marca = marca;
            Orcamento = orcamento;
            NomeDaColecao = nomeDaColecao;
            idResponsavel = idResponsavel;
            AnoDeLancamento= anoLancamento;
            estacao = Estacao;
            Status = status;
        }
    }
}
