using LabClothingCollection.Domain.Dto;
using LabClothingCollection.Domain.Entities;

namespace LabClothingCollection.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CreateAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync(string status);

        Task UpdateUsuarioAsync();

        Task<Usuario?> GetByIdAsync(int id);
    }
}
