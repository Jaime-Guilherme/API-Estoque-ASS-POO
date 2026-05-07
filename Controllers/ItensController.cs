using Microsoft.AspNetCore.Mvc;
using ProjetoEstoqueASS.Models;
using ProjetoEstoqueASS.Services;

namespace ProjetoEstoqueASS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItensController : ControllerBase
    {
        private readonly ItemService _service;

        public ItensController(ItemService service)
        {
            _service = service;
        }

        // ====================== CADASTRAR ======================
        [HttpPost]
        public IActionResult Cadastrar([FromBody] ItemCreateDto dto)
        {
            try
            {
                var item = new Item(
                    dto.Codigo,
                    dto.Nome,
                    dto.Categoria,
                    dto.PrecoCompra,
                    dto.QuantidadeInicial,
                    dto.Descricao
                );

                var novoItem = _service.Cadastrar(item);
                return CreatedAtAction(nameof(BuscarPorCodigo), 
                    new { codigo = novoItem.Codigo }, novoItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ====================== LISTAR TODOS ======================
        [HttpGet]
        public IActionResult ListarTodos()
        {
            var itens = _service.ListarTodos();
            return Ok(itens);
        }

        // ====================== BUSCAR POR CÓDIGO ======================
        [HttpGet("{codigo}")]
        public IActionResult BuscarPorCodigo(string codigo)
        {
            var item = _service.BuscarPorCodigo(codigo);
            return item != null ? Ok(item) : NotFound("Item não encontrado");
        }

        // ====================== ENTRADA DE ESTOQUE ======================
        [HttpPost("{codigo}/entrada")]
        public IActionResult Entrada([FromRoute] string codigo, [FromQuery] int quantidade)
        {
            try
            {
                _service.EntradaEstoque(codigo, quantidade);
                return Ok($"Entrada de {quantidade} unidades realizada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ====================== SAÍDA DE ESTOQUE ======================
        [HttpPost("{codigo}/saida")]
        public IActionResult Saida([FromRoute] string codigo, [FromQuery] int quantidade)
        {
            try
            {
                _service.SaidaEstoque(codigo, quantidade);
                return Ok($"Saída de {quantidade} unidades realizada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}