namespace ProjetoEstoqueASS.Models
{
    public class ItemResponseDto
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal PrecoCompra { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}