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
          Console.WriteLine("Opción 2");
          break;
        case "3. Agregar un libro":
          Console.WriteLine("Opción 3");
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