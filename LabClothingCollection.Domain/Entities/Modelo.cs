using LabClothingCollection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.Entities
{
    public class Modelo
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo NomeDoModelo é obrigatório")]
        public string NomeDoModelo { get; set; }

        [Required(ErrorMessage = "O campo IdentificadorDaColecao é obrigatório")]
        public int IdentificadorDaColecao { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório")]
        [EnumDataType(typeof(TipoEnum))]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo Layout é obrigatório")]
        [EnumDataType(typeof(LayoutEnum))]
        public string Layout { get; set; }

        public void updateAll(string nomeDoModelo, int identificadorDaColecao, string tipo, string layout)
        {
            NomeDoModelo= nomeDoModelo;
            IdentificadorDaColecao = identificadorDaColecao;
            Tipo= tipo;
            Layout = layout;
        }
    }
}
