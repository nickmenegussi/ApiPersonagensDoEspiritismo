// Repositories/PersonagensRepository.cs
using System.Data;
using ApiPersonagensDoEspiritismo.Data;
using ApiPersonagensDoEspiritismo.Models;

namespace ApiPersonagensDoEspiritismo.Repositories
{
    public class PersonagensRepository
    {
        //private static string server = "localhost\\SQLEXPRESS";
        //private static string database = "PersonagensEspiritismo";
        //private static string user = "administrador";
        //private static string password = "adminmaisprati";

        // CONSULTAR TODOS COM AS LISTAS
        public static List<Personagem> ConsultarPersonagens()
        {
            var personagens = new List<Personagem>();
            var ObraPrincipal = new List<ObraPrincipal>();

            Database db = new Database();
            // Buscar personagens - SEM as colunas ObrasPrincipais e Contribuicoes
            var tablePersonagens = db.ExecuteQuery("SELECT * FROM Personagens ORDER BY Nome, IdPersonagem Desc");



            foreach (DataRow row in tablePersonagens.Rows)
            {
                int idPersonagem = Convert.ToInt32(row["IdPersonagem"]);

                var personagem = new Personagem
                {
                    IdPersonagem = idPersonagem,
                    Nome = row["Nome"].ToString() ?? "",
                    NomeCompleto = row["NomeCompleto"] == DBNull.Value ? null : row["NomeCompleto"].ToString(),
                    DataNascimento = row["DataNascimento"] == DBNull.Value ? null : Convert.ToDateTime(row["DataNascimento"]),
                    DataFalecimento = row["DataFalecimento"] == DBNull.Value ? null : Convert.ToDateTime(row["DataFalecimento"]),
                    Pais = row["Pais"] == DBNull.Value ? null : row["Pais"].ToString(),
                    CidadeNatal = row["CidadeNatal"] == DBNull.Value ? null : row["CidadeNatal"].ToString(),
                    Biografia = row["Biografia"] == DBNull.Value ? null : row["Biografia"].ToString(),
                    FotoUrl = row["FotoUrl"] == DBNull.Value ? null : row["FotoUrl"].ToString(),
                    Tipo = row["Tipo"] == DBNull.Value ? null : row["Tipo"].ToString(),

                    // REMOVIDO: ObrasPrincipais e Contribuicoes daqui
                };

                // Buscar as listas relacionadas SEPARADAMENTE
                personagem.ObrasPrincipais = ConsultarObrasPorPersonagem(idPersonagem);
                personagem.Contribuicoes = ConsultarContribuicoesPorPersonagem(idPersonagem);

                personagens.Add(personagem);
            }

            return personagens;
        }

        // CONSULTAR POR ID COM LISTAS
        public static Personagem? ConsultarPorId(int idPersonagem)
        {
            Database db = new Database();
            var table = db.ExecuteQuery($"SELECT * FROM Personagens WHERE IdPersonagem = {idPersonagem}");

            if (table.Rows.Count == 0)
                return null;

            var row = table.Rows[0];
            var personagem = new Personagem
            {
                IdPersonagem = Convert.ToInt32(row["IdPersonagem"]),
                Nome = row["Nome"].ToString() ?? "",
                NomeCompleto = row["NomeCompleto"] == DBNull.Value ? null : row["NomeCompleto"].ToString(),
                DataNascimento = row["DataNascimento"] == DBNull.Value ? null : Convert.ToDateTime(row["DataNascimento"]),
                DataFalecimento = row["DataFalecimento"] == DBNull.Value ? null : Convert.ToDateTime(row["DataFalecimento"]),
                Pais = row["Pais"] == DBNull.Value ? null : row["Pais"].ToString(),
                CidadeNatal = row["CidadeNatal"] == DBNull.Value ? null : row["CidadeNatal"].ToString(),
                Biografia = row["Biografia"] == DBNull.Value ? null : row["Biografia"].ToString(),
                FotoUrl = row["FotoUrl"] == DBNull.Value ? null : row["FotoUrl"].ToString(),
                Tipo = row["Tipo"] == DBNull.Value ? null : row["Tipo"].ToString()
            };

            // Buscar as listas relacionadas SEPARADAMENTE
            personagem.ObrasPrincipais = ConsultarObrasPorPersonagem(idPersonagem);
            personagem.Contribuicoes = ConsultarContribuicoesPorPersonagem(idPersonagem);

            return personagem;
        }

