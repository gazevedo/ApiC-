using System.Linq;
using System.Net;
using System.Web.Http;
using WebApi.Dal;
using WebApi.Model;

namespace ApiFolhaPagamento.Controllers
{
    [RoutePrefix("api/funcionario")]
    public class FuncionarioController : ApiController
    {
        [HttpGet]
        [Route("lista")]
        public IHttpActionResult GetListaFuncionarios()
        {
            var funcionarios = FolhaPagamentoDao.GetFolha();
            return Ok(funcionarios.Select(f => f.Funcionario));
        }

        [HttpGet] 
        public IHttpActionResult GetFuncionario(int codigo)
        {
            var funcionarios = FolhaPagamentoDao.GetFolha();
            var funcionario = funcionarios.FirstOrDefault(f => f.Codigo == codigo);
            if (funcionario == null)
                return Content(HttpStatusCode.NotFound, new { error = "Funcionário não encontrado" });

            return Ok(funcionario);
        }

        [HttpPost]
        [Route("atualizarSalario")]
        public IHttpActionResult AtualizarSalario([FromBody] FuncionarioModel atualizado)
        {
            if (atualizado == null)
                return BadRequest("Solicitação deve ser JSON");

            var funcionarios = FolhaPagamentoDao.GetFolha();
            var funcionario = funcionarios.FirstOrDefault(f => f.Codigo == atualizado.Codigo);
            if (funcionario == null)
                return Content(HttpStatusCode.NotFound, new { error = "Funcionário não encontrado" });
             
            FolhaPagamentoDao.AtualizaSalario(atualizado.Codigo, atualizado.Salario);
            return Ok(new { success = true });
        }

        [HttpDelete]
        [Route("excluir/{codigo}")]
        public IHttpActionResult ExcluirFuncionario(int codigo)
        { 
            FolhaPagamentoDao.DeletaFuncionario(codigo);
            return Ok(new { success = true });
        }
    }
}
