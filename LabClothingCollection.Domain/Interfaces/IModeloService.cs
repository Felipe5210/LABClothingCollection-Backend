using LabClothingCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.Interfaces
{
    public interface IModeloService
    {
        Task<Modelo> CreateAsync(Modelo modelo);

        Task<IEnumerable<Modelo>> GetAllAsync(string status);

        Task<Modelo?> GetByIdAsync(int id);

        Task UpdateStatusAsync();

        Task DeleteAsync(Modelo modelo);
    }
}
