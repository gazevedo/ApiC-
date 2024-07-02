using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Model
{
    public class FuncionarioModel
    {
        public int Codigo { get; set; }
        public string Funcionario { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}