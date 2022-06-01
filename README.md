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
* SQLite
* C# (.NET Core)
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
  * Tarefa 2: Preparar o ambiente para desenvolvimento com MySQL [André e Vitor R.]
  * Tarefa 3: Preparar o ambiente para desenvolvimento em React com Typescript [Vitor A. e Vitor R.]
  * Tarefa 4: Discutir e criar o esquema de dados [André]
  * Tarefa 5: Criar o projeto e estrutura inicial do frontend [Vitor A.]
  * Tarefa 6: Criar o projeto e estrutura inicial do backend [Vitor R.]
* História: Como usuário, quero me cadastrar no sistema.
  * Tarefa 1: Implementar a página web. [Vitor A.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [André]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de cadastrar um cliente. [André]
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de cadastrar um freelancer. [André]
* História: Como usuário, quero logar e deslogar do sistema.
  * Tarefa 1: Implementar a página web. [Vitor A.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [Vitor R.]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de logar no sistema. [Vitor R.]
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de deslogar do sistema. [Vitor R.]
* História: Como usuário, quero ter acesso a um chat de texto entre cliente e freelancer.
  * Tarefa 1: Implementar a página web. [Vitor R.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [Vitor R.]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de carregar o histórico de mensagens. [Vitor R.]
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de enviar mensagens. [Vitor R.]
* História:  Como cliente, quero poder encontrar o freelancer ideal para resolver o meu problema.
  * Tarefa 1: Implementar a página web. [Vitor A.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [André]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de carregar freelancers que se cadastraram para um determinado job. [André]
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de ordenar os freelancers pelo nível de habilidade. [André]
* História: Como cliente, quero ter liberdade para descrever meu problema e quais habilidades serão necessárias para resolvê-lo.
  * Tarefa 1: Implementar a página web. [Vitor A.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [André]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de cadastrar um novo job. [André]
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de cadastrar uma nova habilidade. [André]
  * Tarefa 5: Implementar a camada de lógica de negócio e a camada de controle para a operação de selecionar habilidades dentre uma lista de habilidades. [André]
* História: Como cliente, quero poder avaliar o serviço de um freelancer após contratá-lo.
  * Tarefa 1: Implementar a página web. [Vitor R.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [Vitor R.]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de escrever uma avaliação para um freelancer. [Vitor R.]
* História: Como usuário, quero ter acesso a uma página inicial que facilite a navegação pela aplicação.
  * Tarefa 1: Implementar a página web. [Vitor A.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [André]
* História: Como freelancer, quero poder buscar por todos os jobs atribuidos a mim.
  * Tarefa 1: Implementar a página web. [Vitor A.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [Vitor R.]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de exibir todos os jobs atribuídos ao freelancer. [Vitor R.]
* História: Como cliente, quero poder buscar por todos os jobs ofertados por mim.
  * Tarefa 1: Implementar a página web. [Vitor A.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [Vitor R.]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de exibir todos os jobs criados por um cliente. [Vitor R.]
* História: Como freelancer, quero poder buscar por todos os jobs disponíveis oferecidos pelos clientes.
  * Tarefa 1: Implementar a página web. [Vitor A.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [Vitor R.]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de exibir todos os jobs criados por clientes. [Vitor R.]
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de filtrar os jobs exibidos de acordo com as habilidades do freelancer. [Vitor R.]
* História: Como freelancer, quero poder analisar um job específico e oferecer meus serviços.
  * Tarefa 1: Implementar a página web. [Vitor R.]
  * Tarefa 2: Implementar a camada de acesso aos dados. [Vitor R.]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de exibir detalhes do job selecionado. [Vitor R.]
  * Tarefa 4: Implementar a camada de lógica de negócio e a camada de controle para a operação de candidatar-se a um job específico. [Vitor R.]

* História: Como usuário, quero poder adicionar novas habilidades no sistema.
  * Tarefa 2: Implementar a camada de acesso aos dados. [Vitor R.]
  * Tarefa 3: Implementar a camada de lógica de negócio e a camada de controle para a operação de adicionar novas habilidades. [Vitor R.]

### Protótipos das Telas

https://www.figma.com/file/MHr9zWxxdfCjEYeTqEYSRX/FindJob

### Documentação da Arquitetura

A escolha da arquitetura do sistema é essencial em seu design, e traz diversos impactos positivos ao seu desenvolvimento. Nesse contexto, optamos por uma arquitetura baseada em Domain-Driven Design e Arquitetura Hexagonal como forma de organizar a estrutura do sistema.

#### Arquitetura Hexagonal

O sistema adota a arquitetura hexagonal com o objetivo de separar o código relativo às tecnologias usadas (Web API e SQLite com Entity Framework Core) do código do domínio do sistema. Assim, para isso, foram criados três pacotes principais: Controllers, Domain e Persistence. O pacote de Controllers implementa a Web API, o pacote de Persistence implementa o acesso ao banco de dados SQLite e o pacote Domain implementa as lógicas de negócio.

Os pontos do sistema nos quais as tecnologias mencionadas são acessadas foram encapsulados em adaptadores, classes que servem como mediadoras do sistema ao acesso externo. Nesse caso, os adaptadores estão localizados nos pacotes Controllers, onde a entrada de informações é feita na API, e Persistance, onde é feita a saída de dados para o banco.

Para cada adaptador, o acesso entre ele e o domínio é feito por meio de uma porta. Uma porta define uma interface, acessada ou implementada por cada adaptador, para permitir o acesso entre ele e o domínio. Desse modo, elas servem como forma de inverter as dependências do domínio aos adaptadores, nos quais as tecnologias são acessadas, estabelecendo por completo o seu isolamento. No sistema, as portas de entrada são definidas como interfaces acessadas pelos adaptadores em Controllers, e são implementadas pelas classes de serviço do domínio. Já as portas de saída são definidas como interfaces acessadas pelo domínio, e implementadas pelos repositórios do banco em Persistance. A seguinte imagem ilustra a relação do sistema com suas portas e adaptadores:

[imagem :)]

Note que há uma relação direta entre os adaptadores, as portas e os serviços do domínio. Evidentemente, como os serviços são bem divididos nas partes do sistema de interesse do contexto, o mais coerente seria que as portas e adaptadores também seguissem essa divisão.

Desse modo, o pacote Controllers possui quatro adaptadores, UserController, JobController, SkillController e MessageController, cada um contendo as rotas das APIs relativas às ações de cada serviço associado, e ligado a ele por meio de uma interface que cada serviço implementa. Já o pacote Persistance possui também quatro adaptadores, UserRepository, JobRepository, SkillRepository e MessageRepository, cada um implementando os métodos de acesso ao banco de dados utilizados por cada serviço do domínio, e acessado por ele por meio de uma interface que cada repositório implementa.

Com isso, o domínio fica completamente livre de tecnologias, que é o principal preceito da Arquitetura Hexagonal.

#### Domain-Driven Design

Embora a Arquitetura Hexagonal estabeleça o isolamento do domínio, é necessário definir seus aspectos e estruturas. Para isso, utilizamos o princípio de projeto Domain-Driven Design. Ele se fundamenta na ideia de que o domínio é a parte mais importante do sistema, e aquela à qual maior foco deve ser atribuído, enquanto outras partes, como tecnologias externas, devem apenas atender ao domínio.

##### Linguagem Ubíqua

Em DDD, a definição do domínio começa estabelecendo uma linguagem ubíqua, que se constitui em um conjunto de termos comuns ao sistema e ao contexto no qual ele será usado. No caso do sistema implementado, que é uma plataforma de comunicação entre clientes e freelancers, dentre os termos da linguagem ubíqua temos:

>Job, Freelancer, Client, Candidate, Skill, Message, User, Chat, Rating.

##### Entidades e Objetos de Valor

Tendo estabelecido os termos, é necessário definir os objetos. As entidades em DDD representam objetos de identidade única, que os diferencia de outros objetos no sistema. Cada entidade representa um elemento semanticamente definido na linguagem ubíqua do sistema. No sistema, temos três entidades: User, Job e Message.

A entidade User representa um usuário do sistema. Um usuário do sistema pode ser um cliente ou um freelancer, e ambos são representados no sistema por esta entidade. Um User possui como atributos um nome, email, senha, telefone e uma flag indicando se é um cliente ou um freelancer. Caso ele seja um freelancer, o User possui também um dicionário associando cada uma de suas Skills a uma nota.

A entidade Job representa um job ofertado por um cliente. O job pode ou estar disponível, tendo uma lista de freelancers candidatos, ou indisponível, tendo um freelancer escolhido pelo cliente para realizá-lo. Um job possui como atributos um título, descrição, valor de pagamento, data de entrega, uma flag indicando se o pagamento é por hora, um usuário cliente, um usuário freelancer associado, que pode ou não estar definido, uma lista de usuários candidatos e flags indicando se o job está ativo e disponível.

A entidade Message representa uma mensagem de chat entre dois usuários. Uma mensagem sempre está associada a dois usuários: um remetente e um destinatŕario. Assim, um objeto Message tem como atributos […]

Objetos de valor, como entidades, também representam elementos da linguagem ubíqua. No entanto, objetos de valor não têm identificador, sendo identificados somente pelos seus atributos. No sistema, há apenas um objeto de valor, Skill, que representa uma habilidade do usuário. Ela tem como atributos o nome o nome normalizado, e é identificada pelo nome normalizado.

