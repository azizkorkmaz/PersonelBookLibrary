using PersonalBookLibrary.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.DataAccess.Abstract;
using AutoMapper;
using PersonalBookLibrary.Entities.ComplexTypes;
using System.Web;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Security;

namespace PersonalBookLibrary.Business.Concrete.Managers
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;
        private IMapper _mapper;

        public BookManager(IBookDal bookDal, IMapper mapper)
        {
            _bookDal = bookDal;
            _mapper = mapper;
        }

        public Book Add(Book book)
        {
            var bookAdd = new Book();

            if (book != null)
            {
                book.InsertDate = DateTime.Now.ToLocalTime();
                book.InsertUser = (HttpContext.Current.User.Identity as Identity).UserName;//burayı cookiden al
                book.Status = true;

                bookAdd = _mapper.Map<Book, Book>(_bookDal.Add(book));

                return bookAdd;
            }
            return bookAdd;
        }

        public List<BookDetail> GetActiveBook()
        {
            //burada statusu true olan kitapların listesini çek
            var bookDetails = new List<BookDetail>();
            var bookDetail = new BookDetail();
            var activeBooks = 
                _mapper.Map<List<Book>, List<Book>>(_bookDal.GetList(b=>b.Status==true)).ToList();
            foreach (var book in activeBooks)
            {
                bookDetail = 
                    _mapper.Map<BookDetail, BookDetail>(_bookDal.GetBookDetailById(book.BookId));

                bookDetails.Add(bookDetail);
            }
            return bookDetails;
        }

        public List<BookDetail> GetAll()
        {
            var bookDetail = new BookDetail();
            var bookDetails = new List<BookDetail>();
            var bookGetAll = _mapper.Map<List<Book>, List<Book>>(_bookDal.GetList());

            foreach (var book in bookGetAll)
            {
                bookDetail = 
                    _mapper.Map<BookDetail, BookDetail>
                    (_bookDal.GetBookDetailById(book.BookId));

                bookDetails.Add(bookDetail);
            }

            return bookDetails;
        }

        public List<Book> GetAllBook()
        {
            var bookAll = _mapper.Map<List<Book>, List<Book>>(_bookDal.GetList()).ToList();

            return bookAll;
        }

        public List<BookDetail> GetBookDetail(Book book)
        {
            var bookDetail = _mapper.Map<List<BookDetail>, List<BookDetail>>(_bookDal.GetBookDetail(book));

            return bookDetail;
        }

        public Book GetById(int id)
        {
            var bookGetById = new Book();

            if (id > 0)
            {
                bookGetById = _mapper.Map<Book, Book>(_bookDal.Get(b => b.BookId == id));

                return bookGetById;
            }

            return bookGetById;
        }

        public BookDetail GetByIdBookDetail(int id)
        {
            var book = new Book();
            var bookDetails = new List<BookDetail>();
            var bookDetail = new BookDetail();
            if (id > 0)
            {
                //burayı daha güzel kodla
                book = _mapper.Map<Book, Book>(_bookDal.Get(b => b.BookId == id));
                bookDetails = _mapper.Map<List<BookDetail>, List<BookDetail>>(_bookDal.GetBookDetail(book));

                foreach (var bookD in bookDetails)
                {
                    if (bookD.BookID==id)
                    {
                        bookDetail = bookD;
                    }
                }

                return bookDetail;
            }
            return bookDetail;
        }

        public void HardDelete(Book book)
        {
            _bookDal.HardDelete(book);
        }

        public Book LooseDelete(Book book)
        {
            book.Status = false;
            var bookLooseDelete = new Book();

            if (book != null)
            {
                bookLooseDelete = _mapper.Map<Book, Book>(_bookDal.LooseDelete(book));

                return bookLooseDelete;
            }
            return bookLooseDelete;
        }

        public Book Update(Book book)
        {
            var bookUpdate = new Book();

            if (book != null)
            {
                book.UpdateDate = DateTime.Now.ToLocalTime();
                book.UpdateUser = (HttpContext.Current.User.Identity as Identity).UserName;//burayı cookieden çek
                book.LastUpdated = true;

                bookUpdate = _mapper.Map<Book, Book>(_bookDal.Update(book));

                return bookUpdate;
            }

            return bookUpdate;
        }
    }
}
