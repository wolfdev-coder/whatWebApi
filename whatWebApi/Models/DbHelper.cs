using System.ComponentModel.DataAnnotations;
using whatWebApi.CoreModels;
namespace whatWebApi.Models
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context) {  _context = context; }
        //authors
        public List<AuthorModel> GetAuthors()
        {
            List<AuthorModel> response = new List<AuthorModel>();
            var dataList = _context.Authors.ToList();
            dataList.ForEach(row => response.Add(new AuthorModel()
            {
                id = row.id,
                name = row.name,
                bio = row.bio,

            }));
            return response;
        }
        public AuthorModel GetAuthorsById(int id)
        {
            AuthorModel response = new AuthorModel();
            var dataList = _context.Authors.Where(d=>d.id.Equals(id)).FirstOrDefault();
            return new AuthorModel()
            {
                id = dataList.id,
                name = dataList.name,
                bio = dataList.bio,
            };
        }

        public void SaveAuthor(AuthorModel authorModel)
        {
            Authors dbTable = new Authors();
            if (authorModel.id > 0)
            {
                dbTable = _context.Authors.Where(d=>d.id.Equals(authorModel.id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.name = authorModel.name;
                    dbTable.bio = authorModel.bio;
                }
            }
            else
            {
                dbTable.name = authorModel.name;
                dbTable.bio = authorModel.bio;
                _context.Authors.Add(dbTable);
            }
            _context.SaveChanges();
        }
        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }



        //books
        public List<BookModel> GetBooks()
        {
            List<BookModel> response = new List<BookModel>();
            var dataList = _context.Books.ToList();
            dataList.ForEach(row => response.Add(new BookModel()
            {
                id = row.id,
                name = row.name,
                description = row.description,
                author_id = row.author_id,
                genre_id = row.genre_id,

            }));
            return response;
        }
        public BookModel GetBooksById(int id)
        {
            BookModel response = new BookModel();
            var dataList = _context.Books.Where(d => d.id.Equals(id)).FirstOrDefault();
            return new BookModel()
            {
                id = dataList.id,
                name = dataList.name,
                description= dataList.description,
                author_id= dataList.author_id,
                genre_id = dataList.genre_id,
            };
        }

        public void SaveBook(BookModel bookModel)
        {
            Books dbTable = new Books();
            if (bookModel.id > 0)
            {
                dbTable = _context.Books.Where(d => d.id.Equals(bookModel.id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.name = bookModel.name;
                    dbTable.description = bookModel.description;
                    dbTable.author_id = bookModel.author_id;
                    dbTable.genre_id = bookModel.genre_id;
                }
            }
            else
            {
                dbTable.name = bookModel.name;
                dbTable.description = bookModel.description;
                dbTable.author_id = bookModel.author_id;
                dbTable.genre_id = bookModel.genre_id;
                _context.Books.Add(dbTable);
            }
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = _context.Books.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        //genre
        public List<GenresModel> GetGenres()
        {
            List<GenresModel> response = new List<GenresModel>();
            var dataList = _context.Genres.ToList();
            dataList.ForEach(row => response.Add(new GenresModel()
            {
                id = row.id,
                name = row.name,
                description = row.description,

            })) ;
            return response;
        }
        public GenresModel GetGenreById(int id)
        {
            GenresModel response = new GenresModel();
            var dataList = _context.Genres.Where(d => d.id.Equals(id)).FirstOrDefault();
            return new GenresModel()
            {
                id = dataList.id,
                name = dataList.name,
                description = dataList.description,
            };
        }

        public void SaveGenre(GenresModel genresModel)
        {
            Genres dbTable = new Genres();
            if (genresModel.id > 0)
            {
                dbTable = _context.Genres.Where(a => a.id.Equals(genresModel.id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.name = genresModel.name;
                    dbTable.description = genresModel.description;
                }
            }
            else
            {
                dbTable.name = genresModel.name;
                dbTable.description = genresModel.description;
                _context.Genres.Add(dbTable);
            }
            _context.SaveChanges();
        }
        public void DeleteGenre(int id)
        {
            var genre = _context.Genres.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}
