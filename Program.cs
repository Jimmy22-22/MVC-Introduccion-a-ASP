using Biblioteca.Clases;

namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la biblioteca JimLec");

            MiBiblioteca miBiblioteca = new MiBiblioteca();
            miBiblioteca.CargarLibrosPorDefecto();

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\n¿Qué quieres hacer?");
                Console.WriteLine("1. Agregar un libro");
                Console.WriteLine("2. Listar todos los libros");
                Console.WriteLine("3. Buscar libros por autor");
                Console.WriteLine("4. Eliminar un libro por título");
                Console.WriteLine("5. Salir");
                Console.Write("Ingresa el número de tu opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Título del libro: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor del libro: ");
                        string autor = Console.ReadLine();
                        Console.Write("Año de publicación (opcional): ");
                        string anioTexto = Console.ReadLine();
                        int? anio = string.IsNullOrEmpty(anioTexto) ? (int?)null : int.Parse(anioTexto);
                        Console.Write("ISBN (opcional): ");
                        string isbn = Console.ReadLine();

                        miBiblioteca.AgregarLibro(titulo, autor, anio, isbn);
                        break;

                    case "2":
                        miBiblioteca.ListarLibros();
                        break;

                    case "3":
                        Console.Write("Ingresa el nombre del autor: ");
                        string autorBusqueda = Console.ReadLine();
                        miBiblioteca.BuscarLibro(autorBusqueda);
                        break;

                    case "4":
                        Console.Write("Ingresa el título del libro a eliminar: ");
                        string tituloEliminar = Console.ReadLine();
                        miBiblioteca.EliminarLibro(tituloEliminar);
                        break;

                    case "5":
                        continuar = false;
                        Console.WriteLine("¡Gracias por usar la biblioteca! ¡Hasta la próxima!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, por favor intenta de nuevo.");
                        break;
                }
            }
        }
    }
}
