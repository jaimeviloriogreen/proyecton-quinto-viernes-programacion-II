using QuintoProyecto.Models;

namespace QuintoProyecto.Services;

public class BookService() {

  /// <summary>
  /// Esta es una lista de libros. Simula una base de datos.
  /// </summary>
  private readonly List<Book> _books = [
    new Book{
      Id = 1,
      Title = "La fiesta del chivo",
      Gender = "Novela política",
      Author = "Mario Vargas Llosa"
    },

    new Book{
      Id = 2,
      Title = "El mundo de Sofía",
      Gender = "Novela filosófica",
      Author = "Jostein Gaarder"
    }
  ];

  /// <summary>
  /// Obtiene la lista de libros almacenados.
  /// </summary>
  /// <returns>Una lista de libros.</returns>
  public List<Book> FindAll() {
    return _books;
  }
}