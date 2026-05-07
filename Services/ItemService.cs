using ProjetoEstoqueASS.Models;
using ProjetoEstoqueASS.Repositories;

namespace ProjetoEstoqueASS.Services
{
    public class ItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public Item Cadastrar(Item item) => _repository.Cadastrar(item);

        public IEnumerable<ItemResponseDto> ListarTodos()
        {
            return _repository.ListarTodos()
                .Select(i => new ItemResponseDto
                {
                    Codigo = i.Codigo,
                    Nome = i.Nome,
                    Categoria = i.Categoria,
                    PrecoCompra = i.PrecoCompra,
                    QuantidadeEstoque = i.QuantidadeEstoque,
                    Descricao = i.Descricao,
                    Ativo = i.Ativo
                });
        }

        public ItemResponseDto? BuscarPorCodigo(string codigo)
        {
            var item = _repository.BuscarPorCodigo(codigo);
            if (item == null) return null;

            return new ItemResponseDto
            {
                Codigo = item.Codigo,
                Nome = item.Nome,
                Categoria = item.Categoria,
                PrecoCompra = item.PrecoCompra,
                QuantidadeEstoque = item.QuantidadeEstoque,
                Descricao = item.Descricao,
                Ativo = item.Ativo
            };
        }

        public void EntradaEstoque(string codigo, int quantidade)
        {
            var item = _repository.BuscarPorCodigo(codigo) ?? throw new Exception("Item não encontrado");
            item.EntradaEstoque(quantidade);
            _repository.Atualizar(item);
        }

        public void SaidaEstoque(string codigo, int quantidade)
        {
            var item = _repository.BuscarPorCodigo(codigo) ?? throw new Exception("Item não encontrado");
            item.SaidaEstoque(quantidade);
            _repository.Atualizar(item);
        }
    }
}