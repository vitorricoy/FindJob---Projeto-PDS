# FindJob
##### Projeto de Prática e Desenvolvimento de Software

## Grupo:
* André Luiz Moreira Dutra - 2019006345 - Backend
* Vitor Assunção Rabello de Oliveira - 2019007104 - Frontend
* Vitor Rodarte Ricoy - 2019007112 - Full-stack

## Escopo

### Objetivo:
Sistema para clientes encontrarem profissionais freelancers para seus projetos. O objetivo do sistema é fornecer uma plataforma em que clientes postam propostas de projetos, que são atendidas por freelancers. Os freelancers se cadastram, indicando suas habilidades, e ganham recomendações dos clientes à medida que realizam projetos.

### Features Básicas:
* Cadastro de clientes e freelancers
* Sistema de criação de projetos por clientes, indicando as habilidades necessárias para ele
* Sistema de classificação dos freelancers que se interessaram em um projeto
* Sistema de comunicação entre o freelancer contratado e o cliente
* Sistema de avaliação do freelancer no fim de um projeto

### Tecnologias:
* MySQL
* C#
* Typescript (React)

### MVP

O MVP será do tipo “Mágico de Oz”, ou seja, existirá uma interface web simples, mas todo o backend será feito de forma manual. O objetivo principal deste MVP é simular como será a interação entre os clientes e os freelancers, analisando a viabilidade do produto, verificando se essa aplicação e as funcionalidades são do interesse de ambas as partes. O foco do MVP é simular a experiência do usuário, de tal modo que ela seja o mais parecida possível, dentro dos limites do MVP, com o que seria a experiência final.

![Screenshot_1](https://user-images.githubusercontent.com/32375749/164996877-d7291d1f-0c62-48e7-b964-4491d18b70a6.png)

A infraestrutura do MVP consistirá nos seguintes elementos: existirá uma planilha excel contendo dos jobs disponíveis, além de informações dos freelancers que se candidatarem a esse job, bem como avaliações dos freelancers feitas pelos clientes. Será criada também uma simples interface web, para que os clientes possam criar os seus jobs. Toda a parte do back-end será feita de forma manual.

O fluxo do MVP será o seguinte: primeiro, um cliente que necessitar de algum serviço específico deverá acessar a página web e fazer uma espécie de cadastro, passando algumas informações pessoais e em seguida descrevendo o job que deseja criar. Ao receber o cadastro, adicionaremos as informações do job à planilha. Num segundo momento, um ou mais freelancers com interesse em oferecer algum tipo de serviço deverão consultar a planilha e escolher algum dos jobs disponíveis. Após isso, nós o incluímos na planilha, indicando que ele tem interesse em realizar aquele job. Após um tempo o cliente poderá ver na planilha quais freelancers estão interessados no job dele e escolher algum deles. Assim o freelancer escolhido ficará responsável por aquele job. Se o freelancer aceitar fazer o serviço e o cliente concordar com o orçamento, o freelancer pode iniciar o trabalho. Com o serviço concluído, o cliente deverá realizar o pagamento. Receberemos o pagamento e repassaremos o valor para o freelancer, desse valor será descontada uma taxa de serviço (que não será descontada para os primeiros usuários). Finalmente, se o cliente desejar, poderá deixar um comentário, que será inserido na planilha.

### Backlog do Produto

* Como usuário, quero me cadastrar no sistema.
* Como usuário, quero logar e deslogar do sistema.
* Como usuário, quero ter acesso a um chat de texto entre cliente e freelancer.
* Como cliente, quero poder avaliar o serviço de um freelancer após contratá-lo.
* Como usuário, quero ter acesso a uma página inicial que facilite a navegação pela aplicação.
* Como cliente, quero poder encontrar o freelancer ideal para resolver o meu problema.
* Como freelancer, quero poder buscar por todos os jobs disponíveis oferecidos pelos clientes.
* Como freelancer, quero poder analisar um job específico e oferecer meus serviços.
* Como cliente, quero ter liberdade para descrever meu problema e quais habilidades serão necessárias para resolvê-lo.
* Como usuário, quero ter acesso a um fórum de discussões e dúvidas dentro da plataforma.
* Como cliente, quero poder obter um reembolso do meu dinheiro caso o serviço prestado não esteja de acordo com o combinado.
* Como freelancer, quero poder receber pagamentos através da plataforma.
* Como cliente, quero fazer pagamentos online de forma segura através da plataforma.
* Como cliente, quero poder ler as avaliações dadas por outros clientes a um freelancer.

### Backlog da Sprint

* Tarefas Técnicas.
  * Tarefa 1: Preparar o ambiente para desenvolvimento em C# (.NET Core) [André e Vitor R.]
  * Tarefa 2: Preparar o ambiente para desenvolvimento com MySQL (.NET Core) [André e Vitor R.]
  * Tarefa 3: Preparar o ambiente para desenvolvimento em React com Typescript [Vitor A. e Vitor R.]
  * Tarefa 4: Discutir e criar o esquema de dados [André]
  * Tarefa 5: Criar o projeto e estrutura inicial do frontend [Vitor A.]
  * Tarefa 6: Criar o projeto e estrutura inicial do backend [Vitor R.]


* História: Como usuário, quero me cadastrar no sistema.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de cadastrar um cliente.
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de cadastrar um freelancer.
* História: Como usuário, quero logar e deslogar do sistema.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de logar no sistema.
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de deslogar do sistema.
* História: Como usuário, quero ter acesso a um chat de texto entre cliente e freelancer.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de carregar o histórico de mensagens.
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de enviar mensagens.
* História:  Como cliente, quero poder encontrar o freelancer ideal para resolver o meu problema.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de carregar freelancers que se cadastraram para um determinado job.
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de ordenar os freelancers pelo nível de habilidade.
* História: Como cliente, quero ter liberdade para descrever meu problema e quais habilidades serão necessárias para resolvê-lo.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de cadastrar um novo job.
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de cadastrar uma nova habilidade.
  * Tarefa 5: Implementar a camada de lógica de negócio e a camada de controle para a operação de selecionar habilidades dentre uma lista de habilidades.
* História: Como cliente, quero poder avaliar o serviço de um freelancer após contratá-lo.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de escrever uma avaliação para um freelancer.
* História: Como usuário, quero ter acesso a uma página inicial que facilite a navegação pela aplicação.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
* História: Como freelancer, quero poder buscar por todos os jobs disponíveis oferecidos pelos clientes.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de exibir todos os jobs criados por clientes.
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de filtrar os jobs exibidos de acordo com as habilidades do freelancer.
* História: Como freelancer, quero poder buscar por todos os jobs disponíveis oferecidos pelos clientes.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de exibir todos os jobs criados por clientes.
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de filtrar os jobs exibidos de acordo com as habilidades do freelancer.
* História: Como freelancer, quero poder analisar um job específico e oferecer meus serviços.
  * Tarefa 1: Implementar a página web
  * Tarefa 2: Implementar a camada de acesso aos dados
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de exibir detalhes do job selecionado.
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de candidatar-se a um job específico.

### Protótipos das Telas

https://www.figma.com/file/MHr9zWxxdfCjEYeTqEYSRX/FindJob
