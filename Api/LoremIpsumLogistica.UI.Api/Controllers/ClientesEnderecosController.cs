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
    public class ClientesEnderecosController : ControllerBase
    {
        private readonly ILogger<ClientesEnderecosController> _logger;
        private readonly IServicoDeAplicacaoDeClientesEnderecos _servicoDeAplicacaoDeClientesEnderecos;
        private readonly IMapper _mapper;

        public ClientesEnderecosController(ILogger<ClientesEnderecosController> logger,
             IServicoDeAplicacaoDeClientesEnderecos servicoDeAplicacaoDeClientesEnderecos,
             IMapper mapper
            )
        {
            _logger = logger;
            _servicoDeAplicacaoDeClientesEnderecos = servicoDeAplicacaoDeClientesEnderecos;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastrar ou Edita um endereço do cliente
        /// </summary>
        /// <response code="200">Sucesso!</response>
        /// <response code="400">Caso haja algum problema com a requisição</response>
        [HttpPost]
        [Route("cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult Cadastrar(ClienteEnderecoCadastroModel model)
        {
            var parametros = _mapper.Map<ClienteEnderecoCadastroDTO>(model);
            try
            {
                var retorno = this._servicoDeAplicacaoDeClientesEnderecos.Cadastrar(parametros);
                var retornoModel = _mapper.Map<ClienteEnderecoModel>(retorno);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Remove um endereço do cliente 
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
                this._servicoDeAplicacaoDeClientesEnderecos.Excluir(id);
                
                return Ok();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Recupera um endereço do cliente
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
                var retorno = this._servicoDeAplicacaoDeClientesEnderecos.Recuperar(id);
                
                if (retorno == null)
                    return NotFound();
                
                var retornoModel = _mapper.Map<ClienteEnderecoModel>(retorno);
                return Ok(retorno);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Recupera uma coleção de endereços do cliente
        /// </summary>
        /// <response code="200">Sucesso!</response>
        /// <response code="400">Caso haja algum problema com a requisição</response>
        [HttpGet]
        [Route("todos/{clienteId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public IActionResult RecuperarTodos(int clienteId)
        {
            try
            {
                var retorno = this._servicoDeAplicacaoDeClientesEnderecos.RecuperarTodos(clienteId);
                var retornoModel = _mapper.Map<ICollection<ClienteEnderecoModel>>(retorno);
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