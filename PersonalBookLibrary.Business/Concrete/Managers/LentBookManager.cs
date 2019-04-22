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
    public class LentBookManager : ILentBookService
    {
        private ILentBookDal _lentBookDal;
        private IBookDal _bookDal;
        private IMapper _mapper;

        public LentBookManager(ILentBookDal lentBookDal, IBookDal bookDal, IMapper mapper)
        {
            _lentBookDal = lentBookDal;
            _bookDal = bookDal;
            _mapper = mapper;
        }

        public LentBook Add(LentBook lentBook)
        {
            var addLentBook = new LentBook();
            var getBook = new Book();
            try
            {
                if (lentBook != null)
                {
                    lentBook.Status = true;
                    lentBook.GivenDate = lentBook.InsertDate = DateTime.Now.ToLocalTime();
                    lentBook.InsertUser = (HttpContext.Current.User.Identity as Identity).UserName;
                    getBook = 
                        _mapper.Map<Book, Book>(_bookDal.Get(b => b.BookId == lentBook.BookID));
                    addLentBook = _mapper.Map<LentBook, LentBook>(_lentBookDal.Add(lentBook));
                    getBook.Status = false;
                    var deleteBook = _mapper.Map<Book, Book>(_bookDal.LooseDelete(getBook));
                }

                return addLentBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LentBook> GetAll()
        {
            try
            {
                var lentBooks = new List<LentBook>();
                lentBooks = _mapper.Map<List<LentBook>, List<LentBook>>(_lentBookDal.GetList());
                return lentBooks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LentBookDetail> GetAllActiveLentBookDetail()
        {
            try
            {
                var lentBookDetails = new List<LentBookDetail>();
                var lentBookDetail = new LentBookDetail();
                var lentBooks = new List<LentBook>();
                lentBooks = 
                    _mapper.Map<List<LentBook>, List<LentBook>>
                    (_lentBookDal.GetList(lb=>lb.Status==true));

                foreach (var lentBook in lentBooks)
                {
                    lentBookDetail = _mapper.Map<LentBookDetail, LentBookDetail>(_lentBookDal.GetByIdLentBookDetail(lentBook.LentBookId));

                    lentBookDetails.Add(lentBookDetail);
                }
                return lentBookDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LentBookDetail> GetAllLentBookDetail()
        {
            try
            {
                var lentBookDetails = new List<LentBookDetail>();
                var lentBookDetail = new LentBookDetail();
                var lentBooks = new List<LentBook>();
                lentBooks = _mapper.Map<List<LentBook>, List<LentBook>>(_lentBookDal.GetList());
                foreach (var lentBook in lentBooks)
                {
                    lentBookDetail = _mapper.Map<LentBookDetail, LentBookDetail>(_lentBookDal.GetByIdLentBookDetail(lentBook.LentBookId));

                    lentBookDetails.Add(lentBookDetail);
                }
                return lentBookDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LentBook GetById(int id)
        {
            try
            {
                var lentBook = new LentBook();
                var lentBookDetail = new LentBookDetail();

                if (id != 0)
                {
                    lentBook = _mapper.Map<LentBook, LentBook>(_lentBookDal.Get(lb => lb.LentBookId == id));
                }
                return lentBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LentBookDetail GetByIdLentBookDetail(int id)
        {
            try
            {
                var lentBook = new LentBook();
                var lentBookDetail = new LentBookDetail();
                if (id != 0)
                {
                    lentBook = _mapper.Map<LentBook, LentBook>(_lentBookDal.Get(lb => lb.LentBookId == id));

                    lentBookDetail =_mapper.Map<LentBookDetail, LentBookDetail>
                        (_lentBookDal.GetByIdLentBookDetail(id));
                }
                return lentBookDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LentBook LooseDelete(LentBook lentBook)
        {
            try
            {
                var deleteLentBook = new LentBook();
                if (lentBook != null)
                {
                    lentBook.Status = false;
                    lentBook.LastUpdated = true;
                    lentBook.UpdateDate = DateTime.Now.ToLocalTime();
                    lentBook.UpdateUser = "Aziz" /*(HttpContext.Current.User.Identity as Identity).UserName*/;
                    deleteLentBook = 
                        _mapper.Map<LentBook, LentBook>(_lentBookDal.LooseDelete(lentBook));
                }
                return deleteLentBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LentBook Update(LentBook lentBook)
        {
            try
            {
                var updateLentBook = new LentBook();
                if (lentBook != null)
                {
                    lentBook.LastUpdated = true;
                    lentBook.UpdateDate = DateTime.Now.ToLocalTime();
                    lentBook.UpdateUser = (HttpContext.Current.User.Identity as Identity).UserName;
                    updateLentBook = _mapper.Map<LentBook, LentBook>(_lentBookDal.Update(lentBook));
                }
                return updateLentBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LentBook UndoBook(LentBook lentBook)
        {
            try
            {
                var undoBook = new LentBook();
                if (lentBook != null)
                {
                    lentBook.Status = false;
                    lentBook.LastUpdated = true;
                    lentBook.UpdateDate = DateTime.Now.ToLocalTime();
                    lentBook.UpdateUser = "Aziz"/*(HttpContext.Current.User.Identity as Identity).UserName*/;
                    lentBook.UndoDate = DateTime.Now.ToLocalTime();

                    var book = _bookDal.Get(b => b.BookId == lentBook.BookID);
                    book.Status = true;
                    book = _bookDal.Update(book);

                    undoBook = _mapper.Map<LentBook,LentBook>(_lentBookDal.LooseDelete(lentBook));
                }

                return undoBook;
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
