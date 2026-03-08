// Controllers/PersonagensController.cs
using Microsoft.AspNetCore.Mvc;
using ApiPersonagensDoEspiritismo.Models;
using ApiPersonagensDoEspiritismo.Repositories;

namespace ApiPersonagensDoEspiritismo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Personagem>> GetPersonagens()
        {
            var personagens = PersonagensRepository.ConsultarPersonagens();
            return Ok(personagens);
        }

        [HttpGet("buscaPorNomePersonagem")]
        public ActionResult<Personagem> GetPersonagemByNome([FromQuery] string nome)
        {
            var personagem = PersonagensRepository.ConsultarPorNome(nome.Trim().ToLower());

            if (personagem == null)
                return NotFound($"Personagem {nome} não encontrado");

            return Ok(personagem);
        }

        [HttpGet("{idPersonagem}")]
        public ActionResult<Personagem> GetPersonagemPorId(int idPersonagem)
        {
            var personagem = PersonagensRepository.ConsultarPorId(idPersonagem);

            if (personagem == null)
                return NotFound($"Personagem com ID {idPersonagem} não encontrado");

            return Ok(personagem);
        }



        
        [HttpGet("tipo/{tipo}")]
        public ActionResult<List<Personagem>> GetPersonagensPorTipo(string tipo)
        {
            var personagens = PersonagensRepository.ConsultarPorTipo(tipo);
            return Ok(personagens);
        }

        [HttpPost]
        public ActionResult<int> PostPersonagem([FromBody] Personagem personagem)
        {
            if (string.IsNullOrEmpty(personagem.Nome))
                return BadRequest("O nome do personagem é obrigatório");

            int resultado = PersonagensRepository.CadastrarPersonagem(personagem);
            return Ok(resultado);
        }

        [HttpPut]
        public ActionResult<int> PutPersonagem([FromBody] Personagem personagem)
        {
            if (personagem.IdPersonagem <= 0)
                return BadRequest("ID do personagem inválido");

            var personagemExistente = PersonagensRepository.ConsultarPorId(personagem.IdPersonagem);
            if (personagemExistente == null)
                return NotFound($"Personagem com ID {personagem.IdPersonagem} não encontrado");

            int resultado = PersonagensRepository.AlterarPersonagem(personagem);
            return Ok(resultado);
        }

        [HttpDelete("{idPersonagem}")]
        public ActionResult<int> DeletePersonagem(int idPersonagem)
        {
            var personagemExistente = PersonagensRepository.ConsultarPorId(idPersonagem);
            if (personagemExistente == null)
                return NotFound($"Personagem com ID {idPersonagem} não encontrado");

            int resultado = PersonagensRepository.ExcluirPersonagemPorId(idPersonagem);
            return Ok(resultado);
        }
    }
}