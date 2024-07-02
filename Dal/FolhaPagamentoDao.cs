using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using WebApi.Model;

namespace WebApi.Dal
{
    public class FolhaPagamentoDao
    {
        private static string csvFilePath = @"D:\WorkSpace\WebApi\WebApi\Folha.csv";

        public static List<FuncionarioModel> GetFolha()
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",", // Define o delimitador como vírgula
            }))
            {
                csv.Context.RegisterClassMap<FuncionarioMap>(); // Registra o mapeamento de classe no contexto do CsvReader

                var funcionarios = csv.GetRecords<FuncionarioModel>().ToList();
                return funcionarios;
            }
        }

        internal static void AtualizaSalario(int codigo, decimal novoSalario)
        {
            var funcionarios = GetFolha();

            // Encontra o funcionário pelo código
            var funcionario = funcionarios.FirstOrDefault(f => f.Codigo == codigo);
            if (funcionario != null)
            {
                // Atualiza o salário
                funcionario.Salario = novoSalario;

                // Salva os dados atualizados de volta no arquivo CSV
                using (var writer = new StreamWriter(csvFilePath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                }))
                {
                    csv.Context.RegisterClassMap<FuncionarioMap>();
                    csv.WriteRecords(funcionarios);
                }
            }
            else
            {
                throw new KeyNotFoundException("Funcionário não encontrado");
            }
        }

        internal static void DeletaFuncionario(int codigo)
        {
            var funcionarios = GetFolha();

            // Remove o funcionário pelo código
            var funcionarioRemovido = funcionarios.RemoveAll(f => f.Codigo == codigo) > 0;
            if (funcionarioRemovido)
            {
                // Salva os dados atualizados de volta no arquivo CSV
                using (var writer = new StreamWriter(csvFilePath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                }))
                {
                    csv.Context.RegisterClassMap<FuncionarioMap>();
                    csv.WriteRecords(funcionarios);
                }
            }
            else
            {
                throw new KeyNotFoundException("Funcionário não encontrado");
            }
        }
    }

    public sealed class FuncionarioMap : ClassMap<FuncionarioModel>
    {
        public FuncionarioMap()
        {
            Map(m => m.Codigo).Name("Codigo"); // Mapeia o campo Codigo para a coluna 'codigo' no CSV
            Map(m => m.Funcionario).Name("Funcionario"); // Mapeia o campo Funcionario para a coluna 'Funcionario' no CSV
            Map(m => m.Cargo).Name("Cargo"); // Mapeia o campo Cargo para a coluna 'Cargo' no CSV
            Map(m => m.Salario).Name("Salario"); // Mapeia o campo Salario para a coluna 'Salario' no CSV
        }
    }
}
