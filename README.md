# MealControl API com Clean Architecture [![My Skills](https://skillicons.dev/icons?i=cs,dotnet)](https://skillicons.dev)
<p>Back-End da segunda versão do <b>Meal Control</b>, aplicação para gerenciamento e controle de refeições de equipes em obra, seguindo o padrão de arquitetura Clean Architecture.</p>

# Camadas implementadas:
<h2><b>Camada Core</b></h2>
<ul>
    <li>Definir os modelos de entidades, seus comportamentos e validações ✔️</li>
    <li>Garantir o tratamento de exceções <b>(Em andamento)</b></li> 
    <li>Definir quais métodos devem ser implementados nas interfaces dos repositórios ✔️</li>
</ul>

<h2><b>Camada Application</b></h2>
<ul>
    <li>Definir os DTOs e seus mapeamentos com os modelos de domínimo <b>(Em andamento)</b></li>
    <li>Implementar o CQRS com seus commands, queries e handlers <b>(Em andamento)</b></li>
    <li>Definir e implementar as interfaces dos serviços da aplicação</li>
</ul>

<h2><b>Camada de infraestrutura Database</b></h2>
<ul>
    <li>Definir o contexto da aplicação e fazer o mapeamento ORM ✔️</li>
    <li>Implementar as configurações das entidades com FluentAPI ✔️</li>
    <li>Implemetar as interfaces dos repositórios <b> ✔️</b></li>
</ul>

<h2><b>Camada de infraestrutura IoC</b></h2>
<ul>
    <li>Implementar o contêiner de injeção de dependência <b>(Em andamento)</b></li>
</ul>

<h2><b>Camada WebAPI</b></h2>
<ul>
    <li>Implementar controladores com os endpoints que serão consumidos</li>
</ul>

# Tecnologias utilizadas:
<p>C#</p>
<p>ASP.NET Core</p>
<p>Entity Framework Core</p>
<p>PostgreSQL</p>

# Design Patterns utilizados:
<p>Strategy</p>
<p>Data Tranfer Object</p>