using LabClothingCollection.Domain.Dto;
using LabClothingCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CreateAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync(string status);
        Task UpdateUsuarioAsync();

        Task<Usuario?> GetByIdAsync(int id);
    }
}
