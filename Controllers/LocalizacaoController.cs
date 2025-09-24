using Microsoft.AspNetCore.Mvc;
using Mottu.Patio.API.Models;
using Mottu.Patio.API.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Mottu.Patio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly ILocalizacaoService _service;
        public LocalizacaoController(ILocalizacaoService service) => _service = service;

        /// <summary>
        /// Retorna a lista de localiza��es cadastradas.
        /// </summary>
        /// <param name="page">N�mero da p�gina (padr�o = 1)</param>
        /// <param name="pageSize">Quantidade de itens por p�gina (padr�o = 10)</param>
        /// <response code="200">Lista paginada de localiza��es</response>
        [HttpGet]
        [ProducesResponseType(200)]
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
                    x.MotoId,
                    x.Latitude,
                    x.Longitude,
                    x.Data,
                    links = new
                    {
                        self = Url.Action(nameof(GetById), new { id = x.Id }),
                        update = Url.Action(nameof(Put), new { id = x.Id }),
                        delete = Url.Action(nameof(Delete), new { id = x.Id }),
                        moto = Url.Action("Get", "Moto", new { id = x.MotoId })
                    }
                })
            };
            return Ok(result);
        }

        /// <summary>
        /// Retorna uma localiza��o espec�fica pelo ID.
        /// </summary>
        /// <param name="id">ID da localiza��o</param>
        /// <response code="200">Localiza��o encontrada</response>
        /// <response code="404">Localiza��o n�o encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var l = await _service.GetByIdAsync(id);
            if (l == null) return NotFound();

            var result = new
            {
                l.Id,
                l.MotoId,
                l.Latitude,
                l.Longitude,
                l.Data,
                links = new
                {
                    self = Url.Action(nameof(GetById), new { id = l.Id }),
                    update = Url.Action(nameof(Put), new { id = l.Id }),
                    delete = Url.Action(nameof(Delete), new { id = l.Id }),
                    moto = Url.Action("Get", "Moto", new { id = l.MotoId })
                }
            };

            return Ok(result);
        }

        /// <summary>
        /// Cadastra uma nova localiza��o.
        /// </summary>
        /// <param name="loc">Objeto de localiza��o</param>
        /// <remarks>
        /// Exemplo de requisi��o:
        /// 
        ///     POST /api/localizacao
        ///     {   
        ///        "id": 
        ///        "motoId": 1,
        ///        "latitude": -23.561684,
        ///        "longitude": -46.655981,
        ///        "data": "2025-09-23T14:30:00Z"
        ///     }
        /// 
        /// Observa��es:
        /// - **motoId** deve ser de uma moto j� cadastrada.
        /// - **latitude** e **longitude** usam o formato decimal (padr�o GPS).
        /// - **data** deve ser informada em formato ISO 8601 (`yyyy-MM-ddTHH:mm:ssZ`).
        /// </remarks>
        /// <response code="201">Localiza��o criada com sucesso</response>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Localizacao>> Post([FromBody] Localizacao loc)
        {
            var created = await _service.CreateAsync(loc);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma localiza��o existente.
        /// </summary>
        /// <param name="id">ID da localiza��o</param>
        /// <param name="loc">Objeto de localiza��o atualizado</param>
        /// <response code="204">Atualiza��o bem-sucedida</response>
        /// <response code="400">IDs n�o conferem</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] Localizacao loc)
        {
            if (id != loc.Id) return BadRequest();
            await _service.UpdateAsync(loc);
            return NoContent();
        }

        /// <summary>
        /// Remove uma localiza��o pelo ID.
        /// </summary>
        /// <param name="id">ID da localiza��o</param>
        /// <response code="204">Remo��o bem-sucedida</response>
        /// <response code="404">Localiza��o n�o encontrada</response>
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
