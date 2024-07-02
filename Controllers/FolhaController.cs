using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Dal;
using WebApi.Model;

namespace WebApi.Controllers
{
    public class FolhaController : ApiController
    { 
        [HttpGet] 
        public IHttpActionResult GetFolha()
        {
            var funcionarios = FolhaPagamentoDao.GetFolha();
            return Ok(funcionarios);
        }

        [HttpGet] 
        public IHttpActionResult GetTotalFolha()
        {
            var funcionarios = FolhaPagamentoDao.GetFolha();
            return Ok(funcionarios.Sum(f => f.Salario));  
        }
    }
}