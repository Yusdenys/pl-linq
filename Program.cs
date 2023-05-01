﻿LinqQueries queries = new LinqQueries();

//Toda la coleccion
//PrintValues(queries.TodaLaColeccion());

//Libros despues del 2000
//PrintValues(queries.LibrosDespuesdel2000());

//Libros que tienen mas de 250 pags y tienen en el titulo la palabra in action
//PrintValues(queries.LibrosConMasde250PagConPalabrasInAction());

//Todos los libros tienen Status
//Console.WriteLine($" Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

//Si algun libro fue publicado en 2005
//Console.WriteLine($" Algun libro fue publicado en 2005? - {queries.SiAlgunLibroFuePublicado2005()}");

//Books Python
//PrintValues(queries.PythonBooks());

//Libros de Java ordenados ASC
//PrintValues(queries.BooksJavaAsc());

//Libros ordenados DESC por Numero Pages
//PrintValues(queries.BooksMore450PagesAndOrderDesc());

//Tres primeros libros Java ordenados por fecha
//PrintValues(queries.ThreeBooksOrderByDate());

//Retorna el tercero y cuarto libro con cantidad de paginas mayor a 400
//PrintValues(queries.BooksThreeAndFourMore450Pages());

//Tres primeros libros filtrados con Select
//PrintValues(queries.ThreeBooksCollections());
//Console.WriteLine($"Libros: {queries.PageRange200And500()}");

//Menor fecha de publicacion utilizando Min
//Console.WriteLine($"Minimun Publish Date: {queries.MinPublishData()}");

//Libro con mayor numero de paginas
//Console.WriteLine($"Maximun Pages: {queries.MaxBookPages()}");

//Libro con menor numero de paginas
//Console.WriteLine($"Minimun Pages: {queries.BooksMinPages().Title} - {queries.BooksMinPages().PageCount}");

//Libro con fecha publicacion mas recient
//var bookObj = queries.BooksPublishedDateRecent();
//Console.WriteLine($"Minimun Pages: {bookObj.Title} - {bookObj.PublishedDate.ToShortDateString()}");

//Suma paginas entre 0 y 500 por libro
Console.WriteLine($"Suma de rango de paginas: {queries.SumAllPagesBeetwen0And500Pages()}");


void PrintValues(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}