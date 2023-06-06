using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioAPI.Migrations
{
    public partial class PopulateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Usuarios(Id, Login, Senha, Email, Role) VALUES(1, 'Admin','Gft@1234', '','Admin')");
            migrationBuilder.Sql("INSERT INTO Usuarios(Id, Login, Senha, Email, Role) VALUES(2, 'coot','Gftbrasil2022', 'clauds.true@gmail.com','Usuario')");

            migrationBuilder.Sql("INSERT INTO Categorias(Id, Tecnologia, Nome) VALUES(1, 'Java','Turma 1 - 2022')");
            migrationBuilder.Sql("INSERT INTO Categorias(Id, Tecnologia, Nome) VALUES(2, 'C#','Turma 1 - 2022')");
            migrationBuilder.Sql("INSERT INTO Categorias(Id, Tecnologia, Nome) VALUES(3, 'Python','Turma 1 - 2022')");
            migrationBuilder.Sql("INSERT INTO Categorias(Id, Tecnologia, Nome) VALUES(4, 'Java','Turma 2 - 2022')");
            migrationBuilder.Sql("INSERT INTO Categorias(Id, Tecnologia, Nome) VALUES(5, 'C#','Turma 2 - 2022')");

            migrationBuilder.Sql("INSERT INTO Starters(Id, Nome, CPF, Login, Email, CategoriaId) VALUES(1, 'Claudio Oliveira','358.174.140-74', 'coot', 'claudio@gft.com', 2)");
            migrationBuilder.Sql("INSERT INTO Starters(Id, Nome, CPF, Login, Email, CategoriaId) VALUES(2, 'Cleber Pereira','759.335.590-08', 'clet', 'clebs@gft.com', 1)");
            migrationBuilder.Sql("INSERT INTO Starters(Id, Nome, CPF, Login, Email, CategoriaId) VALUES(3, 'Clovis Silveira','632.309.080-58', 'clot', 'clovis@gft.com', 2)");
            migrationBuilder.Sql("INSERT INTO Starters(Id, Nome, CPF, Login, Email, CategoriaId) VALUES(4, 'Carlos Madureira','295.867.260-37', 'carm', 'carlos@gft.com', 1)");
            migrationBuilder.Sql("INSERT INTO Starters(Id, Nome, CPF, Login, Email, CategoriaId) VALUES(5, 'Celio Gomes','769.974.010-66', 'ceos', 'celio@gft.com', 1)");
            migrationBuilder.Sql("INSERT INTO Starters(Id, Nome, CPF, Login, Email, CategoriaId) VALUES(6, 'Ricardo Silva','009.188.900-63', 'risa', 'rick@gft.com', 3)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Usuarios");
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Starters");
        }
    }
}
