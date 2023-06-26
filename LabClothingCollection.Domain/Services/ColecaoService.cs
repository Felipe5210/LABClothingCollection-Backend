using LabClothingCollection.Domain.Entities;
using LabClothingCollection.Domain.Enums;
using LabClothingCollection.Domain.Interfaces;
using LabClothingCollection.Domain.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabClothingCollection.Domain.Services
{
    public class ColecaoService : IColecaoService
    {
        private readonly IColecaoRepository _colecaoRepository;

        public ColecaoService(IColecaoRepository colecaoRepository)
        {
            _colecaoRepository = colecaoRepository;
        }

        public async Task<Colecao> CreateAsync(Colecao colecao)
        {
            var tipoEstacao = colecao.estacao;
            if (!Enum.IsDefined(typeof(EstacaoEnum), tipoEstacao))
            {
                throw new Exception("Tipo de estacao inválidos.");
            }
            return await _colecaoRepository.CreateAsync(colecao);
        }

        public async Task<IEnumerable<Colecao>> GetAllAsync(string status) => await _colecaoRepository.GetAllAsync(status);

        public async Task<Colecao?> GetByIdAsync(int id)
        {
            var colecao = await _colecaoRepository.GetByIdAsync(id);
            if (colecao is null)
                throw new KeyNotFoundException("Colecao não encontrado");

            return colecao;
        }

        public async Task UpdateStatusAsync() => await _colecaoRepository.UpdateStatusAsync();


        public async Task DeleteAsync(Colecao colecao) => await _colecaoRepository.DeleteAsync(colecao);
    }
}
