using ENTITIES.DTO.CreateDTO;
using ENTITIES.DTO.DeleteDTO;
using ENTITIES.DTO.UpdateDTO;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS.Interfaces
{
    public interface IUser
    {
        List<User> GetAll(); // Kullanıcıları listele
        User GetSingle(int id); // Id'ye göre kullanıcı getir
        string AddUser(UserCreateDTO user); // Kullanıcı ekle
        string UpdateUser(UserUpdateDTO user); // Kullanıcı güncelle
        string DeleteUser(UserDeleteDTO user); // Kullanıcı Sil
        string BorrowBook(int userId, int bookId); // Kullanıcıya kitap ödünç ver
        string ReturnBook(int userId, int bookId); // Kullanıcıdan kitap teslim al
        List<Book> BookRecords(int userId); // Kullanıcının ödünç aldığı kitapları listele
    }
}
