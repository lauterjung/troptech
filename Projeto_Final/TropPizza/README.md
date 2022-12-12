# Projeto Final - TropPizza
https://lauterjung.github.io/troppizza/troppizza.mp4
(https://lauterjung.github.io/troppizza/troppizza.mp4)
<video src="https://lauterjung.github.io/troppizza/troppizza.mp4" controls="controls" style="max-width: 730px;">
</video>

[![TropPizza](http://img.youtube.com/vi/MmOjE9PJER0/0.jpg)](http://www.youtube.com/watch?v=MmOjE9PJER0 "Trop Pizza")
# Descrição geral do projeto

## Proposta
O projeto final se propõe a criar um sistema de um comércio eletrônico de pizzaria.
Neste sistema, é possível gerenciar clientes, produtos e pedidos.  

## Requisitos
- Um navegador compatível (testado em Firefox v.107.0 64-bits)  
- Um servidor (localhost) para rodar:  
\- a API (necessita do framework .NET 5.0)  
\- a página da web do sistema  

## Funcionalidades / Telas
- Página inicial  

- Gerenciamento de clientes:  
\- Cadastrar novo cliente  
\- Editar cliente cadastrado  

- Gerenciamento de produtos:  
\- Cadastrar novo produto  
\- Editar produto cadastrado  

- Gerenciamento de pedidos:  
\- Realizar novo pedido  
\- Carrinho  
\- Editar pedidos  
\- Atualizar status do pedido  
\- Acompanhar pedido  
----
# Descrição técnica do projeto

## Linguagens e frameworks utilizados
- C# / .NET v. 5.0  
- Microsoft SQL Server  
- TypeScript / JavaScript / CSS / HTML  
- Bootstrap v. 5.0  
- Angular v. 14  

## Especificações técnicas
- O back-end da aplicação foi construído em C# / .NET 5.0  
- O código possui cobertura de testes unitários  
- A persistência dos dados foi feita por meio de banco de dados relacional (SQL)  
- A comunicação entre o back-end e o front-end da aplicação foi feita por meio de uma API REST  
- O front-end utilizou os princípios de Single Page Application (SPA) com auxílio do serviço de router do Angular  

## Entidades
- Cliente  
- Produto  
- Pedido  
  
Para maiores detalhes das entidades, verificar os diagramas de classe:  
- [Diagrama de classes](https://github.com/lauterjung/troptech/blob/main/Projeto_Final/TropPizza/documentation/diagrams/class_diagram.svg)  
- [Diagrama relacional](https://github.com/lauterjung/troptech/blob/main/Projeto_Final/TropPizza/documentation/diagrams/sql_diagram.svg)  

## Regras de negócio
- Cliente:  
\- Todos os campos são obrigatórios  
\- O nome deve ter no mínimo 3 caracteres  
\- O CPF deve ter 11 dígitos numéricos  
\- A data de nascimento não pode ser superior a data de hoje  
\- Não pode existir mais de um cliente com o mesmo CPF  
\- Os pontos de fidelidade iniciam em zero e são adicionados no final do pedido, de acordo com a seguinte equação:  
Pontos de fidelidade = 2 x Valor total do pedido  
\- Ao excluir um cliente, os pedidos em aberto vinculados a ele também deverão ser excluídos  

- Produto:  
\- O nome não pode ser nulo  
\- A descrição deve ter no mínimo 3 caracteres  
\- O preço unitário deve ser maior que 0  
\- A data de validade deve ser superior a data atual  
\- A quantidade do produto em estoque deve ser maior ou igual a zero  
\- Deve inicializar como ativo  
\- Só deve ser disponível para compra se for ativo e se a quantidade for maior que 0  

- Pedido:  
\- Pode ou não ter um cliente (CPF) associado  
\- Deve conter no mínimo um produto  
\- Os produtos do pedido devem ter quantidade superior a zero  
\- Os produtos do pedido devem ter a quantidade em estoque  
\- A data e hora associada é registrada no momento em que o pedido é realizado  
\- O pedido inicia com o status "pendente"  
\- Um pedido finalizado não pode ser editado ou excluído  