🎬 Filmes API

API REST desenvolvida em ASP.NET Core para gerenciamento de filmes.
Permite operações de CRUD, atualização parcial com JsonPatch, suporte a paginações e mapeamento com DTOs + AutoMapper.

📌 Índice

Sobre

Tecnologias

Modelo de Dados

Banco de Dados (SQL Server)

Configuração

Execução

Rotas da API

Exemplos de Requisição

Licença

📖 Sobre

A Filmes API permite o cadastro, consulta, atualização e remoção de filmes em um banco SQL Server.
Ela foi construída utilizando boas práticas como:

DTOs para controlar entrada/saída de dados

AutoMapper para conversão entre entidades e DTOs

Validações via Data Annotations

Swagger para documentação interativa

🛠 Tecnologias

.NET 6+

Entity Framework Core

SQL Server

AutoMapper

Swagger (Swashbuckle)

JsonPatch

🗂 Modelo de Dados
🎥 Filme
public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O titulo do filme é obrigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatorio")]
    [MaxLength(50, ErrorMessage = "O tamanho do genêro não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatoria")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}

📌 DTOs

CreateFilmeDto → usado no POST

ReadFilmeDto → usado nas respostas da API

UpdateFilmeDto → usado em PUT e PATCH

🗄️ Banco de Dados (SQL Server)

A API utiliza Entity Framework Core com SQL Server.

🔌 Configuração da conexão

No arquivo Program.cs, a conexão é registrada:

builder.Services.AddDbContext<FilmeContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("FilmeConnection")));


No appsettings.json, configure sua connection string:

"ConnectionStrings": {
  "FilmeConnection": "Server=SEU_SERVIDOR;Database=FilmesDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

🏗️ Estrutura criada no banco

Quando a migration inicial é aplicada, a tabela filmes é criada com a seguinte estrutura:

Campo	Tipo	Restrições
Id	int	PK, Identity (1,1), Not Null
Titulo	nvarchar(max)	Not Null
Genero	nvarchar(50)	Not Null, Máx 50 caracteres
Duracao	int	Not Null, Entre 70 e 600
▶️ Criar o banco e aplicar migrations
dotnet ef migrations add InitialCreate
dotnet ef database update


Isso criará automaticamente o banco de dados FilmesDb (ou o nome definido na sua connection string) e a tabela filmes.

⚙️ Configuração

Clone o repositório:

git clone https://github.com/seu-usuario/nome-do-repo.git
cd nome-do-repo


Configure a connection string no arquivo appsettings.json.

Restaure dependências:

dotnet restore


Crie o banco de dados e rode as migrations:

dotnet ef database update

▶️ Execução

Para rodar a API:

dotnet run


Acesse no navegador:
👉 https://localhost:5001/swagger

📡 Rotas da API
🎥 Filmes
Método	Endpoint	Descrição
POST	/Filme	Adiciona um novo filme
GET	/Filme	Lista todos os filmes (com paginação skip e take)
GET	/Filme/{id}	Retorna filme por ID
PUT	/Filme/{id}	Atualiza filme existente (todos os campos)
PATCH	/Filme/{id}	Atualiza parcialmente um filme com JsonPatch
DELETE	/Filme/{id}	Remove filme existente
📌 Exemplos de Requisição
➕ Criar Filme (POST /Filme)
{
  "titulo": "O Poderoso Chefão",
  "genero": "Drama",
  "duracao": 175
}

📖 Recuperar Filmes (GET /Filme?skip=0&take=2)
[
  {
    "id": 1,
    "titulo": "O Poderoso Chefão",
    "genero": "Drama",
    "duracao": 175,
    "dataConsulta": "2025-08-22T14:30:00Z"
  },
  {
    "id": 2,
    "titulo": "Interestelar",
    "genero": "Ficção Científica",
    "duracao": 169,
    "dataConsulta": "2025-08-22T14:32:00Z"
  }
]

✏️ Atualização Parcial (PATCH /Filme/1)
[
  { "op": "replace", "path": "/titulo", "value": "O Poderoso Chefão - Parte I" }
]

❌ Remover Filme (DELETE /Filme/1)

Retorno: 204 No Content
