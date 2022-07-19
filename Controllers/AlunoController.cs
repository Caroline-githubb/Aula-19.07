using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoCWebAPI.Models;

namespace PoCWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private EscolaContext dbEscola = new EscolaContext();      

        [HttpGet]
        public List<Aluno> AcessarAlunos()
        {
            return dbEscola.Alunos.ToList();
        }

        [HttpGet("{id}")]
        public Aluno AcessarAlunoPelaId(int id)
        {          
            Aluno aluno = dbEscola.Alunos.Find(id);
            return aluno;
        }

        [HttpPost]
        public Aluno CadastrarAluno(Aluno novoAluno)
        {
            dbEscola.Alunos.Add(novoAluno);
            dbEscola.SaveChanges();

            return novoAluno;
        }

        [HttpDelete]
        public Aluno DeleteAluno(int id)
        {
            Aluno aluno = dbEscola.Alunos.Find(id);

            dbEscola.Alunos.Remove(aluno);
            dbEscola.SaveChanges();

            return aluno;
        }





    }
}
