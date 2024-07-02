# **Webapi C#**

Nesta tarefa, foi desenvolvida uma API utilizando o .NETframework, com o objetivo de estudo da linguagem. 

## **Detalhamento das Funcionalidades Implementadas:**

-Listagem de Funcionários: Implementada através da rota /listafuncionario, que retorna uma lista com os nomes de todos os funcionários registrados na folha de pagamento.

-Total da Folha de Pagamento: A funcionalidade disponível na rota /totalfolha calcula e retorna o valor total da folha de pagamento, somando os salários de todos os funcionários.

-Detalhes da Folha de Pagamento: A rota /folha retorna todos os dados da folha de pagamento em formato JSON, incluindo informações como nome do funcionário, código e salário.

-Consulta de Funcionário por Código: Implementada na rota /funcionario/<codigo>, que permite consultar e retornar detalhes específicos de um funcionário através do seu código único.

-Atualização de Salário: A rota /atualizarSalario possibilita a atualização do salário de um funcionário especificado pelo seu código, utilizando requisições do tipo POST com dados em formato JSON.

-Exclusão de Funcionário: Implementada na rota /excluirFuncionario/<codigo>, que permite remover um funcionário do sistema com base no seu código, utilizando requisições do tipo DELETE.

## **Tecnologias Utilizadas:**
 
C# é a linguagem de programação principal utilizada no desenvolvimento da API. Ela é amplamente usada para aplicativos Windows, web e móveis, sendo uma linguagem fortemente tipada orientada a objetos.
ASP.NET Web API:

ASP.NET Web API é um framework da plataforma ASP.NET da Microsoft para a construção de APIs HTTP baseadas em RESTful. Ele permite que você construa APIs que podem ser consumidas por uma ampla variedade de clientes, incluindo navegadores e dispositivos móveis.
CSVHelper:

CSVHelper é uma biblioteca .NET que facilita a leitura e a escrita de arquivos CSV. Ela oferece métodos simples e poderosos para mapear objetos .NET para linhas de CSV e vice-versa, facilitando o processamento de dados estruturados em formato CSV.
