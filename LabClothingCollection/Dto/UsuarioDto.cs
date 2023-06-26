namespace LabClothingCollection.Api.Dto
{
    public class UsuarioDto
    {
            public string NomeCompleto { get; set; }
            public string Genero { get; set; }
            public DateTime DataDeNascimento { get; set; }
            public string CpfOuCnpj { get; set; }
            public string Telefone { get; set; }

            public string TipoDeUsuario { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
    }
}
