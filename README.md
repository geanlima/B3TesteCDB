# CDBCalculator

## Requisitos

- Visual Studio 2022 ou superior
- .NET 6 SDK
- Node.js e Angular CLI

## Execução

### API

1. Abra a solução no Visual Studio.
2. Compile a solução.
3. Execute o projeto CDBCalculator.Api.

### Aplicação Angular

1. Navegue até a pasta CDBCalculatorApp.
2. Execute `npm install` para instalar as dependências.
3. Execute `ng serve` para iniciar a aplicação Angular.

## Testes

### API

1. Abra a janela Test Explorer no Visual Studio.
2. Execute todos os testes.

## Estrutura da Solução

- `CDBCalculator.Api`: Projeto da API .NET 6
- `CDBCalculatorApp`: Aplicação Angular CLI

## Arquitetura da Solução

### Descrição

A solução CDBCalculator é dividida em três principais projetos:

1. **CDBCalculator.Api**: Este projeto contém a API construída em .NET 6. Ele é responsável por expor endpoints para o cálculo de CDB. A lógica de negócio é encapsulada em serviços, enquanto as validações são realizadas por validadores específicos. Os controladores da API lidam com as requisições HTTP e utilizam os serviços e validadores para processar e retornar as respostas adequadas.

2. **CDBCalculator.Domain**: Este projeto contém a lógica de negócio e as regras de validação. Ele é composto por entidades, interfaces, serviços e validadores. A separação do domínio permite que a lógica de negócio seja reutilizável e testável independentemente do projeto da API.

3. **CDBCalculator.Test**: Este projeto contém os testes unitários para os serviços e validadores. Usamos o framework de teste `xUnit` para garantir que nossa lógica de negócio e validação estejam corretas e funcionando conforme o esperado.

### Motivos das Escolhas Arquiteturais

- **Separação de Responsabilidades**: Separar a API, a lógica de negócio (domínio) e os testes em projetos distintos promove a separação de responsabilidades. Isso torna o código mais organizado, modular e fácil de manter. As alterações na lógica de negócio não afetam diretamente a API e vice-versa.
- **Reutilização e Testabilidade**: Ao isolar a lógica de negócio no projeto `CDBCalculator.Domain`, conseguimos reutilizar essa lógica em diferentes contextos e garantir que ela seja facilmente testável. Isso melhora a manutenibilidade e a qualidade do código.
- **Testes Unitários**: A inclusão de testes unitários no projeto `CDBCalculator.Test` permite validar a funcionalidade da aplicação de forma automatizada, garantindo que alterações futuras no código não introduzam novos erros.
- **Frameworks Modernos**: Utilizar .NET 6 para a API e Angular CLI para a aplicação web garante que estamos utilizando tecnologias modernas, com bom suporte da comunidade e atualizações regulares. Isso ajuda a manter a aplicação segura e eficiente.

Essa arquitetura modular permite escalabilidade e facilidade de manutenção, garantindo que a aplicação possa evoluir e crescer conforme necessário.
