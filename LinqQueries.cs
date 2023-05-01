using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>();

    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return booksCollection;
    }

    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        //extension method
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //query expresion
        ArrayList arrayList = new ArrayList();
        arrayList.Add("10");
        arrayList.Add(10);


        return from l in booksCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
    {
        //extension methods
        return booksCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expression
        return from l in booksCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return booksCollection.All(p=> !string.IsNullOrWhiteSpace(p.Status));
    }

    public bool SiAlgunLibroFuePublicado2005()
    {
        return booksCollection.Any(p=> p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> PythonBooks()
    {
        return booksCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> BooksJavaAsc()
    {
        return booksCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);            
    }

    public IEnumerable<Book> BooksMore450PagesAndOrderDesc()
    {
        return booksCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> ThreeBooksOrderByDate()
    {
        return booksCollection
            .Where(p => p.Categories.Contains("Java"))
            .OrderByDescending(x => x.PublishedDate)
            .Take(3);
    }

    public IEnumerable<Book> BooksThreeAndFourMore450Pages()
    {
        return booksCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<Book> ThreeBooksCollections()
    {
        return booksCollection.Take(3)
            .Select(p => new Book() {Title = p.Title,PageCount = p.PageCount });
    }

    public int PageRange200And500()
    {
        return booksCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime MinPublishData()
    {
        return booksCollection.Min(p => p.PublishedDate);
    }

    public int MaxBookPages()
    {
        return booksCollection.Max(p => p.PageCount);
    }

    public Book BooksMinPages()
    {
        return booksCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book BooksPublishedDateRecent()
    {
        return booksCollection.MaxBy(p => p.PublishedDate);
    }

    public int SumAllPagesBeetwen0And500Pages()
    {
        return booksCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);

    }

    public string BooksAfter2015Concated()
    {
        return booksCollection
            .Where(p => p.PublishedDate.Year > 2015)
            .Aggregate("", (Titles, next) =>
            {
                if (Titles != string.Empty)
                    Titles += " - " + next.Title;
                else
                    Titles += next.Title;

                return Titles;
            });
    }

    public double AverageTitle()
    {
        return booksCollection.Average(p => p.Title.Length);
    }

    public double AverageTitleMoreThanZero()
    {
        return booksCollection
            .Where(p => p.Title.Length > 0)
            .Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> BooksGroupByYearAfter2000()
    {
        return booksCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char, Book> BooksLookupGroupFirstLetter()
    {
        return booksCollection.ToLookup(p => p.Title[0], p => p);

    }

    public IEnumerable<Book> BooksMoreThan500PagesAfter2005()
    {
        var booksAfter2005 = booksCollection.Where(p => p.PublishedDate.Year > 2005);
        var booksMoreThan500 = booksCollection.Where(p => p.PageCount > 500);

        return booksAfter2005.Join(booksMoreThan500, p => p.Title, x => x.Title, (p, x) => p);
    }
}