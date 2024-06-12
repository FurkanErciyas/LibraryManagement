using AutoMapper;
using BUSINESS.Interfaces;
using DAL.DataAccess;
using ENTITIES.DTO.CreateDTO;
using ENTITIES.DTO.DeleteDTO;
using ENTITIES.DTO.UpdateDTO;
using ENTITIES.Enums;
using ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Services
{
    public class BookService : IBook
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books.Where(b => b.Status == StatusEnum.Active).ToList();   
        }

        public Book GetSingle(int id)
        {
            return _dbContext.Books.First(b => b.Id == id);
        }

        public string AddBook(BookCreateDTO bookDTO)
        {
            try
            {
                var book = _mapper.Map<Book>(bookDTO); // bookDTO ile gelen bilgileri automapper kullanarak yeni bir book oluştur.
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                return "Book Created Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBook(BookDeleteDTO bookDTO)
        {
            try
            {
                var book = _dbContext.Books.Find(bookDTO.Id);
                if (book != null)
                {
                    _mapper.Map(bookDTO, book); // book nesnesinin verilerini, bookDTO ile gelen verilerle değiştir. Veri tamamen silinmemektedir. Silindir olarak görünmektedir.
                    _dbContext.SaveChanges();
                    return "Book Deleted Successfully";
                }
                else
                {
                    return "Book Not Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBook(BookUpdateDTO bookDTO)
        {
            try
            {
                var book = _dbContext.Books.Find(bookDTO.Id);
                if (book != null)
                {
                    _mapper.Map(bookDTO, book); // book nesnesinin verilerini, bookDTO ile gelen verilerle güncelle.
                    _dbContext.SaveChanges();
                    return "Book Updated Successfully";
                }
                else
                {
                    return "Book Not Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<User> UserRecords(int bookId)
        {
            var users = _dbContext.Checkouts
                .Include(x => x.User)
                .Where(x => x.BookId == bookId)
                .Select(x => x.User)
                .ToList(); // Checkout listesinde BookId verileri, gelen bookId verileri ile eşit olan kullanıcıları listele --> Kullanıcının geçmişte ve günümüzde ödünç aldığı bütün kitaplar 

            return users;
        }
    }
}
