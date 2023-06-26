using LabClothingCollection.Domain.Dto;
using LabClothingCollection.Domain.Entities;
using LabClothingCollection.Domain.Enums;
using LabClothingCollection.Domain.Interfaces;
using LabClothingCollection.Domain.utils;

namespace LabClothingCollection.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            var tipoUsuarioString = usuario.TipoDeUsuario;
            if (!Enum.IsDefined(typeof(TipoUsuarioEnum), tipoUsuarioString))
            {
                throw new Exception("Tipo de usuário inválido.");
            }

            var documentoValido = ValidationUtils.IsCpfOrCnpjValid(usuario.CpfOuCnpj);
            if (!documentoValido)
            {
                throw new Exception("Cpf ou Cnpj inválido.");
            }

            return await _usuarioRepository.CreateAsync(usuario);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync(string status) => await _usuarioRepository.GetAllAsync(status);

        public async Task<Usuario?> GetByIdAsync(int id )
        {
            var usuario =  await _usuarioRepository.GetByIdAsync(id);
            if (usuario is null)
                throw new KeyNotFoundException("Usuario não encontrado");

            return usuario;
        }

        public async Task UpdateUsuarioAsync() => await _usuarioRepository.UpdateUsuarioAsync();


    }
}
