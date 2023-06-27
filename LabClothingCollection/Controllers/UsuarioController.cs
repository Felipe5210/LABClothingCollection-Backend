using LabClothingCollection.Data.Repositories;
using LabClothingCollection.Domain.Dto;
using LabClothingCollection.Domain.Entities;
using LabClothingCollection.Domain.Enums;
using LabClothingCollection.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LabClothingCollection.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario model)
        {
            try
            {
                var resultado = await _usuarioService.CreateAsync(model);
                return Ok(new { pessoa = model.nomeCompleto });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> getAllPesoa(string? status)
        {

            if (!Enum.TryParse(typeof(StatusEnum), status, true, out var _) && !string.IsNullOrEmpty(status))
            {
                return BadRequest("O status especificado é inválido. Valores validos: Ativo e Inativo");
            }

            var resultado = await _usuarioService.GetAllAsync(status);
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetByIdAsync(id);
                return Ok(usuario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuarioUpdateDto model)
        {
            try
            {
                var usuario = await _usuarioService.GetByIdAsync(id);
                if (usuario == null)
                    return NotFound();

                if (!Enum.TryParse(typeof(StatusEnum), model.Status, true, out var _))
                    return BadRequest("O status especificado é inválido. Valores validos: Ativo e Inativo");

                usuario.update(model.Status);
                await _usuarioService.UpdateUsuarioAsync();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
