using QuintoProyecto.Models;
using QuintoProyecto.Services;
using Spectre.Console;

class Program {
  public static bool running = true;
  public static string[] choices = [
    "1. Mostrar libros",
    "2. Eliminar un libro",
    "3. Agregar un libro",
    "4. Salir"
  ];
  public static BookService bookService = new();
  public static void Main() {
    // Bucle
    while (running) {

      var selections = new SelectionPrompt<string>()
        .Title("[green]Indica la acción a realizar:[/]")
        .HighlightStyle("DarkGoldenrod")
        .AddChoices(choices);

      var option = AnsiConsole.Prompt(selections);

      List<Book> books = bookService.FindAll();

      // Estructura para evaluar la opción seleccionada
      switch (option) {
        case "1. Mostrar libros":
          AnsiConsole.Clear();

          var table = new Table();
          table.AddColumn("Id");
          table.AddColumn("Título");
          table.AddColumn("Género");
          table.AddColumn("Autor");

          // Inyecto valores a las filas de la tabla
          foreach (Book book in books) {
            table.AddRow(
              book.Id.ToString(),
              book.Title,
              book.Gender,
              book.Author
            );
          }

          // Muestro la tabla
          AnsiConsole.Write(table);

          break;
        case "2. Eliminar un libro":
          AnsiConsole.Clear();
          int id = AnsiConsole.Ask<int>("Indica el id que quieres eliminar: ");

          AnsiConsole.WriteLine("");
          var confirmed = AnsiConsole.Confirm("¿Estás seguro?");

          if (confirmed) {
            bool deleted = bookService.Delete(id);

            if (deleted) {
              AnsiConsole.MarkupLine("\n[DarkOliveGreen1_1]Libro eliminado![/]\n");
              break;
            }

            AnsiConsole.MarkupLine("\n[red]Libro no encontrado![/]\n");
          }
          else {
            AnsiConsole.MarkupLine("\n[yellow]Operación cancelada![/]\n");

          }


          break;
        case "3. Agregar un libro":
          AnsiConsole.Clear();
          string title = AnsiConsole.Ask<string>("[DarkGoldenrod]Indica el título del libro: [/]");
          string gender = AnsiConsole.Ask<string>("[DarkGoldenrod]Indica el género del libro: [/]");
          string author = AnsiConsole.Ask<string>("[DarkGoldenrod]Indica el author del libro: [/]");

          var maxId = books.Max((b) => b.Id);

          Book newBook = new() {
            Id = maxId + 1,
            Title = title,
            Gender = gender,
            Author = author
          };
          bookService.Create(newBook);
          AnsiConsole.MarkupLine("\n[DarkOliveGreen1_1]Libro agregado![/]\n");
          break;
        case "4. Salir":
          AnsiConsole.Clear();
          AnsiConsole.MarkupLine("[DarkOliveGreen1_1]¡Fin del programa![/]");
          running = false;
          break;
      }
    }

  }
}