using LabClothingCollection.Domain.Entities;
using LabClothingCollection.Domain.Interfaces;
using LabClothingCollection.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Data.Repositories
{
    public class ColecaoRepository : IColecaoRepository
    {
        private readonly ClothingCollectionDbContext _dbContext;

        public ColecaoRepository(ClothingCollectionDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Colecao> CreateAsync(Colecao colecao)
        {
            _dbContext.Colecoes.Add(colecao);
            await _dbContext.SaveChangesAsync();
            return colecao;
        }

        public async Task<IEnumerable<Colecao>> GetAllAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return await _dbContext.Set<Colecao>().ToListAsync();
            }
            return await _dbContext.Set<Colecao>().Where(u => u.Status == status).ToListAsync();
        }

        public async Task<Colecao?> GetByIdAsync(int id) => await _dbContext.Colecoes.FirstOrDefaultAsync(u => u.id == id);

        public async Task UpdateStatusAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Colecao colecao)
        {
            _dbContext.Remove(colecao);
            await _dbContext.SaveChangesAsync();    
        }
    }
}
