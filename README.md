# Consumidor de Filmes

## Objetivo

Desenvolver uma API que apresente os próximos filmes a serem lançados no cinema.
Site da API
 - https://developers.themoviedb.org/3/getting-started/introduction
APIs consumidas
 - https://developers.themoviedb.org/3/movies/get-upcoming
 - https://developers.themoviedb.org/3/genres/get-movie-list

## Instruções de uso
Rodar o comando "dotnet run" dentro da pasta Filmes.Api ou executar o projeto utilizando o IISExpress no visual studio 2019

APIs disponíveis:
  - https://localhost:5001/api/filme (Recupera filmes a serem lançados com parametros default: language = pt-BR, pagina=1 e region = "")
  - https://localhost:5001/api/filme?language=en-US (Recupera filmes a serem lançados de acordo com a lingua selecionada exemplo: [en-US, de, pt-BR])
  - https://localhost:5001/api/filme?language=en-US&page=2 (Recupera filmes a serem lançados de acordo com a lingua selecionada exemplo: [en-US, de, pt-BR] e a pagina que deseja visualizar exemplo [2])

## Padrões Utilizados
 - TDD: Desenvolvimento Orientado por Testes foi utilizado para melhorar a segurança no desenvolvimento e manutenções futuras.
 - DTO: Data Transfer Object foi utilizado para representar as estruturas json consumidas nas responses da API.
 - VM: View Model foi utilizado para apresentar as informações das DTOs retornadas do projeto Core na camada da Web API.
 - Injeção de Depêndencia: Utilizado para evitar o alto acomplamento e facilitar os testes.
 - DRY (não repita você mesmo) encapsular lógicas parecidas/iguais em métodos únicos para tentar minimizar o máximo de código duplicado.

## Bibliotecas Utilizadas
 - http://restsharp.org/
   Segundo o site, uma das bibliotecas mais populares para se trabalhar com REST API.
   Foi escolhida para facilitar a interação com a REST API do movie database. Por ter uma comunidade grande, é uma biblioteca em constante evolução com poucos bugs.
 - https://www.newtonsoft.com/json
   NewtonSoft para facilitar a serialização e desserialização.

## Outras Informações
- Projeto de teste feito para realizar testes de integração com a API consumida. 
- Rodar todos os testes toda vez que alterar algo ou para garantir que a parte da integração entre a aplicação e a API está funcionando como esperado.


