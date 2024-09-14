using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Clases
{
    class MiBiblioteca
    {
        private List<Libro> Libros;
        private bool librosCargados;

        public MiBiblioteca()
        {
            Libros = new List<Libro>();
            librosCargados = false;
        }

        public void AgregarLibro(Libro libro)
        {
            Libros.Add(libro);
        }

        public void AgregarLibro(string titulo, string autor, int? anioPublicacion = null, string? isbn = null)
        {
            Libro nuevoLibro = new Libro(titulo, autor, anioPublicacion, isbn);
            Libros.Add(nuevoLibro);
        }

        public void ListarLibros()
        {
            Console.WriteLine("Libros disponibles en la biblioteca JimLec:");
            foreach (Libro libro in Libros)
            {
                Console.WriteLine(libro.ObtenerInformacion());
            }
        }

        public void EliminarLibro(string titulo)
        {
            var librosAEliminar = Libros.Where(libro => libro.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosAEliminar.Count > 0)
            {
                foreach (var libro in librosAEliminar)
                {
                    Libros.Remove(libro);
                    Console.WriteLine($"Libro '{libro.Titulo}' eliminado de la biblioteca");
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron libros que coincidan con '{titulo}'");
            }
        }

        public void BuscarLibro(string autor)
        {
            var librosEncontrados = Libros.Where(libro => libro.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosEncontrados.Count > 0)
            {
                Console.WriteLine($"Libros encontrados de el autor '{autor}':");
                foreach (var libro in librosEncontrados)
                {
                    Console.WriteLine(libro.ObtenerInformacion());
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron libros del autor '{autor}'");
            }
        }

        public void CargarLibrosPorDefecto()
        {
            if (!librosCargados)
            {
                AgregarLibro("Cien cuentos latinoamericanos", "Gabriel Castillo", 2005, "9780");
                AgregarLibro("Mitos y leyendas de los Andes", "María López", 1998, "6543");
                AgregarLibro("Historia de un continente", "Juan Pérez", 2010, "9712");
                AgregarLibro("Cocina tradicional latinoamericana", "Ana Gómez", 2015, "5549");
                librosCargados = true;
            }
        }
    }
}
