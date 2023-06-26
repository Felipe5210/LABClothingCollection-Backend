using LabClothingCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.Interfaces
{
    public interface IColecaoRepository
    {
        Task<Colecao> CreateAsync(Colecao colecao);

        Task<IEnumerable<Colecao>> GetAllAsync(string status);

        Task<Colecao?> GetByIdAsync(int id);

        Task UpdateStatusAsync();

        Task DeleteAsync(Colecao colecao);
    }
}