        public static Personagem? ConsultarPorNome(String nome)
        {
            Database db = new Database();
            var table = db.ExecuteQuery($"SELECT * FROM Personagens WHERE Nome LIKE '%{nome.Trim().ToLower()}%'");

            if (table.Rows.Count == 0)
                return null;

            var row = table.Rows[0];
            var personagem = new Personagem
            {
                IdPersonagem = Convert.ToInt32(row["IdPersonagem"]),
                Nome = row["Nome"].ToString() ?? "",
                NomeCompleto = row["NomeCompleto"] == DBNull.Value ? null : row["NomeCompleto"].ToString(),
                DataNascimento = row["DataNascimento"] == DBNull.Value ? null : Convert.ToDateTime(row["DataNascimento"]),
                DataFalecimento = row["DataFalecimento"] == DBNull.Value ? null : Convert.ToDateTime(row["DataFalecimento"]),
                Pais = row["Pais"] == DBNull.Value ? null : row["Pais"].ToString(),
                CidadeNatal = row["CidadeNatal"] == DBNull.Value ? null : row["CidadeNatal"].ToString(),
                Biografia = row["Biografia"] == DBNull.Value ? null : row["Biografia"].ToString(),
                FotoUrl = row["FotoUrl"] == DBNull.Value ? null : row["FotoUrl"].ToString(),
                Tipo = row["Tipo"] == DBNull.Value ? null : row["Tipo"].ToString(),

            };

            //// Buscar as listas relacionadas SEPARADAMENTE
            personagem.ObrasPrincipais = ConsultarObrasPorPersonagem(personagem.IdPersonagem);
            personagem.Contribuicoes = ConsultarContribuicoesPorPersonagem(personagem.IdPersonagem);

            return personagem;
        }

        // CONSULTAR POR TIPO COM LISTAS
        public static List<Personagem> ConsultarPorTipo(string tipo)
        {
            var personagens = new List<Personagem>();

            Database db = new Database();
            var tablePersonagens = db.ExecuteQuery($"SELECT * FROM Personagens WHERE Tipo = '{tipo}' ORDER BY Nome");

            foreach (DataRow row in tablePersonagens.Rows)
            {
                int idPersonagem = Convert.ToInt32(row["IdPersonagem"]);

                var personagem = new Personagem
                {
                    IdPersonagem = idPersonagem,
                    Nome = row["Nome"].ToString() ?? "",
                    NomeCompleto = row["NomeCompleto"] == DBNull.Value ? null : row["NomeCompleto"].ToString(),
                    DataNascimento = row["DataNascimento"] == DBNull.Value ? null : Convert.ToDateTime(row["DataNascimento"]),
                    DataFalecimento = row["DataFalecimento"] == DBNull.Value ? null : Convert.ToDateTime(row["DataFalecimento"]),
                    Pais = row["Pais"] == DBNull.Value ? null : row["Pais"].ToString(),
                    CidadeNatal = row["CidadeNatal"] == DBNull.Value ? null : row["CidadeNatal"].ToString(),
                    Biografia = row["Biografia"] == DBNull.Value ? null : row["Biografia"].ToString(),
                    FotoUrl = row["FotoUrl"] == DBNull.Value ? null : row["FotoUrl"].ToString(),
                    Tipo = row["Tipo"] == DBNull.Value ? null : row["Tipo"].ToString()
                };

                // Buscar as listas relacionadas SEPARADAMENTE
                personagem.ObrasPrincipais = ConsultarObrasPorPersonagem(idPersonagem);
                personagem.Contribuicoes = ConsultarContribuicoesPorPersonagem(idPersonagem);

                personagens.Add(personagem);
            }

            return personagens;
        }

