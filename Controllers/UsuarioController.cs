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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service) => _service = service;

        /// <summary>
        /// Retorna a lista de usu�rios cadastrados com pagina��o.
        /// </summary>
        /// <param name="page">N�mero da p�gina (padr�o: 1)</param>
        /// <param name="pageSize">Quantidade de itens por p�gina (padr�o: 10)</param>
        /// <response code="200">Lista de usu�rios retornada com sucesso</response>
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
                items = items.Select(u => new
                {
                    u.Id,
                    u.PrimeiroNome,
                    u.Sobrenome,
                    u.Email,
                    u.Cargo,
                    u.Idade,
                    links = new[]
                    {
                        Url.Action(nameof(Get), new { id = u.Id }),
                        Url.Action(nameof(Put), new { id = u.Id })
                    }
                })
            };
            return Ok(result);
        }

        /// <summary>
        /// Retorna os detalhes de um usu�rio espec�fico.
        /// </summary>
        /// <param name="id">ID do usu�rio</param>
        /// <response code="200">Usu�rio encontrado</response>
        /// <response code="404">Usu�rio n�o encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var u = await _service.GetByIdAsync(id);
            if (u == null) return NotFound();

            var obj = new
            {
                u.Id,
                u.PrimeiroNome,
                u.Sobrenome,
                u.Email,
                u.Cargo,
                u.Idade,
                links = new
                {
                    self = Url.Action(nameof(Get), new { id = u.Id }),
                    update = Url.Action(nameof(Put), new { id = u.Id }),
                    delete = Url.Action(nameof(Delete), new { id = u.Id })
                }
            };

            return Ok(obj);
        }

        /// <summary>
        /// Cria um novo usu�rio.
        /// </summary>
        /// <param name="usuario">Objeto do usu�rio</param>
        /// <remarks>
        /// Exemplo de requisi��o:
        /// 
        ///     POST /api/usuario
        ///     {
        ///        "id": 1,
        ///        "primeiroNome": "Jo�o",
        ///        "sobrenome": "Silva",
        ///        "email": "joao.silva@email.com",
        ///        "cargo": "Administrador",
        ///        "idade": 30,
        ///        "filialId": 1,
        ///        "senha": "123456"
        ///     }
        /// </remarks>
        /// <response code="201">Usu�rio criado com sucesso</response>
        /// <response code="400">Requisi��o inv�lida</response>
        [HttpPost]
        [ProducesResponseType(typeof(Usuario), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            var created = await _service.CreateAsync(usuario);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza os dados de um usu�rio existente.
        /// </summary>
        /// <param name="id">ID do usu�rio</param>
        /// <param name="usuario">Objeto do usu�rio atualizado</param>
        /// <response code="204">Atualiza��o bem-sucedida</response>
        /// <response code="400">IDs n�o conferem</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();
            await _service.UpdateAsync(usuario);
            return NoContent();
        }

        /// <summary>
        /// Remove um usu�rio pelo ID.
        /// </summary>
        /// <param name="id">ID do usu�rio</param>
        /// <response code="204">Remo��o bem-sucedida</response>
        /// <response code="404">Usu�rio n�o encontrado</response>
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
