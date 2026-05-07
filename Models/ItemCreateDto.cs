namespace ProjetoEstoqueASS.Models
{
    public class ItemCreateDto
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal PrecoCompra { get; set; }
        public int QuantidadeInicial { get; set; } = 0;
        public string? Descricao { get; set; }
    }
}