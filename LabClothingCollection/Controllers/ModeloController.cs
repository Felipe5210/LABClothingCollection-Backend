using LabClothingCollection.Domain.Dto;
using LabClothingCollection.Domain.Entities;
using LabClothingCollection.Domain.Enums;
using LabClothingCollection.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabClothingCollection.Api.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class ModeloController : Controller
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Modelo model)
        {
            try
            {
                var resultado = await _modeloService.CreateAsync(model);
                return Ok(new { pessoa = model.NomeDoModelo });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> getAllmodelo(string? layout)
        {

            if (!Enum.TryParse(typeof(LayoutEnum), layout, true, out var _) && !string.IsNullOrEmpty(layout))
            {
                return BadRequest("O status especificado é inválido. Valores validos: Bordado,Estampa,Liso");
            }

            var resultado = await _modeloService.GetAllAsync(layout);
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _modeloService.GetByIdAsync(id);
                return Ok(usuario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColecao(int id, [FromBody] ModeloUpdateDto model)
        {
            try
            {
                var modelo = await _modeloService.GetByIdAsync(id);
                if (modelo is null) return NotFound();

                modelo.updateAll(model.NomeDoModelo, model.IdentificadorDaColecao, model.Tipo, model.Layout);
                await _modeloService.UpdateStatusAsync();
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteColecao(int id)
        {
            try
            {
                var colecao = await _modeloService.GetByIdAsync(id);
                if (colecao is null) return NotFound();

                await _modeloService.DeleteAsync(colecao);
                return Ok(colecao.id);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

