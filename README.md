# Password Checker API
É uma aplicação simples para verificar a força de senhas. Este README fornece instruções básicas sobre como executar o projeto, detalhes sobre a solução implementada e as decisões tomadas durante o desenvolvimento.

## Como Executar o Projeto
Para executar o projeto localmente, siga estas etapas:

- Certifique-se de ter o .NET SDK instalado,  esse projeto usa a versão .NET 8.0 SDK. 
- Clone este repositório para o seu ambiente local.
- Navegue até o diretório do projeto usando o terminal ou prompt de comando.
- Execute o comando dotnet run para compilar e executar o projeto se não der certo, execute pelo própria IDE.
- Acesse a API usando o navegador e vá para https://localhost: port /swagger/index.html, onde "port" é a porta em que o servidor está sendo executado.
- Uma observação importante é que se você não possuir pacote 'Swashbuckle.AspNetCore', que é utilizado para integrar o Swagger à API ASP.NET Core, precisa ser instalado separadamente no projeto. Execute o seguinte comando no terminal:
< Install-Package Swashbuckle.AspNetCore.Annotations> E 
< Install-Package Swashbuckle.AspNetCore>

## Detalhes da Solução
- A Password Checker API foi desenvolvida usando o ASP.NET Core, um framework de desenvolvimento web da Microsoft. Aqui estão alguns detalhes sobre a solução implementada:

- Estrutura de Projeto: A aplicação segue uma estrutura padrão do ASP.NET Core, com os controladores na pasta Controllers e serviços de configuração em Program.cs

- Validação de Senha: A API permite que os usuários enviem uma senha para validação. A senha é verificada em relação a várias regras, como comprimento mínimo, presença de dígitos, letras maiúsculas, minúsculas, caracteres especiais, etc.

- Documentação da API: A API é documentada usando o Swagger. A documentação inclui detalhes sobre os endpoints disponíveis, seus parâmetros, códigos de status e exemplos de uso.

- Testes Unitários: Foram escritos testes unitários para as regras de validação de senha, garantindo que elas funcionem conforme o esperado.

- Abstração e Acoplamento: As regras de validação de senha foram implementadas utilizando a interface IValidationRule, permitindo fácil extensão e substituição de regras.

- Extensibilidade e Coesão: Cada regra de validação de senha é uma classe separada que implementa a interface IValidationRule, tornando o código modular e fácil de entender. Novas regras podem ser adicionadas sem afetar o código existente.

- Clean Code: O código foi escrito de forma limpa, utilizando nomes descritivos de variáveis e funções, evitando duplicação de código e mantendo a coesão das classes e métodos.

- SOLID: Os princípios SOLID foram seguidos para garantir um design robusto e flexível. As classes foram projetadas para ter responsabilidades únicas e bem definidas, facilitando a manutenção e a evolução do código.

- Design de API: A API foi projetada para ser intuitiva e fácil de usar. O endpoint ValidatePassword aceita uma senha como entrada e retorna um resultado de validação, seguindo padrões RESTful e utilizando os códigos de status HTTP apropriados.

## Decisões de Design
Algumas decisões foram tomadas durante o desenvolvimento da aplicação:

- Injeção de Dependência: Foi utilizada a injeção de dependência do ASP.NET Core para gerenciar as dependências entre os componentes da aplicação, facilitando a manutenção e teste do código.

- Documentação com Swagger: O Swagger foi escolhido para documentar a API devido à sua facilidade de uso e integração com o ASP.NET Core. Isso permite que os desenvolvedores entendam rapidamente como interagir com os endpoints da API.

- Validação de Senha em Várias Etapas: A validação da senha é feita em várias etapas, cada uma verificando um aspecto diferente da senha. Isso permite uma abordagem modular e extensível para adicionar ou modificar as regras de validação no futuro.

## Assunções e Premissas
Durante o desenvolvimento, algumas premissas foram feitas:

- Simplicidade da Aplicação: A aplicação foi mantida simples e focada apenas na validação da força da senha. Recursos adicionais, como autenticação de usuários ou persistência de dados, não foram implementados para manter a simplicidade e o foco.

- Segurança da Senha: A validação da senha é realizada no lado do servidor para garantir a segurança das informações do usuário. Não foram feitas premissas sobre a segurança do armazenamento ou transmissão de senhas.

- Testes Unitários: Foi assumido que os testes unitários são suficientes para garantir a qualidade e a robustez do código. Testes de integração ou testes de carga não foram implementados devido à natureza simples da aplicação.

Espero que estas informações forneçam uma compreensão clara do projeto e das decisões tomadas durante o desenvolvimento. Se houver alguma dúvida ou sugestão, não hesite em entrar em contato:

- Nome: Eraldo A S Jr
- E-mail: eraldojunior096@gmail.com
- GitHub: github.com/eraldoASJr