        // MÉTODOS AUXILIARES PARA BUSCAR LISTAS
        private static List<ObraPrincipal> ConsultarObrasPorPersonagem(int idPersonagem)
        {
            var obras = new List<ObraPrincipal>();

            Database db = new Database();
            var table = db.ExecuteQuery($"SELECT * FROM ObrasPrincipais WHERE IdPersonagem = {idPersonagem}");

            foreach (DataRow row in table.Rows)
            {
                var obra = new ObraPrincipal
                {
                    IdObra = Convert.ToInt32(row["IdObra"]),
                    IdPersonagem = Convert.ToInt32(row["IdPersonagem"]),
                    Titulo = row["Titulo"].ToString() ?? "",
                    AnoPublicacao = row["AnoPublicacao"] == DBNull.Value ? null : Convert.ToInt32(row["AnoPublicacao"]),
                    Descricao = row["Descricao"] == DBNull.Value ? null : row["Descricao"].ToString()
                };
                obras.Add(obra);
            }

            return obras;
        }

        private static List<Contribuicao> ConsultarContribuicoesPorPersonagem(int idPersonagem)
        {
            var contribuicoes = new List<Contribuicao>();

            Database db = new Database();
            var table = db.ExecuteQuery($"SELECT * FROM Contribuicoes WHERE IdPersonagem = {idPersonagem}");

            foreach (DataRow row in table.Rows)
            {
                var contribuicao = new Contribuicao
                {
                    IdContribuicao = Convert.ToInt32(row["IdContribuicao"]),
                    IdPersonagem = Convert.ToInt32(row["IdPersonagem"]),
                    Descricao = row["Descricao"].ToString() ?? "",
                    Categoria = row["Categoria"] == DBNull.Value ? null : row["Categoria"].ToString()
                };
                contribuicoes.Add(contribuicao);
            }

            return contribuicoes;
        }

        // CADASTRAR PERSONAGEM COM OBRAS E CONTRIBUIÇÕES
        public static int CadastrarPersonagem(Personagem personagem)
        {
            Database db = new Database();

            // 1. Inserir personagem (SEM ObrasPrincipais e Contribuicoes)
            string nomeCompleto = FormatStringForSQL(personagem.NomeCompleto);
            string dataNascimento = personagem.DataNascimento == null ? "NULL" : $"'{personagem.DataNascimento.Value:yyyy-MM-dd}'";
            string dataFalecimento = personagem.DataFalecimento == null ? "NULL" : $"'{personagem.DataFalecimento.Value:yyyy-MM-dd}'";
            string pais = FormatStringForSQL(personagem.Pais);
            string cidadeNatal = FormatStringForSQL(personagem.CidadeNatal);
            string biografia = FormatStringForSQL(personagem.Biografia);
            string fotoUrl = FormatStringForSQL(personagem.FotoUrl);
            string tipo = FormatStringForSQL(personagem.Tipo);

            var sqlPersonagem = $@"
                INSERT INTO Personagens
                (Nome, NomeCompleto, DataNascimento, DataFalecimento, Pais, CidadeNatal, Biografia, FotoUrl, Tipo)
                OUTPUT INSERTED.IdPersonagem
                VALUES
                ('{personagem.Nome.Replace("'", "''")}', 
                 {nomeCompleto}, 
                 {dataNascimento}, 
                 {dataFalecimento}, 
                 {pais}, 
                 {cidadeNatal}, 
                 {biografia}, 
                 {fotoUrl}, 
                 {tipo})";

            // Pegar o ID gerado
            int idPersonagem = Convert.ToInt32(db.ExecuteScalar(sqlPersonagem));

            // 2. Inserir obras
            foreach (var obra in personagem.ObrasPrincipais)
            {
                string titulo = FormatStringForSQL(obra.Titulo);
                string descricao = FormatStringForSQL(obra.Descricao);
                string ano = obra.AnoPublicacao == null ? "NULL" : obra.AnoPublicacao.ToString();

                var sqlObra = $@"
                    INSERT INTO ObrasPrincipais (IdPersonagem, Titulo, AnoPublicacao, Descricao)
                    VALUES ({idPersonagem}, {titulo}, {ano}, {descricao})";

                db.ExecuteNonQuery(sqlObra);
            }

            // 3. Inserir contribuições
            foreach (var contribuicao in personagem.Contribuicoes)
            {
                string descricao = FormatStringForSQL(contribuicao.Descricao);
                string categoria = FormatStringForSQL(contribuicao.Categoria);

                var sqlContribuicao = $@"
                    INSERT INTO Contribuicoes (IdPersonagem, Descricao, Categoria)
                    VALUES ({idPersonagem}, {descricao}, {categoria})";

                db.ExecuteNonQuery(sqlContribuicao);
            }

            return 1; // Sucesso
        }

