using Microsoft.AspNetCore.Mvc;
using Mottu.Patio.API.Models;
using Mottu.Patio.API.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _service;
        public MotoController(IMotoService service) => _service = service;

        /// <summary>
        /// Retorna a lista de motos com paginação.
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Quantidade de itens por página</param>
        /// <response code="200">Lista de motos retornada com sucesso</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var all = (await _service.GetAllAsync()).ToList();
            var total = all.Count;
            var items = all.Skip((page - 1) * pageSize).Take(pageSize);

            var result = new
            {
                total,
                page,
                pageSize,
                items = items.Select(m => new
                {
                    m.Id,
                    m.Placa,
                    m.Modelo,
                    links = new
                    {
                        self = Url.Action(nameof(GetById), new { id = m.Id }),
                        update = Url.Action(nameof(Put), new { id = m.Id }),
                        delete = Url.Action(nameof(Delete), new { id = m.Id })
                    }
                })
            };

            return Ok(result);
        }

        /// <summary>
        /// Retorna uma moto específica pelo ID.
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <response code="200">Moto encontrada</response>
        /// <response code="404">Moto não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var m = await _service.GetByIdAsync(id);
            if (m == null) return NotFound();

            var result = new
            {
                m.Id,
                m.Placa,
                m.Modelo,
                links = new
                {
                    self = Url.Action(nameof(GetById), new { id = m.Id }),
                    update = Url.Action(nameof(Put), new { id = m.Id }),
                    delete = Url.Action(nameof(Delete), new { id = m.Id })
                }
            };

            return Ok(result);
        }

        /// <summary>
        /// Cadastra uma nova moto.
        /// </summary>
        /// <param name="moto">Objeto da moto</param>
        /// <remarks>
        /// Exemplo de requisição (JSON):
        ///
        ///     POST /api/moto
        ///     {
        ///       "id": 1,
        ///       "placa": "ABC-1D23",
        ///       "modelo": "Honda CG 160",
        ///       "quilometragem": 12000,
        ///       "filialId": 1
        ///     }
        ///
        /// Observações:
        /// - **placa** deve estar no padrão brasileiro (ex: "ABC-1D23").
        /// - **quilometragem** em quilômetros rodados (inteiro).
        /// - **filialId** deve referenciar uma filial existente.
        /// </remarks>
        /// <response code="201">Moto criada com sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(Moto), 201)]
        public async Task<ActionResult<Moto>> Post([FromBody] Moto moto)
        {
            var created = await _service.CreateAsync(moto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza os dados de uma moto existente.
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <param name="moto">Objeto atualizado</param>
        /// <response code="204">Atualização bem-sucedida</response>
        /// <response code="400">IDs não conferem</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] Moto moto)
        {
            if (id != moto.Id) return BadRequest();
            await _service.UpdateAsync(moto);
            return NoContent();
        }

        /// <summary>
        /// Remove uma moto pelo ID.
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <response code="204">Remoção bem-sucedida</response>
        /// <response code="404">Moto não encontrada</response>
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
