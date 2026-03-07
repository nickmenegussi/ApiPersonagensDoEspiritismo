namespace ApiPersonagensDoEspiritismo.Dto
{
    public class PersonagemResumoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }
        public string Tipo { get; set; }
        public string FotoUrl { get; set; }
        public int QuantidadeObras { get; set; }
    }

    public class PersonagemDetalheDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string DataFalecimento { get; set; }
        public string Pais { get; set; }
        public string CidadeNatal { get; set; }
        public string Biografia { get; set; }
        public string FotoUrl { get; set; }
        public string Tipo { get; set; }
        public int? IdadeAoFalecer { get; set; }
        public List<ObraDto> Obras { get; set; }
        public List<ContribuicaoDto> Contribuicoes { get; set; }
    }

    public class ObraDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? Ano { get; set; }
    }

    public class ContribuicaoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
    }
}

