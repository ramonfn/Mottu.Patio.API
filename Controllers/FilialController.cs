using Microsoft.AspNetCore.Mvc;
using Mottu.Patio.API.Models;
using Mottu.Patio.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilialController : ControllerBase
    {
        private readonly IFilialService _service;
        public FilialController(IFilialService service) => _service = service;

        /// <summary>
        /// Retorna todas as filiais com pagina��o.
        /// </summary>
        /// <param name="page">N�mero da p�gina</param>
        /// <param name="pageSize">Quantidade de itens por p�gina</param>
        /// <response code="200">Lista paginada de filiais</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), 200)]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var all = (await _service.GetAllAsync()).ToList();
            var total = all.Count;
            var items = all.Skip((page - 1) * pageSize).Take(pageSize);

            var result = new
            {
                total,
                page,
                pageSize,
                items = items.Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Endereco,
                    x.Telefone,
                    links = new
                    {
                        self = Url.Action(nameof(GetById), new { id = x.Id }),
                        update = Url.Action(nameof(Put), new { id = x.Id }),
                        delete = Url.Action(nameof(Delete), new { id = x.Id })
                    }
                })
            };

            return Ok(result);
        }

        /// <summary>
        /// Retorna uma filial espec�fica pelo ID.
        /// </summary>
        /// <param name="id">ID da filial</param>
        /// <response code="200">Filial encontrada</response>
        /// <response code="404">Filial n�o encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var f = await _service.GetByIdAsync(id);
            if (f == null) return NotFound();

            var result = new
            {
                f.Id,
                f.Nome,
                f.Endereco,
                f.Telefone,
                links = new
                {
                    self = Url.Action(nameof(GetById), new { id = f.Id }),
                    update = Url.Action(nameof(Put), new { id = f.Id }),
                    delete = Url.Action(nameof(Delete), new { id = f.Id })
                }
            };

            return Ok(result);
        }

        /// <summary>
        /// Cria uma nova filial.
        /// </summary>
        /// <param name="filial">Objeto da filial</param>
        /// <remarks>
        /// Exemplo de requisi��o (JSON):
        ///
        ///     POST /api/filial
        ///     { 
        ///       "id": 1,
        ///       "nome": "Filial Centro",
        ///       "endereco": "Rua das Flores, 123 - Centro - S�o Paulo/SP",
        ///       "telefone": "(11) 98765-4321"
        ///     }
        ///
        /// Observa��es:
        /// - **nome** � obrigat�rio e deve ser �nico.
        /// - **endereco** deve ser um endere�o v�lido e completo.
        /// - **telefone** deve estar em formato brasileiro, com DDD.
        /// </remarks>
        /// <response code="201">Filial criada com sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(Filial), 201)]
        public async Task<ActionResult<Filial>> Post([FromBody] Filial filial)
        {
            var created = await _service.CreateAsync(filial);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma filial existente.
        /// </summary>
        /// <param name="id">ID da filial</param>
        /// <param name="filial">Objeto atualizado</param>
        /// <response code="204">Atualiza��o bem-sucedida</response>
        /// <response code="400">IDs n�o coincidem</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] Filial filial)
        {
            if (id != filial.Id) return BadRequest();
            await _service.UpdateAsync(filial);
            return NoContent();
        }

        /// <summary>
        /// Remove uma filial pelo ID.
        /// </summary>
        /// <param name="id">ID da filial</param>
        /// <response code="204">Remo��o bem-sucedida</response>
        /// <response code="404">Filial n�o encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
