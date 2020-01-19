# Consumidor de Filmes

## Objetivo

Desenvolver uma API que apresente os próximos filmes a serem lançados no cinema.

## Padrões Utilizados
 - TDD: Desenvolvimento Orientado por Testes foi utilizado para melhorar a segurança no desenvolvimento e manutenções futuras

 - DTO: Data Transfer Object foi utilizado para representar as estruturas json recuperadas nas responses da API.

 - Injeção de Depêndencia: Utilizado para evitar o alto acomplamento e facilitar os testes


## Bibliotecas Utilizadas
 - http://restsharp.org/
   Segundo o site, uma das bibliotecas mais populares para se trabalhar com REST API.
   Foi escolhida para facilitar a interação com a REST API do movie database. Por ter uma comunidade grande, é uma biblioteca em constante evolução com poucos bugs.
 - https://www.newtonsoft.com/json
   NewtonSoft para serialização e desserialização de objetos

## Outras Informações


## Instruções de uso
Rodar o comando "dotnet run" dentro da pasta ConsumidorDeFilmes\Filmes.Api
Chamadas disponíveis da API:
  - https://localhost:5001/api/filme
  - https://localhost:5001/api/filme?language=en-US
  - https://localhost:5001/api/filme?language=en-US&page=2
