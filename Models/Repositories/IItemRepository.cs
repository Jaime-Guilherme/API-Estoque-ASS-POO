using ProjetoEstoqueASS.Models;

namespace ProjetoEstoqueASS.Repositories
{
    public interface IItemRepository
    {
        Item Cadastrar(Item item);
        IEnumerable<Item> ListarTodos();
        Item? BuscarPorCodigo(string codigo);
        void Atualizar(Item item);           // para futuras atualizações
        void Remover(string codigo);         // opcional
    }
}