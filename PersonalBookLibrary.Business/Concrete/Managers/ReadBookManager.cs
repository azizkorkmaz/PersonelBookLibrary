using PersonalBookLibrary.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.DataAccess.Abstract;
using AutoMapper;
using System.Web;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Security;

namespace PersonalBookLibrary.Business.Concrete.Managers
{
    public class ReadBookManager : IReadBookService
    {
        private IReadBookDal _readBookDal;
        private IMapper _mapper;

        public ReadBookManager(IReadBookDal readBookDal, IMapper mapper)
        {
            _readBookDal = readBookDal;
            _mapper = mapper;
        }

        public ReadBook Add(ReadBook readBook)
        {
            try
            {
                var addReadBook = new ReadBook();

                if (readBook != null)
                {
                    readBook.InsertDate = DateTime.Now.ToLocalTime();
                    readBook.InsertUser = (HttpContext.Current.User.Identity as Identity).UserName;
                    readBook.Status = true;

                    addReadBook = _mapper.Map<ReadBook, ReadBook>(_readBookDal.Add(readBook));
                }

                return addReadBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ReadBook> GetAll()
        {
            try
            {
                var readBooks = _mapper.Map<List<ReadBook>>(_readBookDal.GetList());

                return readBooks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadBook GetById(int id)
        {
            try
            {
                var readBook = new ReadBook();
                if (id != 0)
                {
                    readBook = _mapper.Map<ReadBook, ReadBook>(_readBookDal.Get(b => b.ReadBookId == id));
                }

                return readBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void HardDelete(ReadBook readBook)
        {
            try
            {
                if (readBook != null)
                {
                    _readBookDal.HardDelete(readBook);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadBook Update(ReadBook readBook)
        {
            try
            {
                var readBookUpdate = new ReadBook();
                if (readBook != null)
                {
                    readBook.LastUpdated = true;
                    readBook.UpdateDate = DateTime.Now.ToLocalTime();
                    readBook.UpdateUser = (HttpContext.Current.User.Identity as Identity).UserName;

                    readBookUpdate = _mapper.Map<ReadBook, ReadBook>(_readBookDal.Update(readBook));
                }

                return readBookUpdate;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
