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
        /// Retorna a lista de usuários cadastrados com paginação.
        /// </summary>
        /// <param name="page">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Quantidade de itens por página (padrão: 10)</param>
        /// <response code="200">Lista de usuários retornada com sucesso</response>
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
        /// Retorna os detalhes de um usuário específico.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <response code="200">Usuário encontrado</response>
        /// <response code="404">Usuário não encontrado</response>
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
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="usuario">Objeto do usuário</param>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/usuario
        ///     {
        ///        "id": 1,
        ///        "primeiroNome": "João",
        ///        "sobrenome": "Silva",
        ///        "email": "joao.silva@email.com",
        ///        "cargo": "Administrador",
        ///        "idade": 30,
        ///        "filialId": 1,
        ///        "senha": "123456"
        ///     }
        /// </remarks>
        /// <response code="201">Usuário criado com sucesso</response>
        /// <response code="400">Requisição inválida</response>
        [HttpPost]
        [ProducesResponseType(typeof(Usuario), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            var created = await _service.CreateAsync(usuario);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="usuario">Objeto do usuário atualizado</param>
        /// <response code="204">Atualização bem-sucedida</response>
        /// <response code="400">IDs não conferem</response>
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
        /// Remove um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <response code="204">Remoção bem-sucedida</response>
        /// <response code="404">Usuário não encontrado</response>
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
