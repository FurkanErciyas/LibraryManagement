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
    public class UserService : IUser
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<User> GetAll()
        {
            return _dbContext.Users.Where(u => u.Status == StatusEnum.Active).ToList();
        }

        public User GetSingle(int id)
        {
            return _dbContext.Users.First(u => u.Id == id);
        }

        public string AddUser(UserCreateDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO); // userDTO ile gelen bilgileri automapper kullanarak yeni bir user oluştur.
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return "User Created Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteUser(UserDeleteDTO userDTO)
        {
            try
            {
                var user = _dbContext.Users.Find(userDTO.Id);
                if (user != null)
                {
                    _mapper.Map(userDTO, user); // user nesnesinin verilerini, userDTO ile gelen verilerle değiştir. Veri tamamen silinmemektedir. Silindir olarak görünmektedir.
                    _dbContext.SaveChanges();
                    return "User Deleted Successfully";
                }
                else
                {
                    return "User Not Found";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateUser(UserUpdateDTO userDTO)
        {
            try
            {
                var user = _dbContext.Users.Find(userDTO.Id);
                if (user != null)
                {
                    _mapper.Map(userDTO, user); // user nesnesinin verilerini, userDTO ile gelen verilerle güncelle.
                    _dbContext.SaveChanges();
                    return "User Updated Successfully";
                }
                else
                {
                    return "User Not Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string BorrowBook(int userId, int bookId)
        {
            try
            {
                var user = _dbContext.Users.Find(userId);
                var book = _dbContext.Books.Find(bookId);

                if (user != null && book != null)
                {
                    if (book.Status == StatusEnum.Active)
                    {
                        Checkout checkout = new Checkout()
                        {
                            BookId = bookId,
                            UserId = userId
                        };
                        book.Status = StatusEnum.Passive;
                        _dbContext.Checkouts.Add(checkout);
                        _dbContext.SaveChanges();
                        return $"Book {book.Title} was delivered to user {user.FirstName} {user.LastName}.";
                    }
                    else
                    {
                        return "The book is currently unavailable for checkout.";
                    }

                }
                else
                {
                    return "User or book not found. Please check the information.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ReturnBook(int userId, int bookId)
        {
            var user = _dbContext.Users.Find(userId);
            var book = _dbContext.Books.Find(bookId);
            var checkout = _dbContext.Checkouts.FirstOrDefault(x => x.UserId == userId && x.BookId == bookId && x.Status == StatusEnum.Active);

            if (user != null && book != null)
            {
                if (checkout != null)
                {
                    checkout.CheckInDate = DateTime.Now;
                    book.Status = StatusEnum.Active;
                    checkout.Status = StatusEnum.Passive;
                    _dbContext.SaveChanges();
                    return $"Book {book.Title} was delivered by user {user.FirstName} {user.LastName}.";
                }
                else
                {
                    return "No active checkout found";
                }

            }
            else
            {
                return "User or book not found. Please check the information.";
            }
        }

        public List<Book> BookRecords(int userId)
        {
            var books = _dbContext.Checkouts
                .Include(x => x.Book)
                .Where(x => x.UserId == userId)
                .Select(x => x.Book)
                .ToList(); // Checkout listesinde UserId verileri, gelen userId verileri ile eşit olan kitapları listele --> Kitabın geçmişte ve günümüzde hangi kullanıcılara ödünç verildiği

            return books;
        }
    }
}
