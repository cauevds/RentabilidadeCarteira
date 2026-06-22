Projeto que calcula a performance da carteira de um determinado período e faz benchmark com indices do mercado.
Indices utilizados: CDI, IBOV e IPCA.
É possível cadastrar novas carteiras e novos períodos e rentabilidades dos indices/benchmarks de referencia.

O projeto foi feito com .Net e possui swagger para facilitar a visualização dos resultados. 

Para os períodos o formato deve ser "yyyy-MM".
Para competencia o formato deve ser "yyyy-MM".

Indices cadastrados:
- ID 1 = CDI:
- ID 2 = IBOC;
- ID 3 = IPCA;

Para extração de relatório o endpoint é: /api/RelatorioCarteira/{idCarteira}/{periodoInicial}/{periodoFinal}

Sugestão de body:
{
  "carteiraId": 1,
  "periodoInicio": "2026-01",
  "periodoFim": "2026-03",
  "benchmarkIds": [
    1,
    2,
    3
  ]
}

Só há uma carteira cadastrada, com ID 1, e os seguintes períodos de rentabilidade: Janeiro a Fevereiro de 2026.
É possível cadastrar novas carteiras e novos períodos e rentabilidades dos indices/benchmarks de referencia pelo endpoint: /api/Carteira e /api/Benchmark.