# Star Wars Lets Code
Compreendendo como foi feita:

  ### ConfigStartup
  - Isolando todas as configurações do Startup separando as responsabilidades das injeções de dependência que estão sendo utilizadas:
    - AutoMapper
    - Swagger
    - IdentityConfig (autenticação em andamento)
  ### Controllers
  - Camada responsável por intermediar o que está sendo enviado através dos DTO's e orquestrando em conjunto com as Models.
  
  ### Data 
  - Configuração dos contextos da aplicação, separados por:
    - ContexIdentity: contexto do Identity
    - ContextApplication: Contexto da Aplicação em si
  ### DTO
  - Aqui estão todos os objetos de transferências de dados, ele é responsável por receber o conteúdo que será orquestrado nas demais camadas.
  ### Extensions 
  - Aqui está sendo armazenado as extensões do projeto.
    - MainController: utilizada para orquestrar os results das requisições de forma padronizada.
  ### Interfaces
  - Configuração das camadas das interfaces que serão utilizadas nas services, com base nessas interfaces as services serão criadas
  ### Models
  - Configuração das Entidades que serão utilizadas
  ### Services
  - Configuração do Core da aplicação, onde fica toda orquestração para realizar as requisições.
  ### Utils
  - Métodos que podem ser reutilizados no decorrer do projeto.
 
 
## Andamento 🧭 
- [x] Está sendo feita a mesma api usando o designer pattern mediator, que pode ser conferida  [aqui](https://github.com/Jaquelaurenti/LetsCodeMediator)
- [ ] Deploy Herok
- [ ] Banco Azure para configuração das migrations e execução do projeto
  
## Configuração 🔨

- [x] Versão 2.2 .net Core
- [x] Swagger
- [x] Configuração Dockerfile para Deploy 
- [ ] Configuração yml para deploy utilizando o Heroku
- [x] Banco InMemory
- [x] Swagger  

## O que foi entregue  ✅

- [x] Adicionar rebeldes
- [x] Atualizar localização do rebelde
- [x] Reportar o rebelde como um traidor
- [x] Negociar itens
- [x] Relatórios Porcentagem de traidores
- [x] Relatórios Porcentagem de rebeldes
- [x] Relatórios Quantidade média de cada tipo de recurso por rebelde
- [x] Relatórios Pontos perdidos devido a traidores
- [x] Testes
- [x] Documentação Swagger
- [x] Autenticação utilizando o Identity
  

