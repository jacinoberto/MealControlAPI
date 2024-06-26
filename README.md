# MealControl API com Clean Architecture [![My Skills](https://skillicons.dev/icons?i=cs)](https://skillicons.dev)
<p>Back-End da segunda versão <b>Meal Control</b>, aplicação para gerenciamento e controle de refeições de equipes em obra, seguindo o padrão de arquitetura Clean Architecture.</p>

# Camadas implementadas:
<p>Camada <b>Core</b> (Definir os modelos de entidades, seus comportamentos e validações, garantir o tratamento de exceções e definir quais métodos devem ser implementadas nas interfaces de repositórios)</p>

<p>Camada <b>Application</b> (Definir os DTOs e seus mapeamentos com os modelos de domínimo, definir as interfaces dos serviços, implemntar as classes dos serviços da aplicação e implementar o CQRS com seus commands, queries e handlers)</p>

<p>Camada de infraestrutura <b>Database</b> (Definir o contexto da aplicação, fazer o mapeamento ORM, definir as configurações das entidades com FluentAPI e implemetar as interfaces dos repositórios)</p>

<p>Camada de infraestrutura <b>IoC</b> (Implementar o contêiner de injeção de dependência)</p>

<p>Camada <b>WebAPI</b> (Implementar controladores com os endpoints que serão consumidos)</p>

# Tecnologias utilizadas:
<p>C#</p>
<p>ASP.NET Core</p>
<p>Entity Framework Core</p>
<p>PostgreSQL</p>

# Design Patterns utilizados: