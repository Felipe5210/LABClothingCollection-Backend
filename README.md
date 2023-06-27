<h1>LAB Clothing Collection Backend</h1>

![LabClothingCollectionImage2](https://github.com/Felipe5210/LABClothingCollection-Backend/assets/119754214/d016c026-befb-4fb9-bc3d-9632dd7147ae)


O LAB Clothing Collection é uma API REST desenvolvida utilizando C# .NET e SQL. É uma plataforma que gerencia uma coleção de roupas, permitindo aos usuários visualizar, adicionar, editar e excluir informações sobre as peças de roupa.

A API oferece recursos para gerenciar diferentes aspectos da coleção e modelo de roupas, estação, tipos de peças, layout,  entre outros. Ela permite cadastrar usuários para que realizem consultas para obter informações específicas sobre as roupas, bem como executem ações de criação, atualização e exclusão.

<h2>Recursos</h2>

+ Gerenciamento do cadastro de usuários.

+ Gerenciamento dos dados de Coleção.

+ Gerenciamento de dados de Modelos.

<h2>Tecnologias Utilizadas</h2>
  
  C# .NET e SQL

  <h2>Como executar o projeto</h2>
 
  + Faça Download do projeto.
  
  + Abra o terminal na pasta LabClothingCollection.Api e execute o comando dotnet restore.
    
  + Coloque sua connection string no arquivo appsetting.json localizado na pasta LabClothingCollection.Api.
    
  + Use o comando no terminal dotnet ef database update --startup-project ..\LabClothingCollection\ para fazer a conexão com o banco de dados.
