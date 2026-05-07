using System.ComponentModel.DataAnnotations;

namespace ProjetoEstoqueASS.Models
{
    public class Item
    {
        // Chave primária
        public string Codigo { get; private set; } = string.Empty;

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres")]
        public string Nome { get; private set; } = string.Empty;

        [Required(ErrorMessage = "Categoria é obrigatória")]
        public string Categoria { get; private set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        public decimal PrecoCompra { get; private set; }

        public int QuantidadeEstoque { get; private set; }

        public string? Descricao { get; private set; }

        public bool Ativo { get; private set; } = true;

        // === CONSTRUTOR SEM PARÂMETROS (obrigatório para EF Core) ===
        public Item() { }   // ← Adicionado aqui!

        // === CONSTRUTOR PRINCIPAL (para uso na aplicação) ===
        public Item(string codigo, string nome, string categoria, decimal precoCompra,
                    int quantidadeInicial = 0, string? descricao = null)
        {
            ValidarCodigo(codigo);
            ValidarNome(nome);
            ValidarCategoria(categoria);
            ValidarPreco(precoCompra);
            ValidarQuantidadeInicial(quantidadeInicial);

            Codigo = codigo.ToUpper().Trim();
            Nome = nome.Trim();
            Categoria = categoria.Trim();
            PrecoCompra = precoCompra;
            QuantidadeEstoque = quantidadeInicial;
            Descricao = string.IsNullOrWhiteSpace(descricao) ? null : descricao.Trim();
        }

        // ====================== VALIDAÇÕES ======================
        private static void ValidarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("Código é obrigatório.");
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length < 3)
                throw new ArgumentException("Nome deve ter pelo menos 3 caracteres.");
        }

        private static void ValidarCategoria(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("Categoria é obrigatória.");
        }

        private static void ValidarPreco(decimal preco)
        {
            if (preco <= 0)
                throw new ArgumentException("Preço de compra deve ser maior que zero.");
        }

        private static void ValidarQuantidadeInicial(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentException("Quantidade inicial não pode ser negativa.");
        }

        // ====================== REGRAS DE NEGÓCIO ======================
        public void EntradaEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade de entrada deve ser maior que zero.");
            QuantidadeEstoque += quantidade;
        }

        public void SaidaEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade de saída deve ser maior que zero.");

            if (quantidade > QuantidadeEstoque)
                throw new InvalidOperationException($"Estoque insuficiente. Disponível: {QuantidadeEstoque} unidades.");

            QuantidadeEstoque -= quantidade;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            ValidarPreco(novoPreco);
            PrecoCompra = novoPreco;
        }

        public void AtualizarDescricao(string novaDescricao)
        {
            Descricao = string.IsNullOrWhiteSpace(novaDescricao) ? null : novaDescricao.Trim();
        }

        public void Desativar() => Ativo = false;
        public void Ativar() => Ativo = true;
    }
}