# Star Wars Lets Code


## Descrição do problema

O império continua sua luta incessante de dominar a galáxia, tentando ao máximo expandir seu território e eliminar os rebeldes.

Você, como um soldado da resistência, foi designado para desenvolver um sistema para compartilhar recursos entre o rebeldes.

## Requisitos

Você irá desenvolver uma **API REST** (sim, nós levamos a arquitetura da aplicação a sério mesmo no meio de uma guerra), ao qual irá armazenar informação sobre os rebeldes, bem como os recursos que eles possuem.

* **Adicionar rebeldes**

  Um rebelde deve ter um *nome*, *idade*, *gênero*, *localização*(latitude, longitude e nome, na galáxia, da base ao qual faz parte).

  Um rebelde também possui um inventário que deverá ser passado na requisição com os recursos em sua posse.

* **Atualizar localização do rebelde**

  Um rebelde deve possuir a capacidade de reportar sua última localização, armazenando a nova latitude/longitude/nome (não é necessário rastrear as localizações, apenas sobrescrever a última é o suficiente).

* **Reportar o rebelde como um traidor**

  Eventualmente algum rebelde irá trair a resistência e se aliar ao império. Quando isso acontecer, nós precisamos informar que o rebelde é um traidor.

  Um traidor não pode negociar os recursos com os demais rebeldes, não pode manipular seu inventário, nem ser exibido em relatórios.

  **Um rebelde é marcado como traidor quando, ao menos, três outros rebeldes reportarem a traição.**

  Uma vez marcado como traidor, os itens do inventário se tornam inacessíveis (eles não podem ser negociados com os demais).

* **Rebeldes não podem Adicionar/Remover itens do seu inventário**

  Seus pertences devem ser declarados quando eles são registrados no sistema. Após isso eles só poderão mudar seu inventário através de negociação com os outros rebeldes.

* **Negociar itens**

  Os rebeldes poderão negociar itens entre eles.

  Para isso, eles devem respeitar a tabela de preços abaixo, onde o valor do item é descrito em termo de pontos.

  Ambos os lados deverão oferecer a mesma quantidade de pontos. Por exemplo, 1 arma e 1 água (1 x 4 + 1 x 2) valem 6 comidas (6 x 1) ou 2 munições (2 x 3).

  A negociação em si não será armazenada, mas os itens deverão ser transferidos de um rebelde a outro.

  | Item      | Pontos   |
  |-----------|----------|
  | 1 Arma    | 4 pontos |
  | 1 Munição | 3 pontos |
  | 1 Água    | 2 pontos |
  | 1 Comida  | 1 ponto  |

* **Relatórios**

  A API deve oferecer os seguintes relatórios:

  1. Porcentagem de traidores.
  2. Porcentagem de rebeldes.
  3. Quantidade média de cada tipo de recurso por rebelde (Ex: 2 armas por rebelde).
  4. Pontos perdidos devido a traidores.


# Tasks 

- [x] Adicionar rebeldes
- [x] Atualizar localização do rebelde
- [x] Reportar o rebelde como um traidor
- [x] Negociar itens
- [ ] Relatórios Porcentagem de traidores
- [ ] Relatórios Porcentagem de rebeldes
- [ ] Relatórios Quantidade média de cada tipo de recurso por rebelde
- [ ] Relatórios Pontos perdidos devido a traidores

- [x] Adicionar Testes (Unitários e/ou integração)

- [x] Documentação Swagger
