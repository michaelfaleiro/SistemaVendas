# Sistema de Criação de Orçamentos para Vendas de Peças Automotivas

Esta é uma Api desenvolvida em C# utilizando .NET 8, ASP.NET e Entity Framework, com SQL Server como banco de dados, para facilitar a criação de orçamentos para vendas de peças automotivas.
O sistema permite adicionar clientes, produtos e criar cotações para produtos não cadastrados.
Além disso, está em desenvolvimento uma funcionalidade para enviar cotações para fornecedores, comparar preços e escolher a melhor opção de custo-benefício.

## Funcionalidades

- Adicionar clientes: Cadastre novos clientes para os quais você deseja criar orçamentos.
- Adicionar produtos: Cadastre produtos disponíveis para venda. Se um produto não estiver cadastrado, é possível criar uma cotação para ele.
- Criar cotações: Para produtos não cadastrados, é possível criar cotações e enviar para fornecedores.
- Comparar preços: Após receber informações dos fornecedores, compare os preços e escolha a melhor opção de preço ou custo-benefício.
- Converter cotações em produtos cadastrados: Após escolher a melhor opção, o produto que não estava cadastrado pode ser adicionado ao sistema com as informações recebidas dos fornecedores.
- Gerar PDF de orçamentos: Na aba de orçamentos, é possível gerar um PDF com as informações do orçamento para enviar ao cliente.

## Requisitos

- .NET 8 SDK
- ASP.NET
- Entity Framework
- SQL Server

## Instalação e Configuração

1. Clone este repositório em sua máquina local.
2. Certifique-se de ter todos os requisitos mencionados acima instalados.
3. Configure o banco de dados SQL Server e atualize as strings de conexão no arquivo `appsettings.json` para refletir suas configurações.
4. Execute as migrações do Entity Framework para criar o banco de dados e as tabelas necessárias.
   ```bash
   dotnet ef database update
   ```
5. Execute a aplicação.
   ```bash
   dotnet run
   ```

## Contribuição

Contribuições são bem-vindas! Se você quiser contribuir com novas funcionalidades, correções de bugs ou melhorias no sistema, sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais detalhes.

## Contato

Para mais informações ou dúvidas sobre este projeto, entre em contato com [Michael Faleiro](mailto:michaelfaleiro@gmail.com).

--- 

Este README é uma introdução básica ao sistema de criação de orçamentos para vendas de peças automotivas. Sinta-se à vontade para expandi-lo conforme necessário e adicionar mais detalhes sobre a arquitetura, funcionalidades e instruções de uso.
