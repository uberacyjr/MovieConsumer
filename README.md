# Consumidor de Filmes

## Objetivo

Desenvolver uma API que apresente os próximos filmes a serem lançados no cinema.

## Padrões Utilizados
 - TDD: Desenvolvimento Orientado por Testes foi utilizado para melhorar a segurança no desenvolvimento e manutenções futuras
 - DTO: Data Transfer Object foi utilizado para representar as estruturas json recuperadas nas responses da API.
 - VM: View Model foi utilizado para representar as estruturas json recuperadas nas responses da API.
 - Injeção de Depêndencia: Utilizado para evitar o alto acomplamento e facilitar os testes
 - DRY (não repita você mesmo) encapsular lógicas parecidas em métodos únicos para tentar minimizar o máximo de código duplicado

## Bibliotecas Utilizadas
 - http://restsharp.org/
   Segundo o site, uma das bibliotecas mais populares para se trabalhar com REST API.
   Foi escolhida para facilitar a interação com a REST API do movie database. Por ter uma comunidade grande, é uma biblioteca em constante evolução com poucos bugs.
 - https://www.newtonsoft.com/json
   NewtonSoft para serialização e desserialização de objetos

## Outras Informações


## Instruções de uso
Rodar o comando "dotnet run" dentro da pasta ConsumidorDeFilmes\Filmes.Api ou executar utilizando o IISEpres

Chamadas disponíveis da API:
  - https://localhost:5001/api/filme (Recupera filmes a serem lançados com parametros default: language = en-US, pagina=1 e region = "")
  - https://localhost:5001/api/filme?language=en-US (Recupera filmes a serem lançados de acordo com a lingua selecionada exemplo: [en-US, de, pt-BR])
  - https://localhost:5001/api/filme?language=en-US&page=2 (Recupera filmes a serem lançados de acordo com a lingua selecionada exemplo: [en-US, de, pt-BR] e a pagina que deseja visualizar exemplo [2])
