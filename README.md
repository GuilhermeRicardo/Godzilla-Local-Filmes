# Godzilla Local Filmes


### Frond-End: Angular + Angular Material Library:
    
Interface contruida utilizando Angular 15 + Angular Materiais, ações de criação de nova locação de filme e listagem de filmes locados serão validadas via Jwt Token armazeda no LocalStorage e serão carregadas em cada requisição utilizando Angular Interceptor.

Para inilizar a interface em ambiente local deve ser utilizado o comando '*ng* serve' dentro do repositório.
 
### Back-End: API .Net 6.0 + Entity Framework & JWT Bearer Authentication + SQL Server:

###### *Importante: Para utilização do Backend para validação de endpoint será necessário o serviço SQL Server 2019 para criação de um banco de dados local utilizando o comando dotnet ef database update.*
 
  
Para inicializar a API em ambiente local deve-se utilizar o comando '*dotnet* run' dentro do repositório '*BlockbusterApi/*'

A API estará disponivel a partir do endpoint *'https://localhost:7288;'*, para testes utilizando o SwaggerAPI, utilizar o link: 'https://localhost:7288/swagger/index.html'

## Authentication

Os endpoints disponiveis para registro de novo usuario e login de usuario existente, são respectivamente:

#### Registro: *'https://localhost:7288/api/Authentication/register'*
utilizando Body em JSON em formato:

{
  "name": "string",
  "email": "string",
  "password": "string"
} 

É necessário que a senha(*password*) possua caracteres em caixa alta, baixa, números e caracteres especiais. Segue exemplo de usuario:

{
  "name": "usuario",
  "email": "usuario@gmail.com",
  "password": "Passw0rd!"
}

##### Login: *'https://localhost:7288/api/Authentication/login'*

Para o login, deve ser fornecido Body em JSON no seguinte formato:

{
  "email": "string",
  "password": "string"
}

## Movie

Para listagem de filmes, checagem de disponibilidade de filme e busca por titulo de filme utilizando palavra-chave, são disponibilizados respectivamente os endpoint:

##### Listagem: *'https://localhost:7288/api/Movie/list'*

Não é necessário fornecer parâmetros.

##### Disponibilidade: *'https://localhost:7288/api/Movie/availability/{id}'*

Deverá ser informado o Id do filme que deseja ser verificada a disponibilidade para locação.

##### Busca por titulo: *'https://localhost:7288/api/Movie/search/{keyword}'*
Para busca deve ser fornecido uma *string* de palavra-chave(*keyword*) que contenha um trecho do titulo que deseja ser localizado, por exemplo:

*'https://localhost:7288/api/Movie/search/2000'*

Retornará o filme: 
{
    "id": 1,
    "titulo": "Godzilla 2000",
    "diretor": "Takao Okawara",
    "estoque": 1
}

## Rental

Todas as operações realizadas dentro do endpoint 'https://localhost:7288/api/Rental/' deverão ser autenticadas via JWT Bearer Token fornecido durante registro/login de usuario.

Para listagem de filmes locados, criação de um novo registro de locação e exclusão de registro de locação, serão utlizados os seguintes endpoints:

##### Listagem de Locação: *'https://localhost:7288/api/Rental/list'*

Será apresentada a relação entre usuarios e filmes locados, relacionados pelos atributos:

"movieId": *int* e "userId": *string*

##### Registro de nova Locação: *'https://localhost:7288/api/Rental/rent'*

Para criação de novo registro de locação é necessário informar Body em JSON no seguite formato:

{
  "movieId": int,
  "userId": "string"
}

O userId é fornecido ao usuario por meio do Payload:data do Token como atributo "Id" ou ao realizar o login como atributo "userId".

##### Exclusão de registro de Locação: *'https://localhost:7288/api/Rental/delete/{id}'*

Para exclusão de registro de locação é necessário informar o valor *Id* do respecitvo registro a ser excluido. O valor pode ser obtido na listagem de locação.
