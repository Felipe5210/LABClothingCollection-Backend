using LabClothingCollection.Domain.Entities;
using LabClothingCollection.Domain.Interfaces;
using LabClothingCollection.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Data.Repositories
{
    public class ModeloRepository : IModeloRepository
    {

        private readonly ClothingCollectionDbContext _dbContext;

        public ModeloRepository(ClothingCollectionDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Modelo> CreateAsync(Modelo modelo)
        {
            _dbContext.Modelos.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<IEnumerable<Modelo>> GetAllAsync(string layout)
        {
            if (string.IsNullOrWhiteSpace(layout))  return await _dbContext.Set<Modelo>().ToListAsync();

            return await _dbContext.Set<Modelo>().Where(u => u.Layout == layout).ToListAsync();
        }

        public async Task<Modelo?> GetByIdAsync(int id) => await _dbContext.Modelos.FirstOrDefaultAsync(u => u.id == id);

        public async Task UpdateStatusAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Modelo modelo)
        {
            _dbContext.Remove(modelo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
