// Models/Personagem.cs
namespace ApiPersonagensDoEspiritismo.Models
{
    public class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataFalecimento { get; set; }
        public string? Pais { get; set; }
        public string? CidadeNatal { get; set; }
        public string? Biografia { get; set; }
        public string? FotoUrl { get; set; }
        public string? Tipo { get; set; }


        // Relacionamentos - agora são listas (batendo com o BD)
        public List<ObraPrincipal> ObrasPrincipais { get; set; } = new List<ObraPrincipal>();
        public List<Contribuicao> Contribuicoes { get; set; } = new List<Contribuicao>();
    }

    public class ObraPrincipal
    {
        public int IdObra { get; set; }
        public int IdPersonagem { get; set; }
        public string? Titulo { get; set; }
        public int? AnoPublicacao { get; set; }

        public String? FotoUrl { get; set; }
        public string? Descricao { get; set; }
    }

    public class Contribuicao
    {
        public int IdContribuicao { get; set; }
        public int IdPersonagem { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string? Categoria { get; set; }
    }
}