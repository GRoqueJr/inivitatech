using AutoMapper;
using LoremIpsumLogistica.Aplicacao.Dtos;
using LoremIpsumLogistica.Aplicacao.Interfaces;
using LoremIpsumLogistica.UI.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoremIpsumLogistica.UI.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IServicoDeAplicacaoDeClientes _servicoDeAplicacaoDeClientes;
        private readonly IMapper _mapper;

        public ClientesController(ILogger<ClientesController> logger,
             IServicoDeAplicacaoDeClientes servicoDeAplicacaoDeClientes,
             IMapper mapper
            )
        {
            _logger = logger;
            _servicoDeAplicacaoDeClientes = servicoDeAplicacaoDeClientes;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastrar ou Editar um cliente
        /// </summary>
        /// <response code="200">Sucesso!</response>
        /// <response code="400">Caso haja algum problema com a requisição</response>
        [HttpPost]
        [Route("cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult Cadastrar([FromBody] ClienteCadastroModel model)
        {
            var parametros = _mapper.Map<ClienteCadastroDTO>(model);
            try
            {
                /* Se for implementado o parametro vindo da tela, remover a declaração */
                var retorno = this._servicoDeAplicacaoDeClientes.Cadastrar(parametros);
                var retornoModel = _mapper.Map<ClienteModel>(retorno);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Remove um cliente, incluse remove também os endereços daquele cliente.
        /// </summary>
        /// <response code="200">Sucesso!</response>
        /// <response code="400">Caso haja algum problema com a requisição</response>
        [HttpDelete]
        [Route("excluir/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult Excluir(int id)
        {
            try
            {
                /* Se for implementado o parametro vindo da tela, remover a declaração */
                this._servicoDeAplicacaoDeClientes.Excluir(id);
                
                return Ok();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Recupera um cliente
        /// </summary>
        /// <response code="200">Sucesso!</response>
        /// <response code="400">Quando acontecer algum erro na requisicao</response>
        /// <response code="404">Quando não encontrar o cliente</response>
        [HttpGet]
        [Route("recuperar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult Recuperar(int id)
        {
            try
            {
                /* Se for implementado o parametro vindo da tela, remover a declaração */
                var retorno = this._servicoDeAplicacaoDeClientes.Recuperar(id);
                
                if (retorno == null)
                    return NotFound();
                
                var retornoModel = _mapper.Map<ClienteModel>(retorno);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Recupera uma coleção com todos os clientes da base
        /// </summary>
        /// <response code="200">Sucesso!</response>
        /// <response code="400">Caso haja algum problema com a requisição</response>
        [HttpGet]
        [Route("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult RecuperarTodos()
        {
            try
            {
                /* Se for implementado o parametro vindo da tela, remover a declaração */
                var retorno = this._servicoDeAplicacaoDeClientes.RecuperarTodos();
                var retornoModel = _mapper.Map<ICollection<ClienteModel>>(retorno);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

    }
}