using LabClothingCollection.Domain.Entities;
using LabClothingCollection.Domain.Enums;
using LabClothingCollection.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.Services
{
    public class ModeloService : IModeloService
    {
            private readonly IModeloRepository _modeloRepository;

            public ModeloService(IModeloRepository modeloRepository)
            {
                _modeloRepository = modeloRepository;
            }

            public async Task<Modelo> CreateAsync(Modelo modelo)
            {
                var tipo = modelo.Tipo;
                var layout = modelo.Layout;

                if (!Enum.IsDefined(typeof(TipoEnum), tipo)) throw new Exception("Tipo de estacao inválidos.");

                if (!Enum.IsDefined(typeof(LayoutEnum), layout)) throw new Exception("Layout inválidos.");

                return await _modeloRepository.CreateAsync(modelo);
            }

            public async Task<IEnumerable<Modelo>> GetAllAsync(string status) => await _modeloRepository.GetAllAsync(status);

            public async Task<Modelo?> GetByIdAsync(int id)
            {
                var colecao = await _modeloRepository.GetByIdAsync(id);
                if (colecao is null)  throw new KeyNotFoundException("Colecao não encontrado");

                return colecao;
            }

            public async Task UpdateStatusAsync() => await _modeloRepository.UpdateStatusAsync();

            public async Task DeleteAsync(Modelo modelo) => await _modeloRepository.DeleteAsync(modelo);
    }
}
