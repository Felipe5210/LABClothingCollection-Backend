using LabClothingCollection.Domain.Dto;
using LabClothingCollection.Domain.Entities;
using LabClothingCollection.Domain.Enums;
using LabClothingCollection.Domain.Interfaces;
using LabClothingCollection.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LabClothingCollection.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClothingCollectionDbContext _dbContext;

        public UsuarioRepository(ClothingCollectionDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> GetByIdAsync(int id) => await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.id == id);
        public async Task<IEnumerable<Usuario>> GetAllAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return await _dbContext.Set<Usuario>().ToListAsync();
            }

            return await _dbContext.Set<Usuario>().Where(u => u.Status == status).ToListAsync();
        }

        public async Task UpdateUsuarioAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
