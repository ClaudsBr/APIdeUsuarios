<h1  align="center">Desafio API Starters #3</h1>

  

  

<h2><b>Desafio:</b></h2>

  

Desenvolver uma API REST, contendo os métodos HTTP básicos (GET, POST, PUT, DELETE) para um sistema do Programa Starter.

  

  

As principais entidades(models) do sistema são:

  

<b>• Categoria (CRUD)</b>

  

o Tecnologia (tipo : Java, C#, Php...)

  

o Nome (tipo : Turma 1 – 2022, Turma 2 - 2022...)

  

  

<font  color=blue>Rota para acessar Categorias na API:</font>

  

https://localhost:5001/Categorias

https://localhost:5001/Categorias/{id}

  

<b>• Starter (CRUD)</b>

  

o Nome

  

o CPF

  

o 4 Letras

  

o E-mail

  

  

<font  color=blue>Rotas para acessar Starters da API:</font>

  

https://localhost:5001/api/v1/Starters

https://localhost:5001/api/v1/Starters/{id}

  

  

<b>O sistema deverá possuir 2 perfis de acesso:</b>

  

• Admin

• Usuário

  

  

<b>Descrição do Sistema:</b>

  

  

▪ Popular banco

  

▪ Admin:

  

- Acesso 100% do sistema

  

- Usuário: Admin

  

- Senha: Gft@1234

  

  

▪ Usuário:

  

- Somente acesso as listas, sem mudanças no sistema após se registrar

  

<font  color=blue>Para registrar usuarios deve-se entrar com login e senha atraves da rota:

  

https://localhost:5001/api/v1/usuarios/registro

  

<font  color=blue>Para logar usuarios deve-se fornecer um login e senha cadastrados através da rota:

  

https://localhost:5001/api/v1/usuarios/login

  

<font  color=blue>Apos logar um token será fornecido

  

  

<font  color=blue>O perfil do tipo <b>Admin</b> tem total acesso aos Controllers de Categorias e Starters, o perfil do tipo Usuário é fornecido por Default assim que um usuário é registrado e da acesso somente ao métodos Get dos Controllers de Categoria e Starter.

  
  

<h2><b>Exceeds:</b></h2>

<b>• Validação de CPF</b>

<font  color=blue> a Validação de CPF é feita atraves do <b>método ValidaCPF da classe Validando CPF.</b>

  

<b>• Quando um Usuário acessar o sistema, ele recebe um e-mail dizendo que ele acessou a API.</b>

<font  color=blue> A classe <b>EmailSender<b> faz um envio automatico de email apos o login na API atraves do método <b>Send</b>

  

<h3><b>• Criar os seguintes endpoints com Swagger:</b></h3>

<b>Listar os starters em ordem alfabética crescente por nome</b>

<font  color=blue> Rota para acessar a lista de Starters em ordem alfabetica:

https://localhost:5001/api/v1/Starters/asc

  

<b>Listar os sarters em ordem alfabética decrescente por nome</b>

<font  color=blue> Rota para acessar a lista de Starters em ordem descrescente por nome:

https://localhost:5001/api/v1/Starters/desc

  

<b>Buscar starter por nome</b>

<font  color=blue> Rota para buscar o Starter pelo nome <b>(Acesso somente pelo perfil de Admin)</b>:

https://localhost:5001/api/v1/Starters/nome/{nome}