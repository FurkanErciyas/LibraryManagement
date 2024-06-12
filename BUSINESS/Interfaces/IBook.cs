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
    public interface IBook
    {
        List<Book> GetAll(); // Kitapları listele
        Book GetSingle(int id); // Id'ye göre kitap getir
        string AddBook(BookCreateDTO book); // Kitap Ekleme
        string UpdateBook(BookUpdateDTO book); // Kitap güncelleme
        string DeleteBook(BookDeleteDTO book); // Kitap silme
        List<User> UserRecords(int bookId); // Kitabı ödünç alanları listele
    }
}