        // ALTERAR PERSONAGEM
        public static int AlterarPersonagem(Personagem personagem)
        {
            Database db = new Database();

            // 1. Atualizar personagem (SEM ObrasPrincipais e Contribuicoes)
            string nomeCompleto = FormatStringForSQL(personagem.NomeCompleto);
            string dataNascimento = personagem.DataNascimento == null ? "NULL" : $"'{personagem.DataNascimento.Value:yyyy-MM-dd}'";
            string dataFalecimento = personagem.DataFalecimento == null ? "NULL" : $"'{personagem.DataFalecimento.Value:yyyy-MM-dd}'";
            string pais = FormatStringForSQL(personagem.Pais);
            string cidadeNatal = FormatStringForSQL(personagem.CidadeNatal);
            string biografia = FormatStringForSQL(personagem.Biografia);
            string fotoUrl = FormatStringForSQL(personagem.FotoUrl);
            string tipo = FormatStringForSQL(personagem.Tipo);

            var sqlPersonagem = $@"
                UPDATE Personagens SET
                Nome = '{personagem.Nome.Replace("'", "''")}',
                NomeCompleto = {nomeCompleto},
                DataNascimento = {dataNascimento},
                DataFalecimento = {dataFalecimento},
                Pais = {pais},
                CidadeNatal = {cidadeNatal},
                Biografia = {biografia},
                FotoUrl = {fotoUrl},
                Tipo = {tipo}
                WHERE IdPersonagem = {personagem.IdPersonagem}";

            db.ExecuteNonQuery(sqlPersonagem);

            // 2. Remover obras antigas e inserir novas
            db.ExecuteNonQuery($"DELETE FROM ObrasPrincipais WHERE IdPersonagem = {personagem.IdPersonagem}");

            foreach (var obra in personagem.ObrasPrincipais)
            {
                string titulo = FormatStringForSQL(obra.Titulo);
                string descricao = FormatStringForSQL(obra.Descricao);
                string ano = obra.AnoPublicacao == null ? "NULL" : obra.AnoPublicacao.ToString();

                var sqlObra = $@"
                    INSERT INTO ObrasPrincipais (IdPersonagem, Titulo, AnoPublicacao, Descricao)
                    VALUES ({personagem.IdPersonagem}, {titulo}, {ano}, {descricao})";

                db.ExecuteNonQuery(sqlObra);
            }

            // 3. Remover contribuições antigas e inserir novas
            db.ExecuteNonQuery($"DELETE FROM Contribuicoes WHERE IdPersonagem = {personagem.IdPersonagem}");

            foreach (var contribuicao in personagem.Contribuicoes)
            {
                string descricao = FormatStringForSQL(contribuicao.Descricao);
                string categoria = FormatStringForSQL(contribuicao.Categoria);

                var sqlContribuicao = $@"
                    INSERT INTO Contribuicoes (IdPersonagem, Descricao, Categoria)
                    VALUES ({personagem.IdPersonagem}, {descricao}, {categoria})";

                db.ExecuteNonQuery(sqlContribuicao);
            }

            return 1;
        }

        // EXCLUIR PERSONAGEM
        public static int ExcluirPersonagemPorId(int idPersonagem)
        {
            Database db = new Database();

            // As obras e contribuições serão excluídas em cascata pelo banco
            var sql = $"DELETE FROM Personagens WHERE IdPersonagem = {idPersonagem}";
            var linhas = db.ExecuteNonQuery(sql);
            return linhas;
        }

        // Método auxiliar para formatar strings para SQL
        private static string FormatStringForSQL(string? valor)
        {
            if (string.IsNullOrEmpty(valor))
                return "NULL";
            return $"'{valor.Replace("'", "''")}'";
        }
    }
}