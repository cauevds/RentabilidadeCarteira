Projeto que calcula a performance da carteira de um determinado período e faz benchmark com índices do mercado.
Índices utilizados: CDI, IBOV e IPCA.
É possível cadastrar novas carteiras, novos períodos e rentabilidades dos índices/benchmarks de referência.

O projeto foi feito com .NET e possui Swagger para facilitar a visualização dos resultados.


Para os períodos o formato deve ser "yyyy-MM".
Para competência o formato deve ser "yyyy-MM".

Índices cadastrados:
ID 1 = CDI;
ID 2 = IBOV;
ID 3 = IPCA;

Para extração de relatório, o endpoint é: /api/RelatorioCarteira/{idCarteira}/{periodoInicial}/{periodoFinal}
Sugestão de body:
json{
  "carteiraId": 1,
  "periodoInicio": "2026-01",
  "periodoFim": "2026-03",
  "benchmarkIds": [
    1,
    2,
    3
  ]
}
Só há uma carteira cadastrada, com ID 1, e os seguintes períodos de rentabilidade: janeiro a fevereiro de 2026.
É possível cadastrar novas carteiras, novos períodos e rentabilidades dos índices/benchmarks de referência pelos endpoints: /api/Carteira e /api/Benchmark.